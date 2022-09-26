using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace DUNameplateGUI
{
    // This class is where all the main printing functions belong.
    internal static class MachineControl
    {
        // This value should never be accessed directly, only through isPrinting
        private static bool _isPrinting = false;

        public static bool isPrinting
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

        public static AutoResetEvent reloadedEvent = new AutoResetEvent(false);

        // This will be set to true whenever the queue is cleared from UIControl
        public static bool cancellationRequested = false;

        private static void printTag(Nameplate plateToPrint)
        {
            // Send our current settings to the machine, just in case our settings are different from what the machine has right now
            SerialCom.sendSettings();

            string tagText = plateToPrint.PrintableLines;

            //tagText = tagText.ToUpper(); // Not needed due to marking all the text fields to automatically uppercase everything
            tagText = ("<" + "a" + Jig.XStartLocation + "," + Jig.YStartLocation + "," + tagText + ">");

            SerialCom.sendString(tagText);
        }

        //private static void printMultipleOfOneTag(Nameplate plateToPrint)
        //{
        //    int currentTagQuantity = plateToPrint.Quantity;

        //    for (int i = 0; i < currentTagQuantity; i++)
        //    {
        //        // If cancellationRequested is true, throw an OperationCancelled exception to stop the printing here
        //        // This exception will be caught by the code in startPrintingTaskIfNotPrinting
        //        if (cancellationRequested == true)
        //        {
        //            cancellationRequested = false;
        //            throw new OperationCanceledException();
        //        }

        //        // serialComF1.clearInputBuffer();
        //        // Was doing before and after but only because
        //        // of a bunch of messy serial output in arduino

        //        printTag(plateToPrint);

        //        //Jig.Position++;

        //        waitPlateDone();

        //        PlateQueue.DecrementTopPlateQuantity();

        //        //if (Jig.Position == Jig.Capacity)
        //        if (Jig.Position + 1 == Jig.Capacity)
        //        {
        //            home();

        //            // If the tag is not the final tag being printed, ask the user to reload
        //            if (i != currentTagQuantity - 1 || PlateQueue.Count != 0)
        //            {
        //                // Set the status to ReloadNeeded
        //                UIControl.changeStatusIndicator(UIControl.Status.ReloadNeeded);

        //                //MessageBox.Show("Please reload, press OK when done");

        //                // Wait/Block this thread until the reloadedEvent gets set from someone
        //                // pressing the reload button on the GUI, or by scanning a barcode with
        //                // the right key combination
        //                // Learn more about AutoResetEvents here:https://docs.microsoft.com/en-us/dotnet/api/system.threading.autoresetevent?view=net-6.0
        //                reloadedEvent.WaitOne();

        //                // And now we're printing again, so set it back
        //                UIControl.changeStatusIndicator(UIControl.Status.Printing);
        //            }

        //            Jig.Position = 0;
        //        } 
        //        else
        //        {
        //            Jig.Position++;
        //        }
        //    }
        //}

        private static void printOneTagFromQueue()
        {
            // If cancellationRequested is true, throw an OperationCancelled exception to stop the printing here
            // This exception will be caught by the code in startPrintingTaskIfNotPrinting
            if (cancellationRequested == true)
            {
                cancellationRequested = false;
                throw new OperationCanceledException();
            }

            // Grab a copy of the nameplate on the top of the queue, without removing it
            Nameplate currentPlate = PlateQueue.Peek();

            // Tell the machine to print that nameplate out
            printTag(currentPlate);

            // Block right here until the plate is done printing
            waitPlateDone();

            // Decrement the quantity of the plate on top of the queue, which should be the one we just printed
            // Maybe this should be changed to decrement the quantity of the plate we just printed
            // by finding that plate?
            //PlateQueue.DecrementTopPlateQuantity();

            PlateQueue.DecrementSpecificPlateQuantity(currentPlate);

            // If there is no more room in the jig, home, and then tell the user to reload the machine
            if (Jig.Position + 1 == Jig.Capacity)
            {
                home();

                // If the tag is not the final tag being printed, ask the user to reload
                if (PlateQueue.Count != 0)
                {
                    // Set the status to ReloadNeeded
                    UIControl.changeStatusIndicator(UIControl.Status.ReloadNeeded);

                    //MessageBox.Show("Please reload, press OK when done");

                    // Wait/Block this thread until the reloadedEvent gets set from someone
                    // pressing the reload button on the GUI, or by scanning a barcode with
                    // the right key combination
                    // Learn more about AutoResetEvents here:https://docs.microsoft.com/en-us/dotnet/api/system.threading.autoresetevent?view=net-6.0
                    Log.Debug("MachineCntrl - printonetag - wait reload");
                    reloadedEvent.WaitOne();

                    // And now we're printing again, so set it back
                    UIControl.changeStatusIndicator(UIControl.Status.Printing);
                }

                Jig.Position = 0;
            }
            else
            {
                Jig.Position++;
            }
        }

        public static void startPrintingTaskIfNotPrinting()
        {

            if (!isPrinting)
            {
                // Changing isPrinting automatically changes the status indicator
                isPrinting = true;

                // Reset cancellationRequested to false, because it might be true due to a clearing of the queue
                // while no printing was happening
                cancellationRequested = false;
                
                // Disable home button while printing
                UIControl.disableSomeUIWhilePrinting();

                Task.Run(() =>
                {
                    // This should probably be removed so that the last position persists between prints
                    // Maybe add a timer automatically reset jig.Position to 0 after a period of inactivity
                    // Make sure the jig's position is set to zero to avoid weird behavior
                    //jig.Position = 0;

                    // Go through each Nameplate in the queue and print them
                    while (PlateQueue.Count != 0)
                    {
                        //// We peek the nameplate at the top of the queue, because we don't want to remove it from
                        //// the UI and confuse the user if the plate had a large quantity
                        //// The nameplate will be removed from the queue after the printMultipleOfOneTag
                        //// function completes.
                        //Nameplate currentPlate = PlateQueue.Peek();

                        //// printMultipleOfOneTag will throw an OperationCancelledException if cancellationRequested is true
                        //// This try-catch block will catch that exception, and stop this printing task
                        //try
                        //{
                        //    printMultipleOfOneTag(currentPlate);
                        //} 
                        //catch (OperationCanceledException)
                        //{
                        //    Console.WriteLine("Catching OperationCanceledException from printMultipleOfOneTag, stopping printing now");
                        //    break; // break out of this while loop, which will jump straight to the code at the end of printing
                        //}

                        // printOneTagFromQueue will throw an OperationCancelledException if cancellationRequested is true
                        // This try-catch block will catch that exception, and stop this printing task
                        try
                        {
                            printOneTagFromQueue();
                        }
                        catch (OperationCanceledException)
                        {
                            Log.Debug("Catching OperationCanceledException from printOneTagFromQueue, stopping printing now");
                            break; // break out of this while loop, which will jump straight to the code at the end of printing
                        }
                    }

                    // Home after queue completes or printing is cancelled
                    home();

                    Log.Debug("Done printing");

                    // Changing isPrinting automatically changes the status indicator
                    isPrinting = false;

                    // If the setting for resetting the jig after each print is enabled,
                    // reset the jig.
                    if (Properties.Settings.Default.resetJigAfterQueueCompletes)
                    {
                        Jig.Position = 0;
                    }

                    // Re-enable the UI that was disabled when we started printing
                    UIControl.reenableSomeUIAfterPrinting();
                });
            }
            else
            {
                Log.Debug("It is currently printing right now, so we'll ignore the request to print");
            }
        }

        private static void waitPlateDone()
        {
            Log.Debug("Waiting for plate to be complete...");

            bool plateIsDone = false;
            bool homeIsDone = false;

            while (plateIsDone == false)
            {
                SerialCom.checkIfPlateDone_Estop_Homed(ref plateIsDone, ref homeIsDone);
            }

            Log.Debug("Plate complete");
        }


        public static void home()
        {
            SerialCom.sendString("<h>");
            waitHomeDone();
        }

        private static void waitHomeDone()
        {
            Log.Debug("Waiting for homing to be complete...");

            bool homeIsDone = false;
            bool plateIsDone = false;

            while (homeIsDone == false)
            {
                SerialCom.checkIfPlateDone_Estop_Homed(ref plateIsDone, ref homeIsDone);
            }

            Log.Debug("home complete");
        }

    }
}
