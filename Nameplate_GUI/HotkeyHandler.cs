using System;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    internal class HotkeyHandler
    {
        Form MainForm;

        public HotkeyHandler(Form mainForm)
        {
            MainForm = mainForm;

            // This means that our MainForm will receive all key press events
            // before any of our controls (UI elements) receive the keypresses.
            MainForm.KeyPreview = true;

            // Now we subscribe our own KeyDown function to the KeyDown event of
            // the MainForm
            MainForm.KeyDown += HotkeyKeyDownHandler;
        }

        // For now we are going to hard-code all of the hotkeys and their actions into this function
        private void HotkeyKeyDownHandler(object sender, KeyEventArgs args)
        {
            //if (args.Modifiers == (Keys.Control | Keys.Alt))
            if (args.Modifiers == (Keys.Control))
            {
                // This silences Windows from making a noise on each Ctrl+key input
                args.SuppressKeyPress = true;
                switch (args.KeyCode) 
                {
                    case Keys.Q:
                        UIControl.printQueue();
                        break;
                    case Keys.W:
                        UIControl.addCurrentTagToQueue();
                        break;
                    case Keys.E:
                        UIControl.clearTag();
                        break;
                    case Keys.R:
                        UIControl.clearQueue();
                        break;
                    case Keys.T:
                        UIControl.signalReloaded();
                        break;
                    case Keys.Y:
                        // Prevent the user from homing the machine while printing
                        if (!MachineControl.isPrinting)
                        {
                            UIControl.home();
                        }
                        break;
                    case Keys.U:
                        UIControl.requestCancel();
                        break;
                    // Changing the jig with a barcode is not a feature we need
                    //case Keys.F:
                    //    UIControl.setJig(0);
                    //    break;
                    //case Keys.G:
                    //    UIControl.setJig(1);
                    //    break;
                    //case Keys.H:
                    //    UIControl.setJig(2);
                    //    break;
                    //case Keys.J:
                    //    UIControl.setJig(3);
                    //    break;

                    // These are set to weird arbitrary keys due to not being able to
                    // create barcodes that do Ctrl + all of the numbers
                    case Keys.D1:
                        UIControl.setQuantity(1);
                        break;
                    case Keys.G:
                        UIControl.setQuantity(2);
                        break;
                    case Keys.D2:
                        UIControl.setQuantity(3);
                        break;
                    case Keys.J:
                        UIControl.setQuantity(4);
                        break;
                    case Keys.K:
                        UIControl.setQuantity(5);
                        break;
                    case Keys.L:
                        UIControl.setQuantity(6);
                        break;
                    case Keys.B:
                        UIControl.setQuantity(7);
                        break;
                    case Keys.N:
                        UIControl.setQuantity(8);
                        break;
                    case Keys.D6:
                        UIControl.setQuantity(9);
                        break;

                }
            }
        }
    }
}