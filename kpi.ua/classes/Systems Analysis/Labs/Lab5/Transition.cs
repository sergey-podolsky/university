using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Petri
{        
    [Serializable]
    public class Transition : Element
    {
        public bool active = false;

        public Transition(Point point, List<Element> elementListToAdd)
            : base(point, elementListToAdd)
        {
            name = "T" + name;
        }
    }
}
