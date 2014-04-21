using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Contracts.Utility;
using Functional.Utility;
using Functional.Implementation;
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {
    [Export(typeof(ISyncTestCase))]
    public class test_json_tokenizer : ISyncTestCase {
        private const string _Name = "test_json_tokenizer";
        private const string _Description = "that the JSON tokenizer return the correct set of tokens>";
        public string TestFile { get { return "TestCaseJSONTokenizer.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            IJSONTokenizer JsonTokenizer = new JSONTokenizer();
            IEnumerable<IJSONToken> tokens = JsonTokenizer.Tokenize("{ \"id\" : \"one\" }");
            int index = 0;
            foreach (IJSONToken token in tokens) {
                if (0 == index) result = result && (token.Kind == JSONTokenType.OpenCurly);
                if (1 == index) result = result && (token.Kind == JSONTokenType.QuotedString);
                if (1 == index) result = result && (token.Value == "id");
                if (2 == index) result = result && (token.Kind == JSONTokenType.Colon);
                if (3 == index) result = result && (token.Kind == JSONTokenType.QuotedString);
                if (3 == index) result = result && (token.Value == "one");
                if (4 == index) result = result && (token.Kind == JSONTokenType.CloseCurly);
                if (4 == index) result = result && (token.Value == "}");
                if (5 == index) result = result && (token.Kind == JSONTokenType.EOF);
                index++;
            }
            bool threw_parse_exception = false;
            try {
                tokens = JsonTokenizer.Tokenize("9.45.6");
                foreach (IJSONToken token in tokens) {
                    string s = token.Value;
                }
            } catch (ParseException) {
                threw_parse_exception = true;
            }
            result = result && threw_parse_exception;
            threw_parse_exception = false;
            try {
                tokens = JsonTokenizer.Tokenize(" - kdoif");
                foreach (IJSONToken token in tokens) {
                    string s = token.Value;
                }
            } catch (ParseException) {
                threw_parse_exception = true;
            }
            result = result && threw_parse_exception;

            // now test all the token types
            tokens = JsonTokenizer.Tokenize("{ } [] uiuo  \"literal\" : ; , .844 -43");
            index = 0;
            foreach (IJSONToken token in tokens) {
                if (0 == index) result = result && (token.Kind == JSONTokenType.OpenCurly) && (token.Value == "{");
                if (1 == index) result = result && (token.Kind == JSONTokenType.CloseCurly) && (token.Value == "}");
                if (2 == index) result = result && (token.Kind == JSONTokenType.OpenBracket) && (token.Value == "[");
                if (3 == index) result = result && (token.Kind == JSONTokenType.CloseBracket) && (token.Value == "]");
                if (4 == index) result = result && (token.Kind == JSONTokenType.UnquotedString) && (token.Value == "uiuo");
                if (5 == index) result = result && (token.Kind == JSONTokenType.QuotedString) && (token.Value == "literal");
                if (6 == index) result = result && (token.Kind == JSONTokenType.Colon) && (token.Value == ":");
                if (7 == index) result = result && (token.Kind == JSONTokenType.Semicolon) && (token.Value == ";");
                if (8 == index) result = result && (token.Kind == JSONTokenType.Comma) && (token.Value == ",");
                if (9 == index) result = result && (token.Kind == JSONTokenType.Number) && (token.Value == ".844");
                if (10 == index) result = result && (token.Kind == JSONTokenType.Number) && (token.Value == "-43");
                if (11 == index) result = result && (token.Kind == JSONTokenType.EOF);
                index++;
            }
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_json_tokenizer() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Utility_JSON_Tokenizer);

            this.coverage.Add(TestCoverage.Utility_JSON_Tokenizer);
        }
    }
}
