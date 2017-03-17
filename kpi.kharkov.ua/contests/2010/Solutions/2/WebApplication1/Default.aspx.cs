using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get process list on a server machine
            foreach (var process in System.Diagnostics.Process.GetProcesses())
                // Add each process name to ListBox on the Web Page
                ListBox1.Items.Add(process.ProcessName);
        }
    }
}
