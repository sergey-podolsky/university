using System;
using System.Collections.Generic;

namespace Parser
{
    class StateMachineMain
    {
        public enum Symbol
        {
            Separator,  // Space, Tab, New line
            Slash,      // /
            Asterisk,   // *
            Sharp,      // #
            Letter,     // Letter
            Eof,        // End of file
            Other       // Other symbol
        }

        public enum State
        {
            Ready,      // No structures processing now
            Slash,      // Current symbol is "/"
            End,        // Parsing done
            Error       // Error occured
        }

        #region Actions
        public delegate void Method(char c, List<object> items);

        static void SlashComment(char c, List<object> items)
        {
            items.Add(new StateMachineCommentSlash().Parse());
        }

        static void SharpComment(char c, List<object> items)
        {
            items.Add(new StateMachineCommentSharp().Parse());
        }

        static void Name(char c, List<object> items)
        {
            items.Add(new StateMachineName().Parse(c));
        }

        static void Error(char c, List<object> items)
        {
            throw new SyntaxException("Unexpected char occured");
        }
        #endregion

        static readonly State[,] TransitionTable =
        { // Ready          Slash           End         Error
            {State.Ready,   State.Error,    State.End,  State.Error}, // Separator
            {State.Slash,   State.Error,    State.End,  State.Error}, // Slash
            {State.Error,   State.Ready,    State.End,  State.Error}, // Asterisk
            {State.Ready,   State.Error,    State.End,  State.Error}, // Sharp
            {State.Ready,   State.Error,    State.End,  State.Error}, // Letter
            {State.End,     State.Error,    State.End,  State.Ready}, // Eof
            {State.Error,   State.Error,    State.End,  State.Error}  // Other
        };

        static readonly Method[,] ActionTable =
        { // Ready          Slash           End         Error
            {null,          Error,          null,       Error}, // Separator
            {null,          Error,          null,       Error}, // Slash
            {Error,         SlashComment,   null,       Error}, // Asterisk
            {SharpComment,  Error,          null,       Error}, // Sharp
            {Name,          Error,          null,       Error}, // Letter
            {null,          null,           null,       Error}, // Eof
            {Error,         Error,          null,       Error}  // Other
        };

        State state = State.Ready;

        List<object> items = new List<object>();

        Symbol GetSymbol(char c)
        {
            return
                c == ' ' || c == '\t' || c == '\n' ? Symbol.Separator :
                c == '/' ? Symbol.Slash :
                c == '*' ? Symbol.Asterisk :
                c == '#' ? Symbol.Sharp :
                char.ToUpper(c) >= 65 && char.ToUpper(c) <= 90 ? Symbol.Letter :
                c == Program.Eof ? Symbol.Eof :
                Symbol.Other;
        }

        public List<object> Parse()
        {
            for (char c = Program.form.ReadChar(); ; c = Program.form.ReadChar())
            {
                Symbol symbol = GetSymbol(c);
                if (ActionTable[(int)symbol, (int)state] != null)
                    ActionTable[(int)symbol, (int)state](c, items);
                state = TransitionTable[(int)symbol, (int)state];
                Program.form.ShowStatus(state, "Main");
                Program.form.Invoke(new Action(delegate
                {
                    Program.form.listBox.Items.Clear();
                    Program.form.WriteResult(items, "");
                }));
                if (state == State.End) break;
            }
            return items;
        }
    }
}
