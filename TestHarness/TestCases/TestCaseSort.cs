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
    public class test_sort : ISyncTestCase {
        private const string _Name = "test_sort,F_T_sort_naked";
        private const string _Description = "sort a sequence of random integers using array sort";
        public string TestFile { get { return "TestCaseSort.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            IList<int> unsorted = new List<int>() { 9, 4, 6, 2, 1, 3, 7, 8, 4 };
            IList<int> sorted = new List<int>() { 1, 2, 3, 4, 4, 6, 7, 8, 9 };
            IList<int> reverse = new List<int>() { 9, 8, 7, 6, 4, 4, 3, 2, 1 };
            IEnumerable<int> test;

            test = F<int>.sort(unsorted, (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1);
            IEnumerator<int> eSorted = sorted.GetEnumerator();
            IEnumerator<int> e2 = test.GetEnumerator();
            while ((eSorted.MoveNext()) && (e2.MoveNext())) {
                result = result && (eSorted.Current == e2.Current);
            }
            result = result && (sorted.Count == test.ToList().Count);

            test = F<int>.sort(unsorted, (l, r) => (l == r) ? 0 : (l > r) ? -1 : 1);
            IEnumerator<int> eReverse = reverse.GetEnumerator();
            e2 = test.GetEnumerator();
            while ((eReverse.MoveNext()) && (e2.MoveNext())) {
                result = result && (eReverse.Current == e2.Current);
            }
            result = result && (reverse.Count == test.ToList().Count);
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_sort() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_sort);
            this.feature.Add(TestCoverage.F_T_sort_naked);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_sort);
            this.coverage.Add(TestCoverage.F_T_sort_naked);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_sort_order_by : ISyncTestCase {
        private const string _Name = "test_sort_order_by";
        private const string _Description = "sort a sequence of random integers using linq order by";
        public string TestFile { get { return "TestCaseSort.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            IList<int> unsorted = new List<int>() { 9, 4, 6, 2, 1, 3, 7, 8, 4 };
            IList<int> sorted = new List<int>() { 1, 2, 3, 4, 4, 6, 7, 8, 9 };
            IList<int> reverse = new List<int>() { 9, 8, 7, 6, 4, 4, 3, 2, 1 };
            IEnumerable<int> test;

            test = F<int>.sort_order_by(unsorted, (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1);
            IEnumerator<int> eSorted = sorted.GetEnumerator();
            IEnumerator<int> e2 = test.GetEnumerator();
            while ((eSorted.MoveNext()) && (e2.MoveNext())) {
                result = result && (eSorted.Current == e2.Current);
            }
            result = result && (sorted.Count == test.ToList().Count);

            test = F<int>.sort_order_by(unsorted, (l, r) => (l == r) ? 0 : (l > r) ? -1 : 1);
            IEnumerator<int> eReverse = reverse.GetEnumerator();
            e2 = test.GetEnumerator();
            while ((eReverse.MoveNext()) && (e2.MoveNext())) {
                result = result && (eReverse.Current == e2.Current);
            }
            result = result && (reverse.Count == test.ToList().Count);

            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_sort_order_by() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_sort);
            this.feature.Add(TestCoverage.F_T_sort_order_by);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_sort);
            this.coverage.Add(TestCoverage.F_T_sort_order_by);
        }
    }
}
