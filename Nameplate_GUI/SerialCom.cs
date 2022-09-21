using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using Serilog;

namespace DUNameplateGUI {
    public static class SerialCom
    {
        private static SerialPort serialPort1 = new SerialPort();
        //public delegate void serialReciever(string stringIn);
        private static bool plateIsDone = false;
        private static bool eSTOP = false;
        public static AutoResetEvent resetEstopEvent = new AutoResetEvent(false);

        // PUBLIC FUNCTIONS ==============================================

        public static void setupPort()
        {
            if (Global.SerialOn)
            {
                serialPort1.BaudRate = 115200;
                serialPort1.PortName = "COM3";
                serialPort1.ReadTimeout = -1;
                serialPort1.WriteTimeout = -1;
                
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
            if (Global.SerialOn) serialPort1.Write("<p" + Properties.Settings.Default.xOffsetSet.ToString() + "," +
                Properties.Settings.Default.yOffsetSet.ToString() + "," +
                Properties.Settings.Default.lineSpaceingSet.ToString() + "," +
                Properties.Settings.Default.charSpaceingSet.ToString() + ">");
        }

        public static void sendString(string stringToSend)
        {
            MessageBox.Show(stringToSend); // For development purpose, remove later

            Log.Debug("Sending {string} down serial", stringToSend);

            if (Global.SerialOn) serialPort1.Write(stringToSend);
        }

        public static void checkIfPlateDone(ref bool done)
        {
            if (Global.SerialOn)
            {
                plateIsDone = false;
                checkDataRecieved();
                if (plateIsDone == true) done = true;
                if (eSTOP == true)
                {
                    done = true;
                    UIControl.requestCancel();
                    UIControl.changeStatusIndicator(UIControl.Status.Estopped);

                    // Wait/Block this thread until the resetEstopEvent gets set from someone
                    // pressing the estop button on the GUI
                    // Learn more about AutoResetEvents here:https://docs.microsoft.com/en-us/dotnet/api/system.threading.autoresetevent?view=net-6.0
                    resetEstopEvent.WaitOne();

                    // And now we're ready again, so set it back
                    UIControl.changeStatusIndicator(UIControl.Status.Ready);
                    
                    eSTOP = false;
                }
                return;
            }

            else done = true;
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

        private static void checkDataRecieved()
        {
            string stringIn = serialPort1.ReadLine();
            respondInput(stringIn);
        }

        private static void respondInput(string stringRecieved)
        {
            char firstChar = stringRecieved[0];
            char secondChar = stringRecieved[1];

            switch (firstChar)
            {
                case 'z':
                    {
                        if (secondChar == '1') plateIsDone = true;
                        if (secondChar == '2')  eSTOP = true;
                        break;
                    }
            }
        }
    }
}