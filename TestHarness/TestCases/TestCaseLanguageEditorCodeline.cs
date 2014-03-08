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
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {
    [Export(typeof(ISyncTestCase))]
    public class test_editor_codeline : ISyncTestCase {
        private const string _Name = "test editor_codeline";
        private const string _Description = "test edtor codeline";
        public string TestFile { get { return "TestCaseLanguageEditor.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            ICodeDocument document = new CodeDocument();
            ICodeLine codeline = MemoryManager.New(document);
            document.AddBefore(codeline);
            
            result = result && (document.Cursor == codeline);
            
            IToken tokenFirst = MemoryManager.New(MemoryManager.New("filename", 0, 0, 10), "first", TokenKind.LiteralString);
            codeline.AddBefore(tokenFirst);  // codeline = [(first)]
            result = result && (codeline.Cursor == tokenFirst);
            IToken tokenAfter = MemoryManager.New(MemoryManager.New("filename", 0, 0, 10), "after", TokenKind.LiteralInteger);
            codeline.AddAfter(tokenAfter); // codeline = (first)[(after)]
            result = result && (codeline.Cursor == tokenAfter); // we set cursor to added item

            IToken tokenBefore = MemoryManager.New(MemoryManager.New("filename", 0, 0, 10), "before", TokenKind.LiteralFloat);
            codeline.AddBefore(tokenBefore); // codeline = (first)[(before)](after)
            result = result && (codeline.Cursor == tokenBefore);

            codeline.MoveCursorPrev(); // codeline = [(first)](before)(aft
            result = result && (codeline.Cursor == tokenFirst);
            codeline.MoveCursorNext(); // codeline - (first)[(before)](after)
            result = result && (codeline.Cursor == tokenBefore);
            codeline.MoveCursorNext(); // codeline = (first)(before)[(after)]
            result = result && (codeline.Cursor == tokenAfter);

            // now test saturation
            foreach (int i in F.range(0, 6)) codeline.MoveCursorPrev();
            result = result && (codeline.Cursor == tokenFirst);
            foreach (int i in F.range(0, 6)) codeline.MoveCursorNext();
            result = result && (codeline.Cursor == tokenAfter);
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_editor_codeline() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Editor);
            this.feature.Add(TestCoverage.Lang_Editor_CodeLine);
            this.feature.Add(TestCoverage.Lang_Editor_CodeLine_AddFirst);
            this.feature.Add(TestCoverage.Lang_Editor_CodeLine_AddBefore);
            this.feature.Add(TestCoverage.Lang_Editor_CodeLine_AddAfter);
            this.feature.Add(TestCoverage.Lang_Editor_CodeLine_MovePrev);
            this.feature.Add(TestCoverage.Lang_Editor_CodeLine_MoveNext);

            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Editor);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeDocument);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeDocument_AddFirst);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeLine);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeLine_AddFirst);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeLine_AddBefore);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeLine_AddAfter);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeLine_MovePrev);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeLine_MoveNext);
            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_range);
            this.coverage.Add(TestCoverage.F_range_start_end);
        }
    }
}