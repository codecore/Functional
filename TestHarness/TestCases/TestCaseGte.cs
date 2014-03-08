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
    public class gte_int : ISyncTestCase {
        private const string _Name = "gte int,F_gte_int";
        private const string _Description = "F.gte_int(left,right) works correctly";
        public string TestFile { get { return "TestCaseGte.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.gte_int(1,0));
            result = result && (true  == F.gte_int(0,0));
            result = result && (false == F.gte_int(0,1));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public gte_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_gte);
            this.feature.Add(TestCoverage.F_gte_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_gte);
            this.coverage.Add(TestCoverage.F_gte_int);
        }
    }


    [Export(typeof(ISyncTestCase))]
    public class gte_long : ISyncTestCase {
        private const string _Name = "gte long,F_gte_long";
        private const string _Description = "F.gte_long(left,right) works correctly";
        public string TestFile { get { return "TestCaseGte.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.gte_long(1L,0L));
            result = result && (true  == F.gte_long(0L,0L));
            result = result && (false == F.gte_long(0L,1L));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public gte_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_gte);
            this.feature.Add(TestCoverage.F_gte_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_gte);
            this.coverage.Add(TestCoverage.F_gte_long);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class gte_short : ISyncTestCase {
        private const string _Name = "gte short,F_gte_short";
        private const string _Description = "F.gte_short(left,right) works correctly";
        public string TestFile { get { return "TestCaseGte.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.gte_short(1,0));
            result = result && (true  == F.gte_short(0,0));
            result = result && (false == F.gte_short(0,1));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public gte_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_gte);
            this.feature.Add(TestCoverage.F_gte_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_gte);
            this.coverage.Add(TestCoverage.F_gte_short);
        }
    }
}
