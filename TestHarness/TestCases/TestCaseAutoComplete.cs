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
    public class test_auto_complete_add_item : ISyncTestCase {
        private const string _Name = "test auto complete add item";
        private const string _Description = "tests that auto-complete add item is functional";
        public string TestFile { get { return "TestCaseAutoComplete.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            IAutoComplete autoComplete = new AutoComplete();
            IAutoCompleteItem item = new AutoCompleteItem();
            item.Value = "test";
            autoComplete.AddItem(item);
            result = autoComplete.Items.Contains(item);
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_auto_complete_add_item() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang_Editor_AutoComplete);
            this.feature.Add(TestCoverage.Lang_Editor_AutoComplete_Add_Item);

            this.coverage.Add(TestCoverage.Lang_Editor_AutoComplete);
            this.coverage.Add(TestCoverage.Lang_Editor_AutoComplete_Add_Item);
        }
    }
}