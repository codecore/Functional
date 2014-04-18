using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using Functional.Language.Contract;
using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {
    [Export(typeof(ISyncTestCase))]
    public class test_character : ISyncTestCase {
        private const string _Name = "test character,Lang_Character";
        private const string _Description = "test character";
        public string TestFile { get { return "TestCaseLanguageCharacter.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            ICharacter ch = Character.Create('a');
            result = result && (ch.Info == 'a');
            result = result && (ch.Kind == CharKind.ALPHA);
            
            ch = Character.Create('"');
            result = result && (ch.Kind == CharKind.QUOTE);

            ch = Character.Create(' ');
            result = result && (ch.Kind == CharKind.SPACE);

            foreach (char x in F.chars("~?+=!@#$%^&*_><';:[]\\|/'`")) {
                ch = Character.Create(x);
                result = result && (ch.Kind == CharKind.PUNCTUATION);
            }
            ch = Character.Create('\n');
            result = result && (ch.Kind == CharKind.CARRAGERETURN);
            ch = Character.Create('\r');
            result = result && (ch.Kind == CharKind.LINEFEED);
            
            ch = Character.Create('.');
            result = result && (ch.Kind == CharKind.DOT);
            
            ch = Character.Create(',');
            result = result && (ch.Kind == CharKind.COMMA);

            ch = Character.Create('-');
            result = result && (ch.Kind == CharKind.DASH);

            ch = Character.Create('(');
            result = result && (ch.Kind == CharKind.OPEN_PAREN);

            ch = Character.Create(')');
            result = result && (ch.Kind == CharKind.CLOSE_PAREN);

            ch = Character.Create('{');
            result = result && (ch.Kind == CharKind.OPEN_SQ);

            ch = Character.Create('}');
            result = result && (ch.Kind == CharKind.CLOSE_SQ);

            foreach (char c in F.chars("0123456789")) {
                ch = Character.Create(c);
                result = result && (ch.Kind == CharKind.DIGIT);
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
        public test_character() {
            this.ID = TestCoverage.Lang_Character;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Character);

            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Character);
            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_chars);
        }
    }
}

