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
    
    /****************************************************/
 


   





    [Export(typeof(ISyncTestCase))] 
    public class test_chars_string_same : ISyncTestCase {
        private const string _Name = "test_chars_string_same";
        private const string _Description = "chars('one') should return <o,n,e>";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            IEnumerable<char> test = F.chars("one");
            IList<char> one = new List<char>() { 'o', 'n', 'e' };
            IEnumerator<char> eTest = test.GetEnumerator();
            IEnumerator<char> eOne = one.GetEnumerator();
            while((eTest.MoveNext()) && (eOne.MoveNext())) {
                result = result && (eTest.Current == eOne.Current);
            }
            result = result && (test.ToList().Count() == one.Count());
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_chars_string_same() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_chars);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_chars);
        }
    }





    [Export(typeof(ISyncTestCase))]
    public class test_items : ISyncTestCase {
        private const string _Name = "test_items,F_T_items";
        private const string _Description = "a sequence of three dictionaries in which two have the value returns a sequence with both values";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool success = true;
            IDictionary<string, int> d1 = new Dictionary<string, int>();
            IDictionary<string, int> d2 = new Dictionary<string, int>();
            IDictionary<string, int> d3 = new Dictionary<string, int>();
            IList<IDictionary<string, int>> lst = new List<IDictionary<string, int>>();
            d1.Add("xyz", 7); d1.Add("abc", 32);
            d2.Add("xyz", 21); d2.Add("def", 188);
            d3.Add("tuv", 3);
            lst.Add(d1);
            lst.Add(d2);
            lst.Add(d3);
            IList<int> result = F<int>.items(lst, "xyz").ToList();
            success = success && (result.Contains(7) && result.Contains(21) && (result.Count() == 2));
            return success;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_items() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_items);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_items);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_transform : ISyncTestCase {
        private const string _Name = "test_transform,F_T_transform";
        private const string _Description = "a sequence of ints and a function that takes string, applies a given string transform function to each int";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = false;
            Action<string> yes = (s) => { if (s == "yes") result = true; };
            Func<int,string> isTwo = (n) => { return (n==2)?"yes":"no";};
            Action<int> fn = F<int>.transform<string>(yes, isTwo);
            fn.Invoke(2);
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_transform() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_transform);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_transform);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_same : ISyncTestCase {
        private const string _Name = "test_same,F_T_same";
        private const string _Description = "identical sequences of ints and the equal function returns true";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Func<int, int, bool> equal = (x, y) => (x == y);
            result = result && (true  == F<int>.same(new List<int>(){0,1,2,3},new List<int>(){0,1,2,3}, equal)); // pos content test
            result = result && (false == F<int>.same(new List<int>{4,5,6,7},new List<int>(){4,5,6,7,8}, equal)); // neg length test
            result = result && (false == F<int>.same(new List<int>{3,4,5,6,7},new List<int>(){4,5,6,7,8},equal)); // neg content test
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_same() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_same);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_same);
        }
    }



    [Export(typeof(ISyncTestCase))]
    public class test_any : ISyncTestCase {
        private const string _Name = "test_any,F_T_any";
        private const string _Description = "any returns correct result";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = (true == F<int>.any(new List<int>(){3,7,19}, (x) => (x == 3)));
            result = result && (false == F<int>.any(new List<int>() { 3, 7, 19 }, (x) => (x == 4)));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_any() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_any);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_same);
            this.coverage.Add(TestCoverage.F_T_any);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_all : ISyncTestCase {
        private const string _Name = "test_all,F_T_all";
        private const string _Description = "all returns the corrct result";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = (true == F<int>.all(new List<int>() { 5, 6, 7, 8, 9 }, x => (x > 0)));
            result = result && (false == F<int>.all(new List<int> { 5, 6, 7, 8, 9 }, x => (x != 6)));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_all() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_all);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_all);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_filter : ISyncTestCase {
        private const string _Name = "test_filter,F_T_filter";
        private const string _Description = "filter result in a filtered sequence";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            IList<int> list = new List<int>(){1,4,2,8,5,3,2,6,5,5,3,8}; // note 3 5s.
            IEnumerable<int> fives = F<int>.filter(list, (x) => (x == 5));
            result = result && fives.Contains(5);
            int sum = 0;
            foreach (int n in fives) sum += n;
            result = result && (sum == 15);
            IEnumerable<int> sevens = F<int>.filter(list, (x) => (x == 7));
            result = result && !sevens.Contains(7);
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_filter() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_filter);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_filter);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_first : ISyncTestCase {
        private const string _Name = "test_first,F_T_first";
        private const string _Description = "first returns the first item in a sequence";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (7 == F<int>.first(new List<int>{7,8,9,10}));
            result = result && ("one" == F<string>.first(new List<string>() { "one", "two", "three" }));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_first() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_first);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_first);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_rest : ISyncTestCase {
        private const string _Name = "test_rest,F_T_rest";
        private const string _Description = "the rest of the sequence <1,...7> is the sequence <2,...,7>";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            IList<int> full = new List<int>(){0,1,2,3,4,5,6,7};
            IList<int> rest = new List<int>(){1,2,3,4,5,6,7};
            
            // make sure that rest returned a correct sequence

            IEnumerator<int> e1 = rest.GetEnumerator();
            IEnumerator<int> e2 = F<int>.rest(full).GetEnumerator();
            
            while ((e1.MoveNext()) && (e2.MoveNext())) {
                result = result && (e1.Current == e2.Current);
            }
            int count = F<int>.rest(full).ToList().Count;  // make sure they are the same length
            result = result && (count == rest.Count());
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_rest() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_rest);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_rest);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_find : ISyncTestCase {
        private const string _Name = "test_find,F_T_find";
        private const string _Description = "find (x==7) in the sequence <3,...,9> results in '7'";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            // find maps to IEnumerable<T>.Find. Handle not found exception.
            result = result && (7 == F<int>.find(new List<int>(){3,4,5,6,7,8,9}, x => (x==7)));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_find() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_find);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_find);
        }
    }



   
    
    [Export(typeof(ISyncTestCase))]
    public class test_iterate_while: ISyncTestCase {
        private const string _Name = "test_iterate_while";
        private const string _Description = "verify that starting with 0 and iterating while the calculated value is less than 4 results in the sequence '0' '1' '2' '3'";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            int f = 0;
            IEnumerable<int> y = F<int>.iterate_while((x)=>++x, x =>(x<4), 0); // the danger of x++ is that result will never inc
            foreach (int i in y) f = i;
            result = result && (f == 3);
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_iterate_while() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_iterate_while);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_iterate_while);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_always: ISyncTestCase {
        private const string _Name = "test_always,F_T_always";
        private const string _Description = "verify that always(3) results in a function that returns a 3";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Func<string> test = ()=>"test";
            result = result && (3 ==  F<int>.always(3).Invoke());
            Func<Func<string>> fn = F<Func<string>>.always(test);
            result = result && ("test" == fn.Invoke().Invoke());
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_always() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_always);

            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_always);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_curry_one : ISyncTestCase {
        private const string _Name = "test_curry_one";
        private const string _Description = "make a square function factory, and ask for the function that returns the square of the input value";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Curry1<int, int> sqr = new Curry1<int, int>(F.sqr_int);
            Func<int, int> noConfig = sqr.Create();
            int r = noConfig(5);
            result = result && (25 == r);
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_curry_one() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Curry1);

            this.coverage.Add(TestCoverage.Curry1);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_sqr);
            this.coverage.Add(TestCoverage.F_sqr_int);
            this.coverage.Add(TestCoverage.F_T);
        }
    }


    [Export(typeof(ISyncTestCase))]
    public class test_curry_two : ISyncTestCase {
        private const string _Name = "test_curry_two";
        private const string _Description = "make a sum function factory, and ask for a function that returns the sum of 10 and an input value";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Curry2<int, int> add = new Curry2<int, int>(F.add_int);
            Func<int, int> add10 = add.Create(10);
            int r = add10(6); // 16
            result =  result && (F.equ_int(16,r));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_curry_two() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Curry2);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_add);
            this.coverage.Add(TestCoverage.F_add_int);
            this.coverage.Add(TestCoverage.F_equ_int);
            this.coverage.Add(TestCoverage.Curry2);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_intersperse : ISyncTestCase {
        private const string _Name = "test_intersperse";
        private const string _Description = "verify that using reduce to create interspersed objects is possible";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool success = true;
            Func<char, string, string> intersperse = (c, s) => {
                IEnumerable<char> seq = F.chars(s);
                string result = F<char>.reduce<string>(F<char>.rest(seq), (st, ch) => st + c + ch, (F<char>.toString(F<char>.first(seq))));
                return result;
            };
            Func<string, string> swedish = (s) => {
                return intersperse('f', s);
            };
            string swedisHello = swedish("Hello");
            success = F<char>.same(F.chars(swedisHello), F.chars("Hfeflflfo"), F.equ_char);
            return success;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_intersperse() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Test_Integration);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_reduce);
            this.feature.Add(TestCoverage.F_T_reduce_U_init);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_chars);
            this.coverage.Add(TestCoverage.F_equ_char);
            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_reduce);
            this.coverage.Add(TestCoverage.F_T_rest);
            this.coverage.Add(TestCoverage.F_T_first);
            this.coverage.Add(TestCoverage.F_T_same);
            this.coverage.Add(TestCoverage.F_T_toString);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class test_flatten_one : ISyncTestCase {
        private const string _Name = "test_flatten_one,F_T_flatten";
        private const string _Description = "verify that the flatten function works on homogenous type int";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            IEnumerable<IEnumerable<int>> llist = new List<IEnumerable<int>>() { new List<int>() { 2, 3, 6 }, new List<int>() { 5, 2, 2, 1 } };
            IEnumerable<int> flat = F<IEnumerable<int>>.flatten<int>(llist, F<IEnumerable<int>>.identity);
            IList<int> check = new List<int>() { 2, 3, 6, 5, 2, 2, 1 };
            IEnumerator<int> eCheck = check.GetEnumerator();
            IEnumerator<int> eFlat = flat.GetEnumerator();
            while ((eCheck.MoveNext()) && (eFlat.MoveNext())) {
                result = result && (eCheck.Current == eFlat.Current);
            }
            result = result && (check.Count() == flat.ToList().Count());

            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_flatten_one() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_flatten);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_equ_int);
            this.coverage.Add(TestCoverage.F_T);
            this.coverage.Add(TestCoverage.F_T_flatten);
            this.coverage.Add(TestCoverage.F_T_identity);
            this.coverage.Add(TestCoverage.F_T_same);
        }
    }


    [Export(typeof(ISyncTestCase))]
    public class test_chain_one : ISyncTestCase {
        private const string _Name = "test_chain_one";
        private const string _Description = "verify that the chain function";
        public string TestFile { get { return "TestCase.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            int current = 0;
            int last = 0;
            IStatelessChain<int> statelessChain = StatelessChain<int>.Create((x) => x < 3, F.DoNothing<int>);
            while(null != statelessChain) {
                last = current;
                current++;
                statelessChain = statelessChain.Run(current);
            }
            result = result.And(F.equ_int(last, 2));
            int count = 0;
            IStatefulChain<int> statefulChain = StatefulChain<int>.Create((x) => x < 3, (y)=>{count++;}, (v) => v + 1, 0);
            while (null != statefulChain) {
                statefulChain = statefulChain.Run();
            }
            result = result && (count == 3);
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public test_chain_one() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Chain);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_equ_int);
            this.coverage.Add(TestCoverage.Chain);
            this.coverage.Add(TestCoverage.bool_);
            this.coverage.Add(TestCoverage.bool_And);
        }
    }
}
