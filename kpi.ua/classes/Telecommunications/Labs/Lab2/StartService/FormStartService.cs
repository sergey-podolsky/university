using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StartService
{
    public partial class FormStartService : Form
    {
        public FormStartService()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
                textBoxWebServer.Text,
                String.Format("/port:{0} /path:\"{1}\" /vpath:\"{2}\"",
                textBoxPort.Text,
                textBoxPhysicalPath.Text,
                textBoxVirtualPath.Text
                ));
        }

        private void buttonBrowseServer_Click(object sender, EventArgs e)
        {
            if (openFileDialogServer.ShowDialog() == DialogResult.OK)
                textBoxWebServer.Text = openFileDialogServer.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogPhysicalPath.ShowDialog() == DialogResult.OK)
                textBoxPhysicalPath.Text = folderBrowserDialogPhysicalPath.SelectedPath;
        }
    }
}
