using System.Collections.Generic;
using System.Linq;

namespace RelationsComputing
{
    /// <summary>
    /// Wirth-Weber precedence relationship computing algorithm
    /// </summary>
    /// <see href="http://en.wikipedia.org/wiki/Wirth-Weber_precedence_relationship"/>
    /// <see href="http://en.wikipedia.org/wiki/Simple_precedence_grammar"/>
    public class RelationTable : Table<string, Relation>
    {
        public const string limitMarker = "$";

        public static readonly string[] NonTerminals =
        { 
            "<signal-program>",
            "<program>",
            "<block>",
            "<statements-list>",
            "<statements>",
            "<statement>",
            "<loop-declaration>",
            "<expression>",
            "<summands-list>",
            "<summand>",
            "<identifier>",
            "<unsigned-integer>"
        };

        /// <summary>
        /// Get all productions of specified non-terminal
        /// </summary>
        /// <param name="symbol">Non-terminal</param>
        /// <returns>Set of productions</returns>
        public IEnumerable<string[]> Productions(string symbol)
        {
            switch (symbol)
            {
                case "<signal-program>":
                    yield return new[] { "<program>" };
                    break;
                case "<program>":
                    yield return new[] { "PROGRAM", "<identifier>", ";", "<block>", "." };
                    break;
                case "<block>":
                    yield return new[] { "BEGIN", "<statements-list>", "END" };
                    yield return new[] { "BEGIN", "END" };
                    break;
                case "<statements-list>":
                    yield return new[] { "<statements>" };
                    break;
                case "<statements>":
                    yield return new[] { "<statement>" };
                    yield return new[] { "<statement>", "<statements>" };
                    break;
                case "<statement>":
                    yield return new[] { "LOOP", "<statements-list>", "ENDLOOP", ";" };
                    yield return new[] { "LOOP", "ENDLOOP", ";" };
                    yield return new[] { "FOR", "<identifier>", ":=", "<loop-declaration>", "ENDFOR", ";" };
                    break;
                case "<loop-declaration>":
                    yield return new[] { "<expression>", "TO", "<expression>", "DO", "<statements-list>" };
                    yield return new[] { "<expression>", "TO", "<expression>", "DO" };
                    break;
                case "<expression>":
                    yield return new[] { "<summands-list>" };
                    yield return new[] { "-", "<summands-list>" };
                    break;
                case "<summands-list>":
                    yield return new[] { "<summand>" };
                    yield return new[] { "<summand>", "-", "<summands-list>" };
                    yield return new[] { "<summand>", "+", "<summands-list>" };
                    break;
                case "<summand>":
                    yield return new[] { "<identifier>" };
                    yield return new[] { "<unsigned-integer>" };
                    break;
                case "<identifier>":
                    foreach (var identifier in identifiers)
                        yield return new[] { identifier };
                    break;
                case "<unsigned-integer>":
                    foreach (var constant in constants)
                        yield return new[] { constant };
                    break;
            }
        }

        IEnumerable<string> identifiers, constants;

        public RelationTable(IEnumerable<string> identifiers, IEnumerable<string> constants)
        {
            /* List of user-defined identifiers and constants */
            this.identifiers = identifiers;
            this.constants = constants;

            /* Compute the Wirth-Weber precedence relationship table */
            foreach (var nonTerminal in NonTerminals)
                foreach (var production in Productions(nonTerminal))
                    for (var i = 0; i < production.Length - 1; i++)
                    {
                        /* = */
                        this[production[i], production[i + 1]] = Relation.Equal;

                        /* < */
                        ComputeLowerRelations(production[i], production[i + 1], Enumerable.Empty<string>());

                        /* > */
                        ComputeGreaterRelations(production[i], production[i + 1], Enumerable.Empty<string>());
                    }

            /* Include limit marker to the Wirth-Weber precedence relationship table */
            ComputeLowerRelations(limitMarker, "<signal-program>", Enumerable.Empty<string>());
            ComputeGreaterRelations("<signal-program>", limitMarker, Enumerable.Empty<string>());
        }

        void ComputeLowerRelations(string left, string right, IEnumerable<string> used)
        {
            if (!used.Contains(right))
                foreach (var production in Productions(right))
                {
                    this[left, production.First()] = Relation.Lower;
                    ComputeLowerRelations(left, production.First(), used.Concat(new[] { right }));
                }
        }

        void ComputeGreaterRelations(string left, string right, IEnumerable<string> used)
        {
            if (!used.Contains(left))
                foreach (var production in Productions(left))
                {
                    ComputeGreaterDeepRight(production.Last(), right, Enumerable.Empty<string>());
                    ComputeGreaterRelations(production.Last(), right, used.Concat(new[] { left }));
                }
        }

        void ComputeGreaterDeepRight(string left, string right, IEnumerable<string> used)
        {
            if (!used.Contains(right))
            {
                this[left, right] = Relation.Greater;
                foreach (var production in Productions(right))
                    ComputeGreaterDeepRight(left, production.First(), used.Concat(new[] { right }));
            }
        }
    }
}
