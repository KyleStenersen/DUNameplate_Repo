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
            //Running these once on startup

            InitializeComponent();

            // Initialize our HotkeyHandler
            hotkeyHandler = new HotkeyHandler(this);

            // Set the JigComboBox to 1-Plate by default to prevent bugs
            jigComboBox.SelectedIndex = 0;

            // Initialize the queue with our ListView of queued plates, so that it can change the list on screen
            // when the queue is changed
            //queue = new PlateQueue(queuedPlatesListView);
            PlateQueue.SetListView(queuedPlatesListView);

            // Make sure the Jig is properly initialized
            Jig.setValues(jigComboBox.SelectedIndex);

            arrayOfTagTextBoxes = new TextBox[4] { tag1Line0Box, tag1Line1Box, tag1Line2Box, tag1Line3Box };
            //arrayOfTagLines = new string[4];

            arrayOfJigIndicatorPanels = new Panel[4] { jigIndicator0, jigIndicator1, jigIndicator2, jigIndicator3 };

            // UIControl's functions will not work unless it has access to several main UI elements
            UIControl.Initialize(arrayOfTagTextBoxes, tagQuantityBox, jigComboBox, statusLabel, arrayOfJigIndicatorPanels);

            SerialCom.setupPort();
            SerialCom.sendSettings();
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

        // SelectedIndexChanged is a better event here, because it fires whenever we change the value through code as well
        private void JigComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Jig.setValues(jigComboBox.SelectedIndex);
        }

        private void printQueueBtn_Click(object sender, EventArgs e)
        {
            UIControl.printQueue();
        }
        private void addToQueueBtn_Click(object sender, EventArgs e)
        {
            UIControl.addCurrentTagToQueue();          
        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            UIControl.signalReloaded();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            UIControl.requestCancel();
        }
    }
}
