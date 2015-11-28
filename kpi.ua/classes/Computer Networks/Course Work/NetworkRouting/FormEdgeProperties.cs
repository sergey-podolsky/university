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
    public partial class FormEdgeProperties : Form
    {
        Edge edge;

        public FormEdgeProperties(Edge currentEdge)
        {
            InitializeComponent();
            edge = currentEdge;
            numericUpDownWeight.Value = (decimal)edge.Weight;
            checkBoxEdgeEnabled.Checked = edge.Enabled;
            radioButtonHalf.Checked = !(radioButtonFull.Checked = edge.FullDuplex);
            numericUpDownErrorRate.Value = (decimal)edge.ErrorRate;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            edge.Weight = (double)numericUpDownWeight.Value;
            edge.Enabled = checkBoxEdgeEnabled.Checked;
            edge.FullDuplex = radioButtonFull.Checked;
            edge.ErrorRate = (double)numericUpDownErrorRate.Value;
            FormRouteTable.TablesRequired = true;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
