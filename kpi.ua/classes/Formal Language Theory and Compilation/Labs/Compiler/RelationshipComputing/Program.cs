using System;
using System.Linq;

namespace RelationsComputing
{
    static class Program
    {
        static void Main(string[] args)
        {
            var relationTable = new RelationTable(Enumerable.Empty<string>(), Enumerable.Empty<string>());
            foreach (var pair in relationTable)
                Console.WriteLine("{0} {1} {2}", pair.Key.Item1, pair.Value.Sign(), pair.Key.Item2);
        }

        public static string Sign(this Relation relation)
        {
            switch (relation)
            {
                case Relation.None: return "?";
                case Relation.Equal: return "=";
                case Relation.Lower: return "<";
                case Relation.Greater: return ">";
                default: return "???";
            }
        }
    }
}
