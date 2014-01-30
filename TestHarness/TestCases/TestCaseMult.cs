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
    public class mult_double : ITestCase {
        private const string _Name = "mult double,F_mult_double";
        private const string _Description = "F.mult_double(X,Y) returns X * Y";
        public string TestFile { get { return "TestCaseMult.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && F.close_double( 30.0d, F.mult_double( 5.0d, 6.0d));
            result = result && F.close_double(  6.0d, F.mult_double( 2.0d, 3.0d));
            result = result && F.close_double(  1.0d, F.mult_double( 1.0d, 1.0d));
            result = result && F.close_double(-12.0d, F.mult_double(-3.0d, 4.0d));
            result = result && F.close_double(-24.0d, F.mult_double(  8.0d,-3.0d));
            result = result && F.close_double(  0.0d, F.mult_double( 0.0d, 7.0d));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public mult_double() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_mult);
            this.feature.Add(TestCoverage.F_mult_double);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_mult);
            this.coverage.Add(TestCoverage.F_mult_double);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_double);
        }
    }
    [Export(typeof(ITestCase))]
    public class mult_float : ITestCase {
        private const string _Name = "mult float,F_mult_double";
        private const string _Description = "F.mult_float(X,Y) returns X * Y";
        public string TestFile { get { return "TestCaseMult.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && F.close_float( 30.0f, F.mult_float( 5.0f, 6.0f));
            result = result && F.close_float(  6.0f, F.mult_float( 2.0f, 3.0f));
            result = result && F.close_float(  1.0f, F.mult_float( 1.0f, 1.0f));
            result = result && F.close_float(-12.0f, F.mult_float(-3.0f, 4.0f));
            result = result && F.close_float(-24.0f, F.mult_float(  8.0f,-3.0f));
            result = result && F.close_float(  0.0f, F.mult_float( 0.0f, 7.0f));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public mult_float() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_mult);
            this.feature.Add(TestCoverage.F_mult_float);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_mult);
            this.coverage.Add(TestCoverage.F_mult_float);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_float);
        }
    }
    [Export(typeof(ITestCase))]
    public class mult_int : ITestCase {
        private const string _Name = "mult int,F_mult_int";
        private const string _Description = "F.mult_int(X,Y) returns X * Y";
        public string TestFile { get { return "TestCaseMult.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && ( 30 == F.mult_int( 5, 6));
            result = result && (  6 == F.mult_int( 2, 3));
            result = result && (  1 == F.mult_int( 1, 1));
            result = result && (-12 == F.mult_int(-3, 4));
            result = result && (-24 == F.mult_int( 8,-3));
            result = result && (  0 == F.mult_int( 0, 7));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public mult_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_mult);
            this.feature.Add(TestCoverage.F_mult_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_mult);
            this.coverage.Add(TestCoverage.F_mult_int);
        }
    }
    [Export(typeof(ITestCase))]
    public class mult_long : ITestCase {
        private const string _Name = "mult long,F_mult_long";
        private const string _Description = "F.mult_long(X,Y) returns X * Y";
        public string TestFile { get { return "TestCaseMult.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && ( 30L == F.mult_long( 5L, 6L));
            result = result && (  6L == F.mult_long( 2L, 3L));
            result = result && (  1L == F.mult_long( 1L, 1L));
            result = result && (-12L == F.mult_long(-3L, 4L));
            result = result && (-24L == F.mult_long( 8L,-3L));
            result = result && (  0L == F.mult_long( 0L, 7L));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public mult_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_mult);
            this.feature.Add(TestCoverage.F_mult_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_mult);
            this.coverage.Add(TestCoverage.F_sqr_long);
        }
    }
    [Export(typeof(ITestCase))]
    public class mult_short : ITestCase {
        private const string _Name = "mult short,F_mult_short";
        private const string _Description = "F.mult_short(X,Y) returns X * Y";
        public string TestFile { get { return "TestCaseMult.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && ( 30 == F.mult_short( 5, 6));
            result = result && (  6 == F.mult_short( 2, 3));
            result = result && (  1 == F.mult_short( 1, 1));
            result = result && (-12 == F.mult_short(-3, 4));
            result = result && (-24 == F.mult_short( 8,-3));
            result = result && (  0 == F.mult_short( 0, 7));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public mult_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_mult);
            this.feature.Add(TestCoverage.F_mult_short);
            
            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_mult);
            this.coverage.Add(TestCoverage.F_mult_short);
        }
    }
}
