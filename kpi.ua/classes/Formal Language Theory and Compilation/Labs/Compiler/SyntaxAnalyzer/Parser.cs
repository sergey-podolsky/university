using System;
using System.Collections.Generic;
using System.Linq;
using RelationsComputing;

namespace SyntaxAnalyzer
{
    /// <summary>
    /// Simple precedence parser
    /// </summary>
    /// <see href="http://en.wikipedia.org/wiki/Simple_precedence_parser"/>
    public class Parser
    {
        /// <summary>
        /// Wirth-Weber precedence relationship table
        /// </summary>
        RelationTable relationTable;

        /// <summary>
        /// Create syntax analyser instance
        /// </summary>
        /// <param name="relationTable">Wirth-Weber precedence relationship table</param>
        public Parser(RelationTable relationTable)
        {
            this.relationTable = relationTable;
        }
       
        /// <summary>
        /// Parse input
        /// </summary>
        /// <param name="input">A list of tuples.
        /// <para>Each tuple is defined by two items.</para>
        /// <para>Item1: symbol code assigned by scanner;</para>
        /// <para>Item2: symbol;</para></param>
        public Tree Parse(List<Tuple<int, string>> input)
        {
            /* Start with a stack with only the starting marker */
            var stack = new List<Tree> { new Tree() { Token = RelationTable.limitMarker } };

            /* Start with the string being parsed (input) ended with an ending marker */
            input.Add(Tuple.Create(-1, RelationTable.limitMarker));

            /* Stack of pivots offsets indices
             * Each element is an index of such token B that satisfies a condition "A < B",
             * where A is a previous token before B
             */
            var pivotsOffsets = new Stack<int>();

            /* While not (Stack equals to $S and Input equals to $) (S = Initial symbol of the grammar) */
            while (stack.Last().Token != "<signal-program>" || input.First().Item2 != RelationTable.limitMarker)
            {
                /* Search in the table the relationship between Top(stack) and NextToken(Input) */
                switch (relationTable[stack.Last().Token, input.First().Item2])
                {
                    case Relation.Lower:
                        /* Push relationship to pivots offsets stack */
                        pivotsOffsets.Push(stack.Count);
                        goto case Relation.Equal;
                    case Relation.Equal:
                        /* Push next token to stack */
                        stack.Add(new Tree { Token = input.First().Item2 });
                        /* Remove remove next token from input */
                        input.RemoveAt(0);
                        break;
                    case Relation.Greater:
                        /* Search production to reduce */
                        var reduced = Reduce(stack.Skip(pivotsOffsets.Peek()));
                        /* Remove pivot from stack */
                        stack = stack.Take(pivotsOffsets.Peek()).ToList();
                        /* Pop index from pivots offsets stack if the relationship between the Non-terminal
                         * from the production and first symbol in the stack (Starting from top) is not equal to "<"
                         */
                        if (relationTable[stack.Last().Token, reduced.Token] == Relation.Equal)
                            pivotsOffsets.Pop();
                        /* Push reduced non-terminal to stack instead of pivot */
                        stack.Add(reduced);
                        break;
                    default:
                        throw new SyntaxException("unexpected symbol '" + input.First().Item2 + "'");
                }
            }

            return stack.Last();
        }

        /// <summary>
        /// Serch production to reduce in all productions
        /// </summary>
        /// <param name="pivot">List of tokens to reduce</param>
        /// <returns>Reduced non-terminal</returns>
        Tree Reduce(IEnumerable<Tree> pivot)
        {
            foreach (var nonTerminal in RelationTable.NonTerminals)
                foreach (var production in relationTable.Productions(nonTerminal))
                    if (Enumerable.SequenceEqual(from tree in pivot select tree.Token, production))
                        return new Tree(pivot) { Token = nonTerminal };
            throw new SyntaxException("can not reduce the following code\n" + pivot.Aggregate("", (code, tree) => code + tree + "\n"));
        }
    }
}
