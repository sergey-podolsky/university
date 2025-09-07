using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Petri
{  
    [Serializable]
    public class Place : Element
    {
        public int markers = 0;

        public Place(Point point, List<Element> elementListToAdd)
            : base(point, elementListToAdd)
        {
            name = "P" + name; ;
        }
    }
}
