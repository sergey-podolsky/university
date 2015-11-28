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
    public partial class FormSend : Form
    {
        public static int MessageID = 0;

        public FormSend()
        {
            InitializeComponent();

            dataGridView1.Rows.Add(4096, "Datagram", 0, 11); /////////temp
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var packets = new List<Packet>();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                    if (!row.IsNewRow)
                    {
                        var packetCount = (int)Math.Ceiling(Convert.ToDouble(row.Cells[0].Value)/ Packet.Size);
                        for (var i = 0; i < packetCount; i++)
                            packets.Add(new Packet
                            {
                                mode = (Mode)Enum.Parse(typeof(Mode), row.Cells[1].Value.ToString().Replace(" ", "")),
                                Source = FormMain.nodes[Convert.ToInt32(row.Cells[2].Value)],
                                Target = FormMain.nodes[Convert.ToInt32(row.Cells[3].Value)],
                                part = i,
                                MessageID = MessageID,
                                MessageSize = Convert.ToInt32(row.Cells[0].Value),
                                SendTime = FormMain.Tact,
                                ReceiveTime = FormMain.Tact,
                                partCount = packetCount,
                            });
                        MessageID++;
                    }
                foreach (var packet in packets)
                    packet.Source.packets.Add(packet);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void FormSend_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
