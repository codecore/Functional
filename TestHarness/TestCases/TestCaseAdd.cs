using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {
    [Export(typeof(ISyncTestCase))]
    public class add_double : ISyncTestCase {
        private const string _Name = "add double,F_add_double";
        private const string _Description = "F.add_double() returns correct";
        public string TestFile { get { return "TestCaseAdd.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (F.close_double( 3.0d, F.add_double( 1.0d, 2.0d))); // p + p
            result = result && (F.close_double(-5.0d, F.add_double(-3.0d,-2.0d))); // n + n
            result = result && (F.close_double( 0.0d, F.add_double( 3.0d,-3.0d))); // p + n
            result = result && (F.close_double( 0.0d, F.add_double(-3.0d, 3.0d))); // n + p
            result = result && (F.close_double( 4.0d, F.add_double( 0.0d, 4.0d))); // 0 + p
            result = result && (F.close_double( 5.0d, F.add_double( 5.0d, 0.0d))); // p + 0
            result = result && (F.close_double(-6.0d, F.add_double( 0.0d,-6.0d))); // 0 + n
            result = result && (F.close_double(-7.0d, F.add_double(-7.0d, 0.0d))); // n + 0
            result = result && (F.close_double( 0.0d, F.add_double( 0.0d, 0.0d))); // 0 + 0
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public add_double() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_add);
            this.feature.Add(TestCoverage.F_add_double);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_add);
            this.coverage.Add(TestCoverage.F_add_double);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_double);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class add_float : ISyncTestCase {
        private const string _Name = "add float,F_add_float";
        private const string _Description = "F.add_float() returns correct";
        public string TestFile { get { return "TestCaseAdd.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (F.close_float( 3.0f, F.add_float( 1.0f, 2.0f))); // p + p
            result = result && (F.close_float(-5.0f, F.add_float(-3.0f,-2.0f))); // n + n
            result = result && (F.close_float( 0.0f, F.add_float( 3.0f,-3.0f))); // p + n
            result = result && (F.close_float( 0.0f, F.add_float(-3.0f, 3.0f))); // n + p
            result = result && (F.close_float( 4.0f, F.add_float( 0.0f, 4.0f))); // 0 + p
            result = result && (F.close_float( 5.0f, F.add_float( 5.0f, 0.0f))); // p + 0
            result = result && (F.close_float(-6.0f, F.add_float( 0.0f,-6.0f))); // 0 + n
            result = result && (F.close_float(-7.0f, F.add_float(-7.0f, 0.0f))); // n + 0
            result = result && (F.close_float( 0.0f, F.add_float( 0.0f, 0.0f))); // 0 + 0
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public add_float() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;
     
            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_add);
            this.feature.Add(TestCoverage.F_add_float);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_add);
            this.coverage.Add(TestCoverage.F_add_float);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_float);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class add_int : ISyncTestCase {
        private const string _Name = "add int,F_add_int";
        private const string _Description = "F.add_int() returns correct";
        public string TestFile { get { return "TestCaseAdd.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && ( 7 == F.add_int(5, 2));
            result = result && (-1 == F.add_int(-3, 2));
            result = result && ( 6 == F.add_int(3, 3));
            result = result && (12 == F.add_int(7, 5));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public add_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_add);
            this.feature.Add(TestCoverage.F_add_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_add);
            this.coverage.Add(TestCoverage.F_add_int);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class add_long : ISyncTestCase {
        private const string _Name = "add long,F_add_long";
        private const string _Description = "F.add_long() returns correct";
        public string TestFile { get { return "TestCaseAdd.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && ( 7L == F.add_long( 5L, 2L));
            result = result && (-1L == F.add_long(-3L, 2L));
            result = result && ( 6L == F.add_long( 3L, 3L));
            result = result && (12L == F.add_long( 7L, 5L));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public add_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_add);
            this.feature.Add(TestCoverage.F_add_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_add);
            this.coverage.Add(TestCoverage.F_add_long);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class add_short : ISyncTestCase {
        private const string _Name = "add short,F_add_short";
        private const string _Description = "F.add_short() returns correct";
        public string TestFile { get { return "TestCaseAdd.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && ( 7 == F.add_short( 5, 2));
            result = result && (-1 == F.add_short(-3, 2));
            result = result && ( 6 == F.add_short( 3, 3));
            result = result && (12 == F.add_short( 7, 5));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public add_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_add);
            this.feature.Add(TestCoverage.F_add_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_add);
            this.coverage.Add(TestCoverage.F_add_short);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class add_string : ISyncTestCase {
        private const string _Name = "add string,F_add_string";
        private const string _Description = "F.add_string() returns correct";
        public string TestFile { get { return "TestCaseAdd.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result.And(F.equ_string("test", F.add_string("", "test"))); // p + p
            result = result.And(F.equ_string("test", F.add_string("t", "est"))); // n + n
            result = result.And(F.equ_string("test", F.add_string("te", "st"))); // p + n
            result = result.And(F.equ_string("test", F.add_string("tes", "t"))); // n + p
            result = result.And(F.equ_string("test", F.add_string("test", ""))); // 0 + p
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public add_string() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_add);
            this.feature.Add(TestCoverage.F_add_string);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_add);
            this.coverage.Add(TestCoverage.F_add_string);
            this.coverage.Add(TestCoverage.F_equ);
            this.coverage.Add(TestCoverage.F_equ_string);
            this.coverage.Add(TestCoverage.bool_);
            this.coverage.Add(TestCoverage.bool_And);
        }
    }

}
