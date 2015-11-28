using System;
using System.Windows.Forms;

namespace GeneticClusteringAlgorithm
{
    static class Program
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
            GeneticClusteringAlgorithm.Properties.Settings.Default.Save();
        }
    }
}
