﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace DUNameplateGUI
{

    // For whatever reason, I had to install Serilog by manually downloading the .nupkg files from NuGet, and then install them using
    // the Package Manager Console in VS.
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize Serilog logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "/DUNameplateGUILogs/log.txt", rollingInterval: RollingInterval.Day, retainedFileCountLimit: 7)
                .CreateLogger();

            Log.Information("DUNameplateGUI starting up");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new MainForm()); // Form1
            }
            catch (Exception ex)
            {
                Log.Fatal("Unhandled exception: {exception}", ex);
            }


            Log.Information("DUNameplateGUI shutting down");

            // Properly close out the log when the application is closed
            Log.CloseAndFlush();
        }
    }
}
