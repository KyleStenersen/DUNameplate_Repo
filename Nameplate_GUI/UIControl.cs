using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    // This class is where all the main UI button actions are, as well as some other functions for controlling the UI.
    // The reason for separating this class from Form1.cs is to make so that these actions
    // can be activated from elsewhere (mainly HotkeyHandler). It must be initialized with
    // Initialize at the start of the program, otherwise a few of the functions will not work.
    internal static class UIControl
    {
        private static TextBox[] arrayOfTagTextBoxes;

        // Needed for clearTag and addCurrentTagToQueue
        private static NumericUpDown tagQuantityBox;

        // Needed for disableJigComboBox
        private static ComboBox jigComboBox;

        public static void Initialize(TextBox[] textBoxes, NumericUpDown quantityBox, ComboBox jigSelector)
        {
            arrayOfTagTextBoxes = textBoxes;
            tagQuantityBox = quantityBox;
            jigComboBox = jigSelector;
        }

        // Clears the tag text boxes, resets the quantity, and focuses the first text box
        public static void clearTag()
        {
            for (int i = 0; i < arrayOfTagTextBoxes.Length; i++)
            {
                arrayOfTagTextBoxes[i].Text = null;
            }

            tagQuantityBox.Value = 1;

            // Focus the first text box
            arrayOfTagTextBoxes[0].Focus();
        }

        public static void clearQueue()
        {
            PlateQueue.Clear();
        }

        public static void printQueue()
        {
            MachineControl.startPrintingTaskIfNotPrinting();
        }

        public static void addCurrentTagToQueue()
        {
            int currentTagQuantity = (int)tagQuantityBox.Value;

            // Error handling here, because FromTextBoxes can throw an exception if the text in the boxes is invalid
            try
            {
                Nameplate newPlate = Nameplate.FromTextBoxes(arrayOfTagTextBoxes, currentTagQuantity);

                PlateQueue.Enqueue(newPlate);

                // Clear out the tag text boxes, reset quantity
                UIControl.clearTag();

                if (Properties.Settings.Default.autoPrintQueue)
                {
                    MachineControl.startPrintingTaskIfNotPrinting();
                }
            }
            catch (ArgumentException)
            {
                // We don't have to show a message here, because the methods being called by FromTextBoxes will show a MessageBox
                // if this is reached. So we will print a message to the console for debugging instead.

                Console.WriteLine("ArgumentException from Nameplate.FromTextBoxes has been caught");
            }
        }

        public static void disableJigComboBox()
        {
            // This is a delegate for disabling the combo box, because if we are on another thread,
            // we need to Invoke to get back onto it
            Action disableJigComboBox = delegate ()
            {
                jigComboBox.Enabled = false;
            };

            jigComboBox.Invoke(disableJigComboBox);
        }

        public static void enableJigComboBox()
        {
            // This is a delegate for enabling the combo box, because if we are on another thread,
            // we need to Invoke to get back onto it
            Action enableJigComboBox = delegate ()
            {
                jigComboBox.Enabled = true;
            };

            jigComboBox.Invoke(enableJigComboBox);
        }
    }
}
