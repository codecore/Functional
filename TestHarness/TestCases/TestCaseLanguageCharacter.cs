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
    [Export(typeof(ISyncTestCase))]
    public class test_character : ISyncTestCase {
        private const string _Name = "test character,Lang_Character";
        private const string _Description = "test character";
        public string TestFile { get { return "TestCaseLanguageCharacter.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            ICharacter ch = MemoryManager.New('a');
            result = result && (ch.Info == 'a');
            result = result && (ch.Kind == CharKind.ALPHA);
            MemoryManager.Delete(ch);
            
            ch = MemoryManager.New('"');
            result = result && (ch.Kind == CharKind.QUOTE);
            MemoryManager.Delete(ch);

            ch = MemoryManager.New(' ');
            result = result && (ch.Kind == CharKind.SPACE);
            MemoryManager.Delete(ch);

            foreach (char x in F.chars("~.?-+=!@#$%^&*()_><,';:[]{}\\|/'`")) {
                ch = MemoryManager.New(x);
                result = result && (ch.Kind == CharKind.PUNCTUATION);
                MemoryManager.Delete(ch);
            }
            ch = MemoryManager.New('\n');
            result = result && (ch.Kind == CharKind.CARRAGERETURN);
            MemoryManager.Delete(ch);
            ch = MemoryManager.New('\r');
            result = result && (ch.Kind == CharKind.LINEFEED);
            MemoryManager.Delete(ch);
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
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Character);

            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Character);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ICharacter);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ICharacter_New);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ICharacter_Delete);
            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_chars);
        }
    }
}

