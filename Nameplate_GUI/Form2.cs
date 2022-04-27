using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public partial class SETTINGS_FORM : Form
    {
        CheckSettings checkSettings = new CheckSettings();
        SerialCom serialComF2 = new SerialCom();

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

        private void SETTINGS_FORM_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.xOffsetSet != float.Parse(xOffsetDefault.Text))
                xOffsetBox.Text = Properties.Settings.Default.xOffsetSet.ToString();

            if (Properties.Settings.Default.yOffsetSet != float.Parse(yOffsetDefault.Text))
                yOffsetBox.Text = Properties.Settings.Default.yOffsetSet.ToString();

            if (Properties.Settings.Default.plateSpaceingSet != float.Parse(plateSpaceingDefault.Text))
                plateSpaceingBox.Text = Properties.Settings.Default.plateSpaceingSet.ToString();

            if (Properties.Settings.Default.lineSpaceingSet != float.Parse(lineSpaceingDefault.Text))
                lineSpaceingBox.Text = Properties.Settings.Default.lineSpaceingSet.ToString();

            if (Properties.Settings.Default.charSpaceingSet != float.Parse(charSpaceingDefault.Text))
                charSpaceingBox.Text = Properties.Settings.Default.charSpaceingSet.ToString();
        }


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


            Properties.Settings.Default.Save();
            serialComF2.sendSettings();
            this.Close();
        }

        private void resetDefaultsBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(xOffsetBox.Text) == false)
            { 
                Properties.Settings.Default.xOffsetSet = float.Parse(xOffsetDefault.Text);
                xOffsetBox.Clear();
            }

            if (String.IsNullOrWhiteSpace(yOffsetBox.Text) == false)
            {
                Properties.Settings.Default.yOffsetSet = float.Parse(yOffsetDefault.Text);
                yOffsetBox.Clear();
            }

            if (String.IsNullOrWhiteSpace(plateSpaceingBox.Text) == false)
            {
                Properties.Settings.Default.plateSpaceingSet = float.Parse(plateSpaceingDefault.Text);
                plateSpaceingBox.Clear();
            }

            if (String.IsNullOrWhiteSpace(lineSpaceingBox.Text) == false)
            {
                Properties.Settings.Default.lineSpaceingSet = float.Parse(lineSpaceingDefault.Text);
                lineSpaceingBox.Clear();
            }

            if (String.IsNullOrWhiteSpace(charSpaceingBox.Text) == false)
            {
                Properties.Settings.Default.charSpaceingSet = float.Parse(charSpaceingDefault.Text);
                charSpaceingBox.Clear();
            }

            Properties.Settings.Default.Save();
            serialComF2.sendSettings();
        }

    }
}
