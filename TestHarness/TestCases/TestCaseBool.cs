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
    [Export(typeof(ISyncTestCase))]
    public class bool_and : ISyncTestCase {
        private const string _Name = "bool and,F_bool_and";
        private const string _Description = "F.bool_and() returns correct";
        public string TestFile { get { return "TestCaseBool.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.bool_and(true));                          //      T => T
            result = result && (false == F.bool_and(false));                         //      F => F
            result = result && (true  == F.bool_and(true,true));                     //     TT => T
            result = result && (false == F.bool_and(true,false));                    //     TF => F
            result = result && (false == F.bool_and(false,true));                    //     FT => F
            result = result && (false == F.bool_and(false,false));                   //     FF => F
            result = result && (true  == F.bool_and(true,true,true));                //    TTT => T
            result = result && (false == F.bool_and(false,true,true));               //    FTT => F
            result = result && (false == F.bool_and(true,false,true));               //    TFT => F
            result = result && (false == F.bool_and(true,true,false));               //    TTF => F
            result = result && (false == F.bool_and(false,false,false));             //    FFF => F
            result = result && (true  == F.bool_and(true,true,true,true));           //   TTTT => T
            result = result && (false == F.bool_and(false,true,true,true));          //   FTTT => F
            result = result && (false == F.bool_and(true,false,true,true));          //   TFTT => F
            result = result && (false == F.bool_and(true,true,false,true));          //   TTFT => F
            result = result && (false == F.bool_and(true,true,true,false));          //   TTTF => F
            result = result && (false == F.bool_and(false,false,false,false));       //   FFFF => F
            // the rest later
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public bool_and() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_bool);
            this.feature.Add(TestCoverage.F_bool_and);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_bool);
            this.coverage.Add(TestCoverage.F_bool_and);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class bool_eqv : ISyncTestCase {
        private const string _Name = "bool eqv,F_bool_eqv";
        private const string _Description = "F.bool_eqv() returns correct";
        public string TestFile { get { return "TestCaseBool.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.bool_eqv(true,true));
            result = result && (false == F.bool_eqv(false,true));
            result = result && (false == F.bool_eqv(true,false));
            result = result && (true  == F.bool_eqv(false,false));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public bool_eqv() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_bool);
            this.feature.Add(TestCoverage.F_bool_eqv);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_bool);
            this.coverage.Add(TestCoverage.F_bool_eqv);
        }
    }
    [Export(typeof(ISyncTestCase))]
    public class bool_or : ISyncTestCase {
        private const string _Name = "bool or,F_bool_or";
        private const string _Description = "F.bool_or() returns correct";
        public string TestFile { get { return "TestCaseBool.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.bool_or(true));                               //      T => T
            result = result && (false == F.bool_or(false));                              //      F => F
            result = result && (true  == F.bool_or(true,true));                          //     TT => T
            result = result && (true  == F.bool_or(true,false));                         //     TF => T
            result = result && (true  == F.bool_or(false,true));                         //     FT => T
            result = result && (false == F.bool_or(false,false));                        //     FF => F
            result = result && (true  == F.bool_or(true,true,true));                     //    TTT => T
            result = result && (true  == F.bool_or(true,false,false));                   //    TFF => T
            result = result && (true  == F.bool_or(false,true,false));                   //    FTF => T
            result = result && (true  == F.bool_or(false,false,true));                   //    FFT => T
            result = result && (false == F.bool_or(false,false,false));                  //    FFF => F
            result = result && (true  == F.bool_or(true,true,true,true));                //   TTTT => T
            result = result && (true  == F.bool_or(true,false,false,false));             //   TFFF => T
            result = result && (true  == F.bool_or(false,true,false,false));             //   FTFF => T
            result = result && (true  == F.bool_or(false,false,true,false));             //   FFTF => T
            result = result && (true  == F.bool_or(false,false,false,true));             //   FFFT => T
            result = result && (false == F.bool_or(false,false,false,false));            //   FFFF => F
            result = result && (true  == F.bool_or(true,true,true,true,true));           //  TTTTT => T
            result = result && (true  == F.bool_or(true,false,false,false,false));       //  TFFFF => T
            result = result && (true  == F.bool_or(false,true,false,false,false));       //  FTFFF => T
            result = result && (true  == F.bool_or(false,false,true,false,false));       //  FFTFF => T
            result = result && (true  == F.bool_or(false,false,false,true,false));       //  FFFTF => T
            result = result && (true  == F.bool_or(false,false,false,false,true));       //  FFFFT => T
            result = result && (false == F.bool_or(false,false,false,false,false));      //  FFFFF => F
            return  result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public bool_or() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_bool);
            this.feature.Add(TestCoverage.F_bool_or);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_bool);
            this.coverage.Add(TestCoverage.F_bool_or);
        }
    }
    [Export(typeof(ISyncTestCase))]
    public class bool_xor : ISyncTestCase {
        private const string _Name = "bool xor,F_bool_xor";
        private const string _Description = "F.bool_xor() returns correct";
        public string TestFile { get { return "TestCaseBool.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (false == F.bool_xor(true, true));   // TT => F
            result = result && (true  == F.bool_xor(false,true));   // FT => T
            result = result && (true  == F.bool_xor(true,false));   // TF => T
            result = result && (false == F.bool_xor(false,false));  // FF => F
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public bool_xor() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_bool);
            this.feature.Add(TestCoverage.F_bool_xor);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_bool);
            this.coverage.Add(TestCoverage.F_bool_xor);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class bool_And : ISyncTestCase {
        private const string _Name = "bool And,bool_And";
        private const string _Description = "bool And extension returns correct";
        public string TestFile { get { return "TestCaseBool.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            bool _true = true;
            bool _false = false;

            result = result && (true == _true.And(true));
            result = result && (false == _true.And(false));
            result = result && (false == _false.And(true));
            result = result && (false == _false.And(false));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public bool_And() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.bool_);
            this.feature.Add(TestCoverage.bool_And);

            this.coverage.Add(TestCoverage.bool_);
            this.coverage.Add(TestCoverage.bool_And);;
        }
    }
    [Export(typeof(ISyncTestCase))]
    public class bool_Or : ISyncTestCase {
        private const string _Name = "bool Or,bool_Or";
        private const string _Description = "bool Or extension returns correct";
        public string TestFile { get { return "TestCaseBool.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            bool _true = true;
            bool _false = false;

            result = result && (true == _true.Or(true));
            result = result && (true == _true.Or(false));
            result = result && (true == _false.Or(true));
            result = result && (false == _false.Or(false));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public bool_Or() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.bool_);
            this.feature.Add(TestCoverage.bool_Or);

            this.coverage.Add(TestCoverage.bool_);
            this.coverage.Add(TestCoverage.bool_Or);
        }
    }
}
