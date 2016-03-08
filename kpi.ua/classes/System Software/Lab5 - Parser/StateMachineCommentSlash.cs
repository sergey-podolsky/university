using System;
using System.Collections.Generic;

namespace Parser
{
    class StateMachineCommentSlash
    {    
        public enum Symbol
        {
            Asterisk,   // *
            Slash,      // /
            Eof,        // End of file
            Other       // Other symbol
        }

        public enum State
        {
            Comment,    // Comment chars
            Asterisk,   // Current symbol is "*"
            End,        // Parsing done
            Error       // Error occured
        }

        #region Actions
        public delegate void Method(char c, ref string comment);

        static void AddChar(char c, ref string comment)
        {
            comment += c;
        }

        static void AddAsterAndChr(char c, ref string comment)
        {
            comment += '*' + c;
        }

        static void Error(char c, ref string comment)
        {
            throw new SyntaxException("Parameter value error:\nunexpected end of file - \"*\\\" is missed");
        }
        #endregion

        static readonly State[,] TransitionTable =
        { // Comment            Asterisk        End         Error
            {State.Asterisk,    State.Asterisk, State.End,  State.Error}, // Asterisk
            {State.Comment,     State.End,      State.End,  State.Error}, // Slash
            {State.Error,       State.Error,    State.End,  State.Error}, // Eof
            {State.Comment,     State.Comment,  State.End,  State.Error}  // Other
        };

        static readonly Method[,] ActionTable =
        { // Comment            Asterisk        End         Error
            {null,              AddChar,        null,       Error}, // Asterisk
            {AddChar,           null,           null,       Error}, // Slash
            {Error,             Error,          null,       Error}, // Eof
            {AddChar,           AddAsterAndChr, null,       Error}  // Other
        };

        State state = State.Comment;

        string comment = string.Empty;

        Symbol GetSymbol(char c)
        {
            return
                c == '*' ? Symbol.Asterisk :
                c == '/' ? Symbol.Slash :
                c == Program.Eof ? Symbol.Eof :
                Symbol.Other;
        }

        public string Parse()
        {
            for (char c = Program.form.ReadChar(); ; c = Program.form.ReadChar())
            {
                Symbol symbol = GetSymbol(c);
                if (ActionTable[(int)symbol, (int)state] != null)
                    ActionTable[(int)symbol, (int)state](c, ref comment);
                state = TransitionTable[(int)symbol, (int)state];
                Program.form.ShowStatus(state, "Slash Comment");
                if (state == State.End) break;
            }
            return comment;
        }
    }
}