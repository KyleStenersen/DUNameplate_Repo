using System;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public partial class MAIN_FORM : Form
    {
        TextBox[] arrayOfTagTextBoxes;
        string[] arrayOfTagLines;

        SerialCom serialComF1 = new SerialCom();
        Jig jig = new Jig();
        PlateQueue queue;


        public MAIN_FORM()
        {
            //Running these once on startup

            InitializeComponent();

            // Set the JigComboBox to 1-Plate by default to prevent bugs
            JigComboBox.SelectedIndex = 0;

            // Initialize the queue with our ListView of queued plates, so that it can change the list on screen
            // when the queue is changed
            queue = new PlateQueue(queuedPlatesList);

            // Make sure the Jig is properly initialized
            jig.setValues(JigComboBox.SelectedIndex);

            arrayOfTagTextBoxes = new TextBox[4] { tag1Line0Box, tag1Line1Box, tag1Line2Box, tag1Line3Box };
            arrayOfTagLines = new string[4];

            serialComF1.setupPort();
            serialComF1.sendSettings();
        }

// USER INPUT RESPONSE FUNCTIONS ============================================

        private void tag1Line0Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 0;
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void tag1Line1Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 1;
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }
        private void tag1Line2Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 2;
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void tag1Line3Box_TextChanged(object sender, EventArgs e)
        {
            int TAG_LINE_NUMBER = 3;
            CheckTextBox.redTagBoxIfInputError(ref arrayOfTagLines[TAG_LINE_NUMBER], ref arrayOfTagTextBoxes[TAG_LINE_NUMBER], TAG_LINE_NUMBER);
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            SETTINGS_FORM settings_form = new SETTINGS_FORM();
            settings_form.ShowDialog();
        }

        private void clearTagBtn_Click(object sender, EventArgs e)
        {
            EditTextBox.emptyTag(ref arrayOfTagLines, ref arrayOfTagTextBoxes);
            
            //tag1QuantityBox.Text = null;

            tagQuantityBox.Value = 1;
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            home();
        }

        
        private void JigComboBox_DropDownClosed(object sender, EventArgs e)
        {
            jig.setValues(JigComboBox.SelectedIndex);
        }

        private void printTagsBtn_Click(object sender, EventArgs e)
        {
            // Make sure the jig's position is set to zero to avoid weird behavior
            jig.Position = 0;

            int currentTagQuantity = (int) tagQuantityBox.Value;

            Nameplate plateToPrint;

            // FromTextBoxes can throw an exception due to the text in the TextBoxes being invalid, so we need to handle it
            try
            {
                // Create a new Nameplate from the current text in the text boxes
                plateToPrint = Nameplate.FromTextBoxes(arrayOfTagTextBoxes, currentTagQuantity);
            }
            catch (ArgumentException) 
            {
                return; // We can just return here, because the functions FromTextBoxes calls will show a MessageBox for us
            }

            printTags(plateToPrint);
        }
        private void printQueueBtn_Click(object sender, EventArgs e)
        {
            // Make sure the jig's position is set to zero to avoid weird behavior
            jig.Position = 0;

            // Go through each Nameplate in the queue and print them
            while (queue.Count != 0) 
            {
                Nameplate currentPlate = queue.Dequeue();

                printTags(currentPlate);
            }

        }
        private void addToQueueBtn_Click(object sender, EventArgs e)
        {
            int currentTagQuantity = (int) tagQuantityBox.Value;

            // Error handling here, because FromTextBoxes can throw an exception if the text in the boxes is invalid
            try
            {
                Nameplate newPlate = Nameplate.FromTextBoxes(arrayOfTagTextBoxes, currentTagQuantity);

                queue.Enqueue(newPlate);
            }
            catch(ArgumentException)
            {
                // We don't have to show a message here, because the methods being called by FromTextBoxes will show a MessageBox
                // if this is reached. So we will print a message to the console for debugging instead.

                Console.WriteLine("ArgumentException from Nameplate.FromTextBoxes has been caught");
            }
            
        }

        //  PRIVATE FUNCTIONS=======================================================


        private void printTag(Nameplate plateToPrint)
        {
            // Send our current settings to the machine, just in case our settings are different from what the machine has right now
            serialComF1.sendSettings();

            string tagText = plateToPrint.PrintableLines;

            //tagText = tagText.ToUpper(); // Not needed due to marking all the text fields to automatically uppercase everything
            tagText = ("<" + "a" + jig.XStartLocation + "," + jig.YStartLocation + "," + tagText + ">");

            serialComF1.sendString(tagText);
        }

        private void printTags(Nameplate plateToPrint)
        {
            int currentTagQuantity = plateToPrint.Quantity;

            for (int i = 0; i < currentTagQuantity; i++)
            {
                // serialComF1.clearInputBuffer();
                // Was doing before and after but only because
                // of a bunch of messy serial output in arduino

                printTag(plateToPrint);

                jig.Position++;

                waitPlateDone();

                if (jig.Position == jig.Capacity)
                {
                    home();

                    // If the tag is not the final tag being printed, ask the user to reload
                    if (i != currentTagQuantity - 1 || queue.Count != 0)
                        MessageBox.Show("Please reload, press OK when done");

                    jig.Position = 0;
                }
            }
        }

        private void waitPlateDone()
        {
            bool plateIsDone = false;

            while (plateIsDone == false)
            {
                serialComF1.checkIfPlateDone(ref plateIsDone);
            }
        }

        private void home()
        {
            serialComF1.sendString("<h>");
        }
    }
}
