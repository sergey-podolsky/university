using System;
using System.Collections.Generic;

namespace ProjectManagement
{
    public class Node
    {
        public string ID { get; private set; }
        public int Days { get; set; }
        public readonly HashSet<Node> Dependencies = new HashSet<Node>();
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool HasStarted = false;
        public Checkpoint checkpoint = null;

        public Node(string id, int days)
        {
            if (id == null || id == string.Empty)
                throw new Exception("Task must have an identifier");
            string upper = id.ToUpper();
            int o;
            if (upper == "START" || upper == "FINISH" || upper[0] == 'M' && int.TryParse(upper.Substring(1, upper.Length - 1), out o))
                throw new Exception("\"Start\", \"Finish\" and \"Mi\" are reserved names for checkpoints");
            if (days < 1)
                throw new Exception("Task \"" + id + "\" must have count of days > 0");
            ID = id;
            Days = days;
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public static bool operator ==(Node node1, Node node2)
        {
            return node1.Equals(node2);
        }

        public static bool operator !=(Node node1, Node node2)
        {
            return !node1.Equals(node2);
        }
    }
}
