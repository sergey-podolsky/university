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
    public partial class FormMarkov : Form
    {
        static Dictionary<string, List<string>> states;

        public FormMarkov()
        {
            InitializeComponent();
        }

        static string tmp;

        static bool comparer(string s)
        {
            return s == tmp;
        }

        void FindAllStates()
        {
            Random r = new Random();
            string prevVector = FormTree.GetVector(), sourceVector = prevVector;
            for (int tact = 0; tact < numericUpDown.Value; tact++)
            {
                List<Transition> potential = FormTree.GetPotential();
                if (potential.Count == 0)
                {
                    MessageBox.Show("Мережа перейшла в тупіковий стан після такту №" + tact.ToString(), "Стан", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                Transition transition = potential[r.Next(potential.Count)];

                foreach (Place place in transition.previous.Cast<Place>())
                    place.markers--;
                foreach (Place place in transition.next.Values.Cast<Place>())
                    place.markers++;

                string newVector = FormTree.GetVector();
                states[prevVector].Add(newVector);
                prevVector = newVector;
            }
            FormTree.SetVector(sourceVector);
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (FormMain.elements.Count == 0 || !FormTree.FindAllStates())
                return;

            states = new Dictionary<string, List<string>>();

            // New empty list of all states
            foreach (KeyValuePair<string, List<string>> pair in FormTree.states)
                states.Add(pair.Key, new List<string>());

            FindAllStates();

            // Markov graph matrix
            double[,] matrix = new double[FormTree.states.Count, FormTree.states.Count];

            // Fill matrix
            for (int j = 0; j < FormTree.states.Count; j++)
            {
                tmp = FormTree.states.Keys.ToList<string>()[j];
                for (int i = 0; i < FormTree.states.Count; i++)
                    matrix[i, j] = states.Values.ToList<List<string>>()[i].Count<string>(new Func<string, bool>(comparer));
            }

            // Divide each row by sum
            for (int i = 0; i < FormTree.states.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < FormTree.states.Count; j++)
                    sum += matrix[i, j];
                if (sum != 0)
                    for (int j = 0; j < FormTree.states.Count; j++)
                        matrix[i, j] /= sum;
            }

            // Fill listBox
            listBox.Items.Clear();
            string s = "";
            for (int i = 0; i < FormTree.states.Count; i++)
                s += string.Format("\tM{0}", i);
            listBox.Items.Add(s);
            for (int i = 0; i < FormTree.states.Count; i++)
            {
                s = string.Format("M{0}\t", i);
                for (int j = 0; j < FormTree.states.Count; j++)
                    s += string.Format("{0}\t", Math.Round(matrix[i, j], 3));
                listBox.Items.Add(s);
            }
        }
    }
}
