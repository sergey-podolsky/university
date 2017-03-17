using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Create a new thread which controls current process count
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
               {
                   // Periodically check current process count until application will be closed
                   for (; ; Thread.Sleep(10))
                   {
                       // Get process count with a name "Calc" and not exited yet
                       var processes = Process.GetProcessesByName("Calc").Where(p => !p.HasExited);
                       // Kill an amount of proccess above 4
                       for (int i = 0; i < processes.Count() - 4; i++)
                           processes.ElementAt(i).Kill();
                   }
               }
                   ));
        }
    }
}
