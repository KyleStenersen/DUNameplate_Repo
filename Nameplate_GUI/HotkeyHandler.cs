using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DUNameplateGUI
{
    internal class HotkeyHandler
    {
        Form MainForm;

        private Boolean hotkeyPressed = false;

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
                        UIControl.addCurrentTagToQueue(UIControl.QueuePosition.BottomOfQueue);
                        afterHotkey(args);
                        break;
                    case Keys.E:
                        UIControl.clearTag();
                        afterHotkey(args);
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
                    case Keys.I:
                        UIControl.addCurrentTagToQueue(UIControl.QueuePosition.TopOfQueue);
                        afterHotkey(args);
                        break;
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
                    // Ctrl+Minus is set as the prefix on the barcode scanner, so this code runs
                    // before the rest of the keypresses from the scanner
                    case Keys.OemMinus:
                        hotkeyPressed = false;
                        break;
                    // Ctrl+] is set as the suffix on the barcode scanner, so this code runs after
                    // the barcode scanner has sent all of its keypresses
                    case Keys.OemCloseBrackets:
                        // If no hotkeys were pressed, then this barcode must just be text. So we want to
                        // tab to the next textbox.
                        if (!hotkeyPressed)
                        {
                            tabAfterDelay();
                        }
                        break;

                }
            }
        }

        // This function will be run after every recognized hotkey is pressed, to
        // suppress the noise that happens when any Ctrl+Key goes unhandled.
        // It also doubles as a function to set hotkeyPressed to true.
        private void afterHotkey(KeyEventArgs args)
        {
            args.SuppressKeyPress = true;
            hotkeyPressed = true;
        }

        // For some odd reason, we cannot tab immediately after the barcode scanner is done sending inputs. This is a
        // workaround to tab after a small delay, to prevent that issue.
        private void tabAfterDelay()
        {
            Task.Run(() =>
            {
                Thread.Sleep(5);
                SendKeys.SendWait("{TAB}");
            });
        }
    }
}