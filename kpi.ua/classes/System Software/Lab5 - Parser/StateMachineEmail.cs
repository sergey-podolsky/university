using System;
using System.Collections.Generic;
using System.Linq;

namespace Parser
{
    class StateMachineEmail
    {
        public enum Symbol
        {
            Separator,  // Space, Tab, New line
            At,         // @
            Dot,        // .
            LetrDigit,  // Letter, Digit
            Underline,  // _
            Minus,      // -
            Eof,        // End of file
            Other       // Other symbols
        }

        public enum State
        {
            Ready,      // No emails processing now
            Name,       // Name processing
            DomBegin,   // Begin of domain or subdomain
            Domain,     // Domain processing
            Minus,      // Current symbol is minus
            End,        // Parsing done
            Error       // Error occured
        }

        #region Actions
        delegate void Method(List<Email> emails, char c);

        static void NewEmail(List<Email> emails, char c)
        {
            emails.Add(new Email());
            AppendName(emails, c);
        }

        static void AppendName(List<Email> emails, char c)
        {
            emails[emails.Count - 1].Name += c;
        }

        static void AddDomain(List<Email> emails, char c)
        {
            emails[emails.Count - 1].Domain.Add(string.Empty);
        }

        static void AppendDomain(List<Email> emails, char c)
        {
            emails[emails.Count - 1].Domain[emails[emails.Count - 1].Domain.Count - 1] += c;
        }

        static readonly Method[] Error =
        {
            delegate{throw new SyntaxException("Invalid email format");}, // 0
            delegate{throw new SyntaxException("Invalid email format:\nName expected");}, // 1
            delegate{throw new SyntaxException("Invalid email format:\nDot may separate subdomains");}, // 2
            delegate{throw new SyntaxException("Invalid email format:\nMinus character \"-\" is allowed only in domains");}, // 3
            delegate{throw new SyntaxException("Invalid email format:\nUnexpected char detected");}, // 4
            delegate{throw new SyntaxException("Invalid email format:\nDomain is missed");}, // 5
            delegate{throw new SyntaxException("Invalid email format:\nUnexpected end of file\nDomain/Subdomain is missed");}, // 6
            delegate{throw new SyntaxException("Invalid email format:\nDomain/Subdomain is missed");}, // 7
            delegate{throw new SyntaxException("Invalid email format:\nUnderline is allowed only in names");}, // 8
            delegate{throw new SyntaxException("Invalid email format:\nDomain may begin end end with letter or digit");} // 9
        };

        #endregion

        static readonly State[,] TransitionTable =
        { // Ready          Name            DomBegin        Domain          Minus           End         Error
            {State.Ready,   State.Error,    State.Error,    State.Ready,    State.Error,    State.End,  State.Error}, // Separator
            {State.Error,   State.DomBegin, State.Error,    State.Error,    State.Error,    State.End,  State.Error}, // At
            {State.Error,   State.Error,    State.Error,    State.DomBegin, State.Error,    State.End,  State.Error}, // Dot
            {State.Name,    State.Name,     State.Domain,   State.Domain,   State.Domain,   State.End,  State.Error}, // LetrDigit
            {State.Name,    State.Name,     State.Error,    State.Error,    State.Error,    State.End,  State.Error}, // Underline
            {State.Error,   State.Error,    State.Error,    State.Domain,   State.Domain,   State.End,  State.Error}, // Minus
            {State.End,     State.Error,    State.Error,    State.End,      State.Error,    State.End,  State.Error}, // Eof
            {State.Error,   State.Error,    State.Error,    State.Error,    State.Error,    State.End,  State.Error}  // Other
        };

        static readonly Method[,] ActionTable = 
        { // Ready          Name            DomBegin        Domain          Minus           End         Error
            {null,          Error[5],       Error[7],       null,           Error[8],       null,       Error[0]}, // Separator
            {Error[1],      AddDomain,      Error[4],       Error[4],       Error[4],       null,       Error[0]}, // At
            {Error[2],      Error[2],       Error[4],       AddDomain,      Error[9],       null,       Error[0]}, // Dot
            {NewEmail,      AppendName,     AppendDomain,   AppendDomain,   AppendDomain,   null,       Error[0]}, // LetrDigit
            {NewEmail,      AppendName,     Error[8],       Error[8],       Error[8],       null,       Error[0]}, // Underline
            {Error[3],      Error[3],       Error[9],       AppendDomain,   AppendDomain,   null,       Error[0]}, // Minus
            {null,          Error[6],       Error[6],       null,           Error[9],       null,       Error[0]}, // Eof
            {Error[4],      Error[4],       Error[4],       Error[4],       Error[4],       null,       Error[0]}  // Other
        };

        public State state = State.Ready;

        List<Email> emails = new List<Email>();

        Symbol GetSymbol(char c)
        {
            return
                char.IsSeparator(c) || c == ' ' || c == '\t' || c == '\n' ? Symbol.Separator :
                c == '@' ? Symbol.At :
                c == '.' ? Symbol.Dot :
                char.IsDigit(c) || char.ToUpper(c) >= 65 && char.ToUpper(c) <= 90 ? Symbol.LetrDigit :
                c == '_' ? Symbol.Underline :
                c == '-' ? Symbol.Minus :
                c == Program.Eof ? Symbol.Eof :
                Symbol.Other;
        }

        public IEnumerable<object> Parse()
        {
            for (char c = Program.form.ReadChar(); ; c = Program.form.ReadChar())
            {
                Symbol symbol = GetSymbol(c);
                if (ActionTable[(int)symbol, (int)state] != null)
                    ActionTable[(int)symbol, (int)state](emails, c);
                state = TransitionTable[(int)symbol, (int)state];
                Program.form.ShowStatus(state, "Emails");
                Program.form.Invoke(new Action(delegate
                     {
                         Program.form.listBox.Items.Clear();
                         Program.form.WriteResult(emails.Cast<object>(), "");
                     }));
                if (state == State.End) break;
            }
            return emails.Cast<object>();
        }
    }
}
