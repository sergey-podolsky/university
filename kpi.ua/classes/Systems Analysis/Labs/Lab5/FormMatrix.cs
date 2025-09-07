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
    public partial class FormMatrix : Form
    {
        public FormMatrix()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show matrixes on FormLoad event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMatrix_Load(object sender, EventArgs e)
        {
            // All places available
            List<Place> places = FormMain.elements.OfType<Place>().ToList<Place>();
            places.Sort(new Comparison<Place>(sortComparison));
            // All transitions available
            List<Transition> transitions = FormMain.elements.OfType<Transition>().ToList<Transition>();
            transitions.Sort(new Comparison<Transition>(sortComparison));

            // Header lines
            string s = string.Empty; ;
            for (int i = 0; i < places.Count; i++)
                    s += places[i].name + "\t";
            listBoxDi.Items.Add("DI\t" + s);
            listBoxDq.Items.Add("DQ\t" + s);
            listBoxM.Items.Add("Pi\t" + s);
            
            // Fill matrixes
            for (int t = 0; t < transitions.Count; t++)
            {
                transition = transitions[t];
                string sDI = transition.name + "\t", sDQ = sDI;
                for (int p = 0; p < places.Count; p++)
                {
                    place = places[p];
                    sDI += transitions[t].previous.Count<Element>(new Func<Element, bool>(predicate1)).ToString() + "\t";
                    sDQ += places[p].previous.Count<Element>(new Func<Element, bool>(predicate2)).ToString() + "\t";
                }
                listBoxDi.Items.Add(sDI);
                listBoxDq.Items.Add(sDQ);
            }

            // Fill markers table
            s = "Mi\t";
            for (int p = 0; p < places.Count; p++)
                s += places[p].markers.ToString() + "\t";
            listBoxM.Items.Add(s);
        }

        #region Predicates
        Element place;
        Element transition;

        bool predicate1(Element element)
        {
            return element == place;
        }

        bool predicate2(Element element)
        {
            return element == transition;
        }

        public static int sortComparison(Element el1, Element el2)
        {
            return el1.number > el2.number ? 0 : 1;
        }

        #endregion
    }
}
