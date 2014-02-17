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
    public class test_map_one : ISyncTestCase {
        private const string _Name = "test_map,F_T_map";
        private const string _Description = "verify that sequence of ints and a int to string mapping function results in a sequene of strings";
        public string TestFile { get { return "TestCaseMap.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            IEnumerable<string> sdoubles = new List<string>() { "0", "2", "4", "6" };
            IEnumerable<string> snumbers = new List<string>() { "0", "1", "2", "3" };
            IEnumerable<int> nnumbers = new List<int>() { 0, 1, 2, 3 };
            Func<int, string> toString = (n) => n.ToString();
            IEnumerable<string> test = F<int>.map<string>(nnumbers, toString);
            IEnumerator<string> eTest = test.GetEnumerator();
            IEnumerator<string> eNumbers = snumbers.GetEnumerator();
            while ((eTest.MoveNext()) && (eNumbers.MoveNext())) {
                result = result && (eTest.Current == eNumbers.Current);
            }
            result = result && (snumbers.ToList().Count() == test.ToList().Count());
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_map_one() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_map);
            this.feature.Add(TestCoverage.F_T_map_U);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_map);
            this.coverage.Add(TestCoverage.F_T_map_U);
        }
    }


    [Export(typeof(ISyncTestCase))]
    public class test_map_two : ISyncTestCase {
        private const string _Name = "test_map_two";
        private const string _Description = "verify that a pair of sequences of integers are summed, the result is a sequence of ints where each value is the sum";
        public string TestFile { get { return "TestCaseMap.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            IEnumerable<int> list1 = new List<int>() { 7, 13, 5, 9, -4, 6 };
            IEnumerable<int> list2 = new List<int>() { 3, 1, 4, -3, 6, -14 };
            IEnumerable<int> sum = new List<int>() { 10, 14, 9, 6, 2, -8 };

            IEnumerable<int> test = F<int>.map<int>(list1, list2, (x, y) => x + y);
            IEnumerator<int> eSum = sum.GetEnumerator();
            IEnumerator<int> eTest = test.GetEnumerator();
            while ((eSum.MoveNext()) && (eTest.MoveNext())) {
                result = result && (eSum.Current == eTest.Current);
            }
            result = result && (sum.Count() == test.ToList().Count());
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_map_two() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_map);
            this.feature.Add(TestCoverage.F_T_map_U_2_List);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_map);
            this.coverage.Add(TestCoverage.F_T_map_U_2_List);
        }
    }


    [Export(typeof(ISyncTestCase))]
    public class test_map_three : ISyncTestCase {
        private const string _Name = "test_map_three";
        private const string _Description = "verify that 3 sequences of chars can be correctly transformed to a sequence of functions that return a bool";
        public string TestFile { get { return "TestCaseMap.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() { 
            bool result = true;
            // t f f t
            Func<bool> _true = () => true;
            Func<bool> _false = () => false;
            IEnumerable<Func<bool>> verify = new List<Func<bool>>() { 
                _true,_false,_false,_true
            };
            Func<char, char, char, Func<bool>> fn = (x, y, z) => {
                return ((x == y) && (x == z)) ? _true : _false;
            };
            IEnumerable<char> first = F.chars("xoxo");
            IEnumerable<char> second = F.chars("xxoo");
            IEnumerable<char> third = F.chars("xooo");

            IEnumerable<Func<bool>> test = F<char>.map<Func<bool>>(first, second, third, fn);
            IEnumerator<Func<bool>> eVerify = verify.GetEnumerator();
            IEnumerator<Func<bool>> eTest = test.GetEnumerator();
            while ((eVerify.MoveNext()) && (eTest.MoveNext())) {
                result = result && (eVerify.Current.Invoke() == eTest.Current.Invoke());
            }
            result = result && (test.Count() == test.ToList().Count());
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_map_three() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_map);
            this.feature.Add(TestCoverage.F_T_map_U_3_List);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_map);
            this.coverage.Add(TestCoverage.F_T_map_U_3_List);
        }
    }
}
