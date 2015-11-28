using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace NetworkRouting
{
    [Serializable]
    public class Edge
    {
        public static readonly Random random = new Random();
        public static readonly double[] weights = { 1, 3, 5, 6, 8, 10 };

        public bool Enabled = true;
        public bool FullDuplex = true;
        public double Weight = 5;
        public double ErrorRate = 0;
        public Node[] nodes;
        public Packet[] packets = new Packet[2];

        public Point Center
        {
            get
            {
                return new Point((nodes[0].Center.X + nodes[1].Center.X) / 2, (nodes[0].Center.Y + nodes[1].Center.Y) / 2);
            }
        }

        const int clickDistance = 10;

        public bool Contains(Point point)
        {
            Point p0 = nodes[0].Center, p1 = nodes[1].Center;
            int dy = p0.Y - p1.Y, dx = p0.X - p1.X;
            return Rectangle.FromLTRB(Math.Min(p0.X, p1.X), Math.Min(p0.Y, p1.Y), Math.Max(p0.X, p1.X), Math.Max(p0.Y, p1.Y)).Contains(point)
                && Math.Abs(dy * point.X - dx * point.Y + p0.X * p1.Y - p1.X * p0.Y) / Math.Sqrt(dx * dx + dy * dy) < clickDistance;
        }

        public void SendPackets()
        {
            for (var i = 0; i < 2; i++)
                if (packets[i] != null)
                    if ((packets[i].Progress += 0.2 / Weight) >= 1)
                    {
                        // Increase service message count
                        packets[i].ServiceMessages++;
                        if (ErrorRate > random.NextDouble())
                        {
                            // Transimission error
                            packets[i].Progress = 0;
                            if (packets[i].mode == Mode.VirtualChannel)
                            {
                                packets[i].VirtualChannel.Clear();
                                packets[i].Source.packets.Add(packets[i]);
                                packets[i] = null;
                            }
                        }
                        else
                        {
                            nodes[i ^ 1].packets.Add(packets[i]);
                            packets[i].Progress = 0;
                            packets[i].ReceiveTime = FormMain.Tact;
                            packets[i] = null;
                        }
                    }
        }
    }
}
