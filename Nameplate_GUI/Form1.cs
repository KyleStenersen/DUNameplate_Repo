using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public partial class MAIN_FORM : Form
    {
        TextBox[] arrayOfTagTextBoxes;
        Panel[] arrayOfJigIndicatorPanels;

        HotkeyHandler hotkeyHandler;

        public MAIN_FORM()
        {
            InitializeComponent();
        }

        private void MAIN_FORM_Load(object sender, EventArgs e)
        {
            // This code is run on startup, after the form is loaded

            arrayOfTagTextBoxes = new TextBox[4] { tag1Line0Box, tag1Line1Box, tag1Line2Box, tag1Line3Box };
            //arrayOfTagLines = new string[4];

            arrayOfJigIndicatorPanels = new Panel[8] { jigIndicator0, jigIndicator1, jigIndicator2, jigIndicator3, jigIndicator4, jigIndicator5, jigIndicator6, jigIndicator7 };

            // UIControl's functions will not work unless it has access to several main UI elements
            UIControl.Initialize(arrayOfTagTextBoxes, tagQuantityBox, jigLabel, statusLabel, arrayOfJigIndicatorPanels, homeButton, settingsBtn, jigIndicatorTableLayoutPanel);

            // Initialize our HotkeyHandler
            hotkeyHandler = new HotkeyHandler(this);

            // Initialize the queue with our ListView of queued plates, so that it can change the list on screen
            // when the queue is changed
            //queue = new PlateQueue(queuedPlatesListView);
            PlateQueue.SetListView(queuedPlatesListView);

            // Initialize the Jig to the current setting from the settings form
            Jig.setValues(Properties.Settings.Default.selectedJig);

            SerialCom.setupPort();
            SerialCom.sendSettings();

            // Initialize our idle timer, which will reset the jig after a certain amount of time passes
            IdleTimer.Initialize();

            IdleMessageFilter imf = new IdleMessageFilter();
            Application.AddMessageFilter(imf);

            Application.Idle += new EventHandler(IdleTimer.OnWinFormsIdle);
        }

        // USER INPUT RESPONSE FUNCTIONS ============================================

        private void tag1Line0Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 0;
            //CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void tag1Line1Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 1;
            //CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }
        private void tag1Line2Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 2;
            //CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void tag1Line3Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 3;
            //CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            SETTINGS_FORM settings_form = new SETTINGS_FORM();
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
            UIControl.signalReloaded();
        }

        private void addToTopOfQueueBtn_Click(object sender, EventArgs e)
        {
            UIControl.addCurrentTagToQueue(UIControl.QueuePosition.TopOfQueue);
        }

        private void jigIndicator0_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                Jig.Position = 0;
            }
        }

        private void jigIndicator1_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                Jig.Position = 1;
            }
        }

        private void jigIndicator2_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                Jig.Position = 2;
            }
        }

        private void jigIndicator3_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                Jig.Position = 3;
            }
        }

        private void jigIndicator4_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                Jig.Position = 4;
            }
        }

        private void jigIndicator5_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                Jig.Position = 5;
            }
        }

        private void jigIndicator6_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                Jig.Position = 6;
            }
        }

        private void jigIndicator7_Click(object sender, EventArgs e)
        {
            if (!MachineControl.isPrinting)
            {
                Jig.Position = 7;
            }
        }
    }
}
