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
    public class always_functioin_true : ITestCase {
        private const string _Name = "always function true,F_always_function ";
        private const string _Description = "F.always(true) return alwaysTrue";
        public string TestFile { get { return "TestCaseAlways.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Func<bool> fn = F.always(true);
            result = result.And(F.equ_bool(true, fn.Invoke()));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public always_functioin_true() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_always);
            this.feature.Add(TestCoverage.F_always_function);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_always);
            this.coverage.Add(TestCoverage.F_always_function);
            this.coverage.Add(TestCoverage.F_equ);
            this.coverage.Add(TestCoverage.F_equ_bool);
            this.coverage.Add(TestCoverage.bool_);
            this.coverage.Add(TestCoverage.bool_And);
        }
    }


    [Export(typeof(ITestCase))]
    public class always_functioin_false : ITestCase {
        private const string _Name = "always function false,F_always_function ";
        private const string _Description = "F.always(false) return alwaysFalse";
        public string TestFile { get { return "TestCaseAlways.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Func<bool> fn = F.always(false);
            result = result.And(F.equ_bool(false, fn.Invoke()));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public always_functioin_false() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_always);
            this.feature.Add(TestCoverage.F_always_function);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_always);
            this.coverage.Add(TestCoverage.F_always_function);
            this.coverage.Add(TestCoverage.F_equ);
            this.coverage.Add(TestCoverage.F_equ_bool);
            this.coverage.Add(TestCoverage.bool_);
            this.coverage.Add(TestCoverage.bool_And);
        }
    }

    [Export(typeof(ITestCase))]
    public class always_true : ITestCase {
        private const string _Name = "always true,F_always_true ";
        private const string _Description = "F.alwaysTrue() returns true";
        public string TestFile { get { return "TestCaseAlways.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Func<bool> b = F.alwaysTrue.Invoke();
            result = result.And(F.equ_bool(true, b.Invoke()));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public always_true() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_always);
            this.feature.Add(TestCoverage.F_always_true);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_always);
            this.coverage.Add(TestCoverage.F_always_true);
            this.coverage.Add(TestCoverage.F_equ);
            this.coverage.Add(TestCoverage.F_equ_bool);
            this.coverage.Add(TestCoverage.bool_);
            this.coverage.Add(TestCoverage.bool_And);
        }
    }

    [Export(typeof(ITestCase))]
    public class always_false : ITestCase {
        private const string _Name = "always false,F_always_false ";
        private const string _Description = "F.alwaysFalse() returns false";
        public string TestFile { get { return "TestCaseAlways.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Func<bool> b = F.alwaysFalse.Invoke();
            result = result.And(F.equ_bool(false, b.Invoke()));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public always_false() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_always);
            this.feature.Add(TestCoverage.F_always_false);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_always);
            this.coverage.Add(TestCoverage.F_always_false);
            this.coverage.Add(TestCoverage.F_equ);
            this.coverage.Add(TestCoverage.F_equ_bool);
            this.coverage.Add(TestCoverage.bool_);
            this.coverage.Add(TestCoverage.bool_And);
        }
    }

}
