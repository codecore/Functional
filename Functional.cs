using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Contracts;
namespace Functional.Implementation {
    public class Something<T> : ISomething<T> {
        public T Item { get; set; }
        public override string ToString() { return this.Item.ToString(); }
        private Something(T t){ this.Item = t; }
        public static ISomething<T> Create(T t) { return new Something<T>(t); }
        public static Func<T,T,int> compare = (t1, t2) => 0; //set this to be useful
        public static int Compare(ISomething<T> t1, ISomething<T> t2) { return compare(t1.Item, t2.Item); }
    }
    public class SomethingImmutable<T> : ISomethingImmutable<T> {
        public T Item { get; private set; }
        public override string ToString() { return this.Item.ToString(); }
        private SomethingImmutable(T t) { this.Item = t; }
        public static ISomethingImmutable<T> Create(T t) { return new SomethingImmutable<T>(t); }
        public static Func<T,T,int> compare = (t1, t2) => 0; //set this to be useful
        public static int Compare(ISomethingImmutable<T> t1, ISomethingImmutable<T> t2) { return compare(t1.Item, t2.Item); }
    }
    public static class F {
        public static void DoNothins() { }
        public static void DoNothing<T>(T t) { }
        public static void DoNothing<T,U>(T t, U u) { }
        public static void DoNothing<T,U,V>(T t, U u, V v) { }

        public static Func<string, IEnumerable<char>> Chars = (s) => s.AsEnumerable();
        public static Func<IEnumerable<char>, string> CharSequenceToString = (sequence) => {
            string s = String.Empty;
            foreach (char c in sequence) s = s + c;
            return s;
        };
        public static Func<int, bool> even = (x) => (0 == (x & 0x0001));
        public static Func<int, bool> odd = (x) => (1 == (x & 0x0001));

        public static Func<int,int,int>              compare = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        public static Func<int,int,int>          compare_int = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        public static Func<long,long,int>       compare_long = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        public static Func<short,short,int>    compare_short = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        public static Func<char,char,int>       compare_char = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        public static Func<string,string,int> compare_string = (l, r) => String.Compare(l, r); // need more testing around this
        public static Func<string,string,int> compare_string_case_insensative = (l, r) => String.Compare(l.ToUpper(), r.ToUpper());

        public static Func<int,int,bool>              equ = (l, r) => (l == r);
        public static Func<int,int,bool>          equ_int = (l, r) => (l == r);
        public static Func<long,long,bool>       equ_long = (l, r) => (l == r);
        public static Func<short,short,bool>    equ_short = (l, r) => (l == r);
        public static Func<char,char,bool>       equ_char = (l, r) => (l == r);
        public static Func<string,string,bool> equ_string = (l, r) => (l == r);

        public static Func<int,int,bool>           neq = (l, r) => (l != r);
        public static Func<int,int,bool>       neq_int = (l, r) => (l != r);
        public static Func<long,long,bool>    neq_long = (l, r) => (l != r);
        public static Func<short,short,bool> neq_short = (l, r) => (l != r);

        public static Func<int,int,int>             add = (x, y) => x + y;
        public static Func<int,int,int>         add_int = (x, y) => x + y;
        public static Func<long,long,long>     add_long = (x, y) => x + y;
        public static Func<short,short,short> add_short = (x, y) => (short)(x + y); //beware overflow

        public static Func<int,int,int>             sub = (x, y) => x - y;
        public static Func<int,int,int>         sub_int = (x, y) => x - y;
        public static Func<long,long,long>     sub_long = (x, y) => x - y;
        public static Func<short,short,short> sub_short = (x, y) => (short)(x - y); //beware underflow

        public static Func<int,int,int>             max = (x, y) => (x > y) ? x : y;
        public static Func<int,int,int>         max_int = (x, y) => (x > y) ? x : y;
        public static Func<long,long,long>     max_long = (x, y) => (x > y) ? x : y;
        public static Func<short,short,short> max_short = (x, y) => (x > y) ? x : y;

