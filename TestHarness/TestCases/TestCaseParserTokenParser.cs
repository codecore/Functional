using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using Functional.Language.Contract;
using Functional.Language.Implimentation;

using TestContracts;
using Tests;
namespace Tests {

    [Export(typeof(IAsyncTestCase))]
    public class test_parser_lexer : IAsyncTestCase {
        private const string _Name = "test parser lexer";
        private const string _Description = "test that lexer can create tokens";
        public string TestFile { get { return "TestCaseParserTokenParser.cs"; } }
        public async Task<bool> Run() {
            bool result = true;
            IInputStream inputStream = new InputStreamMock(1, " Pr*+$");
            IGetChar getChar = new GetChar();
            ICharacterStream characterStream = new CharacterStream();
            getChar.Initialize(inputStream);
            characterStream.Initialize(getChar);

            ITokenStream tokenStream = new TokenStream();
            Queue<char> word = new Queue<char>();

            ILexer lexer = new Lexer();
            lexer.Initialize();
            await lexer.Parse(tokenStream, characterStream, "filename", 0, 0);

            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_parser_lexer() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Parser);
            this.feature.Add(TestCoverage.Lang_Parser_Lexer);

            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Parser);
            this.coverage.Add(TestCoverage.Lang_Parser_Lexer);
        }
    }
}
