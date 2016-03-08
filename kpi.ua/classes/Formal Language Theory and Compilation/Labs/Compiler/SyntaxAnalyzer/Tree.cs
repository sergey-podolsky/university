using System.Collections.Generic;
using System.Linq;

namespace SyntaxAnalyzer
{
    /// <summary>
    /// Parse Tree
    /// </summary>
    public class Tree : List<Tree>
    {
        public string Token { get; set; }
        public Tree() : base() { }
        public Tree(IEnumerable<Tree> collection) : base(collection) { }

        public override string ToString()
        {
            return Token;
        }
    }
}
