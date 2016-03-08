using System;
using System.Collections.Generic;

namespace Parser
{
    class StateMachineCommentSharp
    {
        public enum Symbol
        {
            SpaceTab,   // Space, Tab
            NewLine,    // New line
            Eof,        // End of file
            Other       // Other symbol
        }

        public enum State
        {
            Begin,      // Waiting for comment chars
            Comment,    // Comment chars
            End         // Parsing done
        }

        #region Actions
        public delegate void Method(char c, ref string comment);

        static void AddChar(char c, ref string comment)
        {
            comment += c;
        }
        #endregion

        static readonly State[,] TransitionTable =
        { // Begin          Comment         End
            {State.Begin,   State.Comment,  State.End}, // SpaceTab
            {State.End,     State.End,      State.End}, // NewLine
            {State.End,     State.End,      State.End}, // Eof
            {State.Comment, State.Comment,  State.End}  // Other
        };

        static readonly Method[,] ActionTable =
        { // Begin          Comment         End
            {null,          AddChar,        null}, // Separator
            {null,          null,           null}, // NewLine
            {null,          null,           null}, // Eof
            {AddChar,       AddChar,        null}  // Other
        };

        State state = State.Begin;

        string comment = string.Empty;

        Symbol GetSymbol(char c)
        {
            return
                c == ' ' || c == '\t' ? Symbol.SpaceTab :
                c == '\n' ? Symbol.NewLine :
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
                Program.form.ShowStatus(state, "Sharp Comment");
                if (state == State.End) break;
            }
            return comment;
        }
    }
}
