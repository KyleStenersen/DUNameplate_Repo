using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public partial class SETTINGS_FORM : Form
    {
        CheckSettings checkSettings = new CheckSettings();

        const float X_OFFSET_MIN = 0.000F;
        const float X_OFFSET_MAX = 3.400F;
        const float Y_OFFSET_MIN = 0.000F;
        const float Y_OFFSET_MAX = 1.900F;
        const float PLATE_SPACEING_MIN = 0.120F;
        const float PLATE_SPACEING_MAX = 3.000F;
        const float LINE_SPACEING_MIN = 0.120F;
        const float LINE_SPACEING_MAX = 0.700F;
        const float CHAR_SPACEING_MIN = 0.090F;
        const float CHAR_SPACEING_MAX = 0.120F;


        public SETTINGS_FORM()
        {
            InitializeComponent();
        }

        // Run once on opening of settings form2
        private void SETTINGS_FORM_Load(object sender, EventArgs e)
        {
            serialPortComboBox.Text = Properties.Settings.Default.serialPort;

            // Get all the serial ports and add them to the serial port combo box
            serialPortComboBox.Items.AddRange(SerialPort.GetPortNames());

            //if (Properties.Settings.Default.xOffsetSet != float.Parse(xOffsetDefault.Text))
            xOffsetBox.Text = Properties.Settings.Default.xOffsetSet.ToString();

            //if (Properties.Settings.Default.yOffsetSet != float.Parse(yOffsetDefault.Text))
            yOffsetBox.Text = Properties.Settings.Default.yOffsetSet.ToString();

            //if (Properties.Settings.Default.plateSpaceingSet != float.Parse(plateSpaceingDefault.Text))
            plateSpaceingBox.Text = Properties.Settings.Default.plateSpaceingSet.ToString();

            //if (Properties.Settings.Default.lineSpaceingSet != float.Parse(lineSpaceingDefault.Text))
            lineSpaceingBox.Text = Properties.Settings.Default.lineSpaceingSet.ToString();

            //if (Properties.Settings.Default.charSpaceingSet != float.Parse(charSpaceingDefault.Text))
            charSpaceingBox.Text = Properties.Settings.Default.charSpaceingSet.ToString();

            jigComboBox.SelectedIndex = Properties.Settings.Default.selectedJig;

            resetJigIdleTimeBox.Value = Properties.Settings.Default.idleTimeBeforeReset;

            resetJigAfterIdleCheckBox.Checked = Properties.Settings.Default.resetJigAfterIdle;

            autoPrintQueueCheckBox.Checked = Properties.Settings.Default.autoPrintQueue;

            resetJigAfterQueueCompleteCheckBox.Checked = Properties.Settings.Default.resetJigAfterQueueCompletes;
        }

 //PRIVATE USER INPUT RESPONSE FUNCTIONS ================================

        private void xOffsetBox_Leave(object sender, EventArgs e)
        {
            checkSettings.textBoxEntryError(ref xOffsetBox, X_OFFSET_MAX, X_OFFSET_MIN);
        }

        private void yOffsetBox_Leave(object sender, EventArgs e)
        {
            checkSettings.textBoxEntryError(ref yOffsetBox, Y_OFFSET_MAX, Y_OFFSET_MIN);
        }

        private void plateSpaceingBox_Leave(object sender, EventArgs e)
        {
            checkSettings.textBoxEntryError(ref plateSpaceingBox, PLATE_SPACEING_MAX, PLATE_SPACEING_MIN);
        }

        private void lineSpaceingBox_Leave(object sender, EventArgs e)
        {
            checkSettings.textBoxEntryError(ref lineSpaceingBox, LINE_SPACEING_MAX, LINE_SPACEING_MIN);
        }

        private void charSpaceingBox_Leave(object sender, EventArgs e)
        {
            checkSettings.textBoxEntryError(ref charSpaceingBox, CHAR_SPACEING_MAX, CHAR_SPACEING_MIN);
        }

        private void settingsSaveCloseBtn_Click(object sender, EventArgs e)
        {

            if (checkSettings.textBoxEntryError(ref xOffsetBox, X_OFFSET_MAX, X_OFFSET_MIN) == true)
            {
                MessageBox.Show("Invalid Setting Value; out of bounds, or not number");
                return;
            }

            if (checkSettings.textBoxEntryError(ref yOffsetBox, Y_OFFSET_MAX, Y_OFFSET_MIN) == true)
            {
                MessageBox.Show("Invalid Setting Value; out of bounds, or not number");
                return;
            }

            if (checkSettings.textBoxEntryError(ref plateSpaceingBox, PLATE_SPACEING_MAX, PLATE_SPACEING_MIN) == true)
            {
                MessageBox.Show("Invalid Setting Value; out of bounds, or not number");
                return;
            }

            if (checkSettings.textBoxEntryError(ref lineSpaceingBox, LINE_SPACEING_MAX, LINE_SPACEING_MIN) == true)
            {
                MessageBox.Show("Invalid Setting Value; out of bounds, or not number");
                return;
            }

            if (checkSettings.textBoxEntryError(ref charSpaceingBox, CHAR_SPACEING_MAX, CHAR_SPACEING_MIN) == true)
            {
                MessageBox.Show("Invalid Setting Value; out of bounds, or not number");
                return;
            }

            if (String.IsNullOrWhiteSpace(xOffsetBox.Text) == false)
                Properties.Settings.Default.xOffsetSet = float.Parse(xOffsetBox.Text);

            if (String.IsNullOrWhiteSpace(yOffsetBox.Text) == false)
                Properties.Settings.Default.yOffsetSet = float.Parse(yOffsetBox.Text);

            if (String.IsNullOrWhiteSpace(plateSpaceingBox.Text) == false)
                Properties.Settings.Default.plateSpaceingSet = float.Parse(plateSpaceingBox.Text);

            if (String.IsNullOrWhiteSpace(lineSpaceingBox.Text) == false)
                Properties.Settings.Default.lineSpaceingSet = float.Parse(lineSpaceingBox.Text);

            if (String.IsNullOrWhiteSpace(charSpaceingBox.Text) == false)
                Properties.Settings.Default.charSpaceingSet = float.Parse(charSpaceingBox.Text);

            Properties.Settings.Default.serialPort = serialPortComboBox.Text;

            // Save the selected jig index into the settings
            Properties.Settings.Default.selectedJig = jigComboBox.SelectedIndex;

            // Set the global Jig class's values to the new jig
            Jig.setValues(jigComboBox.SelectedIndex);

            // Save idleTimeBeforeReset into settings
            Properties.Settings.Default.idleTimeBeforeReset = (int) resetJigIdleTimeBox.Value;

            // Save the resetJigAfterIdle checkbox into settings
            Properties.Settings.Default.resetJigAfterIdle = resetJigAfterIdleCheckBox.Checked;

            IdleTimer.RefreshSettings();

            // Save the autoPrintQueue checkbox into settings
            Properties.Settings.Default.autoPrintQueue = autoPrintQueueCheckBox.Checked;

            // Save the resetJigAfterQueueCompletes checkbox into settings
            Properties.Settings.Default.resetJigAfterQueueCompletes = resetJigAfterQueueCompleteCheckBox.Checked;



            Properties.Settings.Default.Save();
            SerialCom.sendSettings();
            this.Close();
        }

        private void resetDefaultsBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.xOffsetSet = float.Parse(xOffsetDefault.Text);
            xOffsetBox.Text = xOffsetDefault.Text;
            
            Properties.Settings.Default.yOffsetSet = float.Parse(yOffsetDefault.Text);
            yOffsetBox.Text = yOffsetDefault.Text;

            Properties.Settings.Default.plateSpaceingSet = float.Parse(plateSpaceingDefault.Text);
            plateSpaceingBox.Text = plateSpaceingDefault.Text;
           
            Properties.Settings.Default.lineSpaceingSet = float.Parse(lineSpaceingDefault.Text);
            lineSpaceingBox.Text = lineSpaceingDefault.Text;
            
            Properties.Settings.Default.charSpaceingSet = float.Parse(charSpaceingDefault.Text);
            charSpaceingBox.Text = charSpaceingDefault.Text;

            Properties.Settings.Default.selectedJig = 0;
            jigComboBox.SelectedIndex = 0;

            // Set the global Jig class's values to the new jig
            Jig.setValues(jigComboBox.SelectedIndex);

            Properties.Settings.Default.idleTimeBeforeReset = 60;
            resetJigIdleTimeBox.Value = 60;

            IdleTimer.RefreshSettings();

            Properties.Settings.Default.autoPrintQueue = true;
            autoPrintQueueCheckBox.Checked = true;

            Properties.Settings.Default.resetJigAfterQueueCompletes = false;
            resetJigAfterQueueCompleteCheckBox.Checked = false;

            

            Properties.Settings.Default.Save();
            SerialCom.sendSettings();
        }

        private void changeInputFixingRulesBtn_Click(object sender, EventArgs e)
        {
            InputRuleForm inputRuleForm = new InputRuleForm();
            inputRuleForm.ShowDialog();
        }
    }
}
