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
    public class sub_double : ITestCase {
        private const string _Name = "dub double,F_sub_double";
        private const string _Description = "F.sub_double() returns correct";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (F.close_double( 3.0d, F.sub_double( 5.0d, 2.0d))); 
            result = result && (F.close_double(-5.0d, F.sub_double(-3.0d, 2.0d)));
            result = result && (F.close_double( 0.0d, F.sub_double( 3.0d, 3.0d)));
            result = result && (F.close_double( 2.0d, F.sub_double( 7.0d, 5.0d)));
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
        public sub_double() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_sub);
            this.feature.Add(TestCoverage.F_sub_double);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_sub);
            this.coverage.Add(TestCoverage.F_sub_double);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_double);
        }
    }

    [Export(typeof(ITestCase))]
    public class sub_float : ITestCase {
        private const string _Name = "sub float,F_sub_float";
        private const string _Description = "F.sub_float() returns correct";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (F.close_float( 3.0f, F.sub_float( 5.0f, 2.0f))); 
            result = result && (F.close_float(-5.0f, F.sub_float(-3.0f, 2.0f)));
            result = result && (F.close_float( 0.0f, F.sub_float( 3.0f, 3.0f)));
            result = result && (F.close_float( 2.0f, F.sub_float( 7.0f, 5.0f)));
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
        public sub_float() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_sub);
            this.feature.Add(TestCoverage.F_sub_float);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_sub);
            this.coverage.Add(TestCoverage.F_sub_float);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_float);
        }
    }

    [Export(typeof(ITestCase))]
    public class sub_int : ITestCase {
        private const string _Name = "sub int,F_sub_int";
        private const string _Description = "F.sub_int() returns correct";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && ( 3 == F.sub_int( 5, 2));
            result = result && (-5 == F.sub_int(-3, 2));
            result = result && ( 0 == F.sub_int( 3, 3));
            result = result && ( 2 == F.sub_int( 7, 5));
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
        public sub_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_sub);
            this.feature.Add(TestCoverage.F_sub_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_sub);
            this.coverage.Add(TestCoverage.F_sub_int);
        }
    }

    [Export(typeof(ITestCase))]
    public class sub_long : ITestCase {
        private const string _Name = "sub long,F_sub_long";
        private const string _Description = "F.sub_long() returns correct";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && ( 3L == F.sub_long( 5L, 2L));
            result = result && (-5L == F.sub_long(-3L, 2L));
            result = result && ( 0L == F.sub_long( 3L, 3L));
            result = result && ( 2L == F.sub_long( 7L, 5L));
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
        public sub_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_sub);
            this.feature.Add(TestCoverage.F_sub_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_sub);
            this.coverage.Add(TestCoverage.F_sub_long);
        }
    }

    [Export(typeof(ITestCase))]
    public class sub_short : ITestCase {
        private const string _Name = "sub short,F_add_short";
        private const string _Description = "F.sub_short() returns correct";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && ( 3 == F.sub_short( 5, 2));
            result = result && (-5 == F.sub_short(-3, 2));
            result = result && ( 0 == F.sub_short( 3, 3));
            result = result && ( 2 == F.sub_short( 7, 5));
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
        public sub_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_sub);
            this.feature.Add(TestCoverage.F_sub_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_sub);
            this.coverage.Add(TestCoverage.F_sub_short);
        }
    }
}

