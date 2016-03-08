using System;
using System.Collections.Generic;

namespace Parser
{
    class StateMachineString
    {
        public enum Symbol
        {
            Quoting,        // "
            Slash,          // \
            n,              // n
            t,          
            SingleQuoting,  // '
            Eof,            // End of file
            Other           // Other symbol
        }

        public enum State
        {
            Common,         // String regular chars
            Slash,          // Current char is "/"
            End,            // Parsing done
            Error           // Error occured
        }

        #region Actions
        public delegate void Method(char c, ref string line);

        static void AddSlash(char c, ref string line)
        {
            line += "[Slash]";
        }

        static void AddNewLine(char c, ref string line)
        {
            line += "[NewLine]";
        }

        static void AddTab(char c, ref string line)
        {
            line += "[Tab]";
        }

        static void AddQuoting(char c, ref string line)
        {
            line += "[QuotingMark]";
        }

        static void AddSingleQuote(char c, ref string line)
        {
            line += "[SingleQuotingMark]";
        }

        static void AddChar(char c, ref string line)
        {
            line += c;
        }

        static readonly Method[] Error = new Method[]
        {
            delegate{throw new SyntaxException("Invalid string format");},
            delegate{throw new SyntaxException("Invalid string format:\nUnexpected end of file - right quoting mark expected");},
            delegate{throw new SyntaxException("Invalid string format:\nInvalid char after slash \"\\\" detected");}
        };
        #endregion

        public static readonly State[,] TransitionTable =
        { // Common         Slash           End         Error
            {State.End,     State.Common,   State.End,  State.Error}, // Quoting
            {State.Slash,   State.Common,   State.End,  State.Error}, // Slash
            {State.Common,  State.Common,   State.End,  State.Error}, // n
            {State.Common,  State.Common,   State.End,  State.Error}, // t
            {State.Common,  State.Common,   State.End,  State.Error}, // SingleQuoting
            {State.Error,   State.Error,    State.End,  State.Error}, // Eof
            {State.Common,  State.Error,    State.End,  State.Error}  // Other
        };
        
        public static readonly Method[,] ActionTable =
        { // Common         Slash           End         Error
            {null,          AddQuoting,     null,       Error[0]}, // Quoting
            {null,          AddSlash,       null,       Error[0]}, // Slash
            {AddChar,       AddNewLine,     null,       Error[0]}, // n
            {AddChar,       AddTab,         null,       Error[0]}, // t
            {AddChar,       AddSingleQuote, null,       Error[0]}, // SingleQuoting
            {Error[1],      Error[1],       null,       Error[0]}, // Eof
            {AddChar,       Error[2],       null,       Error[0]}  // Other
        };

        State state = State.Common;

        string line = string.Empty;

        Symbol GetSymbol(char c)
        {
            return
                c == '"' ? Symbol.Quoting :
                c == '\\' ? Symbol.Slash :
                c == 'n' ? Symbol.n :
                c == 't' ? Symbol.t :
                c == '\'' ? Symbol.SingleQuoting :
                c == Program.Eof ? Symbol.Eof :
                Symbol.Other;
        }

        public string Parse()
        {
            for (char c = Program.form.ReadChar(); ; c = Program.form.ReadChar())
            {
                Symbol symbol = GetSymbol(c);
                if (ActionTable[(int)symbol, (int)state] != null)
                    ActionTable[(int)symbol, (int)state](c, ref line);
                state = TransitionTable[(int)symbol, (int)state];
                Program.form.ShowStatus(state, "String");
                if (state == State.End) break;;
            }
            return line;
        }
    }
}
