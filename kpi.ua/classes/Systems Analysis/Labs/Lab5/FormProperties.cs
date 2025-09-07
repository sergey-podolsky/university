using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Petri
{
    public partial class FormProperties : Form
    {
        Place place;

        public FormProperties(Place p)
        {
            InitializeComponent();
            place = p;
            numericUpDownMarkers.Value = place.markers;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            place.markers = (int)numericUpDownMarkers.Value;
            Close();
        }
    }
}
