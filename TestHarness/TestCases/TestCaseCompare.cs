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
    public class compare_bool : ITestCase {
        private const string _Name = "compare bool,F_compare_bool";
        private const string _Description = "F.compare_bool(x,y) returns -1 if x < y, 0 if x = y, and 1 if x > y";
        public string TestFile { get { return "TestCaseCompare.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (-1 == F.compare_bool(false,true));      //     false < true  => -1
            result = result && ( 0 == F.compare_bool(false,false));     //     false = false =>  0
            result = result && ( 0 == F.compare_bool(true,true));       //     true  = true  =>  0
            result = result && ( 1 == F.compare_bool(true,false));      //     true  > false =>  1
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public compare_bool() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_compare);
            this.feature.Add(TestCoverage.F_compare_bool);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_compare);
            this.coverage.Add(TestCoverage.F_compare_bool);
        }
    }

    [Export(typeof(ITestCase))]
    public class compare_char : ITestCase {
        private const string _Name = "compare char,F_compare_ char";
        private const string _Description = "F.compare_char(x,y) returns -1 if x < y, 0 if x = y, and 1 if x > y";
        public string TestFile { get { return "TestCaseCompare.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (-1 == F.compare_char('a','b'));  //     a < b => -1
            result = result && ( 0 == F.compare_char('a','a'));  //     a = a =>  0
            result = result && ( 1 == F.compare_char('b','a'));  //     b > a =>  1
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public compare_char() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_compare);
            this.feature.Add(TestCoverage.F_compare_char);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_compare);
            this.coverage.Add(TestCoverage.F_compare_char);
        }
    }

    [Export(typeof(ITestCase))]
    public class compare_int : ITestCase {
        private const string _Name = "compare int,F_compare_int";
        private const string _Description = "F.compare_int(x,y) returns -1 if x < y, 0 if x = y, and 1 if x > y";
        public string TestFile { get { return "TestCaseCompare.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (-1 == F.compare_int(7,8));  //     a < b => -1
            result = result && ( 0 == F.compare_int(3,3));  //     a = a =>  0
            result = result && ( 1 == F.compare_int(8,7));  //     b > a =>  1
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public compare_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_compare);
            this.feature.Add(TestCoverage.F_compare_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_compare);
            this.coverage.Add(TestCoverage.F_compare_int);

        }
    }

    [Export(typeof(ITestCase))]
    public class compare_long : ITestCase {
        private const string _Name = "compare long,F_compare_long";
        private const string _Description = "F.compare_long(x,y) returns -1 if x < y, 0 if x = y, and 1 if x > y";
        public string TestFile { get { return "TestCaseCompare.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (-1 == F.compare_long(7L,8L));  //     a < b => -1
            result = result && ( 0 == F.compare_long(3L,3L));  //     a = a =>  0
            result = result && ( 1 == F.compare_long(8L,7L));  //     b > a =>  1
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public compare_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_compare);
            this.feature.Add(TestCoverage.F_compare_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_compare);
            this.coverage.Add(TestCoverage.F_compare_long);
        }
    }

    [Export(typeof(ITestCase))]
    public class compare_short : ITestCase {
        private const string _Name = "compare short,F_compare_short";
        private const string _Description = "F.compare_short(x,y) returns -1 if x < y, 0 if x = y, and 1 if x > y";
        public string TestFile { get { return "TestCaseCompare.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (-1 == F.compare_short(7,8));  //     a < b => -1
            result = result && ( 0 == F.compare_short(3,3));  //     a = a =>  0
            result = result && ( 1 == F.compare_short(8,7));  //     b > a =>  1
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public compare_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_compare);
            this.feature.Add(TestCoverage.F_compare_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_compare);
            this.coverage.Add(TestCoverage.F_compare_short);
        }
    }

    [Export(typeof(ITestCase))]
    public class compare_string : ITestCase {
        private const string _Name = "compare string,F_compare_string";
        private const string _Description = "F.compare_string(x,y) returns -1 if x < y, 0 if x = y, and 1 if x > y";
        public string TestFile { get { return "TestCaseCompare.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (-1 == F.compare_string("abc","xyz"));  //     a < b => -1
            result = result && ( 0 == F.compare_string("fun","fun"));  //     a = a =>  0
            result = result && ( 1 == F.compare_string("xyz","abc"));  //     b > a =>  1
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public compare_string() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_compare);
            this.feature.Add(TestCoverage.F_compare_string);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_compare);
            this.coverage.Add(TestCoverage.F_compare_string);
        }
    }

    [Export(typeof(ITestCase))]
    public class compare_string_insensative : ITestCase {
        private const string _Name = "compare string insensative,F_compare_string_insensative";
        private const string _Description = "F.compare_string_insensative(x,y) returns -1 if x < y, 0 if x = y, and 1 if x > y";
        public string TestFile { get { return "TestCaseCompare.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (-1 == F.compare_string_case_insensative("Abc","xyz"));  //     a < b => -1
            result = result && ( 0 == F.compare_string_case_insensative("fun","FUn"));  //     a = a =>  0
            result = result && ( 1 == F.compare_string_case_insensative("xyz","Abc"));  //     b > a =>  1
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public compare_string_insensative() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_compare);
            this.feature.Add(TestCoverage.F_compare_string_insensative);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_compare);
            this.coverage.Add(TestCoverage.F_compare_string_insensative);
        }
    }

}