        public static Func<int,int,int>             min = (x, y) => (x < y) ? x : y;
        public static Func<int,int,int>         min_int = (x, y) => (x < y) ? x : y;
        public static Func<long,long,long>     min_long = (x, y) => (x < y) ? x : y;
        public static Func<short,short,short> min_short = (x, y) => (x < y) ? x : y;

        public static Func<int,int>           neg = (x) => -x;
        public static Func<int,int>       neg_int = (x) => -x;
        public static Func<long,long>    neg_long = (x) => -x;
        public static Func<short,short> neg_short = (x) => (short)(-x);

        public static Func<float, float, float> fadd = (x, y) => x + y;
        public static Func<float, float, float> fsub = (x, y) => x - y;
        public static Func<float, float, float> fmax = (x, y) => (x > y) ? x : y;
        public static Func<float, float, float> fmin = (x, y) => (x < y) ? x : y;
        public static Func<float, float> fneg = (x) => -x;
        public static Func<float, float, bool> close = (x, y) => (Math.Abs(x - y) < 0.01f);

        
        public static Func<int,int,bool>           gt = (l, r) => (l > r);
        public static Func<int,int,bool>       gt_int = (l, r) => (l > r);
        public static Func<long,long,bool>    gt_long = (l, r) => (l > r);
        public static Func<short,short,bool> gt_short = (l, r) => (l > r);

        public static Func<int,int,bool>           gte = (l, r) => (l >= r);
        public static Func<int,int,bool>       gte_int = (l, r) => (l >= r);
        public static Func<long,long,bool>    gte_long = (l, r) => (l >= r);
        public static Func<short,short,bool> gte_short = (l, r) => (l >= r);


        public static Func<int,int,bool>           lt = (l, r) => (l < r);
        public static Func<int,int,bool>       lt_int = (l, r) => (l < r);
        public static Func<long,long,bool>    lt_long = (l, r) => (l < r);
        public static Func<short,short,bool> lt_short = (l, r) => (l < r);


        public static Func<int,int,bool>           lte = (l, r) => (l <= r); // this is one reason why operators suck
        public static Func<int,int,bool>       lte_int = (l, r) => (l <= r);
        public static Func<long,long,bool>    lte_long = (l, r) => (l <= r);
        public static Func<short,short,bool> lte_short = (l, r) => (l <= r);

        

