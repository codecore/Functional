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
    [Export(typeof(ITestCase))]
    public class min_double : ITestCase {
        private const string _Name = "min double,F_min_double";
        private const string _Description = "F.min_double(left,right) works correctly";
        public string TestFile { get { return "TestCaseMin.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (0.0d == F.min_double(0.0d,1.0d));
            result = result && (0.0d == F.min_double(1.0d,0.0d));
            result = result && (1.0d == F.min_double(1.0d,1.0d));
            result = result && (0.0d > F.min_double(1.0d,-1.0d));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public min_double() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_min);
            this.feature.Add(TestCoverage.F_min_double);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_min);
            this.coverage.Add(TestCoverage.F_min_double);
        }
    }

    [Export(typeof(ITestCase))]
    public class min_float : ITestCase {
        private const string _Name = "min float,F_min_float";
        private const string _Description = "F.min_float(left,right) works correctly";
        public string TestFile { get { return "TestCaseMin.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (0.0f == F.min_float(0.0f, 1.0f));
            result = result && (0.0f == F.min_float(1.0f, 0.0f));
            result = result && (1.0f == F.min_float(1.0f, 1.0f));
            result = result && (0.0f >  F.min_float(1.0f,-1.0f));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public min_float() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_min);
            this.feature.Add(TestCoverage.F_min_float);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_min);
            this.coverage.Add(TestCoverage.F_min_float);
        }
    }


    [Export(typeof(ITestCase))]
    public class min_int : ITestCase {
        private const string _Name = "min int,F_min_int";
        private const string _Description = "F.min_int(left,right) works correctly";
        public string TestFile { get { return "TestCaseMin.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (0 == F.min_int( 0, 1));
            result = result && (0 == F.min_int( 1, 0));
            result = result && (1 == F.min_int( 1, 1));
            result = result && (0 >  F.min_int( 1,-1));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public min_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_min);
            this.feature.Add(TestCoverage.F_min_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_min);
            this.coverage.Add(TestCoverage.F_min_int);
        }
    }

    [Export(typeof(ITestCase))]
    public class min_long : ITestCase {
        private const string _Name = "min long,F_min_long";
        private const string _Description = "F.min_long(left,right) works correctly";
        public string TestFile { get { return "TestCaseMin.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (0L == F.min_long(0L, 1L));
            result = result && (0L == F.min_long(1L, 0L));
            result = result && (1L == F.min_long(1L, 1L));
            result = result && (0L >  F.min_long(1L,-1L));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public min_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_min);
            this.feature.Add(TestCoverage.F_min_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_min);
            this.coverage.Add(TestCoverage.F_min_long);
        }
    }

    [Export(typeof(ITestCase))]
    public class min_short : ITestCase {
        private const string _Name = "min short,F_short_int";
        private const string _Description = "F.min_short(left,right) works correctly";
        public string TestFile { get { return "TestCaseMin.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (0 == F.min_short(0, 1));
            result = result && (0 == F.min_short(1, 0));
            result = result && (1 == F.min_short(1, 1));
            result = result && (0 > F.min_short(1, -1));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public min_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_min);
            this.feature.Add(TestCoverage.F_min_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_min);
            this.coverage.Add(TestCoverage.F_min_short);
        }
    }
}
