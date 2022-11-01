using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace DUNameplateGUI
{
    // This class is where all the main UI button actions are, as well as some other functions for controlling the UI.
    // The reason for separating this class from Form1.cs is to make so that these actions
    // can be activated from elsewhere (mainly HotkeyHandler). It must be initialized with
    // Initialize at the start of the program, otherwise a few of the functions will not work.
    internal static class UIControl
    {
        // This enum is used for the different states of the status indicator on the UI
        public enum Status
        {
            Disconnected,
            Ready,
            Printing,
            ReloadNeeded,
            Estopped,
            Homing,
            Cancelling
        }

        public enum QueuePosition
        {
            BottomOfQueue,
            TopOfQueue
        }

        // Stores the current status for checking later (just for when someone clicks the status)
        public static Status currentStatus = Status.Ready;

        private static TextBox[] arrayOfTagTextBoxes;

        // Needed for clearTag, addCurrentTagToQueue, and setQuantity
        private static NumericUpDown tagQuantityBox;

        //// Needed for disableJigComboBox
        //private static ComboBox jigComboBox;

        // Needed for updateJigDisplay
        private static Label jigLabel;

        // Needed for changeStatusIndicator
        private static Label statusLabel;

        // Needed for jigPositionChanged
        private static Panel[] arrayOfJigIndicatorPanels;
        private static int currentlyActivatedIndicator = 0;
        private static TableLayoutPanel jigIndicatorTableLayoutPanel;

        // Needed for disableSomeUIWhilePrinting and reenableSomeUIAfterPrinting
        private static Button homeButton;
        private static Button settingsButton;

        // These function arguments have unique names, due to C# not being happy about the use of this.duplicateName
        public static void Initialize(TextBox[] textBoxes, NumericUpDown quantityBox, Label selectedJigLabel, Label statusIndicator, Panel[] jigIndicatorPanels, Button homeBtn, Button settingsBtn, TableLayoutPanel jigIndicatorTableLayout)
        {
            arrayOfTagTextBoxes = textBoxes;
            tagQuantityBox = quantityBox;
            jigLabel = selectedJigLabel;
            statusLabel = statusIndicator;
            arrayOfJigIndicatorPanels = jigIndicatorPanels;
            homeButton = homeBtn;
            settingsButton = settingsBtn;
            jigIndicatorTableLayoutPanel = jigIndicatorTableLayout;

            // Subscribe jigPositionChanged to the event from the Jig
            Jig.PositionChanged += jigPositionChanged;
        }

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

        // This function clears the PlateQueue, but also requests a cancellation if we are
        // currently printing right now.
        public static void clearQueue()
        {
            //requestCancel();
            PlateQueue.Clear();
        }
        public static void requestCancel()
        {
            MachineControl.cancellationRequested = true;
            if (MachineControl.isPrinting)
            {
                changeStatusIndicator(Status.Cancelling);
            }
        }

        public static void printQueue()
        {
            MachineControl.startPrintingTaskIfNotPrinting();
        }

        public static void addCurrentTagToQueue(QueuePosition queuePosition)
        {
            int currentTagQuantity = (int)tagQuantityBox.Value;

            // Error handling here, because FromTextBoxes can throw an exception if the text in the boxes is invalid
            try
            {
                Nameplate newPlate = Nameplate.FromTextBoxes(arrayOfTagTextBoxes, currentTagQuantity);

                switch (queuePosition)
                {
                    case QueuePosition.TopOfQueue:
                        PlateQueue.EnqueueOnTop(newPlate);
                        break;
                    case QueuePosition.BottomOfQueue:
                        PlateQueue.Enqueue(newPlate);
                        break;
                }

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

        public static void deleteSelectedTag()
        {
            PlateQueue.DeleteSelectedPlate();
        }

        public static void home()
        {
            MachineControl.home();
            Jig.Position = 0;
        }

        // This function is called when we start printing, to prevent the user from pressing the home button, or changing
        // the currently selected jig while printing.
        public static void disableSomeUIWhilePrinting()
        {
            // This is a delegate for disabling the UI elements, because if we are on another thread,
            // we need to Invoke to get back onto it
            Action disableUI = delegate ()
            {
                //jigComboBox.Enabled = false;
                homeButton.Enabled = false;
                settingsButton.Enabled = false;
            };
                
            homeButton.Invoke(disableUI);
        }
            
        // This function is called after the printing is done, to re-enable the home button and jig selector box.
        public static void reenableSomeUIAfterPrinting()
        {
            // This is a delegate for disabling the UI elements, because if we are on another thread,
            // we need to Invoke to get back onto it
            Action enableUI = delegate ()
            {
                //jigComboBox.Enabled = true;
                homeButton.Enabled = true;
                settingsButton.Enabled = true;
            };

            // It doesn't matter which UI element we invoke here, invoking any element will get us on the main thread
            homeButton.Invoke(enableUI);
        }

        public static void changeStatusIndicator(Status status)
        {
            currentStatus = status;

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
                    case Status.Estopped:
                        statusLabel.Text = "ESTOPPED";
                        statusLabel.BackColor = System.Drawing.Color.Red;
                        break;
                    case Status.Homing:
                        statusLabel.Text = "HOMING";
                        statusLabel.BackColor = System.Drawing.Color.Khaki;
                        break;
                    case Status.Cancelling:
                        statusLabel.Text = "CANCELLING AFTER THIS PRINT";
                        statusLabel.BackColor = System.Drawing.Color.MediumVioletRed;
                        break;

                }
            };

            statusLabel.Invoke(changeStatusAction, status);
        }

        // This function should be run after the jig has been reloaded
        public static void signalReloaded()
        {
            Log.Debug("signalReloaded");

            // The reason why we are setting and immediately resetting this AutoResetEvent
            // is to prevent someone from pressing reload when the machine doesn't need it,
            // and then for the machine to think that somebody already reloaded it the
            // next time that it goes to wait for a reload.
            MachineControl.reloadedEvent.Set();
            MachineControl.reloadedEvent.Reset();
        }

        public static void signalEstopResetClicked()
        {
            Log.Debug("signalEstopResetClicked");

            //Send reset signal to Arduino
            SerialCom.estopReset();
            // The reason why we are setting and immediately resetting this AutoResetEvent
            // is to prevent someone from pressing reload when the machine doesn't need it,
            // and then for the machine to think that somebody already reloaded it the
            // next time that it goes to wait for a reload.
            SerialCom.resetEstopEvent.Set();
            SerialCom.resetEstopEvent.Reset();

        }

        // Used from HotkeyHandler, these don't need invokes as they run on the main thread
        public static void setQuantity(int quantity)
        {
            tagQuantityBox.Value = quantity;
        }

        //// Used from HotkeyHandler
        //public static void setJig(int jigNumber)
        //{
        //    jigComboBox.SelectedIndex = jigNumber;
        //}

        // This is the width of the table layout panel when it is set to 8-Plate
        const int FULL_TABLE_LAYOUT_WIDTH = 200;

        // This is the height of the table layout panel when it is set to 8-Plate/4-Plate
        const int FULL_TABLE_LAYOUT_HEIGHT = 250;

        // This function updates the label that says what jig is currently selected, and also modifies the jig indicator's
        // table layout panel to be the correct size for the jig selected.
        public static void updateJigDisplay()
        {
            Action updateJigDisplay = delegate ()
            {
                String selectedJigString = "";

                switch (Jig.currentlySelectedJig)
                {
                    case 0:
                        selectedJigString = "1-Plate";
                        jigIndicatorTableLayoutPanel.RowStyles[0].Height = 100;
                        jigIndicatorTableLayoutPanel.RowStyles[1].Height = 0;
                        jigIndicatorTableLayoutPanel.RowStyles[2].Height = 0;
                        jigIndicatorTableLayoutPanel.RowStyles[3].Height = 0;
                        jigIndicatorTableLayoutPanel.ColumnStyles[0].Width = 100;
                        jigIndicatorTableLayoutPanel.ColumnStyles[1].Width = 0;
                        jigIndicatorTableLayoutPanel.Size = new System.Drawing.Size(FULL_TABLE_LAYOUT_WIDTH / 2, FULL_TABLE_LAYOUT_HEIGHT / 4);
                        break;
                    case 1:
                        selectedJigString = "2-Plate";
                        jigIndicatorTableLayoutPanel.RowStyles[0].Height = 50;
                        jigIndicatorTableLayoutPanel.RowStyles[1].Height = 50;
                        jigIndicatorTableLayoutPanel.RowStyles[2].Height = 0;
                        jigIndicatorTableLayoutPanel.RowStyles[3].Height = 0;
                        jigIndicatorTableLayoutPanel.ColumnStyles[0].Width = 100;
                        jigIndicatorTableLayoutPanel.ColumnStyles[1].Width = 0;
                        jigIndicatorTableLayoutPanel.Size = new System.Drawing.Size(FULL_TABLE_LAYOUT_WIDTH / 2, FULL_TABLE_LAYOUT_HEIGHT / 2);
                        break;
                    case 2:
                        selectedJigString = "4-Plate";
                        jigIndicatorTableLayoutPanel.RowStyles[0].Height = 25;
                        jigIndicatorTableLayoutPanel.RowStyles[1].Height = 25;
                        jigIndicatorTableLayoutPanel.RowStyles[2].Height = 25;
                        jigIndicatorTableLayoutPanel.RowStyles[3].Height = 25;
                        jigIndicatorTableLayoutPanel.ColumnStyles[0].Width = 100;
                        jigIndicatorTableLayoutPanel.ColumnStyles[1].Width = 0;
                        jigIndicatorTableLayoutPanel.Size = new System.Drawing.Size(FULL_TABLE_LAYOUT_WIDTH / 2, FULL_TABLE_LAYOUT_HEIGHT);
                        break;
                    case 3:
                        selectedJigString = "8-Plate";
                        jigIndicatorTableLayoutPanel.RowStyles[0].Height = 25;
                        jigIndicatorTableLayoutPanel.RowStyles[1].Height = 25;
                        jigIndicatorTableLayoutPanel.RowStyles[2].Height = 25;
                        jigIndicatorTableLayoutPanel.RowStyles[3].Height = 25;
                        jigIndicatorTableLayoutPanel.ColumnStyles[0].Width = 50;
                        jigIndicatorTableLayoutPanel.ColumnStyles[1].Width = 50;
                        jigIndicatorTableLayoutPanel.Size = new System.Drawing.Size(FULL_TABLE_LAYOUT_WIDTH, FULL_TABLE_LAYOUT_HEIGHT);
                        break;

                }

                jigLabel.Text = selectedJigString;
            };

            jigLabel.Invoke(updateJigDisplay);
        }
        
        public static void focusFirstTextBox()
        {
            arrayOfTagTextBoxes[0].Focus();
        }

        public static void resetConnection()
        {
            SerialCom.resetConnection();
        }

        public static void saveSlot(int slotNumber)
        {
            SpeedDialManager.SaveCurrentPlateToSlot(slotNumber, arrayOfTagTextBoxes);
        }

        public static void loadSlot(int slotNumber)
        {
            SpeedDialManager.LoadSlotToTextBoxes(slotNumber, arrayOfTagTextBoxes);
        }

    }
}

