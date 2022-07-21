using System.Windows.Forms;
using System.IO.Ports;

public static class SerialCom
{
    private static SerialPort serialPort1 = new SerialPort();
    //public delegate void serialReciever(string stringIn);
    private static bool plateIsDone = false;

// PUBLIC FUNCTIONS ==============================================

    public static void setupPort()
    {
        if (Global.SerialOn)
        {
            serialPort1.BaudRate = 115200;
            serialPort1.PortName = "COM3";
            serialPort1.ReadTimeout = -1;
            serialPort1.WriteTimeout = -1;
            serialPort1.Open();
        }
    }
    public static void sendSettings()
    {
        if (Global.SerialOn) serialPort1.Write("<p" + DUNameplateGUI.Properties.Settings.Default.xOffsetSet.ToString() + "," +
            DUNameplateGUI.Properties.Settings.Default.yOffsetSet.ToString() + "," +
            DUNameplateGUI.Properties.Settings.Default.lineSpaceingSet.ToString() + "," +
            DUNameplateGUI.Properties.Settings.Default.charSpaceingSet.ToString() + ">");
    }

    public static void sendString(string stringToSend)
    {
        MessageBox.Show(stringToSend); // For development purpose, remove later

        if (Global.SerialOn) serialPort1.Write(stringToSend);
    }

    public static void checkIfPlateDone(ref bool done)
    {
        if (Global.SerialOn)
        {
            plateIsDone = false;
            checkDataRecieved();
            if (plateIsDone == true) done = true;
            return;
        }

        done = true;
    }

    public static void clearInputBuffer()
    {
        if (Global.SerialOn) serialPort1.DiscardInBuffer();
    }

    // PRIVATE FUNCTIONS =========================================

    private static void checkDataRecieved()
    {
        string stringIn = serialPort1.ReadLine();
        // Not sure if I can comment this out, needs testing on real hardware
        //var serialInput = new serialReciever(respondInput);
        //serialInput(stringIn); 
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
                    break;
                }
        }
    }
}