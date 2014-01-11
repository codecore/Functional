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
    public class max_double : ITestCase {
        private const string _Name = "max double,F_max_double";
        private const string _Description = "F.max_double(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (1.0d == F.max_double(0.0d, 1.0d));
            result = result && (1.0d == F.max_double(1.0d, 0.0d));
            result = result && (1.0d == F.max_double(1.0d, 1.0d));
            result = result && (0.0d <  F.max_double(1.0d,-1.0d));
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
        public max_double() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_max);
            this.feature.Add(TestCoverage.F_max_double);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_max);
            this.coverage.Add(TestCoverage.F_max_double);
        }
    }

    [Export(typeof(ITestCase))]
    public class max_float : ITestCase {
        private const string _Name = "max float,F_max_float";
        private const string _Description = "F.max_float(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (1.0f == F.max_float(0.0f, 1.0f));
            result = result && (1.0f == F.max_float(1.0f, 0.0f));
            result = result && (1.0f == F.max_float(1.0f, 1.0f));
            result = result && (0.0f <  F.max_float(1.0f,-1.0f));
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
        public max_float() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_max);
            this.feature.Add(TestCoverage.F_max_float);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_max);
            this.coverage.Add(TestCoverage.F_max_float);
        }
    }


    [Export(typeof(ITestCase))]
    public class max_int : ITestCase {
        private const string _Name = "max int,F_max_int";
        private const string _Description = "F.max_int(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (1 == F.max_int(0, 1));
            result = result && (1 == F.max_int(1, 0));
            result = result && (1 == F.max_int(1, 1));
            result = result && (0 < F.max_int(1, -1));
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
        public max_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_max);
            this.feature.Add(TestCoverage.F_max_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_max);
            this.coverage.Add(TestCoverage.F_max_int);
        }
    }

    [Export(typeof(ITestCase))]
    public class max_long : ITestCase {
        private const string _Name = "max long,F_max_long";
        private const string _Description = "F.max_long(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (1L == F.max_long(0L, 1L));
            result = result && (1L == F.max_long(1L, 0L));
            result = result && (1L == F.max_long(1L, 1L));
            result = result && (0L <  F.max_long(1L,-1L));
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
        public max_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_max);
            this.feature.Add(TestCoverage.F_max_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_max);
            this.coverage.Add(TestCoverage.F_max_long);
        }
    }

    [Export(typeof(ITestCase))]
    public class max_short : ITestCase {
        private const string _Name = "max short,F_max_short";
        private const string _Description = "F.max_short(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (1 == F.max_short(0, 1));
            result = result && (1 == F.max_short(1, 0));
            result = result && (1 == F.max_short(1, 1));
            result = result && (0 <  F.max_short(1,-1));
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
        public max_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_max);
            this.feature.Add(TestCoverage.F_max_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_max);
            this.coverage.Add(TestCoverage.F_max_short);
        }
    }
}

