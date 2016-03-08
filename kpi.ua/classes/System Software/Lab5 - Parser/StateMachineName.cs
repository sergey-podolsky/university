using System;
using System.Collections.Generic;

namespace Parser
{
    class StateMachineName
    {
        public enum Symbol
        {
            Separator,  // Space, Tab, New line
            LtrDgtUnd,  // Letter, Digit, _
            Equality,   // =
            Eof,        // End of file
            Other       // Other symbol
        }

        public enum State
        {
            Name,       // Current symbol is name part
            Separator,  // Current symbol is Space, Tab or New line
            End,        // Parsing done
            Error,      // Error occured
        }

        #region Actions
        public delegate void Method(char c, ref string name, ref Parameter parameter);

        static void AddChar(char c, ref string name, ref Parameter parameter)
        {
            name += c;
        }

        static void ReturnSection(char c, ref string name, ref Parameter parameter)
        {
            parameter = new StateMachineSection().Parse(c);
        }

        static void ReturnParameter(char c, ref string name, ref Parameter parameter)
        {
            parameter = new StateMachineParameter().Parse();
        }

        static readonly Method[] Error =
        {
            delegate {throw new SyntaxException("Invalid name format");},
            delegate {throw new SyntaxException("Invalid name format:\nUnexpected end of file detected");},
            delegate {throw new SyntaxException("Invalid name format:\nInvalid char in name detected;\nOnly letters, digits and underline assumed");}
        };
        #endregion

        static readonly State[,] TransitionTable =
        { // Name               Separator           End         Error
            {State.Separator,   State.Separator,    State.End,  State.Error}, // Separator
            {State.Name,        State.End,          State.End,  State.Error}, // LtrDgtUnd
            {State.End,         State.End,          State.End,  State.Error}, // Equality
            {State.Error,       State.Error,        State.End,  State.Error}, // Eof
            {State.Error,       State.End,          State.End,  State.Error}, // Other
        };

        static readonly Method[,] ActionTable =
        { // Name               Separator           End         Error
            {null,              null,               null,       Error[0]}, // Separator
            {AddChar,           ReturnSection,      null,       Error[0]}, // LtrDgtUnd
            {ReturnParameter,   ReturnParameter,    null,       Error[0]}, // Equality
            {Error[1],          Error[1],           null,       Error[0]}, // Eof
            {Error[2],          ReturnSection,      null,       Error[0]}, // Other
        };

        State state = State.Name;

        string name = string.Empty;

        Parameter parameter;

        Symbol GetSymbol(char c)
        {
            return
                c == ' ' || c == '\t' || c == '\n' ? Symbol.Separator :
                char.IsLetter(c) || char.IsDigit(c) || c == '_' ? Symbol.LtrDgtUnd :
                c == '=' ? Symbol.Equality :
                c == Program.Eof ? Symbol.Eof :
                Symbol.Other;
        }

        public Parameter Parse(char firstChar)
        {
            for (char c = firstChar; ; c = Program.form.ReadChar())
            {
                Symbol symbol = GetSymbol(c);
                if (ActionTable[(int)symbol, (int)state] != null)
                    ActionTable[(int)symbol, (int)state](c, ref name, ref parameter);
                state = TransitionTable[(int)symbol, (int)state];
                Program.form.ShowStatus(state, "Section/Parameter Name");
                if (state == State.End) break;
            }
            parameter.Name = name;
            return parameter;
        }
    }
}
