using System;
using System.Collections.Generic;

namespace Parser
{
    class StateMachineParameter
    {
        public enum Symbol
        {
            Separator,  // Space, Tab, New line
            Quoting,    // "
            Semicolon,  // ;
            Eof,        // End of file
            Other       // Other symbol
        }

        public enum State
        {
            Begin,      // Begin of parameter value
            Value,      // Parameter value
            End,        // Parsing done
            Error       // Error occured
        }

        #region Actions
        public delegate void Method(char c, Parameter parameter);

        static void AddChar(char c, Parameter parameter)
        {
            parameter.Value += c;
        }

        static void AddString(char c, Parameter parameter)
        {
            parameter.Value += '"' + new StateMachineString().Parse() + '"';
        }

        static void Error(char c, Parameter parameter)
        {
            throw new SyntaxException("Parameter value error:\nunexpected end of file - \";\" is missed");
        }
        #endregion

        public static readonly State[,] TransitionTable = 
        { // Begin          Parameter       End         Error
            {State.Begin,   State.Value,    State.End,  State.Error}, // Separator
            {State.Value,   State.Value,    State.End,  State.Error}, // Quoting
            {State.End,     State.End,      State.End,  State.Error}, // Semicolon
            {State.End,     State.Error,    State.End,  State.Error}, // Eof
            {State.Value,   State.Value,    State.End,  State.Error}  // Other
        };

        public static readonly Method[,] ActionTable = 
        { // Begin          Parameter       End         Error
            {null,          AddChar,        null,       Error}, // Separator
            {AddString,     AddString,      null,       Error}, // Quoting
            {null,          null,           null,       Error}, // Semicolon
            {Error,         Error,          null,       Error}, // Eof
            {AddChar,       AddChar,        null,       Error}  // Other
        };

        State state = State.Begin;

        Parameter parameter = new Parameter();

        Symbol GetSymbol(char c)
        {
            return
                c == ' ' || c == '\t' || c == '\n' ? Symbol.Separator :
                c == '"' ? Symbol.Quoting :
                c == ';' ? Symbol.Semicolon :
                c == Program.Eof ? Symbol.Eof : 
                Symbol.Other;
        }

        public Parameter Parse()
        {
            for (char c = Program.form.ReadChar(); ; c = Program.form.ReadChar())
            {
                Symbol symbol = GetSymbol(c);
                if (ActionTable[(int)symbol, (int)state] != null)
                    ActionTable[(int)symbol, (int)state](c, parameter);
                state = TransitionTable[(int)symbol, (int)state];
                Program.form.ShowStatus(state, "Parameter");
                if (state == State.End) break;
            }
            return parameter;
        }
    }
}
