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
    public class neq_bool : ITestCase {
        private const string _Name = "neq bool,F_neq_bool";
        private const string _Description = "F.neq_bool";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (false  == F.neq_bool(true,true));
            result = result && (false  == F.neq_bool(false,false));
            result = result && (true == F.neq_bool(true,false));
            result = result && (true == F.neq_bool(false,true));
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
        public neq_bool() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_neq);
            this.feature.Add(TestCoverage.F_neq_bool);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_neq);
            this.coverage.Add(TestCoverage.F_neq_bool);
        }
    }
    [Export(typeof(ITestCase))]
    public class neq_char : ITestCase {
        private const string _Name = "neq char,F_neq_char";
        private const string _Description = "F.neq_char";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (false == F.neq_char('a', 'a'));
            result = result && (false == F.neq_char('A', 'A'));
            result = result && (false == F.neq_char(' ', ' '));
            result = result && (true  == F.neq_char('a', 'b'));
            result = result && (true  == F.neq_char('b', 'a'));
            result = result && (true  == F.neq_char('a', 'A'));
            result = result && (true  == F.neq_char('A', 'a'));
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
        public neq_char() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_neq);
            this.feature.Add(TestCoverage.F_neq_char);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_neq);
            this.coverage.Add(TestCoverage.F_neq_char);
        }
    }
    [Export(typeof(ITestCase))]
    public class neq_int : ITestCase {
        private const string _Name = "neq int,F_neq_int";
        private const string _Description = "F.neq_int";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (false == F.neq_int( 0, 0));
            result = result && (false == F.neq_int(-1,-1));
            result = result && (false == F.neq_int( 1, 1));
            result = result && (true  == F.neq_int( 0, 1));
            result = result && (true  == F.neq_int( 1, 0));
            result = result && (true  == F.neq_int( 0,-1));
            result = result && (true  == F.neq_int(-1, 0));
            result = result && (true  == F.neq_int( 1,-1));
            result = result && (true  == F.neq_int(-1, 1));
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
        public neq_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_neq);
            this.feature.Add(TestCoverage.F_neq_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_neq);
            this.coverage.Add(TestCoverage.F_neq_int);
        }
    }
    [Export(typeof(ITestCase))]
    public class neq_long : ITestCase {
        private const string _Name = "neq long,F_neq_long";
        private const string _Description = "F.neq_long";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (false == F.neq_long( 0L, 0L));
            result = result && (false == F.neq_long(-1L,-1L));
            result = result && (false == F.neq_long( 1L, 1L));
            result = result && (true  == F.neq_long( 0L, 1L));
            result = result && (true  == F.neq_long( 1L, 0L));
            result = result && (true  == F.neq_long( 0L,-1L));
            result = result && (true  == F.neq_long(-1L, 0L));
            result = result && (true  == F.neq_long( 1L,-1L));
            result = result && (true  == F.neq_long(-1L, 1L));
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
        public neq_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_neq);
            this.feature.Add(TestCoverage.F_neq_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_neq);
            this.coverage.Add(TestCoverage.F_neq_long);
        }
    }
    [Export(typeof(ITestCase))]
    public class neq_short : ITestCase {
        private const string _Name = "neq short,F_neq_short";
        private const string _Description = "F.neq_short";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (false == F.neq_short( 0, 0));
            result = result && (false == F.neq_short(-1,-1));
            result = result && (false == F.neq_short( 1, 1));
            result = result && (true  == F.neq_short( 0, 1));
            result = result && (true  == F.neq_short( 1, 0));
            result = result && (true  == F.neq_short( 0,-1));
            result = result && (true  == F.neq_short(-1, 0));
            result = result && (true  == F.neq_short( 1,-1));
            result = result && (true  == F.neq_short(-1, 1));
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
        public neq_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_neq);
            this.feature.Add(TestCoverage.F_neq_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_neq);
            this.coverage.Add(TestCoverage.F_neq_short);
        }
    }
    [Export(typeof(ITestCase))]
    public class neq_string : ITestCase {
        private const string _Name = "neq string,F_neq_string";
        private const string _Description = "F.neq_string";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (false == F.neq_string("test", "test"));
            result = result && (false == F.neq_string("", ""));
            result = result && (true  == F.neq_string("test", "TEST"));
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
        public neq_string() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_neq);
            this.feature.Add(TestCoverage.F_neq_string);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_neq);
            this.coverage.Add(TestCoverage.F_neq_string);
        }
    }
}
