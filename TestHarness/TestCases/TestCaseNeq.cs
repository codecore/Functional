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
    public class neq_bool : ISyncTestCase {
        private const string _Name = "neq bool";
        private const string _Description = "F.neq_bool";
        public string TestFile { get { return "TestCaseNeq.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (false  == F.neq_bool(true,true));
            result = result && (false  == F.neq_bool(false,false));
            result = result && (true == F.neq_bool(true,false));
            result = result && (true == F.neq_bool(false,true));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
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

    [Export(typeof(ISyncTestCase))]
    public class neq_char : ISyncTestCase {
        private const string _Name = "neq char,F_neq_char";
        private const string _Description = "F.neq_char";
        public string TestFile { get { return "TestCaseNeq.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (false == F.neq_char('a', 'a'));
            result = result && (false == F.neq_char('A', 'A'));
            result = result && (false == F.neq_char(' ', ' '));
            result = result && (true  == F.neq_char('a', 'b'));
            result = result && (true  == F.neq_char('b', 'a'));
            result = result && (true  == F.neq_char('a', 'A'));
            result = result && (true  == F.neq_char('A', 'a'));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
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

    [Export(typeof(ISyncTestCase))]
    public class neq_int : ISyncTestCase {
        private const string _Name = "neq int,F_neq_int";
        private const string _Description = "F.neq_int";
        public string TestFile { get { return "TestCaseNeq.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
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
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
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

    [Export(typeof(ISyncTestCase))]
    public class neq_long : ISyncTestCase {
        private const string _Name = "neq long,F_neq_long";
        private const string _Description = "F.neq_long";
        public string TestFile { get { return "TestCaseNeq.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
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
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
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

    [Export(typeof(ISyncTestCase))]
    public class neq_short : ISyncTestCase {
        private const string _Name = "neq short";
        private const string _Description = "F.neq_short";
        public string TestFile { get { return "TestCaseNeq.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
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
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
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

    [Export(typeof(ISyncTestCase))]
    public class neq_string : ISyncTestCase {
        private const string _Name = "neq string,F_neq_string";
        private const string _Description = "F.neq_string";
        public string TestFile { get { return "TestCaseNeq.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (false == F.neq_string("test", "test"));
            result = result && (false == F.neq_string("", ""));
            result = result && (true  == F.neq_string("test", "TEST"));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
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
