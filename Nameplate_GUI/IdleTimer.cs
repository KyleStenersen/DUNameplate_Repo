using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using Serilog;

namespace DUNameplateGUI
{
    // This class takes care of the idle timer of the program, it will automatically reset
    // the jig position after a period of inactivity (customizable in the settings) is over.
    internal static class IdleTimer
    {
        public static Timer idleTimer;

        // This boolean controls whether this feature is enabled or not, which is a setting
        // in the settings menu
        public static Boolean isEnabled = true;

        public static void Initialize()
        {
            idleTimer = new Timer();
            idleTimer.Interval = Properties.Settings.Default.idleTimeBeforeReset * 1000; // the setting is in seconds, while Interval is in milliseconds
            idleTimer.AutoReset = false;
            idleTimer.Elapsed += new ElapsedEventHandler(TimerEnded);

            isEnabled = Properties.Settings.Default.resetJigAfterIdle;
        }

        // This function is called when the save/close settings button is pressed in the settings menu
        public static void RefreshSettings()
        {
            idleTimer.Interval = Properties.Settings.Default.idleTimeBeforeReset * 1000; // the setting is in seconds, while Interval is in milliseconds
            isEnabled = Properties.Settings.Default.resetJigAfterIdle;
        }

        // The timer has elapsed, which means there has been no user input for the last amount of time
        // set as the interval for the idleTimer, so now we will set the jig position back to zero.
        private static void TimerEnded(Object sender, EventArgs args)
        {
            // Another check to make absolutely sure that we don't mess up the jig position while it is printing
            if (!MachineControl.isPrinting)
            {
                Log.Debug("Timer's up, machine is not printing, resetting jig position");
                Jig.Position = 0;
            }
        }

        // This function will be run at least once a second, or more depending on how often WinForms decides to trigger
        // the idle event.
        public static void OnWinFormsIdle(Object sender, EventArgs args)
        {
            // If the machine is not printing, and the idleTimer is not running right now, start the timer.
            if (!MachineControl.isPrinting && !idleTimer.Enabled && isEnabled)
            {
                //Console.WriteLine("Timer started");
                idleTimer.Start();
            }
        }
    }

    // Here is our filter for detecting user input messages and stopping the timer if it detects any user input.
    // See here: https://stackoverflow.com/questions/36430850/how-to-detect-a-winforms-app-has-been-idle-for-certain-amount-of-time
    // and here: https://stackoverflow.com/questions/13210142/how-do-i-determine-idle-time-in-my-c-sharp-application
    // for more about why and how this code works.
    internal class IdleMessageFilter : IMessageFilter
    {
        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;
        const int WM_MOUSEMOVE = 0x0200;
        const int WM_LBUTTONDOWN = 0x0201;
        const int WM_LBUTTONUP = 0x0202;
        const int WM_RBUTTONDOWN = 0x0204;
        const int WM_RBUTTONUP = 0x0205;

        // Our filter here doesn't actually do any filtering, it's just for monitoring inputs, that's why it returns
        // false every time and lets every message through.
        public bool PreFilterMessage(ref Message m)
        {
            // If it's user input, we want to stop the timer.
            if (isUserInput(m))
            {
                //Console.WriteLine("User input detected, stopping timer");
                IdleTimer.idleTimer.Stop();
            }

            return false; // We want to allow this message to pass through to the next control
        }

        private bool isUserInput(Message m)
        {
            if (m.Msg == WM_KEYDOWN ||
                    m.Msg == WM_KEYUP ||
                    m.Msg == WM_MOUSEMOVE ||
                    m.Msg == WM_LBUTTONDOWN ||
                    m.Msg == WM_LBUTTONUP ||
                    m.Msg == WM_RBUTTONDOWN ||
                    m.Msg == WM_RBUTTONUP
                )
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
