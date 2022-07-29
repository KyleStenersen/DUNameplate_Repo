using System;
using System.Threading;
using System.Threading.Tasks;
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
                switch (args.KeyCode) 
                {
                    case Keys.Q:
                        UIControl.printQueue();
                        afterHotkey(args);
                        break;
                    case Keys.W:
                        UIControl.addCurrentTagToQueue();
                        afterHotkey(args);
                        focusFirstTextBoxAfterDelay();
                        break;
                    case Keys.E:
                        UIControl.clearTag();
                        afterHotkey(args);
                        focusFirstTextBoxAfterDelay();
                        break;
                    case Keys.R:
                        UIControl.clearQueue();
                        afterHotkey(args);
                        break;
                    case Keys.T:
                        UIControl.signalReloaded();
                        afterHotkey(args);
                        break;
                    case Keys.Y:
                        // Prevent the user from homing the machine while printing
                        if (!MachineControl.isPrinting)
                        {
                            UIControl.home();
                        }
                        afterHotkey(args);
                        break;
                    case Keys.U:
                        UIControl.requestCancel();
                        afterHotkey(args);
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
                        afterHotkey(args);
                        break;
                    case Keys.G:
                        UIControl.setQuantity(2);
                        afterHotkey(args);
                        break;
                    case Keys.D2:
                        UIControl.setQuantity(3);
                        afterHotkey(args);
                        break;
                    case Keys.J:
                        UIControl.setQuantity(4);
                        afterHotkey(args);
                        break;
                    case Keys.K:
                        UIControl.setQuantity(5);
                        afterHotkey(args);
                        break;
                    case Keys.L:
                        UIControl.setQuantity(6);
                        afterHotkey(args);
                        break;
                    case Keys.B:
                        UIControl.setQuantity(7);
                        afterHotkey(args);
                        break;
                    case Keys.N:
                        UIControl.setQuantity(8);
                        afterHotkey(args);
                        break;
                    case Keys.D6:
                        UIControl.setQuantity(9);
                        afterHotkey(args);
                        break;
                }
            }
        }

        // This function will be run after every recognized hotkey is pressed, to
        // suppress the noise that happens when any Ctrl+Key goes unhandled.
        private void afterHotkey(KeyEventArgs args)
        {
            args.SuppressKeyPress = true;
        }

        // This function will be run after each hotkey that needs to focus the first text box
        // after the hotkey is pressed. This will delay for a small amount of time, and then focus the
        // first text box, to prevent the barcode scanner's tabs from putting us into the second text box.
        private void focusFirstTextBoxAfterDelay()
        {
            Task.Run(() =>
            {
                Thread.Sleep(30);
                UIControl.focusFirstTextBox();
            });
        }
    }
}