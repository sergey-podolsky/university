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
    public partial class FormTree : Form
    {
        public static Dictionary<string, List<string>> states;

        static int recursionLevel;
        const int recursionDepth = 1000;

        public FormTree()
        {
            InitializeComponent();
        }

        public static string StateName(string vector)
        {
            return "M" + Array.IndexOf(states.Keys.ToArray<string>(), vector).ToString();
        }

        public static bool FindAllStates()
        {
            string vector = GetVector();
            try
            {
                recursionLevel = 0;
                states = new Dictionary<string, List<string>>();
                FindAllStates(vector);
            }
            catch (StackOverflowException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                SetVector(vector);
                foreach (Transition transition in FormMain.elements.OfType<Transition>())
                    transition.active = false;
            }
            return recursionLevel < recursionDepth;
        }

        /// <summary>
        /// Get current vector
        /// </summary>
        /// <returns></returns>
        public static string GetVector()
        {
            List<Place> places = FormMain.elements.OfType<Place>().ToList<Place>();
            places.Sort(new Comparison<Place>(FormMatrix.sortComparison));
            string s = "[";
            for (int i = 0; i < places.Count; i++)
                s += places[i].markers.ToString() + ",";
            return s.TrimEnd(',') + "]";
        }

        /// <summary>
        /// Set vector to net
        /// </summary>
        /// <param name="vector">vector of markers for each place</param>
        public static void SetVector(string vector)
        {
            List<Place> places = FormMain.elements.OfType<Place>().ToList<Place>();
            places.Sort(new Comparison<Place>(FormMatrix.sortComparison));
            string[] array = vector.Trim(']', '[').Split(',');
            for (int i = 0; i < array.Length; i++)
                places[i].markers = Convert.ToInt32(array[i]);
        }

        /// <summary>
        /// Get transitions that are potentially can be activated
        /// </summary>
        /// <returns>List of transitions</returns>
        public static List<Transition> GetPotential()
        {
            return FormMain.elements.OfType<Transition>().Where<Transition>(new Func<Transition, bool>(isPotential)).ToList<Transition>();
        }

        /// <summary>
        /// Find and fill all states
        /// </summary>
        /// <param name="startVector">previous state vector</param>
        static void FindAllStates(string startVector)
        {
            if (recursionLevel++ > recursionDepth)
                throw new StackOverflowException("Мережа має нескінченну кількість станів!");

            foreach (Transition transition in FormMain.elements.OfType<Transition>().Where<Transition>(new Func<Transition, bool>(isActive)))
            {
                transition.active = false;
                foreach (Place place in transition.next.Values.Cast<Place>())
                    place.markers++;
            }
            string newVector = GetVector();
            try
            {
                states[startVector].Add(newVector);
            }
            catch { }
            try
            {
                states.Add(newVector, new List<string>());
            }
            catch // Vector already exists in states
            {
                return;
            }
            List<Transition> potential = GetPotential();
            foreach (Transition transition in potential)
            {
                SetVector(newVector);
                transition.active = true;
                foreach (Place place in transition.previous.Cast<Place>())
                    place.markers--;
                FindAllStates(newVector);
            }
        }

        #region Predicates

        public static bool isPotential(Transition transition)
        {
            return transition.previous.Cast<Place>().All<Place>(new Func<Place, bool>(hasMarkers));
        }

        public static bool hasMarkers(Place place)
        {
            return place.markers > 0;
        }

        public static bool isActive(Transition transition)
        {
            return transition.active;
        }

        #endregion

        private void FormTree_Load(object sender, EventArgs e)
        {
            if (FormMain.elements.Count == 0 || !FindAllStates())
            {
                Close();
                return;
            }

            // Fill treeView
            foreach (KeyValuePair<string, List<string>> pair in states)
            {
                TreeNode node = new TreeNode(StateName(pair.Key) + ": " + pair.Key);
                foreach (string v in pair.Value)
                    node.Nodes.Add(StateName(v) + ": " + v);
                treeView.Nodes.Add(node);
            }
            // Fill listBox
            string s = "";
            for (int i = 0; i < states.Count; i++)
                s += string.Format("\tM{0}", i);
            listBox.Items.Add(s);
            for (int i = 0; i < states.Count; i++)
            {
                s = string.Format("M{0}\t", i);
                for (int j = 0; j < states.Count; j++)
                    s += (states.Values.ToList<List<string>>()[i].Contains(states.Keys.ToList<string>()[j]) ? "X" : "") + "\t";
                listBox.Items.Add(s);
            }
        }
    }
}
