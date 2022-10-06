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
        //// This value should never be accessed directly, only through isPrinting
        //private static bool _isPrinting = false;

        //public static bool isPrinting
        //{
        //    get { 
        //        return _isPrinting;
        //    }
        //    set
        //    {
        //        _isPrinting = value;
        //        if (_isPrinting) {
        //            // Change our status indicator to show that we are printing
        //            UIControl.changeStatusIndicator(UIControl.Status.Printing);
        //        } 
        //        else
        //        {
        //            // Change the status indicator to show that we are ready to print again
        //            UIControl.changeStatusIndicator(UIControl.Status.Ready);
        //        }
        //    }
        //}

        public static bool isPrinting = false;

        public static AutoResetEvent reloadedEvent = new AutoResetEvent(false);

        // This will be set to true whenever the queue is cleared from UIControl
        public static bool cancellationRequested = false;

        private static void printTag(Nameplate plateToPrint)
        {
            // Send our current settings to the machine, just in case our settings are different from what the machine has right now
            SerialCom.sendSettings();

            string tagText = plateToPrint.PrintableLines;

            //tagText = tagText.ToUpper(); // Not needed due to marking all the text fields to automatically uppercase everything
            tagText = ("<" + "a" + Jig.XStartLocation + "^" + Jig.YStartLocation + "^" + tagText + ">");

            SerialCom.sendString(tagText);
        }

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
            //waitPlateDone();
            SerialCom.waitForPlateDoneOrEstop();

            // If cancellationRequested is true, throw an OperationCancelled exception to stop the printing here
            // This exception will be caught by the code in startPrintingTaskIfNotPrinting
            if (cancellationRequested == true)
            {
                cancellationRequested = false;
                throw new OperationCanceledException();
            }

            // Decrement the quantity of the plate that we just printed
            PlateQueue.DecrementSpecificPlateQuantity(currentPlate);

            // If there is no more room in the jig, home, and then tell the user to reload the machine
            if (Jig.Position + 1 == Jig.Capacity)
            {
                home();

                // Set the status to ReloadNeeded
                UIControl.changeStatusIndicator(UIControl.Status.ReloadNeeded);

                // Wait/Block this thread until the reloadedEvent gets set from someone
                // pressing the reload button on the GUI, or by scanning a barcode with
                // the right key combination
                // Learn more about AutoResetEvents here:https://docs.microsoft.com/en-us/dotnet/api/system.threading.autoresetevent?view=net-6.0
                Log.Debug("MachineCntrl - printonetag - wait reload");
                reloadedEvent.WaitOne();

                // And now we're printing again, so set it back
                UIControl.changeStatusIndicator(UIControl.Status.Printing);

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
                isPrinting = true;
                UIControl.changeStatusIndicator(UIControl.Status.Printing);

                // Reset cancellationRequested to false, because it might be true due to a clearing of the queue
                // while no printing was happening
                cancellationRequested = false;
                
                // Disable home button while printing
                UIControl.disableSomeUIWhilePrinting();

                Task.Run(() =>
                {
                    // Go through each Nameplate in the queue and print them
                    while (PlateQueue.Count != 0)
                    {
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

                    // If homed successfully, set status to Ready as normal
                    // If unsuccessful, don't change the status
                    if (home())
                    {
                        UIControl.changeStatusIndicator(UIControl.Status.Ready);
                    } 

                    Log.Debug("Printing task complete");

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

        // Homes the machine, waits until it is complete, and then returns true if it succeeded,
        // and false if it did not
        public static bool home()
        {
            UIControl.Status lastStatus = UIControl.currentStatus;

            UIControl.changeStatusIndicator(UIControl.Status.Homing);
            SerialCom.sendString("<h>");
            if (SerialCom.waitForHome())
            {
                // Homed properly
                UIControl.changeStatusIndicator(lastStatus);
                return true;
            } 
            else
            {
                // Timed out or serial disconnected
                Log.Error("MachineControl - home - waitForHome timed out / serial disconnected");
                return false;
            }
            
        }
    }
}
