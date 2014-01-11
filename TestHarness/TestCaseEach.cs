using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;

using Tests;
namespace Tests {
    [Export(typeof(ITestCase))]
    public class test_each : ITestCase {
        private const string _Name = "test_each,F_T_each_naked";
        private const string _Description = "verify an action is called with each item in the sequence <h, e, l, l, o>";
        private static bool _Run() {
            bool result = true;
            string hello = "";
            F<char>.each(new List<char>() { 'h', 'e', 'l', 'l', 'o' }, (c) => { hello = hello + c; });
            result = result && ("hello" == hello);
            return result;
        }
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
        public test_each() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_each);
            this.feature.Add(TestCoverage.F_T_each_naked);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_each);
            this.coverage.Add(TestCoverage.F_T_each_naked);
        }
    }
}
