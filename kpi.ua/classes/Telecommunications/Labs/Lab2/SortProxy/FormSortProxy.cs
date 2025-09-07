using System;
using System.Windows.Forms;
using SortProxy.SortService;

namespace SortProxy
{
    public partial class FormSortProxy : Form
    {
        /// <summary>
        /// Source matrix to sort (List of byte[])
        /// </summary>
        ArrayOfBase64Binary matrix;

        /// <summary>
        /// SortService object
        /// </summary>
        SortServiceSoapClient service = new SortServiceSoapClient();

        /// <summary>
        /// Sort matrix via WebService
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSort_Click(object sender, EventArgs e)
        {
            try
            {
                service.SortMatrix(ref matrix);
                FillListBox(listBoxSorted, matrix);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
                    buttonSort_Click(sender, e);
            }
        }
        
        /// <summary>
        /// Form constructor
        /// </summary>
        public FormSortProxy()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize matrix and user interface on Form.Load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSortProxy_Load(object sender, EventArgs e)
        {
            buttonRandomize_Click(buttonRandomize, e);
        }

        /// <summary>
        /// Randomize matrix and fill listBoxRandom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRandomize_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int size = (int)numericUpDownSize.Value;
            matrix = new SortProxy.SortService.ArrayOfBase64Binary();
            for (int i = 0; i < size; i++)
            {
                byte[] line = new byte[size];
                random.NextBytes(line);
                matrix.Add(line);
            }
            FillListBox(listBoxRandom, matrix);
            listBoxSorted.Items.Clear();
        }

        /// <summary>
        /// Fill specific listBox with specific matrix
        /// </summary>
        /// <param name="listBox">Destination listBox</param>
        /// <param name="matrix">Source matrix</param>
        void FillListBox(ListBox listBox,  ArrayOfBase64Binary matrix)
        {            
            listBox.Items.Clear();
            for (int i = 0; i < numericUpDownSize.Value; i++)
            {
                string line = string.Empty;
                for (int j = 0; j < numericUpDownSize.Value; j++)
                    line += string.Format("{0}\t", matrix[i][j]);
                listBox.Items.Add(line);
            }
        }
    }
}
