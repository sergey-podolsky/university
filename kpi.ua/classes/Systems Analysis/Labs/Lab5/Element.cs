using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Petri
{
    [Serializable]
    public class Element
    {
        public Point location;
        public int number = 1;
        public string name;
        public Dictionary<List<PointF>, Element> next = new Dictionary<List<PointF>, Element>();
        public List<Element> previous = new List<Element>();

        public Element(Point point, List<Element> elementListToAdd)
        {
            location = point;
            while (elementListToAdd.Find(new Predicate<Element>(predicate1)) != null)
                number++;
            name = number.ToString();
        }

        public static Element GetByPoint(Point location, List<Element> elements)
        {
            tmp = location;
            return elements.Find(predicate2);
        }

        #region Predicates

        static Point tmp;

        bool predicate1(Element element)
        {
            return element.GetType() == this.GetType() && element.number == number;
        }

        static bool predicate2(Element element)
        {
            return element.location == tmp;
        }

        #endregion
    }
}
