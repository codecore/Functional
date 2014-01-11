using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;

using Tests;
namespace Tests {

    /****************************************************/
 


   





    [Export(typeof(ITestCase))] 
    public class test_chars_string_same : ITestCase {
        private const string _Name = "test_chars_string_same";
        private const string _Description = "chars('one') should return <o,n,e>";
        private static Func<bool> _Run = () => {
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
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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





    [Export(typeof(ITestCase))]
    public class test_items : ITestCase {
        private const string _Name = "test_items,F_T_items";
        private const string _Description = "a sequence of three dictionaries in which two have the value returns a sequence with both values";
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
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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

    [Export(typeof(ITestCase))]
    public class test_transform : ITestCase {
        private const string _Name = "test_transform,F_T_transform";
        private const string _Description = "a sequence of ints and a function that takes string, applies a given string transform function to each int";
        private static bool _Run() {
            bool success = false;
            Action<string> yes = (s) => { if (s == "yes") success = true; };
            Func<int,string> isTwo = (n) => { return (n==2)?"yes":"no";};
            Action<int> fn = F<int>.transform<string>(yes, isTwo);
            fn.Invoke(2);
            return success;
        }
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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

    [Export(typeof(ITestCase))]
    public class test_same : ITestCase {
        private const string _Name = "test_same,F_T_same";
        private const string _Description = "identical sequences of ints and the equal function returns true";
        private static Func<bool> _Run = () => {
            bool result = true;
            Func<int, int, bool> equal = (x, y) => (x == y);
            result = result && (true  == F<int>.same(new List<int>(){0,1,2,3},new List<int>(){0,1,2,3}, equal)); // pos content test
            result = result && (false == F<int>.same(new List<int>{4,5,6,7},new List<int>(){4,5,6,7,8}, equal)); // neg length test
            result = result && (false == F<int>.same(new List<int>{3,4,5,6,7},new List<int>(){4,5,6,7,8},equal)); // neg content test
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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



    [Export(typeof(ITestCase))]
    public class test_any : ITestCase {
        private const string _Name = "test_any,F_T_any";
        private const string _Description = "any returns correct result";
        private static bool _Run() {
            bool success = true;
            success = (true == F<int>.any(new List<int>(){3,7,19}, (x) => (x == 3)));
            success = success && (false == F<int>.any(new List<int>() { 3, 7, 19 }, (x) => (x == 4)));
            return success;
        }
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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

    [Export(typeof(ITestCase))]
    public class test_all : ITestCase {
        private const string _Name = "test_all,F_T_all";
        private const string _Description = "all returns the corrct result";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = (true == F<int>.all(new List<int>() { 5, 6, 7, 8, 9 }, x => (x > 0)));
            result = result && (false == F<int>.all(new List<int> { 5, 6, 7, 8, 9 }, x => (x != 6)));
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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

    [Export(typeof(ITestCase))]
    public class test_filter : ITestCase {
        private const string _Name = "test_filter,F_T_filter";
        private const string _Description = "filter result in a filtered sequence";
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
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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

    [Export(typeof(ITestCase))]
    public class test_first : ITestCase {
        private const string _Name = "test_first,F_T_first";
        private const string _Description = "first returns the first item in a sequence";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (7 == F<int>.first(new List<int>{7,8,9,10}));
            result = result && ("one" == F<string>.first(new List<string>() { "one", "two", "three" }));
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
        public test_first() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F_T);
            this.feature.Add(TestCoverage.F_T_first);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_T_first);
        }
    }

    [Export(typeof(ITestCase))]
    public class test_rest : ITestCase {
        private const string _Name = "test_rest,F_T_rest";
        private const string _Description = "the rest of the sequence <1,...7> is the sequence <2,...,7>";
        private static Func<bool> _Run = () => {
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
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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

    [Export(typeof(ITestCase))]
    public class test_find : ITestCase {
        private const string _Name = "test_find,F_T_find";
        private const string _Description = "find (x==7) in the sequence <3,...,9> results in '7'";
        private static Func<bool> _Run = () => {
            bool result = true;
            // find maps to IEnumerable<T>.Find. Handle not found exception.
            result = result && (7 == F<int>.find(new List<int>(){3,4,5,6,7,8,9}, x => (x==7)));
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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



   
    
    [Export(typeof(ITestCase))]
    public class test_iterate_while: ITestCase {
        private const string _Name = "test_iterate_while";
        private const string _Description = "verify that starting with 0 and iterating while the calculated value is less than 4 results in the sequence '0' '1' '2' '3'";
        private static bool _Run() {
            bool result = true;
            int f = 0;
            IEnumerable<int> y = F<int>.iterate_while((x)=>x++, x =>(x<4), 0);
            foreach (int i in y) f = i;
            result = result && (f == 3);
            return result;
        }
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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

    [Export(typeof(ITestCase))]
    public class test_always: ITestCase {
        private const string _Name = "test_always,F_T_always";
        private const string _Description = "verify that always(3) results in a function that returns a 3";
        private static Func<bool> _Run = () => {
            bool result = true;
            Func<string> test = ()=>"test";
            result = result && (3 ==  F<int>.always(3).Invoke());
            Func<Func<string>> fn = F<Func<string>>.always(test);
            result = result && ("test" == fn.Invoke().Invoke());
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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








    [Export(typeof(ITestCase))]
    public class test_curry_one : ITestCase {
        private const string _Name = "test_curry_one";
        private const string _Description = "make a square function factory, and ask for the function that returns the square of the input value";
        private static bool _Run() {
            bool success = true;
            Curry1<int, int> sqr = new Curry1<int, int>(F.sqr_int);
            Func<int, int> noConfig = sqr.Create();
            int r = noConfig(5);
            success = success.And(25 == r);
            return success;
        }
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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
            this.coverage.Add(TestCoverage.bool_);
            this.coverage.Add(TestCoverage.bool_And);

        }
    }


    [Export(typeof(ITestCase))]
    public class test_curry_two : ITestCase {
        private const string _Name = "test_curry_two";
        private const string _Description = "make a sum function factory, and ask for a function that returns the sum of 10 and an input value";
        private static bool _Run() {
            bool success = true;
            Curry2<int, int> add = new Curry2<int, int>(F.add_int);
            Func<int, int> add10 = add.Create(10);
            int r = add10(6); // 16
            success = success.And(F.equ_int(16,r));
            return success;
        }
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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
            this.coverage.Add(TestCoverage.bool_);
            this.coverage.Add(TestCoverage.bool_And);
        }
    }

    [Export(typeof(ITestCase))]
    public class test_intersperse : ITestCase {
        private const string _Name = "test_intersperse";
        private const string _Description = "verify that using reduce to create interspersed objects is possible";
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
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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

    [Export(typeof(ITestCase))]
    public class test_flatten_one : ITestCase {
        private const string _Name = "test_flatten_one,F_T_flatten";
        private const string _Description = "verify that the flatten function works on homogenous type int";
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
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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


    [Export(typeof(ITestCase))]
    public class test_chain_one : ITestCase {
        private const string _Name = "test_chain_one";
        private const string _Description = "verify that the chain function";
        private static bool _Run() {
            bool result = true;
            int current = 0;
            int last = 0;
            IChain<int> chain = Chain<int>.Create(0,(n) => n < 3).Run(current);
            while(null != chain) {
                last = current;
                current++;
                chain = chain.Run(current);
            }
            result = result.And(F.equ_int(last, 2));
            return result;
        }
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
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
