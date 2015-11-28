using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NetworkRouting
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formSend = new FormSend();
            formStatistics = new FormStatistics();
            Application.Run(new FormMain());
        }

        public static FormSend formSend;
        public static FormStatistics formStatistics;
    }
}
