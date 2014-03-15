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
using Functional.Language.Contract.Editor;
using Functional.Language.Implimentation;
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {
    [Export(typeof(ISyncTestCase))]
    public class test_memory_manager : ISyncTestCase {
        private const string _Name = "test memory manager";
        private const string _Description = "test memory manager";
        public string TestFile { get { return "TestCaseMemoryManager.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            ICharacter ch = null;
            ch = MemoryManager.New('a');
            MemoryManager.Delete(ch);
            result = result && (MemoryManager.Avail_Character() == ch);

            ILocation location = null;
            location = MemoryManager.New("filename", 1, 2, 5);
            MemoryManager.Delete(location);
            result = result && (MemoryManager.Avail_Location() == location);

            location = MemoryManager.New("xyz", 2, 2, 12);
            IToken token = MemoryManager.New(location, "token", TokenKind.LiteralString);
            MemoryManager.Delete(token); // deletes Location also
            result = result && (MemoryManager.Avail_Location() == location);
            result = result && (MemoryManager.Avail_Token() == token);

            ICodeLine codeline = null;
            CodeDocument document = new CodeDocument();
            codeline = MemoryManager.New(document);
            MemoryManager.Delete(codeline);
            result = result && (MemoryManager.Avail_CodeLine() == codeline);

            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_memory_manager() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Memory_Manager);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_ICharacter);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_ICharacter_New);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_ICharacter_Delete);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_ILocation);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_ILocation_New);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_ILocation_Delete);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_IToken);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_IToken_New);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_IToken_Delete);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_ICodeLine);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_ICodeLine_New);
            this.feature.Add(TestCoverage.Lang_Memory_Manager_ICodeLine_Delete);


            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ICharacter);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ICharacter_New);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ICharacter_Delete);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ILocation);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ILocation_New);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ILocation_Delete);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_IToken);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_IToken_New);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_IToken_Delete);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ICodeLine);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ICodeLine_New);
            this.coverage.Add(TestCoverage.Lang_Memory_Manager_ICodeLine_Delete);
        }
    }
}

