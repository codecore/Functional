using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts.Utility;
namespace Functional.Utility {
    public class JSONToken : IJSONToken {
        public JSONToken(JSONTokenType kind, string value) {
            this.Kind = kind;
            this.Value = value;
        }
        public JSONTokenType Kind { get; private set; }
        public string Value { get; private set; }
        public override string ToString() {
            return this.Value;
        }
    }
    public class JSONTokenizer : IJSONTokenizer {
        private interface ICharater { bool EOF { get; } char C { get; } }
        private class Character : ICharater { 
            public bool EOF { get; set; } 
            public char C { get; set; }
            public override string ToString() {
                return this.C.ToString()+" "+this.EOF;
            }
        }
        private Character character = new Character();
        private ICharater CH_current = null;
        private string input = String.Empty;
        private int index = 0;
        private bool handled = true;
        private Character Get() {
            if (index >= this.input.Length) {
                this.character.EOF = true;
                this.character.C = '~';
            } else {
                this.character.EOF = false;
                this.character.C = this.input[this.index];
                this.index++;
            }
            return this.character;
        }
        private enum State {
            unknown,
            open_curly,
            close_curly,
            open_bracket,
            close_bracket,
            comma,
            colon,
            semi_colon,
            start_number,
            at_least_a_digit,
            in_number,
            start_string,
            in_string,
            start_quote,
            in_quote,
            eof,
            done
        }
        private IJSONToken GetToken() {
            Queue<char> for_string = new Queue<char>();
            IJSONToken token = null;
            bool found_decimal = false;
            int start = this.index;
            State current_state = State.unknown;
            State next_state = State.unknown;
            while (current_state != State.done) {
                current_state = next_state;
                if (this.handled) {
                    this.CH_current = this.Get();
                    this.handled = false;
                }
                switch (current_state) {
                    case State.done: break; // nothing to do here
                    case State.unknown:
                        if (this.CH_current.EOF) next_state = State.eof;
                        else {
                            switch (this.CH_current.C) {
                                case '{': next_state = State.open_curly; break;
                                case '}': next_state = State.close_curly; break;
                                case '[': next_state = State.open_bracket; break;
                                case ']': next_state = State.close_bracket; break;
                                case ',': next_state = State.comma; break;
                                case ':': next_state = State.colon; break;
                                case ';': next_state = State.semi_colon; break;
                                case '"': next_state = State.start_quote; break;
                                case '.': next_state = State.start_number; break;
                                case '-': next_state = State.start_number; break;
                                default:
                                    if ((this.CH_current.C >= '0') && (this.CH_current.C <= '9')) next_state = State.at_least_a_digit;
                                    else if ((this.CH_current.C >= 'a') && (this.CH_current.C <= 'z')) next_state = State.start_string;
                                    else if ((this.CH_current.C >= 'A') && (this.CH_current.C <= 'Z')) next_state = State.start_string;
                                    else handled = true; break; // ignore unknown
                            }
                        }
                        break;
                    case State.eof:
                        token = new JSONToken(JSONTokenType.EOF, "~");
                        this.handled = false;
                        next_state = State.done;
                        break;
                    case State.open_curly:
                        token = new JSONToken(JSONTokenType.OpenCurly, "{");
                        this.handled = true;
                        next_state = State.done;
                        break;
                    case State.close_curly:
                        token = new JSONToken(JSONTokenType.CloseCurly, "}");
                        this.handled = true;
                        next_state = State.done;
                        break;
                    case State.open_bracket:
                        token = new JSONToken(JSONTokenType.OpenBracket, "[");
                        this.handled = true;
                        next_state = State.done;
                        break;
                    case State.close_bracket:
                        token = new JSONToken(JSONTokenType.CloseBracket, "]");
                        this.handled = true;
                        next_state = State.done;
                        break;
                    case State.comma:
                        token = new JSONToken(JSONTokenType.Comma, ",");
                        this.handled = true;
                        next_state = State.done;
                        break;
                    case State.semi_colon:
                        token = new JSONToken(JSONTokenType.Semicolon, ";");
                        this.handled = true;
                        next_state = State.done;
                        break;
                    case State.colon:
                        token = new JSONToken(JSONTokenType.Colon, ":");
                        this.handled = true;
                        next_state = State.done;
                        break;
                    case State.start_quote:
                        for_string.Clear();
                        //for_string.Enqueue('"');
                        this.handled = true;
                        next_state = State.in_quote;
                        break;
                    case State.in_quote:
                        if ('"' == this.CH_current.C) {
                            string sTemp = String.Empty;
                            foreach (char c in for_string) sTemp += c.ToString();
                            token = new JSONToken(JSONTokenType.QuotedString, sTemp);
                            next_state = State.done;
                        } else for_string.Enqueue(this.CH_current.C);
                        this.handled = true;
                        break;
                    case State.start_string:
                        for_string.Clear();
                        for_string.Enqueue(this.CH_current.C);
                        this.handled = true;
                        next_state = State.in_string;
                        break;
                    case State.in_string:
                        bool still = ((this.CH_current.C >= 'a') && (this.CH_current.C <= 'z'));
                        still = still || ((this.CH_current.C >= 'A') && (this.CH_current.C <= 'Z'));
                        still = still || ((this.CH_current.C >= '0') && (this.CH_current.C <= '9'));
                        if (still) {
                            for_string.Enqueue(this.CH_current.C);
                            handled = true;
                        }  else {
                            string sTemp = String.Empty;
                            foreach (char c in for_string) sTemp += c.ToString();
                            token = new JSONToken(JSONTokenType.UnquotedString, sTemp);
                            next_state = State.done;
                        }
                        break;
                    case State.start_number: // handle - and .
                        if (this.CH_current.C == '.') found_decimal = true;
                        for_string.Clear();
                        for_string.Enqueue(this.CH_current.C);
                        this.handled = true;
                        next_state = State.at_least_a_digit;
                        break;
                    case State.at_least_a_digit:
                        if ((this.CH_current.C < '0') || ('9' < this.CH_current.C)) throw new ParseException("got a - without a folloing digit");
                        this.handled = false;
                        next_state = State.in_number;
                        break;
                    case State.in_number:
                        if ((this.CH_current.C == '.') && (found_decimal)) throw new ParseException("string contains two decimal point in number");
                        if (this.CH_current.C == '.') {
                            found_decimal = true;
                            this.handled = true;
                            for_string.Enqueue(this.CH_current.C);
                        } else {
                            if ((this.CH_current.C >= '0') && (this.CH_current.C <= '9')) {
                                this.handled = true;
                                for_string.Enqueue(this.CH_current.C);
                            } else {
                                string sTemp = String.Empty;
                                foreach(char c in for_string) sTemp += c.ToString();
                                token = new JSONToken(JSONTokenType.Number, sTemp);
                                next_state = State.done;
                            }
                        }
                        break;
                }
            }
            return token;
        }
        public IEnumerable<IJSONToken> Tokenize(string s) {
            this.input = s;
            this.index = 0;
            this.handled = true;
            IJSONToken token = this.GetToken();
            while (token.Kind != JSONTokenType.EOF) {
                yield return token;
                token = this.GetToken();
            }
            yield return token;
        }

    }
}
