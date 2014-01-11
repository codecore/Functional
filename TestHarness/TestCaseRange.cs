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
    public class range_start_end : ITestCase {
        private const string _Name = "range start end,F_range_start_end";
        private const string _Description = "F.range(start,end) returns correct";
        private static Func<bool> _Run = () => {
            bool result = true;
            IEnumerable<int> r = F.range(0, 3);
            IEnumerator<int> e = r.GetEnumerator();
            int index = 0;
            while (e.MoveNext()) {
                result = result && (index == e.Current);
                index++;
            }
            result = result && (index == 3);
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
        public range_start_end() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_range);
            this.feature.Add(TestCoverage.F_range_start_end);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_range);
            this.coverage.Add(TestCoverage.F_range_start_end);
        }
    }

    [Export(typeof(ITestCase))]
    public class range_start_end_reverse : ITestCase {
        private const string _Name = "range start end reverse,F_range_start_end";
        private const string _Description = "F.range(start,end) where start > end returns decreasing sequence";
        private static Func<bool> _Run = () => {
            bool result = true;
            IEnumerable<int> r = F.range(6,3);
            IEnumerator<int> e = r.GetEnumerator();
            int index = 6;
            while (e.MoveNext()) {
                result = result && (index == e.Current);
                index--;
            }
            result = result && (index == 3);
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
        public range_start_end_reverse() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_range);
            this.feature.Add(TestCoverage.F_range_start_end);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_range);
            this.coverage.Add(TestCoverage.F_range_start_end);
        }
    }

    [Export(typeof(ITestCase))]
    public class range_end : ITestCase {
        private const string _Name = "range end,F_range_end";
        private const string _Description = "F.range(end) returns correct";
        private static Func<bool> _Run = () => {
            bool result = true;
            IEnumerable<int> r = F.range(3);
            IEnumerator<int> e = r.GetEnumerator();
            int index = 0;
            while (e.MoveNext()) {
                result = result && (index == e.Current);
                index++;
            }
            result = result && (index == 3);
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
        public range_end() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_range);
            this.feature.Add(TestCoverage.F_range_end);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_range);
            this.coverage.Add(TestCoverage.F_range_end);
        }
    }

    [Export(typeof(ITestCase))]
    public class range_start_end_step : ITestCase {
        private const string _Name = "range start end step,F_range_start_end_step";
        private const string _Description = "F.range(start,end,step) returns sequence with step";
        private static Func<bool> _Run = () => {
            bool result = true;
            IEnumerable<int> r = F.range(0,9,2);
            IEnumerator<int> e = r.GetEnumerator();
            int index = 0;
            while (e.MoveNext()) {
                result = result && (index == e.Current);
                index+=2;
            }
            result = result && (index == 10); //<---look for bug here
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
        public range_start_end_step() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_range);
            this.feature.Add(TestCoverage.F_range_start_end_step);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_range);
            this.coverage.Add(TestCoverage.F_range_start_end_step);
        }
    }
    [Export(typeof(ITestCase))]
    public class range_start_end_step_descending : ITestCase {
        private const string _Name = "range start end inverse step descending,F_range_start_end_step";
        private const string _Description = "F.range(start,end,step) returns descending sequence with step";
        private static Func<bool> _Run = () => {
            bool result = true;
            IEnumerable<int> r = F.range(17, 0, -3);
            IEnumerator<int> e = r.GetEnumerator();
            int index = 17;
            while (e.MoveNext()) {
                result = result && (index == e.Current);
                index -= 3;
            }
            result = result && (index == -2); //<---look for bug here
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
        public range_start_end_step_descending() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_range);
            this.feature.Add(TestCoverage.F_range_start_end_step);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_range);
            this.coverage.Add(TestCoverage.F_range_start_end_step);
        }
    }
}
