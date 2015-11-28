using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace NetworkRouting
{
    [Serializable]
    public class Packet
    {
        public static readonly Bitmap icon = NetworkRouting.Properties.Resources.Mail_32x32;
        public const int Size = 1024;

        public Node Source;
        public Node Target;
        public Queue<Node> VirtualChannel = new Queue<Node>();
        public int ServiceMessages = 0;
        public Mode mode;

        public int MessageID;
        public int MessageSize;
        public int part;
        public int partCount;
        public int SendTime;
        public int ReceiveTime;

        public double Progress;
    }

    public enum Mode
    {
        VirtualChannel,
        Datagram
    }
}
