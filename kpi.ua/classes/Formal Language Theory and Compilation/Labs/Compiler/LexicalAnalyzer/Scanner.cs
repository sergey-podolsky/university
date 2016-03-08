using System;
using System.Collections.Generic;
using System.Linq;

namespace LexicalAnalyzer
{
    public class Scanner
    {
        enum Attribute
        {
            Letter,
            Digit,
            Delimiter,
            Colon,
            Equality,
            LeftBracket,
            RightBracket,
            Asterisk,
            Whitespace,
            Other,
            EndOfFile
        }

        enum State
        {
            Ready,
            Identifier,
            Number,
            Delimiter,
            Assignment,
            CommentBegin,
            Comment,
            CommentEnd,
            Error,
            Done
        }

        static readonly State[,] TransitionTable =
        {
            //                  Ready               Identifier          Number              Delimiter           Assignment      CommentBegin        Comment             CommentEnd      
            {/* Letter */       State.Identifier,   State.Identifier,   State.Identifier,   State.Identifier,   State.Error,    State.Error,        State.Comment,      State.Comment   },
            {/* Digit */        State.Number,       State.Identifier,   State.Number,       State.Number,       State.Error,    State.Error,        State.Comment,      State.Comment   },
            {/* Delimiter */    State.Delimiter,    State.Delimiter,    State.Delimiter,    State.Delimiter,    State.Error,    State.Error,        State.Comment,      State.Comment   },
            {/* Colon */        State.Assignment,   State.Assignment,   State.Assignment,   State.Assignment,   State.Error,    State.Error,        State.Comment,      State.Comment   },
            {/* Equality */     State.Error,        State.Error,        State.Error,        State.Error,        State.Delimiter,State.Error,        State.Comment,      State.Comment   },
            {/* LeftBracket */  State.CommentBegin, State.CommentBegin, State.CommentBegin, State.CommentBegin, State.Error,    State.Error,        State.Comment,      State.Comment   },
            {/* RightBracket */ State.Error,        State.Error,        State.Error,        State.Error,        State.Error,    State.Error,        State.Comment,      State.Ready     },
            {/* Asterisk */     State.Error,        State.Error,        State.Error,        State.Error,        State.Error,    State.Comment,      State.CommentEnd,   State.CommentEnd},
            {/* Whitespace*/    State.Ready,        State.Ready,        State.Ready,        State.Ready,        State.Error,    State.Error,        State.Comment,      State.Comment   },
            {/* Other */        State.Error,        State.Error,        State.Error,        State.Error,        State.Error,    State.Error,        State.Comment,      State.Comment   },
            {/* EndOfFile */    State.Ready,        State.Error,        State.Error,        State.Ready,        State.Error,    State.Error,        State.Error,        State.Error     }
        };

        readonly Action[,] ActionTable;

        public Scanner()
        {
            ActionTable = new Action[,]
            {
                //                  Ready           Identifier          Number              Delimiter       Assignment      CommentBegin        Comment             CommentEnd      
                {/* Letter */       () => {},       null,               AddNumber,          AddDelimiter,   Error2,         Error0,             null,               null    },
                {/* Digit */        () => {},       null,               null,               AddDelimiter,   Error2,         Error0,             null,               null    },
                {/* Delimiter */    () => {},       AddIdentifier,      AddNumber,          AddDelimiter,   Error2,         Error0,             null,               null    },
                {/* Colon */        () => {},       AddIdentifier,      AddNumber,          AddDelimiter,   Error2,         Error0,             null,               null    },  
                {/* Equality */     Error1,         Error1,             Error1,             Error1,         null,           Error0,             null,               null    },
                {/* LeftBracket */  null,           AddIdentifier,      AddNumber,          AddDelimiter,   Error2,         Error0,             null,               null    },
                {/* RightBracket */ Error1,         Error1,             Error1,             Error1,         Error2,         Error0,             null,               null    },
                {/* Asterisk */     Error1,         Error1,             Error1,             Error1,         Error2,         null,               null,               null    },
                {/* Whitespace*/    null,           AddIdentifier,      AddNumber,          AddDelimiter,   Error2,         Error0,             null,               null    },
                {/* Other */        Error1,         Error1,             Error1,             Error1,         Error2,         Error0,             null,               null    },
                {/* EndOfFile */    null,           Error3,             Error3,             AddDelimiter,   Error3,         Error3,             Error3,             Error3  }
            };

            #region Define table of attributes

            for (var c = 0; c < attributes.Length; c++)
                attributes[c] = Attribute.Other;
            for (var c = '0'; c <= '9'; c++)
                attributes[c] = Attribute.Digit;
            for (var c = 'A'; c <= 'Z'; c++)
                attributes[c] = attributes[char.ToLower(c)] = Attribute.Letter;
            attributes['+'] = attributes['-'] = attributes[';'] = attributes['.'] = Attribute.Delimiter;
            attributes[':'] = Attribute.Colon;
            attributes['='] = Attribute.Equality;
            attributes['*'] = Attribute.Asterisk;
            attributes['('] = Attribute.LeftBracket;
            attributes[')'] = Attribute.RightBracket;
            attributes[' '] = attributes['\t'] = attributes['\n'] = attributes['\r'] = Attribute.Whitespace;

            #endregion

            #region Define keywords

            foreach (string token in Keywords)
                identifiers[token] = identifier++;

            #endregion

            #region Define long delimiters

            longDelimiters.Add(":=", longDelimiter++);

            #endregion
        }

