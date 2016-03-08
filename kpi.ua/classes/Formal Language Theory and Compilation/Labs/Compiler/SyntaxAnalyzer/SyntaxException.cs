using System;

namespace SyntaxAnalyzer
{
    /// <summary>
    /// Syntax Exception
    /// </summary>
    [Serializable]
    public class SyntaxException : Exception
    {
        public SyntaxException(string message) : base("Syntax error:\n" + message) { }
    }
}
