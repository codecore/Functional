using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;

using TestContracts;
using Tests;
namespace Tests {
    [Export(typeof(ISyncTestCase))]
    public class test_reduce_with_init : ISyncTestCase {
        private const string _Name = "test_reduce_with_init,F_T_reduce_init";
        private const string _Description = "verify reduce";
        public string TestFile { get { return "TestCaseReduce.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            Boolean result = true;
            result = result && ((6 + 3 + 24 + 17) == F<int>.reduce(new List<int> { 3, 24, 17 }, (x, y) => x + y, 6));

            bool containsEven = false;
            bool containsOdd = false;
            Func<int, bool> even = (x) => (0 == (0x01 & x));
            Func<int, bool> odd = (x) => !even(x);
            IEnumerable<int> test = new List<int>() { 1, 6, 3, 2, 4, 3, 3, 5 };
            containsEven = F<int>.reduce<bool>(test, (b, x) => (b || even(x)), false);
            containsOdd = F<int>.reduce<bool>(test, (b, x) => (b || odd(x)), false);
            result = result && (containsEven && containsOdd);
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_reduce_with_init() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T_reduce);
            this.feature.Add(TestCoverage.F_T_reduce_init);
            this.feature.Add(TestCoverage.F_T_reduce_U_init);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_reduce);
            this.coverage.Add(TestCoverage.F_T_reduce_init);
            this.coverage.Add(TestCoverage.F_T_reduce_U_init);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_reduce_one : ISyncTestCase {
        private const string _Name = "test_reduce_one,F_T_reduce_naked";
        private const string _Description = "from a sequence of ints, verfiy that the minimum and maximum values are returned";
        public string TestFile { get { return "TestCaseReduce.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            IEnumerable<int> seq = new List<int> { 1, 6, 3, 9, 4, 4, 12, -4, 0, 5 };
            result = result && (12 == F<int>.reduce(seq, (x, y) => (x > y) ? x : y));
            result = result && (-4 == F<int>.reduce(seq, (x, y) => (x < y) ? x : y));
            result = result && ((16 + 18 - 2) == F<int>.reduce(new List<int>() { 16, 18, -2 }, (x, y) => x + y));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_reduce_one() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_reduce);
            this.feature.Add(TestCoverage.F_T_reduce_naked);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_reduce);
            this.coverage.Add(TestCoverage.F_T_reduce_naked);
        }
    }
}