        public static readonly string[] Keywords = { "PROGRAM", "BEGIN", "END", "LOOP", "ENDLOOP", "FOR", "TO", "DO", "ENDFOR" };

        Attribute[] attributes = new Attribute[char.MaxValue + 1];

        int longDelimiter = 301, constant = 401, identifier = 701;

        public Dictionary<string, int> identifiers = new Dictionary<string, int>();
        public Dictionary<string, int> constants = new Dictionary<string, int>();
        public Dictionary<string, int> longDelimiters = new Dictionary<string, int>();

        string token = string.Empty;
        List<Tuple<int, string>> output = new List<Tuple<int, string>>();

        int line = 1, column = 0;

        /// <summary>
        /// Invoke lexical analyser
        /// </summary>
        /// <param name="text">Input text</param>
        /// <returns>
        /// A list of tuples.
        /// <para>Each tuple is defined by two items.</para>
        /// <para>Item1: symbol code assigned by scanner;</para>
        /// <para>Item2: symbol;</para>
        /// </returns>
        public List<Tuple<int, string>> Scan(string text)
        {
            var state = State.Ready;
            foreach (char c in text)
            {
                /* Get current position in file */
                if (c == '\n')
                {
                    line++;
                    column = 0;
                }
                else
                    column++;

                /* Increase state machine tact */
                var attribute = attributes[c];
                var action = ActionTable[(int)attribute, (int)state];
                state = TransitionTable[(int)attribute, (int)state];
                if (action != null)
                {
                    //token = token.Trim();
                    action();
                    token = string.Empty;
                }
                token += c;
            }

            /* Handle end of file */
            var finalAction = ActionTable[(int)Attribute.EndOfFile, (int)state];
            if (finalAction != null)
                finalAction();

            return output;
        }

        #region Actions

        void AddNumber()
        {
            if (!constants.ContainsKey(token))
                constants[token] = constant++;
            output.Add(Tuple.Create(constants[token], token));
        }

        void AddIdentifier()
        {
            token = token.ToUpper();
            if (!identifiers.ContainsKey(token))
                identifiers[token] = identifier++;
            output.Add(Tuple.Create(identifiers[token], token));
        }

        void AddDelimiter()
        {
            if (token.Length > 1)
                output.Add(Tuple.Create(longDelimiters[token], token));
            else
                output.Add(Tuple.Create((int)token.First(), token));
        }

        #endregion

        #region Errors

        void Error0()
        {
            throw new LexicalException("'*' expected after comment begin '('", line, column);
        }

        void Error1()
        {
            throw new LexicalException("Unexpected symbol", line, column);
        }

        void Error2()
        {
            throw new LexicalException("'=' expected after ':'", line, column);
        }

        void Error3()
        {
            throw new LexicalException("Unexpected end of file", line, column);
        }

        #endregion
    }
}
