using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    public partial class MAIN_FORM : Form
    {
        TextBox[] arrayOfTagTextBoxes;
        //string[] arrayOfTagLines;

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

            // UIControl's functions will not work unless it has access to several main UI elements
            UIControl.Initialize(arrayOfTagTextBoxes, tagQuantityBox, jigComboBox, statusLabel);

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
            MachineControl.home();
        }
        
        private void JigComboBox_DropDownClosed(object sender, EventArgs e)
        {
            Jig.setValues(jigComboBox.SelectedIndex);
        }

        //private void printTagsBtn_Click(object sender, EventArgs e)
        //{
        //    // Make sure the jig's position is set to zero to avoid weird behavior
        //    jig.Position = 0;

        //    int currentTagQuantity = (int) tagQuantityBox.Value;

        //    Nameplate plateToPrint;

        //    // FromTextBoxes can throw an exception due to the text in the TextBoxes being invalid, so we need to handle it
        //    try
        //    {
        //        // Create a new Nameplate from the current text in the text boxes
        //        plateToPrint = Nameplate.FromTextBoxes(arrayOfTagTextBoxes, currentTagQuantity);
        //    }
        //    catch (ArgumentException) 
        //    {
        //        return; // We can just return here, because the functions FromTextBoxes calls will show a MessageBox for us
        //    }

        //    printTags(plateToPrint);
        //}

        private void printQueueBtn_Click(object sender, EventArgs e)
        {
            UIControl.printQueue();

            // This code got moved into startPrintingTask
            //if (!isPrinting) 
            //{
            //    isPrinting = true;
            //    Task.Run(() =>
            //    {
            //        // Make sure the jig's position is set to zero to avoid weird behavior
            //        jig.Position = 0;

            //        // Go through each Nameplate in the queue and print them
            //        while (queue.Count != 0)
            //        {
            //            if (queue.TryDequeue(out Nameplate currentPlate))
            //            {
            //                printTags(currentPlate);
            //            }
            //            else
            //            {
            //                break;
            //            }

            //            //// Single threaded version
            //            //Nameplate currentPlate = queue.Dequeue();

            //            //printTags(currentPlate);
            //        }

            //        Console.WriteLine("Done printing");
            //        isPrinting = false;
            //    });
            //}
            //else
            //{
            //    Console.WriteLine("It is currently printing right now, so we'll ignore the request to print");
            //}

            //// Make sure the jig's position is set to zero to avoid weird behavior
            //jig.Position = 0;

            //// Go through each Nameplate in the queue and print them
            //while (queue.Count != 0)
            //{
            //    Nameplate currentPlate = queue.Dequeue();

            //    printTags(currentPlate);
            //}

        }
        private void addToQueueBtn_Click(object sender, EventArgs e)
        {
            UIControl.addCurrentTagToQueue();
            //int currentTagQuantity = (int) tagQuantityBox.Value;

            //// Error handling here, because FromTextBoxes can throw an exception if the text in the boxes is invalid
            //try
            //{
            //    Nameplate newPlate = Nameplate.FromTextBoxes(arrayOfTagTextBoxes, currentTagQuantity);

            //    PlateQueue.Enqueue(newPlate);

            //    // Clear out the tag text boxes
            //    UIControl.clearTag();

            //    if (Properties.Settings.Default.autoPrintQueue)
            //    {
            //        MachineControl.startPrintingTaskIfNotPrinting();
            //    }
            //}
            //catch(ArgumentException)
            //{
            //    // We don't have to show a message here, because the methods being called by FromTextBoxes will show a MessageBox
            //    // if this is reached. So we will print a message to the console for debugging instead.

            //    Console.WriteLine("ArgumentException from Nameplate.FromTextBoxes has been caught");
            //}
            
        }

        //  PRIVATE FUNCTIONS=======================================================

    }
}
