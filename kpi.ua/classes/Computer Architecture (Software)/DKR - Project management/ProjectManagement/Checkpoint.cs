using System;
using System.Collections.Generic;

namespace ProjectManagement
{
    public class Checkpoint
    {
        public const string template = "M";

        public HashSet<Node> Dependencies = null;
        public string ID = template;
    }
}
