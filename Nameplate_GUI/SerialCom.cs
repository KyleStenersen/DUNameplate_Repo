using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Serilog;
using System.Diagnostics;

namespace DUNameplateGUI {
    public static class SerialCom
    {
        private static SerialPort serialPort1 = new SerialPort();

        public static AutoResetEvent resetEstopEvent = new AutoResetEvent(false);

        private static AutoResetEvent plateCompleteEvent = new AutoResetEvent(false);
        private static AutoResetEvent homeCompleteEvent = new AutoResetEvent(false);
        private static AutoResetEvent estopReceivedEvent = new AutoResetEvent(false);

        // See DataReceivedHandler
        private static char lastCharReceived = ' ';

        // PUBLIC FUNCTIONS ==============================================

        public static void setupPort()
        {
            if (Global.SerialOn)
            {
                serialPort1.BaudRate = 115200;
                serialPort1.PortName = "COM3";
                serialPort1.ReadTimeout = -1;
                serialPort1.WriteTimeout = -1;

                serialPort1.DataReceived += DataReceivedHandler;
                
                bool serialFail = true;
                while (serialFail == true)
                    try
                    {
                        serialPort1.Open();
                        serialFail = false;
                    }
                    catch
                    {
                        MessageBox.Show("Must plug in or power up the machine, and check USB connection." +
                            "\nThen press OK.");
                    }
            }
        }
        public static void sendSettings()
        {
            if (Global.SerialOn) sendString("<p" + Properties.Settings.Default.xOffsetSet.ToString() + "," +
                Properties.Settings.Default.yOffsetSet.ToString() + "," +
                Properties.Settings.Default.lineSpaceingSet.ToString() + "," +
                Properties.Settings.Default.charSpaceingSet.ToString() + ">");
        }

        public static void sendString(string stringToSend)
        {
            //MessageBox.Show(stringToSend); // For development purpose, remove later

            Log.Debug("SerialCom sendString waiting 10 ms before sending {string}", stringToSend);

            Thread.Sleep(10);

            Log.Debug("Sending {string} down serial", stringToSend);

            if (Global.SerialOn) serialPort1.Write(stringToSend);
        }

        // Waits until the machine sends the signal for the plate being complete, or until it is estopped, in which case it will
        // wait until someone clicks on the status button to un-estop. 
        // This function will request a cancellation if it has been estopped or if it times out
        public static bool waitForPlateDoneOrEstop()
        {
            Log.Debug("Waiting for plate to be complete...");

            int waitResult = WaitHandle.WaitAny(new WaitHandle[] { plateCompleteEvent, estopReceivedEvent }, 100000);

            if (waitResult == 0) // Sucessfully printed plate
            {
                Log.Debug("Plate complete");
                return true;
            }
            else if (waitResult == 1) // Machine estopped
            {
                UIControl.requestCancel();
                UIControl.changeStatusIndicator(UIControl.Status.Estopped);

                // Wait/Block this thread until the resetEstopEvent gets set from someone
                // pressing the estop button on the GUI
                // Learn more about AutoResetEvents here:https://docs.microsoft.com/en-us/dotnet/api/system.threading.autoresetevent?view=net-6.0

                Log.Debug("SerialCom - waitForPlateDoneOrEstop - wait estop reset");
                resetEstopEvent.WaitOne();

                // And now we're ready again, so set it back
                UIControl.changeStatusIndicator(UIControl.Status.Ready);

                return false;
            } 
            else // Wait timed out
            {
                UIControl.requestCancel();

                Log.Warning("WaitForPlateDoneOrEstop timed out, waitResult was {WaitResult}", waitResult);
                return false;
            }
        }

        public static bool waitForHome()
        {
            Log.Debug("SerialCom - waitForHome - Waiting for home...");
            if (homeCompleteEvent.WaitOne(20000))
            {
                Log.Debug("SerialCom - waitForHome - Waiting for home complete");
                return true;
            }
            else
            {
                Log.Debug("SerialCom - waitForHome - Timed out");
                return false;
            }

        }

        public static void clearInputBuffer()
        {
            if (Global.SerialOn) serialPort1.DiscardInBuffer();
        }

        public static void estopReset()
        {
            sendString("**");
        }

        // PRIVATE FUNCTIONS =========================================

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string stringReceived = serialPort1.ReadExisting();

            // Because it is possible that our command that we're looking for is split across two
            // communications, so we're going to put the last character received at the beginning of
            // stringReceived, and then store our last character for the next time
            stringReceived = stringReceived.Insert(0, lastCharReceived.ToString());
            Log.Debug("lastCharReceived is {lastCharReceived}", lastCharReceived);
            Log.Debug("DataReceivedHandler has received {String}", stringReceived);

            lastCharReceived = stringReceived.ToCharArray()[stringReceived.Length - 1];

            if (stringReceived.Length < 2)
            {
                Log.Warning("DataReceivedHandler has received too little chars");
                return;
            }


            if (stringReceived.Contains("z1"))
            {
                Log.Debug("plateCompleteEvent set");
                plateCompleteEvent.Set();
                plateCompleteEvent.Reset();
            }
            else if (stringReceived.Contains("z2"))
            {
                Log.Debug("estopReceivedEvent set");
                estopReceivedEvent.Set();
                estopReceivedEvent.Reset();
            }
            else if (stringReceived.Contains("z3"))
            {
                Log.Debug("homeCompleteEvent set");
                homeCompleteEvent.Set();
                homeCompleteEvent.Reset();
            }
        }
    }
}