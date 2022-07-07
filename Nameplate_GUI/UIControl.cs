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
        public enum Status
        {
            Disconnected,
            Ready,
            Printing,
            ReloadNeeded
        }

        private static TextBox[] arrayOfTagTextBoxes;

        // Needed for clearTag and addCurrentTagToQueue
        private static NumericUpDown tagQuantityBox;

        // Needed for disableJigComboBox
        private static ComboBox jigComboBox;

        // Needed for changeStatusIndicator
        private static Label statusLabel;

        // Needed for jigPositionChanged
        private static Panel[] arrayOfJigIndicatorPanels;
        private static int currentlyActivatedIndicator = 0;


        // These function arguments have unique names, due to C# not being happy about the use of this.duplicateName
        public static void Initialize(TextBox[] textBoxes, NumericUpDown quantityBox, ComboBox jigSelector, Label statusIndicator, Panel[] jigIndicatorPanels)
        {
            arrayOfTagTextBoxes = textBoxes;
            tagQuantityBox = quantityBox;
            jigComboBox = jigSelector;
            statusLabel = statusIndicator;
            arrayOfJigIndicatorPanels = jigIndicatorPanels;

            // Subscribe jigPositionChanged to the event from the Jig
            Jig.PositionChanged += jigPositionChanged;
        }

        // Needs fixing, currently can crash due to Jig.Position ending up at 4, which is out of bounds
        // for the array
        private static void jigPositionChanged(object sender, PositionChangedEventArgs e)
        {
            Action<int> changeJigIndicatorAction = delegate (int position)
            {
                // Set our last activated indicator color back to deactivated
                arrayOfJigIndicatorPanels[currentlyActivatedIndicator].BackColor = Control.DefaultBackColor;

                // Set our new jig position's indicator color to LimeGreen
                arrayOfJigIndicatorPanels[position].BackColor = System.Drawing.Color.LimeGreen;

                // Set the currentActivatedIndicator to our new position
                currentlyActivatedIndicator = position;
            };

            // Invoke could have been called on any UI element, but here I chose to invoke it on
            // the first one
            arrayOfJigIndicatorPanels[0].Invoke(changeJigIndicatorAction, e.Position);
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
                clearTag();

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

        public static void changeStatusIndicator(Status status)
        {
            // This is a delegate for changing the status indicator, this is needed
            // because this function will be called from other threads that are not
            // the main thread, so we will Invoke this delegate to jump back
            // onto the main thread, and then do our changes.
            Action<Status> changeStatusAction = delegate (Status statusEnum)
            {
                switch (statusEnum) 
                {
                    case Status.Disconnected:
                        statusLabel.Text = "DISCONNECTED";
                        statusLabel.BackColor = System.Drawing.Color.Red;
                        break;
                    case Status.Ready:
                        statusLabel.Text = "READY";
                        statusLabel.BackColor = System.Drawing.Color.LimeGreen;
                        break;
                    case Status.Printing:
                        statusLabel.Text = "PRINTING";
                        statusLabel.BackColor = System.Drawing.Color.Yellow;
                        break;
                    case Status.ReloadNeeded:
                        statusLabel.Text = "RELOAD NEEDED";
                        statusLabel.BackColor = System.Drawing.Color.Orchid;
                        break;
                }
            };

            statusLabel.Invoke(changeStatusAction, status);
        }

        // This function should be run after the jig has been reloaded
        public static void signalReloaded()
        {
            // The reason why we are setting and immediately resetting this AutoResetEvent
            // is to prevent someone from pressing reload when the machine doesn't need it,
            // and then for the machine to think that somebody already reloaded it the
            // next time that it goes to wait for a reload.
            MachineControl.reloadedEvent.Set();
            MachineControl.reloadedEvent.Reset();
        }
    }
}
