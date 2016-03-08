using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TaskScheduler
{
    static class ProgramEntryPoint
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            TaskScheduler.Properties.Settings.Default.Save();
        }
    }
}
