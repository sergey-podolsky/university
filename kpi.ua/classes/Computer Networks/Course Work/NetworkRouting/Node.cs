using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace NetworkRouting
{
    [Serializable]
    public class Node
    {
        public static readonly Bitmap icon1 = NetworkRouting.Properties.Resources.Computer1;
        public static readonly Bitmap icon2 = NetworkRouting.Properties.Resources.Computer2;

        public bool Enabled = true;

        public int Buffer = 1024 * 1024;

        public int Deadline = 1024;

        public Point Location;

        public Point Center
        {
            get
            {
                return new Point(Location.X + icon1.Width / 2, Location.Y + icon1.Height / 2);
            }
            set
            {
                Location = new Point(value.X - icon1.Width / 2, value.Y - icon1.Height / 2);
            }
        }

        public int ID
        {
            get
            {
                return FormMain.nodes.IndexOf(this);
            }
        }

        public bool Contains(Point point)
        {
            return new Rectangle(Location, icon1.Size).Contains(point);
        }

        public Dictionary<Node, List<Node>> routeTable;

        public List<Packet> packets = new List<Packet>();

        public void SendPackets()
        {
            var packetsToRemove = new List<Packet>();
            foreach (Packet packet in packets)
            {
                if (packet.Target == this)
                {
                    Program.formStatistics.PacketDelivered(packet);
                    packetsToRemove.Add(packet);
                }
                // Deadline is reached
                else if (FormMain.Tact - packet.ReceiveTime > Deadline)
                    packetsToRemove.Add(packet);
                else
                // Packet is datagram
                if (packet.mode == Mode.Datagram)
                {
                    foreach (var nextNode in routeTable[packet.Target])
                        if (nextNode.Enabled && nextNode != packet.Source && nextNode.Buffer > nextNode.packets.Count * Packet.Size)
                        {
                            var nextEdge = FormMain.edges.FirstOrDefault(edge => edge.nodes.Contains(this) && edge.nodes.Contains(nextNode));
                            if (nextEdge != null && nextEdge.Enabled)
                            {
                                var nextPort = nextEdge.nodes.ToList().IndexOf(this);
                                if (!(nextEdge.packets[nextPort] != null || nextEdge.packets[nextPort ^ 1] != null && !nextEdge.FullDuplex))
                                {
                                    packetsToRemove.Add(nextEdge.packets[nextPort] = packet);
                                    break;
                                }
                            }
                        }
                }
                // Virtual channel
                else
                    if (packet.VirtualChannel.Count > 0)
                    {
                        // Try to send packet
                        if (packet.VirtualChannel.First().Enabled)
                        {
                            var nextEdge = FormMain.edges.FirstOrDefault(edge => edge.nodes.Contains(this) && edge.nodes.Contains(packet.VirtualChannel.First()));
                            if (nextEdge == null)
                            {
                                packetsToRemove.Add(packet);
                                continue;
                            }
                            if (nextEdge.Enabled)
                            {
                                var nextPort = nextEdge.nodes.ToList().IndexOf(this);
                                if (!(nextEdge.packets[nextPort] != null || nextEdge.packets[nextPort ^ 1] != null && !nextEdge.FullDuplex))
                                {
                                    packetsToRemove.Add(nextEdge.packets[nextPort] = packet);
                                    packet.VirtualChannel.Dequeue();
                                }
                            }
                        }
                    }
                    else
                    {
                        // Bind virtual channel
                        Node nextNode = this;
                        do
                        {
                            nextNode = nextNode.routeTable[packet.Target].FirstOrDefault(node => node.Enabled && FormMain.edges.First(edge => edge.nodes.Contains(nextNode) && edge.nodes.Contains(node)).Enabled);
                            if (nextNode != null && !packet.VirtualChannel.Contains(nextNode)) packet.VirtualChannel.Enqueue(nextNode);
                            else
                            {
                                packetsToRemove.Add(packet);
                                break;
                            }
                        }
                        while (nextNode != packet.Target);
                    }
            }
            // Remove processed packets from buffer
            packets = packets.Except(packetsToRemove).ToList();
        }
    }
}
