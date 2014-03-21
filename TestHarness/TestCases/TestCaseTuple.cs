using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using Functional.Test;

using imp = Functional.Implementation;

using Test.Contracts;
using Tests;
namespace Tests {
    [Export(typeof(ISyncTestCase))]
    public class tuple_A_B : ISyncTestCase {
        private const string _Name = "tuple_A_B";
        private const string _Description = "Tuple A B works";
        public string TestFile { get { return "TestCaseTuple.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            imp.Tuple<int,int> t = imp.Tuple<int,int>.Create<int,int>(5,7);
            result = result && (imp.Tuple<int,int>.first(t) == 5);
            result = result && (imp.Tuple<int,int>.second(t) == 7);
            int first = 0;
            int second = 0;
            imp.Tuple<int,int>.Extract(ref first, ref second, t);
            result = result && ((first == 5) && (second == 7));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public tuple_A_B() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Tuple);
            this.feature.Add(TestCoverage.Tuple_A_B);
            this.feature.Add(TestCoverage.Tuple_A_B_first);
            this.feature.Add(TestCoverage.Tuple_A_B_second);
            this.feature.Add(TestCoverage.Tuple_A_B_Extract);

            this.coverage.Add(TestCoverage.Tuple);
            this.coverage.Add(TestCoverage.Tuple_A_B);
            this.coverage.Add(TestCoverage.Tuple_A_B_first);
            this.coverage.Add(TestCoverage.Tuple_A_B_second);
            this.coverage.Add(TestCoverage.Tuple_A_B_Extract);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class tuple_A_B_C : ISyncTestCase {
        private const string _Name = "tuple_A_B_C";
        private const string _Description = "Tuple A B C works";
        public string TestFile { get { return "TestCaseTuple.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            imp.Tuple<int,int,int> t = imp.Tuple<int,int,int>.Create<int,int,int>(5, 7,99);
            result = result && (imp.Tuple<int,int,int>.first(t) == 5);
            result = result && (imp.Tuple<int,int,int>.second(t) == 7);
            result = result && (imp.Tuple<int,int,int>.third(t) == 99);
            int first = 0;
            int second = 0;
            int third = 0;
            imp.Tuple<int,int,int>.Extract(ref first, ref second, ref third, t);
            result = result && ((first == 5) && (second == 7) && (third == 99));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public tuple_A_B_C() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Tuple);
            this.feature.Add(TestCoverage.Tuple_A_B_C);
            this.feature.Add(TestCoverage.Tuple_A_B_C_first);
            this.feature.Add(TestCoverage.Tuple_A_B_C_second);
            this.feature.Add(TestCoverage.Tuple_A_B_C_third);
            this.feature.Add(TestCoverage.Tuple_A_B_C_Extract);

            this.coverage.Add(TestCoverage.Tuple);
            this.coverage.Add(TestCoverage.Tuple_A_B_C);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_first);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_second);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_third);
            this.coverage.Add(TestCoverage.Tuple_A_B_Extract);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class tuple_A_B_C_D : ISyncTestCase {
        private const string _Name = "tuple_A_B_C_D";
        private const string _Description = "Tuple A B C D works";
        public string TestFile { get { return "TestCaseTuple.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            imp.Tuple<int,int,int,string> t = imp.Tuple<int,int,int,string>.Create<int,int,int,string>(5, 7, 99,"test");
            result = result && (imp.Tuple<int,int,int,string>.first(t) == 5);
            result = result && (imp.Tuple<int,int,int,string>.second(t) == 7);
            result = result && (imp.Tuple<int,int,int,string>.third(t) == 99);
            result = result && (imp.Tuple<int,int,int,string>.fourth(t) == "test");
            int first = 0;
            int second = 0;
            int third = 0;
            string fourth = "kkkkk";
            imp.Tuple<int,int,int,string>.Extract(ref first, ref second, ref third, ref fourth, t);
            result = result && ((first == 5) && (second == 7) && (third == 99) && (fourth == "test"));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public tuple_A_B_C_D() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Tuple);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_first);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_second);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_third);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_fourth);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_Extract);

            this.coverage.Add(TestCoverage.Tuple);
            this.coverage.Add(TestCoverage.Tuple_A_B);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_first);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_second);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_third);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_fourth);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_Extract);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class tuple_A_B_C_D_E : ISyncTestCase {
        private const string _Name = "tuple_A_B_C_D_E";
        private const string _Description = "Tuple A B C D E works";
        public string TestFile { get { return "TestCaseTuple.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            imp.Tuple<char,int,int,string,float> t = imp.Tuple<char,int,int,string,float>.Create<char,int,int,string,float>('j', 7, 99, "test",6.88f);
            result = result && (imp.Tuple<char,int,int,string,float>.first(t) == 'j');
            result = result && (imp.Tuple<char,int,int,string,float>.second(t) == 7);
            result = result && (imp.Tuple<char,int,int,string,float>.third(t) == 99);
            result = result && (imp.Tuple<char,int,int,string,float>.fourth(t) == "test");
            result = result && (F.close_float(imp.Tuple<char,int,int,string,float>.fifth(t), 6.88f));
            char first = 'm';
            int second = 0;
            int third = 0;
            string fourth = "nnnnnn";
            float fifth = 0.59f;
            imp.Tuple<char,int,int,string,float>.Extract(ref first, ref second, ref third, ref fourth, ref fifth, t);
            result = result && ((first == 'j') && (second == 7) && (third == 99) && (fourth == "test")&&(F.close_float(fifth,6.88f)));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public tuple_A_B_C_D_E() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Tuple);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_first);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_second);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_third);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_fourth);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_fifth);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_Extract);

            this.coverage.Add(TestCoverage.Tuple);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_first);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_second);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_third);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_fourth);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_fifth);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_Extract);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class tuple_A_B_C_D_E_F : ISyncTestCase {
        private const string _Name = "tuple_A_B_C_D_E_F";
        private const string _Description = "Tuple A B C D E F works";
        public string TestFile { get { return "TestCaseTuple.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            imp.Tuple<char, int, int, string, float,int> t = imp.Tuple<char, int, int, string, float,int>.Create<char, int, int, string, float,int>('j', 7, 99, "test", 6.88f,8);
            result = result && (imp.Tuple<char,int,int,string,float,int>.first(t) == 'j');
            result = result && (imp.Tuple<char,int,int,string,float,int>.second(t) == 7);
            result = result && (imp.Tuple<char,int,int,string,float,int>.third(t) == 99);
            result = result && (imp.Tuple<char,int,int,string,float,int>.fourth(t) == "test");
            result = result && (F.close_float(imp.Tuple<char,int,int,string,float,int>.fifth(t), 6.88f));
            result = result && (imp.Tuple<char,int,int,string,float,int>.sixth(t) == 8);
            char first = 'm';
            int second = 0;
            int third = 0;
            string fourth = "nnnnnn";
            float fifth = 0.59f;
            int sixth = 4;
            imp.Tuple<char,int,int,string,float,int>.Extract(ref first, ref second, ref third, ref fourth, ref fifth,ref sixth, t);
            result = result && ((first == 'j') && (second == 7) && (third == 99) && (fourth == "test") && (F.close_float(fifth, 6.88f))&&(sixth == 8));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public tuple_A_B_C_D_E_F() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Tuple);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_F);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_F_first);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_F_second);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_F_third);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_F_fourth);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_F_fifth);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_F_sixth);
            this.feature.Add(TestCoverage.Tuple_A_B_C_D_E_F_Extract);

            this.coverage.Add(TestCoverage.Tuple);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_F);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_F_first);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_F_second);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_F_third);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_F_fourth);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_F_fifth);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_F_sixth);
            this.coverage.Add(TestCoverage.Tuple_A_B_C_D_E_F_Extract);
        }
    }
}

