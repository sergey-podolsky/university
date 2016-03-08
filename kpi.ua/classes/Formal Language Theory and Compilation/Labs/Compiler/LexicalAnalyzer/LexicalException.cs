using System;

namespace LexicalAnalyzer
{
    /// <summary>
    /// Lexical Exception
    /// </summary>
    [Serializable]
    public class LexicalException : Exception
    {
        public LexicalException(string message) : base(message) { }
        public LexicalException(string message, int line, int column)
            : this(string.Format("Lexical error at line {0}, column {1}:\n{2}", line, column, message)) { }
    }
}
