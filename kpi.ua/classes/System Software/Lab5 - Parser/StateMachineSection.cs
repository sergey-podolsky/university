using System;
using System.Collections.Generic;

namespace Parser
{
    class StateMachineSection
    {
        public enum Symbol
        {
            LeftBracket,    // {
            Separator,      // Space, Tab,  New line
            Slash,          // /          
            Asterisk,       // *
            Sharp,          // #
            Letter,         // Letter
            RightBracket,   // }
            Eof,            // End of file
            Other           // Other symbol
        }

        public enum State
        {
            Value,          // Section value
            Inside,         // Inside section
            Slash,          // Current symbol is "/"
            End,            // Parsing done
            Error           // Error occured
        }

        #region Actions
        public delegate void Method(char c, Section section);

        static void AddChar(char c, Section section)
        {
            section.Value += c;
        }

        static void SlashComment(char c, Section section)
        {
            section.Items.Add(new StateMachineCommentSlash().Parse());
        }

        static void SharpComment(char c, Section section)
        {
            section.Items.Add(new StateMachineCommentSharp().Parse());
        }

        static void Name(char c, Section section)
        {
            section.Items.Add(new StateMachineName().Parse(c));
        }

        static readonly Method[] Error =
        {
            delegate {throw new SyntaxException("Invalid section format");}, // 0
            delegate {throw new SyntaxException("Invalid section format:\nUnexpected end of file");}, // 1
            delegate {throw new SyntaxException("Invalid section format:\nInvalid right bracked \"{\";\n Left bracket \"}\" expected");}, // 2
            delegate {throw new SyntaxException("Invalid section format:\nInvalid left bracked \"{\"");}, // 3
            delegate {throw new SyntaxException("Invalid section format:\nUnexpected char detected");}, // 4
            delegate {throw new SyntaxException("Invalid section format:\nUnexpected char after slash \"/\" detected;\nAsterisk \"*\" and comment expected");}, // 5
        };
        #endregion

        static readonly State[,] TransitionTable =
        { // Value          Inside          Slash           End         Error
            {State.Inside,  State.Error,    State.Error,    State.End,  State.Error}, // LeftBracket
            {State.Value,   State.Inside,   State.Error,    State.End,  State.Error}, // Separator
            {State.Value,   State.Slash,    State.Error,    State.End,  State.Error}, // Slash
            {State.Value,   State.Error,    State.Inside,   State.End,  State.Error}, // Asterisk
            {State.Value,   State.Inside,   State.Error,    State.End,  State.Error}, // Sharp
            {State.Value,   State.Inside,   State.Error,    State.End,  State.Error}, // Letter
            {State.Error,   State.End,      State.Error,    State.End,  State.Error}, // Right Bracket
            {State.Error,   State.Error,    State.Error,    State.End,  State.Error}, // Eof
            {State.Value,   State.Error,    State.Error,    State.End,  State.Error}  // Other
        };

        static readonly Method[,] ActionTable =
        { // Value          Inside          Slash           End         Error
            {null,          Error[3],       Error[5],       null,       Error[0]}, // LeftBracket
            {AddChar,       null,           Error[5],       null,       Error[0]}, // Separator
            {AddChar,       null,           Error[5],       null,       Error[0]}, // Slash
            {AddChar,       Error[4],       SlashComment,   null,       Error[0]}, // Asterisk
            {AddChar,       SharpComment,   Error[5],       null,       Error[0]}, // Sharp
            {AddChar,       Name,           Error[5],       null,       Error[0]}, // Letter
            {Error[2],      null,           Error[5],       null,       Error[0]}, // Right Bracket
            {Error[1],      Error[1],       Error[1],       null,       Error[0]}, // Eof
            {AddChar,       Error[4],       Error[5],       null,       Error[0]}  // Other
        };

        State state = State.Value;

        Section section = new Section();

        Symbol GetSymbol(char c)
        {
            return
                c == '{' ? Symbol.LeftBracket :
                c == ' ' || c == '\t' || c == '\n' ? Symbol.Separator :
                c == '/' ? Symbol.Slash :
                c == '*' ? Symbol.Asterisk :
                c == '#' ? Symbol.Sharp :
                char.IsLetter(c) ? Symbol.Letter :
                c == '}' ? Symbol.RightBracket :
                c == Program.Eof ? Symbol.Eof :
                Symbol.Other;
        }

        public Section Parse(char firstChar)
        {
            for (char c = firstChar; ; c = Program.form.ReadChar())
            {
                Symbol symbol = GetSymbol(c);
                if (ActionTable[(int)symbol, (int)state] != null)
                    ActionTable[(int)symbol, (int)state](c, section);
                state = TransitionTable[(int)symbol, (int)state];
                Program.form.ShowStatus(state, "Section");
                if (state == State.End) break;
            }
            return section;
        }
    }
}