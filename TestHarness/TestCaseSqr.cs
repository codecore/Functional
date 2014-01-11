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
    public class sqr_double : ITestCase {
        private const string _Name = "sqr double,F_sqr_double";
        private const string _Description = "F.sqr_double(X) returns X * X";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && F.close_double(25.0d,F.sqr_double(5.0d));
            result = result && F.close_double( 4.0d,F.sqr_double( 2.0d));
            result = result && F.close_double( 1.0d,F.sqr_double( 1.0d));
            result = result && F.close_double( 1.0d,F.sqr_double(-1.0d));
            result = result && F.close_double( 0.0d,F.sqr_double( 0.0d));
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
        public sqr_double() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_sqr);
            this.feature.Add(TestCoverage.F_sqr_double);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_sqr);
            this.coverage.Add(TestCoverage.F_sqr_double);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_double);
        }
    }
    [Export(typeof(ITestCase))]
    public class sqr_float : ITestCase {
        private const string _Name = "sqr float,F_sqr_float";
        private const string _Description = "F.sqr_float(X) returns X * X";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && F.close_float(25.0f, F.sqr_float( 5.0f));
            result = result && F.close_float( 4.0f, F.sqr_float( 2.0f));
            result = result && F.close_float( 1.0f, F.sqr_float( 1.0f));
            result = result && F.close_float( 1.0f, F.sqr_float(-1.0f));
            result = result && F.close_float( 0.0f, F.sqr_float( 0.0f));
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
        public sqr_float() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_sqr);
            this.feature.Add(TestCoverage.F_sqr_float);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_sqr);
            this.coverage.Add(TestCoverage.F_sqr_float);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_float);
        }
    }
    [Export(typeof(ITestCase))]
    public class sqr_int : ITestCase {
        private const string _Name = "sqr int,F_sqr_int";
        private const string _Description = "F.sqr_int(X) returns X * X";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (25 == F.sqr_int( 5));
            result = result && ( 4 == F.sqr_int( 2));
            result = result && ( 1 == F.sqr_int( 1));
            result = result && ( 1 == F.sqr_int(-1));
            result = result && ( 0 == F.sqr_int( 0));
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
        public sqr_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_sqr);
            this.feature.Add(TestCoverage.F_sqr_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_sqr);
            this.coverage.Add(TestCoverage.F_sqr_int);
        }
    }
    [Export(typeof(ITestCase))]
    public class sqr_long : ITestCase {
        private const string _Name = "sqr long,F_sqr_long";
        private const string _Description = "F.sqr_long(X) returns X * X";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (25L == F.sqr_long( 5L));
            result = result && ( 4L == F.sqr_long( 2L));
            result = result && ( 1L == F.sqr_long( 1L));
            result = result && ( 1L == F.sqr_long(-1L));
            result = result && ( 0L == F.sqr_long( 0L));
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
        public sqr_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_sqr);
            this.feature.Add(TestCoverage.F_sqr_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_sqr);
            this.coverage.Add(TestCoverage.F_sqr_long);
        }
    }
    [Export(typeof(ITestCase))]
    public class sqr_short : ITestCase {
        private const string _Name = "sqr short,F_sqr_short";
        private const string _Description = "F.sqr_short(X) returns X * X";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (25 == F.sqr_short( 5));
            result = result && ( 4 == F.sqr_short( 2));
            result = result && ( 1 == F.sqr_short( 1));
            result = result && ( 1 == F.sqr_short(-1));
            result = result && ( 0 == F.sqr_short( 0));;
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
        public sqr_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_sqr);
            this.feature.Add(TestCoverage.F_sqr_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_sqr);
            this.coverage.Add(TestCoverage.F_sqr_short);
        }
    }
}
