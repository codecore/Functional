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
    public class test_editor_codedocument : ISyncTestCase {
        private const string _Name = "test editor_codeline";
        private const string _Description = "test edtor codeline";
        public string TestFile { get { return "TestCaseLanguageEditor.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            ICodeDocument document = new CodeDocument();
            ICodeLine codelineFirst = MemoryManager.New(document);
            document.AddBefore(codelineFirst); // codedocument = [(first)]
            result = result && (document.Cursor == codelineFirst);

            ICodeLine codelineAfter = MemoryManager.New(document);
            document.AddAfter(codelineAfter);  // codedocument = (first)[(after)]
            result = result && (document.Cursor == codelineAfter);
            
            ICodeLine codelineBefore = MemoryManager.New(document);
            document.AddBefore(codelineBefore); // codedocument = (first)[(before)](after)
            result = result && (document.Cursor == codelineBefore);

            document.MoveCursorPrev(); // codedocument = [(first)](before)(after)
            result = result && (document.Cursor == codelineFirst);
            document.MoveCursorNext(); // codedocument = (first)[(before)](after)
            result = result && (document.Cursor == codelineBefore);
            document.MoveCursorNext(); // codedocument = (first)(before)[(after)]
            result = result && (document.Cursor == codelineAfter);

            // Now test saturation
            foreach(int i in F.range(0,6)) document.MoveCursorPrev();
            result = result && (document.Cursor == codelineFirst);
            foreach (int i in F.range(0, 6)) document.MoveCursorNext();
            result = result && (document.Cursor == codelineAfter);


            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_editor_codedocument() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang);
            this.feature.Add(TestCoverage.Lang_Editor);
            this.feature.Add(TestCoverage.Lang_Editor_CodeDocument);
            this.feature.Add(TestCoverage.Lang_Editor_CodeDocument_AddFirst);
            this.feature.Add(TestCoverage.Lang_Editor_CodeDocument_AddBefore);
            this.feature.Add(TestCoverage.Lang_Editor_CodeDocument_AddAfter);
            this.feature.Add(TestCoverage.Lang_Editor_CodeDocument_MovePrev);
            this.feature.Add(TestCoverage.Lang_Editor_CodeDocument_MoveNext);

            this.coverage.Add(TestCoverage.Lang);
            this.coverage.Add(TestCoverage.Lang_Editor);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeDocument);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeDocument_AddFirst);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeDocument_AddBefore);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeDocument_AddAfter);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeDocument_MovePrev);
            this.coverage.Add(TestCoverage.Lang_Editor_CodeDocument_MoveNext);
            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_range);
            this.coverage.Add(TestCoverage.F_range_start_end);
        }
    }
}