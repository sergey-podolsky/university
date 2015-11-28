using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetworkRouting
{
    public partial class FormNodeProperties : Form
    {
        Node node;

        public FormNodeProperties(Node currentNode)
        {
            InitializeComponent();
            node = currentNode;
            checkBoxNodeEnabled.Checked = node.Enabled;
            numericUpDownBufferSize.Value = (decimal)node.Buffer;
            numericUpDownDeadline.Value = (decimal)node.Deadline;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            node.Enabled = checkBoxNodeEnabled.Checked;
            node.Buffer = (int)numericUpDownBufferSize.Value;
            node.Deadline = (int)numericUpDownDeadline.Value;
            FormRouteTable.TablesRequired = true;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
