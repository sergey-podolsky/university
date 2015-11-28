using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NetworkRouting
{
    public partial class FormStatistics : Form
    {
        const int AckPerPackets = 4;

        List<Packet> packets = new List<Packet>();

        public FormStatistics()
        {
            InitializeComponent();
        }

        private void clearStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
        }

        public void PacketDelivered(Packet packet)
        {
            packets.Add(packet);
            if (packets.Count(p => p.MessageID == packet.MessageID) == packet.partCount)
            {
                dataGridView.Rows.Add(
                    packet.MessageID,
                    packet.MessageSize,
                    packet.Source.ID, packet.Target.ID,
                    packet.mode,
                    FormMain.Tact - packet.SendTime,
                    packet.partCount,
                    packet.mode == Mode.Datagram ? (
                    from p in packets where p.MessageID == packet.MessageID select p.ServiceMessages).Sum() : 
                    /*packet.ServiceMessages * */(4 + (int)Math.Ceiling((double)packet.partCount / AckPerPackets)));
                packets.RemoveAll(p => p.MessageID == packet.MessageID);
            }
        }

        private void FormStatistics_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
