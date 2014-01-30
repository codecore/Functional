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
    public class close_double : ITestCase {
        private const string _Name = "close double,F_close_double";
        private const string _Description = "F.close_double(x,y) returns true if x is close to y";
        public string TestFile { get { return "TestCaseClose.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.close_double( 1.0d, 1.0d));      //     1     1
            result = result && (true  == F.close_double(-1.0d,-1.0d));      //    -1    -1
            result = result && (true  == F.close_double( 0.0d, 0.0d));      //     0     0
            result = result && (false == F.close_double( 1.0d, 0.9d));      //     1     1-d
            result = result && (false == F.close_double( 1.0d, 1.1d));      //     1     1+d
            result = result && (false == F.close_double( 0.0d, 0.1d));      //     0     0+d
            result = result && (false == F.close_double( 0.0d,-0.1d));      //     0     0-d
            result = result && (false == F.close_double(-1.0d,-0.9d));      //    -1    -1+d
            result = result && (false == F.close_double(-1.0d,-1.1d));      //    -1    -1-d


            result = result && (false == F.close_double( 0.9d, 1.0d));      //     1-d   1
            result = result && (false == F.close_double( 1.1d, 1.0d));      //     1+d   1
            result = result && (false == F.close_double( 0.1d, 0.0d));      //     0+d   0
            result = result && (false == F.close_double(-0.1d, 0.0d));      //     0-d   0
            result = result && (false == F.close_double(-0.9d,-1.0d));      //    -1+d  -1
            result = result && (false == F.close_double(-1.1d,-1.0d));      //    -1-d  -1
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public close_double() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_close);
            this.feature.Add(TestCoverage.F_close_double);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_double);
        }
    }

    [Export(typeof(ITestCase))]
    public class close_float : ITestCase {
        private const string _Name = "close float,F_close_float";
        private const string _Description = "F.close_float(x,y) returns true if x is close to y";
        public string TestFile { get { return "TestCaseClose.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.close_float( 1.0f, 1.0f));      //     1     1
            result = result && (true  == F.close_float(-1.0f,-1.0f));      //    -1    -1
            result = result && (true  == F.close_float( 0.0f, 0.0f));      //     0     0
            result = result && (false == F.close_float( 1.0f, 0.9f));      //     1     1-d
            result = result && (false == F.close_float( 1.0f, 1.1f));      //     1     1+d
            result = result && (false == F.close_float( 0.0f, 0.1f));      //     0     0+d
            result = result && (false == F.close_float( 0.0f,-0.1f));      //     0     0-d
            result = result && (false == F.close_float(-1.0f,-0.9f));      //    -1    -1+d
            result = result && (false == F.close_float(-1.0f,-1.1f));      //    -1    -1-d


            result = result && (false == F.close_float( 0.9f, 1.0f));      //     1-d   1
            result = result && (false == F.close_float( 1.1f, 1.0f));      //     1+d   1
            result = result && (false == F.close_float( 0.1f, 0.0f));      //     0+d   0
            result = result && (false == F.close_float(-0.1f, 0.0f));      //     0-d   0
            result = result && (false == F.close_float(-0.9f,-1.0f));      //    -1+d  -1
            result = result && (false == F.close_float(-1.1f,-1.0f));      //    -1-d  -1

            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public close_float() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_close);
            this.feature.Add(TestCoverage.F_close_float);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_float);
        }
    }
}
