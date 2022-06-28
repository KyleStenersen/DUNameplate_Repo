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
            if (args.Modifiers == (Keys.Control | Keys.Alt))
            {
                if (args.KeyCode == Keys.P) 
                {
                    // Right now this just prints this line to the console, but the next step is to actually print when
                    // this key combo is pressed.
                    // The main code that controls the machine should be moved from Form1 to a new MachineControl
                    // class, or something similar, so that those functions can be called from elsewhere.
                    Console.WriteLine("Ctrl+ALt+P has been pressed");
                    args.Handled = true;
                }
            }
        }
    }
}