using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SortServer
{
    /// <summary>
    /// Tcp Server to sort random matrix via any count of clients
    /// </summary>
    public partial class SortServer : Form
    {
        /// <summary>
        /// Source random matrix
        /// </summary>
        byte[,] randomMatrix;

        /// <summary>
        /// Present tcp clients connected
        /// </summary>
        List<TcpClient> clients = new List<TcpClient>();

        /// <summary>
        /// Form constructor
        /// </summary>
        public SortServer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Bind TcpListener and initialize source data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize matrix and user interface
            numericUpDownSize_ValueChanged(null, null);
            buttonRandomize_Click(null, null);
            // Get current IP address for local machine
            Text += Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            // Create listener
            TcpListener listener = new TcpListener(IPAddress.Any, 9050);
            listener.Start();
            // Invoke recursive accept method chain
            listener.BeginAcceptTcpClient(new AsyncCallback(Callback), listener);
        }

        /// <summary>
        /// Client connected / recursive wait and accept next client
        /// </summary>
        /// <param name="result">TcpListener in AsyncState field</param>
        void Callback(IAsyncResult result)
        {
            TcpListener listener = (TcpListener)result.AsyncState;
            lock (clients)
                clients.Add(listener.EndAcceptTcpClient(result));
            listener.BeginAcceptTcpClient(new AsyncCallback(Callback), listener);
        }

        /// <summary>
        /// Check if all connections alive / remove dead clients from a "connections" list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            lock (clients)
                for (int i = 0; i < clients.Count; )
                    try
                    {
                        // try to send zero-based array to check if connection alive
                        clients[i].GetStream().Write(new byte[0], 0, 0);
                        i++;
                    }
                    catch
                    {
                        clients.RemoveAt(i);
                    }
            // Refresh count of alive connections
            textBoxCount.Text = clients.Count.ToString();
        }

        /// <summary>
        /// Sort matrix via present clients
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (clients.Count == 0)
                MessageBox.Show("No clients connected.\nAt least one client required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                lock (clients)
                {
                    // Matrix size
                    int size = (int)numericUpDownSize.Value;
                    // Result sorted matrix
                    byte[,] sortedMatrix = new byte[size, size];
                    // Count of rows sorted by clients and received
                    int rowsSent = 0;
                    for (int i = 0; i < size; i++)
                    {
                        // Index of current row (local variable for each thread)
                        int row = i;
                        // Equal count of rows to sort for each client
                        TcpClient client = clients[row % clients.Count];
                        // Sort current row
                        new Thread(new ThreadStart(delegate
                            {
                                lock (client)
                                {
                                    NetworkStream stream = client.GetStream();
                                    // Temporary buffer for current row of matrix
                                    byte[] buffer = new byte[size];
                                    // Copy source row to buffer
                                    for (int column = 0; column < size; column++)
                                        buffer[column] = randomMatrix[row, column];
                                    try
                                    {
                                        // Send row
                                        stream.Write(buffer, 0, buffer.Length);
                                        // Receive sorted row
                                        int receivedCount = stream.Read(buffer, 0, buffer.Length);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    // Copy sorted row (buffer) to sortedMatrix
                                    for (int column = 0; column < size; column++)
                                        sortedMatrix[row, column] = buffer[column];
                                }
                                // Refresh listBoxSorted only if all rows are sorted successfully
                                if (++rowsSent == size) FillListBox(listBoxSorted, sortedMatrix);
                            })).Start();
                    }
                }
        }

        /// <summary>
        /// Changing matrix size by user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDownSize_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)numericUpDownSize.Value;
            randomMatrix = new byte[size, size];
            FillListBox(listBoxRandom, randomMatrix);
        }

        /// <summary>
        /// Randomize randomMatrix and fill listBoxRandom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRandomize_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < numericUpDownSize.Value; i++)
                for (int j = 0; j < numericUpDownSize.Value; j++)
                    randomMatrix[i, j] = (byte)random.Next();
            FillListBox(listBoxRandom, randomMatrix);
        }

        /// <summary>
        /// Fill specific listBox with specific matrix
        /// </summary>
        /// <param name="listBox">Destination listBox</param>
        /// <param name="matrix">Source matrix</param>
        void FillListBox(ListBox listBox, byte[,] matrix)
        {
            BeginInvoke(new ThreadStart(delegate
                {
                    listBox.Items.Clear();
                    for (int i = 0; i < numericUpDownSize.Value; i++)
                    {
                        string line = string.Empty;
                        for (int j = 0; j < numericUpDownSize.Value; j++)
                            line += string.Format("{0}\t", matrix[i, j]);
                        listBox.Items.Add(line);
                    }
                }));
        }
    }
}
