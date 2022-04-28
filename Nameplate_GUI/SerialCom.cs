using System.Windows.Forms;
using System.IO.Ports;

public class SerialCom
{
    private static SerialPort serialPort1 = new SerialPort();
    public delegate void serialReciever(string stringIn);
    private bool plateIsDone = false;

    public void setupPort()
    {
        serialPort1.BaudRate = 115200;
        serialPort1.PortName = "COM9";
        serialPort1.ReadTimeout = -1;
        serialPort1.WriteTimeout = -1;
        serialPort1.Open();
    }
    public void sendSettings()
    {
        //MessageBox.Show("<p" + DUNameplateGUI.Properties.Settings.Default.xOffsetSet.ToString() + "," +
        //DUNameplateGUI.Properties.Settings.Default.yOffsetSet.ToString() + "," +
        //DUNameplateGUI.Properties.Settings.Default.plateSpaceingSet.ToString() + "," +
        //DUNameplateGUI.Properties.Settings.Default.lineSpaceingSet.ToString() + "," +
        //DUNameplateGUI.Properties.Settings.Default.charSpaceingSet.ToString() + ">");

        serialPort1.Write("<p" + DUNameplateGUI.Properties.Settings.Default.xOffsetSet.ToString() + "," +
        DUNameplateGUI.Properties.Settings.Default.yOffsetSet.ToString() + "," +
        DUNameplateGUI.Properties.Settings.Default.plateSpaceingSet.ToString() + "," +
        DUNameplateGUI.Properties.Settings.Default.lineSpaceingSet.ToString() + "," +
        DUNameplateGUI.Properties.Settings.Default.charSpaceingSet.ToString() + ">");
    }

    public void sendString(string stringToSend)
    {
        MessageBox.Show(stringToSend);

       serialPort1.Write(stringToSend);
    }

    public void checkIfPlateDone(ref bool done)
    {
        plateIsDone = false;
        checkDataRecieved();
        if (plateIsDone == true) done = true;        
    }

    public void clearInputBuffer()
    {
        serialPort1.DiscardInBuffer();
    }

    //Private to SerialCom.cs Functions
    //----------------------------------------------

    private void checkDataRecieved()
    {
        string stringIn = serialPort1.ReadLine();
        var serialInput = new serialReciever(respondInput);
        serialInput(stringIn);
    }

    private void respondInput(string stringRecieved)
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