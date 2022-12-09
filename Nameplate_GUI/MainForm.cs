using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace DUNameplateGUI
{
    public partial class MainForm : Form
    {
        TextBox[] arrayOfTagTextBoxes;
        Panel[] arrayOfJigIndicatorPanels;

        HotkeyHandler hotkeyHandler;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // This code is run on startup, after the form is loaded

            arrayOfTagTextBoxes = new TextBox[4] { tag1Line0Box, tag1Line1Box, tag1Line2Box, tag1Line3Box };
            //arrayOfTagLines = new string[4];

            arrayOfJigIndicatorPanels = new Panel[8] { jigIndicator0, jigIndicator1, jigIndicator2, jigIndicator3, jigIndicator4, jigIndicator5, jigIndicator6, jigIndicator7 };

            // UIControl's functions will not work unless it has access to several main UI elements
            UIControl.Initialize(arrayOfTagTextBoxes, tagQuantityBox, jigLabel, statusLabel, arrayOfJigIndicatorPanels, homeButton, settingsBtn, jigIndicatorTableLayoutPanel, inputFixingRulesEnabledCheckBox);

            // Initialize our HotkeyHandler
            hotkeyHandler = new HotkeyHandler(this);

            // Initialize the queue with our ListView of queued plates, so that it can change the list on screen
            // when the queue is changed
            //queue = new PlateQueue(queuedPlatesListView);
            PlateQueue.SetListView(queuedPlatesListView);

            // Initialize the Jig to the current setting from the settings form
            JigManager.setValues(Properties.Settings.Default.selectedJig);

            SerialCom.setupPort();
            SerialCom.sendSettings();

            // Initialize our idle timer, which will reset the jig after a certain amount of time passes
            IdleTimer.Initialize();

            IdleMessageFilter imf = new IdleMessageFilter();
            Application.AddMessageFilter(imf);

            Application.Idle += new EventHandler(IdleTimer.OnWinFormsIdle);

            InputFixer.Initialize();

            Label[] arrayOfSpeedDialLabels = new Label[6] { speedDialLabel1, speedDialLabel2, speedDialLabel3, speedDialLabel4, speedDialLabel5, speedDialLabel6 };

            SpeedDialManager.Initialize(arrayOfSpeedDialLabels);
        }

        // USER INPUT RESPONSE FUNCTIONS ============================================

        private void tag1Line0Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 0;
            //CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            InputFixer.fixInvalidInput(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER]);
        }

        private void tag1Line1Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 1;
            //CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            InputFixer.fixInvalidInput(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER]);
        }
        private void tag1Line2Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 2;
            //CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            InputFixer.fixInvalidInput(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER]);
        }

        private void tag1Line3Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 3;
            //CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            InputFixer.fixInvalidInput(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER]);
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            SettingsForm settings_form = new SettingsForm();
            settings_form.ShowDialog();
        }

        private void clearTagBtn_Click(object sender, EventArgs e)
        {
            UIControl.clearTag();
        }

        private void clearQueueBtn_Click(object sender, EventArgs e)
        {
            UIControl.clearQueue();
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            UIControl.home();
        }
        
        //private void JigComboBox_DropDownClosed(object sender, EventArgs e)
        //{
        //    Jig.setValues(jigComboBox.SelectedIndex);
        //}

        //// SelectedIndexChanged is a better event here, because it fires whenever we change the value through code as well
        //private void JigComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Jig.setValues(jigComboBox.SelectedIndex);
        //}

        private void printQueueBtn_Click(object sender, EventArgs e)
        {
            UIControl.printQueue();
        }
        private void addToQueueBtn_Click(object sender, EventArgs e)
        {
            UIControl.addCurrentTagToQueue(UIControl.QueuePosition.BottomOfQueue);          
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            UIControl.requestCancel();
        }

        // Signal reloaded when the status indicator is clicked
        // It won't cause any issues by signalling reloaded while the printer does not need reloading
        private void statusLabel_Click(object sender, EventArgs e)
        {
            UIControl.signalEstopResetClicked();
            UIControl.signalReloaded();

            if (UIControl.currentStatus == UIControl.Status.Disconnected)
            {
                UIControl.resetConnection();
            }
        }

        private void addToTopOfQueueBtn_Click(object sender, EventArgs e)
        {
            UIControl.addCurrentTagToQueue(UIControl.QueuePosition.TopOfQueue);
        }

        private void jigIndicator0_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                JigManager.Position = 0;
            }
        }

        private void jigIndicator1_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                JigManager.Position = 1;
            }
        }

        private void jigIndicator2_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                JigManager.Position = 2;
            }
        }

        private void jigIndicator3_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                JigManager.Position = 3;
            }
        }

        private void jigIndicator4_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                JigManager.Position = 4;
            }
        }

        private void jigIndicator5_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                JigManager.Position = 5;
            }
        }

        private void jigIndicator6_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                JigManager.Position = 6;
            }
        }

        private void jigIndicator7_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                JigManager.Position = 7;
            }
        }

        private void tag1Line0Box_DoubleClicked(object sender, EventArgs e)
        {
            tag1Line0Box.SelectAll();
        }

        private void tag1Line1Box_DoubleClicked(object sender, EventArgs e)
        {
            tag1Line1Box.SelectAll();
        }

        private void tag1Line2Box_DoubleClicked(object sender, EventArgs e)
        {
            tag1Line2Box.SelectAll();
        }

        private void tag1Line3Box_DoubleClicked(object sender, EventArgs e)
        {
            tag1Line3Box.SelectAll();
        }

        private void deleteSelectedBtn_Click(object sender, EventArgs e)
        {
            UIControl.deleteSelectedTag();
        }

        private void resetConnectionButton_Click(object sender, EventArgs e)
        {
            UIControl.resetConnection();
        }

        // When the focus is moved away from a text box, trim the text (remove spaces before and after)
        private void textBox_FocusLeave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            textBox.Text = textBox.Text.Trim();
        }

        private void saveSlot1Button_Click(object sender, EventArgs e)
        {
            UIControl.saveSlot(0);
        }

        private void loadSlot1Button_Click(object sender, EventArgs e)
        {
            UIControl.loadSlot(0);
        }

        private void saveSlot2Button_Click(object sender, EventArgs e)
        {
            UIControl.saveSlot(1);
        }

        private void loadSlot2Button_Click(object sender, EventArgs e)
        {
            UIControl.loadSlot(1);
        }

        private void saveSlot3Button_Click(object sender, EventArgs e)
        {
            UIControl.saveSlot(2);
        }

        private void loadSlot3Button_Click(object sender, EventArgs e)
        {
            UIControl.loadSlot(2);
        }

        private void saveSlot4Button_Click(object sender, EventArgs e)
        {
            UIControl.saveSlot(3);
        }

        private void loadSlot4Button_Click(object sender, EventArgs e)
        {
            UIControl.loadSlot(3);
        }

        private void saveSlot5Button_Click(object sender, EventArgs e)
        {
            UIControl.saveSlot(4);
        }

        private void loadSlot5Button_Click(object sender, EventArgs e)
        {
            UIControl.loadSlot(4);
        }

        private void saveSlot6Button_Click(object sender, EventArgs e)
        {
            UIControl.saveSlot(5);
        }

        private void loadSlot6Button_Click(object sender, EventArgs e)
        {
            UIControl.loadSlot(5);
        }

        private void queuedPlatesListView_DoubleClicked(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = queuedPlatesListView.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
            {
                //MessageBox.Show("The selected item name is: " + item.Text + " and the number is " + item.Index); // For debugging only, remove later
                PlateQueue.OpenPlateEditor(item.Index);
            }
        }

        private void inputFixingRulesEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            InputFixer.isEnabled = inputFixingRulesEnabledCheckBox.Checked;
        }
    }
}
