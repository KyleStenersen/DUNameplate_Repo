using System.Windows.Forms;
using System.IO.Ports;
using System;

namespace DUNameplateGUI {
    public static class SerialCom
    {
        private static SerialPort serialPort = new SerialPort();
        //public delegate void serialReciever(string stringIn);
        private static bool plateIsDone = false;
        private static bool eSTOP = false;

        public static bool disconnected = true;

        // TODO: Change this class, as well as MachineControl so we can handle disconnections cleanly

        // PUBLIC FUNCTIONS ==============================================

        public static void setupPort()
        {
            if (Global.SerialOn)
            {
                serialPort.BaudRate = 115200;
                serialPort.PortName = "COM3";
                serialPort.ReadTimeout = -1;
                serialPort.WriteTimeout = -1;
                try
                {
                    serialPort.Open();
                }
                catch (System.IO.IOException ex) {
                    MessageBox.Show("Failed to connect to machine, is it plugged in? \n Exception: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    showDisconnectedStatus();
                }
            }
        }
        public static void sendSettings()
        {
            try
            {
                if (Global.SerialOn) serialPort.Write("<p" + Properties.Settings.Default.xOffsetSet.ToString() + "," +
                Properties.Settings.Default.yOffsetSet.ToString() + "," +
                Properties.Settings.Default.lineSpaceingSet.ToString() + "," +
                Properties.Settings.Default.charSpaceingSet.ToString() + ">");
            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine("Couldn't send settings due to " + ex.ToString());
                showDisconnectedStatus();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Couldn't send settings due to " + ex.ToString());
                showDisconnectedStatus();
            }
        }

        public static void sendString(string stringToSend)
        {
            if (Global.SerialOn)
            {
                try
                {
                    serialPort.Write(stringToSend);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Couldn't send string over serial due to " + ex.ToString());
                    showDisconnectedStatus();
                }
            }
            else
            {
                MessageBox.Show(stringToSend); // For development purposes
            }
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
                }
                return;
            }

            done = true;
        }

        public static void clearInputBuffer()
        {
            if (Global.SerialOn) serialPort.DiscardInBuffer();
        }

        // PRIVATE FUNCTIONS =========================================

        private static void checkDataRecieved()
        {
            string stringIn = serialPort.ReadLine();
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
                        if (secondChar == '2') eSTOP = true;
                        break;
                    }
            }
        }

        private static void showDisconnectedStatus()
        {
            UIControl.changeStatusIndicator(UIControl.Status.Disconnected);
        }
    }
}