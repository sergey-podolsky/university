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
    public partial class FormWork : Form
    {
        /// <summary>
        /// Tact number (local)
        /// </summary>
        static int tact = 0;

        /// <summary>
        /// Tact property, also changes textBox text
        /// </summary>
        int Tact
        {
            get
            {
                return tact;
            }
            set
            {
                textBoxTact.Text = (tact = value).ToString();
            }
        }

        string sourceVector = FormTree.GetVector();

        /// <summary>
        /// Form constructor
        /// </summary>
        /// <param name="formMain"></param>
        public FormWork()
        {
            InitializeComponent();
            FormTree.FindAllStates();
            buttonReset_Click(null, null);
        }

        Transition lastActive;

        /// <summary>
        /// Tact parity flag
        /// </summary>
        static bool tactMode = true;

        /// <summary>
        /// Increase tact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTact_Click(object sender, EventArgs e)
        {
            if (tactMode = !tactMode)
            {
                Step1();
                try
                {
                    lastActive = FormMain.elements.OfType<Transition>().First<Transition>(new Func<Transition, bool>(FormTree.isActive));
                }
                catch
                {
                    MessageBox.Show("Мережа досягнула тупікового стану!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tactMode = !tactMode;
                }
            }
            else
            {
                Step2();
                string vector = FormTree.GetVector();
                dataGridView.Rows.Add(FormTree.StateName(vector), vector, lastActive == null ? "Вихідний стан" : lastActive.name);
            }
            Program.main.area.Invalidate();
            ++Tact;
        }

        /// <summary>
        /// Activate transititons, decrease places' markers
        /// </summary>
        public static void Step1()
        {
            List<Transition> potential = FormMain.elements.OfType<Transition>().Where<Transition>(new Func<Transition, bool>(FormTree.isPotential)).ToList<Transition>();
            if (potential.Count > 0)
            {
                Random r = new Random();
                Transition transition = potential[r.Next(0, potential.Count)];
                transition.active = true;
                foreach (Place place in transition.previous.Cast<Place>())
                    place.markers--;
            }
        }

        /// <summary>
        /// Deactivate transitions, increase places' merkers
        /// </summary>
        public static void Step2()
        {
            foreach (Transition transition in FormMain.elements.OfType<Transition>())
                if (transition.active)
                {
                    transition.active = false;
                    foreach (Place place in transition.next.Values.Cast<Place>())
                        place.markers++;
                }
        }

        /// <summary>
        /// Reset tacts and table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            Tact = 0;
            dataGridView.Rows.Clear();
            FormTree.SetVector(sourceVector);
            foreach (Transition transition in FormMain.elements.OfType<Transition>())
                transition.active = false;
            Program.main.area.Invalidate();
        }

        private void FormWork_FormClosing(object sender, FormClosingEventArgs e)
        {
            buttonReset_Click(null, null);
        }
    }
}
