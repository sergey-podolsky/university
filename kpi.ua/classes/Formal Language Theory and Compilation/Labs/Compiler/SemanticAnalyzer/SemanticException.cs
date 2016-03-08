using System;

namespace SemanticAnalyzer
{
    /// <summary>
    /// Semantic Exception
    /// </summary>
    [Serializable]
    public class SemanticException : Exception
    {
        public SemanticException(string message) : base("Semantic error:\n" + message) { }
    }
}
