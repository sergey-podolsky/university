using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Petri
{
    static class Program
    {
        public static FormMain main;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(main = new FormMain());
        }
    }
}
