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
                    case Keys.P:
                        UIControl.printQueue();
                        break;
                    case Keys.A:
                        UIControl.addCurrentTagToQueue();
                        break;
                    case Keys.C:
                        UIControl.clearTag();
                        break;
                    case Keys.Q:
                        UIControl.clearQueue();
                        break;
                    case Keys.R:
                        UIControl.signalReloaded();
                        break;

                }
            }
        }
    }
}