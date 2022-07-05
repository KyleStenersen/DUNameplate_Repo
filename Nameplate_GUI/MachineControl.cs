using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    // This class is where all the main printing functions belong.
    internal static class MachineControl
    {
        private static bool _isPrinting = false;

        private static bool isPrinting
        {
            get { 
                return _isPrinting;
            }
            set
            {
                _isPrinting = value;
                if (_isPrinting) {
                    // Change our status indicator to show that we are printing
                    UIControl.changeStatusIndicator(UIControl.Status.Printing);
                } 
                else
                {
                    // Change the status indicator to show that we are ready to print again
                    UIControl.changeStatusIndicator(UIControl.Status.Ready);
                }
            }
        }

        private static void printTag(Nameplate plateToPrint)
        {
            // Send our current settings to the machine, just in case our settings are different from what the machine has right now
            SerialCom.sendSettings();

            string tagText = plateToPrint.PrintableLines;

            //tagText = tagText.ToUpper(); // Not needed due to marking all the text fields to automatically uppercase everything
            tagText = ("<" + "a" + Jig.XStartLocation + "," + Jig.YStartLocation + "," + tagText + ">");

            SerialCom.sendString(tagText);
        }

        private static void printMultipleOfOneTag(Nameplate plateToPrint)
        {
            int currentTagQuantity = plateToPrint.Quantity;

            for (int i = 0; i < currentTagQuantity; i++)
            {
                // serialComF1.clearInputBuffer();
                // Was doing before and after but only because
                // of a bunch of messy serial output in arduino

                printTag(plateToPrint);

                Jig.Position++;

                waitPlateDone();

                if (Jig.Position == Jig.Capacity)
                {
                    home();

                    // If the tag is not the final tag being printed, ask the user to reload
                    if (i != currentTagQuantity - 1 || PlateQueue.Count != 0)
                    {
                        // Set the status to ReloadNeeded
                        UIControl.changeStatusIndicator(UIControl.Status.ReloadNeeded);

                        // This message box probably needs to be changed to something else,
                        // so that we can reload by scanning a certain barcode or pressing a button
                        // on the UI
                        // Looks like AutoResetEvent might be what we want here: https://docs.microsoft.com/en-us/dotnet/api/system.threading.autoresetevent?view=net-6.0
                        MessageBox.Show("Please reload, press OK when done");

                        // And now we're printing again, so set it back
                        UIControl.changeStatusIndicator(UIControl.Status.Printing);
                    }

                    Jig.Position = 0;
                }
            }
        }

        public static void startPrintingTaskIfNotPrinting()
        {
            if (!isPrinting)
            {
                // Changing isPrinting automatically changes the status indicator
                isPrinting = true;

                // Disable the JigComboBox to prevent Jig changes while printing
                // Maybe this is unwanted behavior and we see if it can be changed
                // mid-print safely?
                //JigComboBox.Enabled = false;
                UIControl.disableJigComboBox();

                Task.Run(() =>
                {
                    // This should probably be removed so that the last position persists between prints
                    // Maybe add a timer automatically reset jig.Position to 0 after a period of inactivity
                    // Make sure the jig's position is set to zero to avoid weird behavior
                    //jig.Position = 0;

                    // Go through each Nameplate in the queue and print them
                    while (PlateQueue.Count != 0)
                    {
                        if (PlateQueue.TryDequeue(out Nameplate currentPlate))
                        {
                            printMultipleOfOneTag(currentPlate);
                        }
                        else
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Done printing");

                    // Changing isPrinting automatically changes the status indicator
                    isPrinting = false;

                    // If the setting for resetting the jig after each print is enabled,
                    // reset the jig.
                    if (Properties.Settings.Default.resetJig)
                    {
                        Jig.Position = 0;
                    }

                    // Re-enable the jigComboBox that was disabled at the start of printing
                    UIControl.enableJigComboBox();
                });
            }
            else
            {
                Console.WriteLine("It is currently printing right now, so we'll ignore the request to print");
            }
        }

        private static void waitPlateDone()
        {
            bool plateIsDone = false;

            while (plateIsDone == false)
            {
                SerialCom.checkIfPlateDone(ref plateIsDone);
            }
        }

        public static void home()
        {
            SerialCom.sendString("<h>");
        }

    }
}
