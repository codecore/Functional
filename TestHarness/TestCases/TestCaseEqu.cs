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
    public class equ_bool : ITestCase {
        private const string _Name = "equ bool,F_equ_bool";
        private const string _Description = "F.equ_bool";
        public string TestFile { get { return "TestCaseEqu.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.equ_bool(true,true));
            result = result && (true  == F.equ_bool(false,false));
            result = result && (false == F.equ_bool(true,false));
            result = result && (false == F.equ_bool(false,true));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public equ_bool() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_equ);
            this.feature.Add(TestCoverage.F_equ_bool);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_equ);
            this.coverage.Add(TestCoverage.F_equ_bool);
        }
    }
    [Export(typeof(ITestCase))]
    public class equ_char : ITestCase {
        private const string _Name = "equ char,F_equ_char";
        private const string _Description = "F.equ_char";
        public string TestFile { get { return "TestCaseEqu.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true == F.equ_char('a','a'));
            result = result && (true == F.equ_char('A','A'));
            result = result && (true == F.equ_char(' ',' '));
            result = result && (false == F.equ_char('a','b'));
            result = result && (false == F.equ_char('b','a'));
            result = result && (false == F.equ_char('a','A'));
            result = result && (false == F.equ_char('A','a'));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public equ_char() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_equ);
            this.feature.Add(TestCoverage.F_equ_char);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_equ);
            this.coverage.Add(TestCoverage.F_equ_char);
        }
    }
    [Export(typeof(ITestCase))]
    public class equ_int : ITestCase {
        private const string _Name = "equ int,F_equ_int";
        private const string _Description = "F.equ_int";
        public string TestFile { get { return "TestCaseEqu.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true == F.equ_int(0, 0));
            result = result && (true == F.equ_int(-1, -1));
            result = result && (true == F.equ_int(1, 1));
            result = result && (false == F.equ_int(0, 1));
            result = result && (false == F.equ_int(1, 0));
            result = result && (false == F.equ_int(0, -1));
            result = result && (false == F.equ_int(-1, 0));
            result = result && (false == F.equ_int(1, -1));
            result = result && (false == F.equ_int(-1, 1));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public equ_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_equ);
            this.feature.Add(TestCoverage.F_equ_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_equ);
            this.coverage.Add(TestCoverage.F_equ_int);
        }
    }
    [Export(typeof(ITestCase))]
    public class equ_long : ITestCase {
        private const string _Name = "equ long,F_equ_long";
        private const string _Description = "F.equ_long";
        public string TestFile { get { return "TestCaseEqu.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.equ_long( 0L, 0L));
            result = result && (true  == F.equ_long(-1L,-1L));
            result = result && (true  == F.equ_long( 1L, 1L));
            result = result && (false == F.equ_long( 0L, 1L));
            result = result && (false == F.equ_long( 1L, 0L));
            result = result && (false == F.equ_long( 0L,-1L));
            result = result && (false == F.equ_long(-1L, 0L));
            result = result && (false == F.equ_long( 1L,-1L));
            result = result && (false == F.equ_long(-1L, 1L));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public equ_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_equ);
            this.feature.Add(TestCoverage.F_equ_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_equ);
            this.coverage.Add(TestCoverage.F_equ_long);
        }
    }
    [Export(typeof(ITestCase))]
    public class equ_short : ITestCase {
        private const string _Name = "equ short,F_equ_short";
        private const string _Description = "F.equ_short";
        public string TestFile { get { return "TestCaseEqu.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.equ_short(0, 0));
            result = result && (true  == F.equ_short(-1,-1));
            result = result && (true  == F.equ_short( 1, 1));
            result = result && (false == F.equ_short( 0, 1));
            result = result && (false == F.equ_short( 1, 0));
            result = result && (false == F.equ_short( 0,-1));
            result = result && (false == F.equ_short(-1, 0));
            result = result && (false == F.equ_short( 1,-1));
            result = result && (false == F.equ_short(-1, 1));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public equ_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_equ);
            this.feature.Add(TestCoverage.F_equ_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_equ);
            this.coverage.Add(TestCoverage.F_equ_short);
        }
    }
    [Export(typeof(ITestCase))]
    public class equ_string : ITestCase {
        private const string _Name = "equ string,F_equ_string";
        private const string _Description = "F.equ_string";
        public string TestFile { get { return "TestCaseEqu.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.equ_string("test","test"));
            result = result && (true  == F.equ_string("",""));
            result = result && (false == F.equ_string("test","TEST"));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public equ_string() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_equ);
            this.feature.Add(TestCoverage.F_equ_string);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_equ);
            this.coverage.Add(TestCoverage.F_equ_string);;
        }
    }
}
