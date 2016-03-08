using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Parser
{
    /// <summary>
    /// Email structure
    /// </summary>
    public class Email
    {
        public string Name = string.Empty;
        public List<string> Domain = new List<string>(); // List of subdomains
    }

    /// <summary>
    /// Syntax exception class to identify syntax exceptions
    /// </summary>
    public class SyntaxException : Exception
    {
        public SyntaxException(string message) : base(message) { }
    }

    /// <summary>
    /// Parameter structure
    /// </summary>
    class Parameter
    {
        public string Name = string.Empty;  // Parameter name
        public string Value = string.Empty; // Parameter value
    }

    /// <summary>
    /// Section structure - the same as parameter but also stores another objects inside
    /// </summary>
    class Section : Parameter
    {
        public List<object> Items = new List<object>(); // List of objects that section contains inside
    }

    /// <summary>
    /// Application entry class
    /// </summary>
    static class Program
    {
        /// <summary>
        /// End of File
        /// </summary>
        public const char Eof = char.MaxValue;

        /// <summary>
        /// Main form
        /// </summary>
        public static FormMain form;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form = new FormMain(args));
        }
    }
}