        public static Func<bool, bool, bool> or = (l, r) => l || r;
        public static Func<bool, bool, bool> and = (l, r) => l && r;
        public static Func<bool, bool, bool> xor = (l, r) => l != r;
        public static Func<bool, bool> not = x => !x;
        /// <summary>
        /// A function given two strings, returns the combined string
        /// </summary>
        /// <returns>A combined string</returns>
        public static Func<string, string, string> combine = (l, r) => l + r;
        /// <summary>
        /// A function given two strings, true if they are equal
        /// </summary>
        /// <returns>true if they are equal</returns>
        public static Func<string, string, bool> sequ = (l, r) => l == r;
        /// <summary>
        /// A function given two strings, true if they are not equal
        /// </summary>
        /// <returns>true if they are not equal</returns>
        public static Func<string, string, bool> sneq = (l, r) => l != r;
        /// <summary>
        /// A function given start, returns an infinite sequence of increasing integers. (warning: integer overflow)
        /// </summary>
        /// <returns>An infinite sequence of increasing integers</returns>
        public static IEnumerable<int> infinite_range(int start) { for (int i = start; true; i++) yield return i; }
        public static IEnumerable<int> range(int start, int end) {
            int step = ((end - start) > 0) ? 1 : -1;
            for (int i = start; neq(i, end); i += step) yield return i;
        }
        public static IEnumerable<int> range(int start, int end, int step) {
            int Step = ((end - start) > 0) ? Math.Abs(step) : -Math.Abs(step);
            Func<int, int, bool> condition = ((end - start) > 0) ? lt : gt;
            for (int i = start; condition(i, end); i += Step) yield return i;
        }
        public static IEnumerable<int> range(int end) { return range(0, end); }
        /// <summary>
        /// A function given minimum, and maximum, that returns a sequence of random integers
        /// </summary>
        /// <returns>An infinite sequence of random integers between minimum and maximum</returns>
        public static IEnumerable<int> random(int minimum, int maximum) {
            Random r = new Random(DateTime.Now.Millisecond);
            while (true) yield return r.Next(minimum, maximum);
        }
        /// <summary>
        /// A function given length, that returns a sequence of random integers
        /// </summary>
        /// <returns>A sequence of random integers</returns>
        public static IEnumerator<int> random(int count) {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < count; i++) yield return r.Next();
        }
        /// <summary>
        /// A function given length, minimum, and maximum, that returns a sequence of random integers
        /// </summary>
        /// <returns>A sequence of random integers between minimum and maximum</returns>
        public static IEnumerable<int> random(int count, int minimum, int maximum) {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < count; i++) yield return r.Next(minimum, maximum);
        }

        public static string toString<T>(T t) { return t.ToString(); }
        public static Func<string, int> StringToInt = (s) => {
            int result = 0;
            int.TryParse(s, out result);
            return result;
        };
        public static Func<string,bool> StringToBool = (s) =>  ("TRUE" == s.ToUpper());
        public static Action<Action<int>,int>          ApplyInt = Functional<int>.Apply;
        public static Action<Action<long>,long>       ApplyLong = Functional<long>.Apply;
        public static Action<Action<short>,short>    ApplyShort = Functional<short>.Apply;
        public static Action<Action<bool>,bool>       ApplyBool = Functional<bool>.Apply;
        public static Action<Action<string>,string> ApplyString = Functional<string>.Apply;
        public static void Add<T>(IList<T> lst, T t) { lst.Add(t); }

        public static IEnumerable<T> LoadTextFile<T>(string filename, Encoding encoding, Func<string,T> fn) {
            using (StreamReader sr = new StreamReader(filename, encoding)) {
                string line = sr.ReadLine();
                while (!String.IsNullOrEmpty(line)) {
                    yield return fn(line);
                    line = sr.ReadLine();
                }
            }
        }

    }
    public static class Functional<T>   {

        public static void Apply(Action<T> fn, T n) { fn(n); }
        /// <summary>
        /// Given a function that takes a T and function that takes an T and returns a X, return a function that takes an X
        /// </summary>
        /// <returns>Function that takes an X</returns>
        public static Action<T> transform<X>(Action<X> a, Func<T, X> fn) { return (n) => a(fn(n)); }
        /// <summary>
        /// from a sequence of dictionaries, get all the values that share the key
        /// </summary>
        /// <returns>sequence of items</returns>
        public static IEnumerable<T> items(IEnumerable<IDictionary<string, T>> lst, string key) {
            foreach (IDictionary<string, T> dictionary in lst) {
                if (dictionary.Keys.Contains(key)) yield return dictionary[key];
            }
        }
        /// <summary>
        /// true if both sequences are the same. Not valid for sequences of functions.
        /// </summary>
        /// <returns>bool</returns>8832707
        /// 8705 willows rd red 98052
        public static Func<IEnumerable<T>, IEnumerable<T>, Func<T, T, bool>, bool> same = (lst1, lst2, fn) => {
            IEnumerator<T> i1 = lst1.GetEnumerator();
            IEnumerator<T> i2 = lst2.GetEnumerator();
            bool result = true;
            bool b1 = i1.MoveNext();
            bool b2 = i2.MoveNext();
            while (result && (b1 && b2)) {
                result = fn(i1.Current, i2.Current);
                b1 = i1.MoveNext();
                b2 = i2.MoveNext();
            }
            return (result && (b1 == b2));
        };
        /// <summary>
        /// Given a sequence and a predicate, indicates if any elemnt passes the predicate
        /// </summary>
        /// <returns>true if any of the elements pass the predicate function</returns>
        public static Func<IEnumerable<T>, Func<T, bool>, bool> any = (lst, fn) => lst.Any(fn);
        /// <summary>
        /// Given a sequence and a predicate, indicates if every elemnt passes the predicate
        /// </summary>
        /// <returns>true if all the elements pass the predicate function</returns>
        public static Func<IEnumerable<T>, Func<T, bool>, bool> all = (lst, fn) => lst.All(fn);
        /// <summary>
        /// Given a sequence and a predicate, return the filtered sequence
        /// </summary>
        /// <returns>a sequence of T that meets the criteria of the predicate function</returns>
        public static Func<IEnumerable<T>, Func<T, bool>, IEnumerable<T>> filter = (lst, fn) => lst.Where(fn);
        /// <summary>
        /// Given a predicate function fn(x) return !fn(x)
        /// </summary>
        /// <returns>The compliment if the predicate function</returns>
        public static Func<T, bool> compliment(Func<T, bool> fn) { return (t) => { return !fn(t); }; }
        /// <summary>
        /// Swap the order of the parameters. compliment of f(a,b) is f(b,a)
        /// </summary>
        /// <returns>T, the result of the call</returns>
        public static Func<T, T, T> compliment(Func<T, T, T> fn) { return (x, y) => { return fn(y, x); }; }

        /// <summary>
        /// get the first element of a sequence
        /// </summary>
        /// <returns>The first element of an IEnumerable</returns>
        public static Func<IEnumerable<T>,T> first = (lst) => lst.First();
        /// <summary>
        /// get the sequence following the first element of a sequence
        /// </summary>
        /// <returns>an IEnermerable following the first element</returns>
        public static Func<IEnumerable<T>,IEnumerable<T>> rest = (lst) => lst.Skip(1);
        /// <summary>
        /// find the first item that meets the condition function
        /// throws System.InvalidOperationException if no match is found
        /// </summary>
        /// <returns>T or null</returns>
        public static Func<IEnumerable<T>,Func<T,bool>,T> find = (lst,cond) => lst.First(cond);
        /// <summary>
        /// sorts a finite sequnce.
        /// </summary>
        /// <returns>a sequence</returns>
        public static Func<IEnumerable<T>, Func<T, T, int>, IEnumerable<T>> sort = (lst, fn) => {
            T[] x = lst.ToArray();
            Array.Sort(x, new Comparer<T>(fn));
            return x.ToList();
        };
        /// <summary>
        /// sorts a sequence (most of the time)
        /// </summary>
        /// <returns>a sorted sequence</returns>
        public static Func<IEnumerable<T>,Func<T, T, int>,IEnumerable<T>> sort2 = (lst,fn) => lst.OrderBy(t=>t, new Comparer<T>(fn));
        /// <summary>
        /// Bubble sort a finite sequence.
        /// </summary>
        /// <returns>A sorted sequence</returns>
        // bubble sort
        public static Func<IEnumerable<T>, Func<T, T, int>, IEnumerable<T>> sort3 = (lst, fn) => {
            T[] array = lst.ToArray();
            bool swapped = true;
            while (swapped) {
                swapped = false;
                for (int i = 0; i < array.Length - 1; i++) {
                    if (fn(array[i], array[1 + 1]) > 0) {
                        swapped = true;
                        T temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
            return array;
        };
        /// <summary>
        /// Runs a function an each member of a sequence
        /// </summary>
        /// <returns>nothing</returns>
        public static void each(IEnumerable<T> lst,Action<T> fn) { foreach (T t in lst) fn(t); }
        public static void each<U>(IEnumerable<T> lst, Action<T,U> fn, U u) { foreach (T t in lst) fn(t, u); }
        public static void each<U,V>(IEnumerable<T> lst, Action<T,U,V> fn, U u, V v) { foreach (T t in lst) fn(t, u, v); }
        public static void each<U,V,W>(IEnumerable<T> lst, Action<T,U,V,W> fn, U u, V v, W w) { foreach (T t in lst) fn(t, u, v, w); }
        public static void each<U,V,W,X>(IEnumerable<T> lst, Action<T,U,V,W,X> fn, U u, V v, W w, X x) { foreach (T t in lst) fn(t, u, v, w, x); }
        /// <summary>
        /// runs an accumulatr function as long as the check function is true
        /// </summary>
        /// <returns>a sequence of T</returns>
        public static IEnumerable<T> iterateWhile(Func<T, T> fun, Func<T, bool> check, T init) {
            T result = init;
            while (check(result)) {
                yield return result;
                result = fun(result);
            }
        }
        /// <summary>
        /// returns a function that return the input 
        /// </summary>
        /// <returns>a Function</returns>
        public static Func<T> always(T t) { return () => t; }
        /// <summary>
        /// returns a function that returns either true or false 
        /// </summary>
        /// <returns>a Function that returns a bool</returns>
        public static Func<bool> always(bool b) { return (b) ? alwaysTrue() : alwaysFalse(); }
        /// <summary>
        /// returns a function that returns true 
        /// </summary>
        /// <returns>a Function that returns a bool</returns>
        public static Func<Func<bool>> alwaysTrue = () => () => true;
        /// <summary>
        /// returns a function that returns false 
        /// </summary>
        /// <returns>a Function that returns a bool</returns>
        public static Func<Func<bool>> alwaysFalse = () => () => false;
        /// <summary>
        /// returns a sequence that is the result of a sequence transformed by a function
        /// </summary>
        /// <returns>A sequence of objects of type T</returns>
        public static IEnumerable<U> map<U>(IEnumerable<T> lst, Func<T,U> fn) { return lst.Select(fn); }
        public static IEnumerable<U> map<U,V>(IEnumerable<T> lst, Func<T,V,U> fn, V v) {
            foreach (T t in lst) yield return fn(t, v);
        }
        public static IEnumerable<U> map<U,V,W>(IEnumerable<T> lst, Func<T,V,W,U> fn, V v, W w) {
            foreach (T t in lst) yield return fn(t, v, w);
        }
        public static IEnumerable<U> map<U,V,W,X>(IEnumerable<T> lst, Func<T,V,W,X,U> fn, V v, W w, X x) {
            foreach (T t in lst) yield return fn(t, v, w, x);
        }
        /// <summary>
        /// returns a sequence that is fed by two other sequences and a combining function fn
        /// </summary>
        /// <returns>A sequence of objects of type T</returns>
        public static IEnumerable<U> map<U>(IEnumerable<T> lst1, IEnumerable<T> lst2, Func<T, T, U> fn) {   
            IEnumerator<T> one = lst1.GetEnumerator();
            IEnumerator<T> two = lst2.GetEnumerator();
            while ((one.MoveNext()) && (two.MoveNext())) {
                yield return fn(one.Current, two.Current);
            }
        }
        /// <summary>
        /// returns a sequence that is fed by three other sequences and a combining function fn
        /// </summary>
        /// <returns>A sequence of objects of type T</returns>
        public static IEnumerable<U> map<U>(IEnumerable<T> lst1, IEnumerable<T> lst2, IEnumerable<T> lst3, Func<T, T, T, U> fn) {
            IEnumerator<T> one = lst1.GetEnumerator();
            IEnumerator<T> two = lst2.GetEnumerator();
            IEnumerator<T> three = lst3.GetEnumerator();
            while ((one.MoveNext()) && (two.MoveNext()) && (three.MoveNext())) {
                yield return fn(one.Current, two.Current, three.Current);
            }
        }
        /// <summary>
        /// Takes a sequence of objects of type T and a map function that transforms an object of type T to a sequence of objects of type U 
        /// </summary>
        /// <returns>A sequence of objects of type U</returns>
        public static IEnumerable<U> flatten<U>(IEnumerable<T> lst, Func<T, IEnumerable<U>> fn) {
            foreach (T t in lst) {
                foreach (U u in fn(t)) {
                    yield return u;
                }
            }
        }
        /// <summary>
        /// Takes a sequence of T and an accumulation function
        /// </summary>
        /// <returns>the accumulation of the sequence</returns>
        public static T reduce(IEnumerable<T> lst,Func<T, T, T> acc) { return lst.Aggregate(acc);}
        /// <summary>
        /// Takes an enumeration of T, an accumulation function, and an initial item, and applies the accumulation function acc to all the element.
        /// </summary>
        /// <returns>A U</returns>
        public static T reduce(IEnumerable<T> lst, Func<T, T, T> acc, T initialItem) { return lst.Aggregate(initialItem, acc); }
        /// <summary>
        /// Takes an enumeration of T, and applies the accumulation function acc to all the element.
        /// </summary>
        /// <returns>A U</returns>
        public static U reduce<U>(IEnumerable<T> lst, Func<U, T, U> acc, U initialItem) {
            return lst.Aggregate<T, U, U>(initialItem, acc, z => z);
        }
        
        /// <summary>
        /// Takes an enumeration of T, and applies the accumulation function acc to all the element.
        /// </summary>
        /// <returns>A U</returns>
        public static U reduce<U>(IEnumerable<T> lst, Func<U, T, T, U> acc, T initialItem, U initialResult) {
            U runningResult = initialResult;
            T lastItem = initialItem;
            foreach (T currentItem in lst) {
                runningResult = acc(runningResult, lastItem, currentItem);
                lastItem = currentItem;
            }
            return runningResult;
        }
        public static void AddNonNull(IList<T> lst, T t) { if (null != t) lst.Add(t); }
    }
    public class Listener<T, U> : IListener<T, U> {
        private Func<T, U> fun;
        public Listener(Func<T, U> fn) { this.fun = fn;  }
        public U Handle(T m) { return this.fun(m); }
    }
    public class Default<T> : IDefault<T> where T : class {
        public Default(T t) { this.d = t; }
        private T d = null;
        /// <summary>
        /// Function that takes a potentially null object
        /// </summary>
        /// <returns>the original object, or the default object if the original object is null</returns>
        public T orDefault(T t) {
            if (null == this.d) throw new NullReferenceException("default value not set");
            return (null != t) ? t : this.d;
        }
    }

    public class Curry1<T, U> : ICurry1<T, U> {
        private Func<T, U> fn;
        public Curry1(Func<T, U> fun) { this.fn = fun; }
        /// <summary>
        /// Creates a curry function object
        /// </summary>
        /// <returns>curry function object</returns>
        public Func<T, U> Create() { return (x) => this.fn(x); }
    }
    public class Curry2<T, U> : ICurry2<T, U> {
        private Func<T, U, U> fn; // U fn(T t, U u)
        public Curry2(Func<T, U, U> fun) { this.fn = fun; }
        /// <summary>
        /// Creates a curry function object
        /// </summary>
        /// <returns>curry function object</returns>
        public Func<U, U> Create(T t) { return (x) => this.fn(t, x); }
    }


    /// <summary>
    /// A compare object requires by a sort function in the .NET framework
    /// </summary>
    /// <returns>System.Collections.Generic.Comparer&lt;T&gt;</returns>
    public class Comparer<T> : System.Collections.Generic.Comparer<T> {
        private Func<T, T, int> compare;
        public Comparer(Func<T, T, int> fn) { this.compare = fn; }
        public override int Compare(T x, T y) {
            return this.compare.Invoke(x, y);
        }
    }
}
