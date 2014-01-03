using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Contracts;

//using validate = Validate.NonNullArgument; 
namespace Functional.Implementation {
    public class Something<T> : ISomething<T> {
        public T Item { get; set; }
        public override string ToString() { return this.Item.ToString(); }
        private Something(T t){ this.Item = t; }
        public static Func<T,ISomething<T>> Create = (t) => new Something<T>(t);
        public static Func<T,T,int> compare = (t1, t2) => 0; //set this to be useful
        public static Func<ISomething<T>,ISomething<T>,int> Compare = (t1,t2) => compare(t1.Item, t2.Item);
    }
    public class SomethingImmutable<T> : ISomethingImmutable<T> {
        public T Item { get; private set; }
        public override string ToString() { return this.Item.ToString(); }
        private SomethingImmutable(T t) { this.Item = t; }
        public static Func<T,ISomethingImmutable<T>> Create = (t) => new SomethingImmutable<T>(t);
        public static Func<T,T,int> compare = (t1, t2) => 0; //set this to be useful
        public static Func<ISomethingImmutable<T>,ISomethingImmutable<T>,int> Compare = (t1,t2) => compare(t1.Item, t2.Item);
    }
    public static class F {
        private const string FN = "fn";
        private const string ITEM = "item";
        private const string LST = "lst";
        private const string LEFT = "left";
        private const string RIGHT = "right";
        private const string X = "x";
        private const string Y = "y";

        public static void DoNothins() { }
        public static void DoNothing<T>(T t) { }
        public static void DoNothing<T,U>(T t, U u) { }
        public static void DoNothing<T,U,V>(T t, U u, V v) { }

        /// <summary>returns a function that returns either true or false</summary><returns>a Function that returns a bool</returns>
        public static Func<bool> always(bool b) { return (b) ? alwaysTrue() : alwaysFalse(); }
        /// <summary>returns a function that returns true</summary><returns>a Function that returns a bool</returns>
        public static Func<Func<bool>> alwaysTrue = () => () => true;
        /// <summary>returns a function that returns false</summary><returns>a Function that returns a bool</returns>
        public static Func<Func<bool>> alwaysFalse = () => () => false;

        public static Func<string, IEnumerable<char>> Chars = (item) => {
            Validate.NonNullArgument(item, ITEM);
            return item.AsEnumerable();
        };
        public static Func<IEnumerable<char>,string> CharSequenceToString = (lst) => {
            Validate.NonNullArgument(lst, LST);
            return F<char>.reduce<string>(lst,F.add_char_to_string, String.Empty);
        };
        public static Func<int,bool> even = (x) => (0 == (x & 0x0001));
        public static Func<int,bool>  odd = (x) => (1 == (x & 0x0001));
        public static bool And(this bool b, bool other) { return F.and(b, other); }
        public static bool Or(this bool b, bool other) { return F.or(b, other); }
        public static bool All(bool b) { return b; }
        public static bool All(bool b1, bool b2) { return F.and(b1, b2); }
        public static bool All(bool b1, bool b2, bool b3) { return (b1 && b2 && b3); }
        public static bool All(bool b1, bool b2, bool b3, bool b4) { return (b1 && b2 && b3 && b4); }
        public static bool All(bool b1, bool b2, bool b3, bool b4, bool b5) { return (b1 && b2 && b3 && b4 && b5); }
        public static bool All(bool b1, bool b2, bool b3, bool b4, bool b5, bool b6) { return (b1 && b2 && b3 && b4 && b5 && b6); }
        public static bool Any(bool b) { return b; }
        public static bool Any(bool b1, bool b2) { return F.or(b1, b2); }
        public static bool Any(bool b1, bool b2, bool b3) { return (b1 || b2 || b3); }
        public static bool Any(bool b1, bool b2, bool b3, bool b4) { return (b1 || b2 || b3 || b4); }
        public static bool Any(bool b1, bool b2, bool b3, bool b4, bool b5) { return (b1 || b2 || b3 || b4 || b5); }
        public static bool Any(bool b1, bool b2, bool b3, bool b4, bool b5, bool b6) { return (b1 || b2 || b3 || b4 || b5 || b6); }

        public static Func<int,int,int>              compare = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        public static Func<int,int,int>          compare_int = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        public static Func<long,long,int>       compare_long = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        public static Func<short,short,int>    compare_short = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        public static Func<bool,bool,int>       compare_bool = (l, r) => (eqv(l, r)) ? 0 : (l == false) ? -1 : 1;
        public static Func<char,char,int>       compare_char = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1;
        public static Func<string, string, int> compare_string = (left, right) => {
            Validate.NonNullArgument(left, LEFT);
            Validate.NonNullArgument(right, RIGHT);
            return String.Compare(left, right);
        };
        public static Func<string,string,int> compare_string_case_insensative = (left, right) => {
            Validate.NonNullArgument(left, LEFT);
            Validate.NonNullArgument(right, RIGHT);
            return String.Compare(left.ToUpper(), right.ToUpper());
        };

        public static Func<int,int,bool>              equ = (left, right) => (left == right);
        public static Func<int,int,bool>          equ_int = (left, right) => (left == right);
        public static Func<long,long,bool>       equ_long = (left, right) => (left == right);
        public static Func<short,short,bool>    equ_short = (left, right) => (left == right);
        public static Func<bool,bool,bool>       equ_bool = eqv;
        public static Func<char,char,bool>       equ_char = (left, right) => (left == right);

        public static Func<int,int,bool>              neq = (left, right) => (left != right);
        public static Func<int,int,bool>          neq_int = (left, right) => (left != right);
        public static Func<long,long,bool>       neq_long = (left, right) => (left != right);
        public static Func<short,short,bool>    neq_short = (left, right) => (left != right);
        public static Func<bool,bool,bool>       neq_bool = xor;
        public static Func<char,char,bool>       neq_char = (left, right) => (left != right);

        public static Func<int,int,int>                 add = (x, y) => x + y;
        public static Func<int,int,int>             add_int = (x, y) => x + y;
        public static Func<long,long,long>         add_long = (x, y) => x + y;
        public static Func<short,short,short>     add_short = (x, y) => (short)(x + y); //beware overflow
        public static Func<float,float,float>     add_float = (x, y) => x + y;
        public static Func<double,double,double> add_double = (x, y) => x + y;

        public static Func<int,int,int>                 sub = (x, y) => x - y;
        public static Func<int,int,int>             sub_int = (x, y) => x - y;
        public static Func<long,long,long>         sub_long = (x, y) => x - y;
        public static Func<short,short,short>     sub_short = (x, y) => (short)(x - y); //beware underflow
        public static Func<float, float, float>   sub_float = (x, y) => x - y;
        public static Func<double,double,double> sub_double = (x, y) => x - y;

        public static Func<int,int,int>                 mult = (x, y) => x * y;
        public static Func<int,int,int>             mult_int = (x, y) => x * y;
        public static Func<long,long,long>         mult_long = (x, y) => x * y;
        public static Func<short,short,short>     mult_short = (x, y) => (short)(x * y);
        public static Func<float,float,float>     mult_float = (x, y) => x * y;
        public static Func<double,double,double> mult_double = (x, y) => x * y;

        public static Func<int, int, int>               max = (x, y) => (F.gt(x, y)) ? x : y;
        public static Func<int, int, int>           max_int = (x, y) => (F.gt(x, y)) ? x : y;
        public static Func<long,long,long>         max_long = (x, y) => (F.gt_long(x,y)) ? x : y;
        public static Func<short,short,short>     max_short = (x, y) => (F.gt_short(x,y)) ? x : y;
        public static Func<float,float,float>     max_float = (x, y) => (F.gt_float(x, y)) ? x : y;
        public static Func<double,double,double> max_double = (x, y) => (F.gt_double(x, y)) ? x : y;

        public static Func<int,int,int>                 min = (x, y) => (F.lt(x,y)) ? x : y;
        public static Func<int,int,int>             min_int = (x, y) => (F.lt(x,y)) ? x : y;
        public static Func<long,long,long>         min_long = (x, y) => (F.lt_long(x,y)) ? x : y;
        public static Func<short,short,short>     min_short = (x, y) => (F.lt_short(x,y)) ? x : y;
        public static Func<float,float,float>     min_float = (x, y) => (F.lt_float(x, y)) ? x : y;
        public static Func<double,double,double> min_double = (x, y) => (F.lt_double(x, y)) ? x : y;

        public static Func<int,int>              neg = (x) => -x;
        public static Func<int,int>          neg_int = (x) => -x;
        public static Func<long,long>       neg_long = (x) => -x;
        public static Func<short,short>    neg_short = (x) => (short)(-x);
        public static Func<float,float>    neg_float = (x) => -x;
        public static Func<double,double> neg_double = (x) => -x;

        public static Func<int,int>           inc = (x) => F.add(x,1);
        public static Func<int, int>      inc_int = inc;
        public static Func<long,long>    inc_long = (x) => F.add_long(x,1L);
        public static Func<short,short> inc_short = (x) => (short)(x + 1);


        
        public static Func<float,float,bool>             close_float = (x, y) => (F.lt_float(Math.Abs(F.sub_float(x,y)),0.01f));
        public static Func<double,double,bool>          close_double = (x, y) => (F.lt_double(Math.Abs(F.sub_double(x, y)), 0.01d));
        public static Func<float,float,float,float>      clamp_float = (x,min,max) => (F.lt_float(x,min)) ? min : (F.gt_float(x,max)) ? max : x;
        public static Func<double,double,double,double> clamp_double = (x,min,max) => (F.lt_double(x,min)) ? min : (F.gt_double(x,max)) ? max : x;

        public static Func<int,int>               sqr = (x) => x * x;
        public static Func<int,int>           sqr_int = (x) => x * x;
        public static Func<long,long>        sqr_long = (x) => x * x;
        public static Func<short, short>    sqr_short = (x) => (short)(x * x);
        public static Func<float,float>     sqr_float = (x) => x * x;
        public static Func<double,double>  sqr_double = (x) => x * x;
        public static Func<float,float>    sqrt_float = (x) => { Validate.PositiveArgument(x, X); return (float)Math.Sqrt(x); };
        public static Func<double,double> sqrt_double = (x) => { Validate.PositiveArgument(x, X); return (float)Math.Sqrt(x); };
        
        public static Func<int,int,bool>                gt = (left, right) => (left > right);
        public static Func<int,int,bool>            gt_int = (left, right) => (left > right);
        public static Func<long,long,bool>         gt_long = (left, right) => (left > right);
        public static Func<short,short,bool>      gt_short = (left, right) => (left > right);
        public static Func<float, float, bool>    gt_float = (left, right) => (left > right);
        public static Func<double, double, bool> gt_double = (left, right) => (left > right);

        public static Func<int,int,bool>           gte = (left, right) => (left >= right);
        public static Func<int,int,bool>       gte_int = (left, right) => (left >= right);
        public static Func<long,long,bool>    gte_long = (left, right) => (left >= right);
        public static Func<short,short,bool> gte_short = (left, right) => (left >= right);


        public static Func<int,int,bool>                lt = (left, right) => (left < right);
        public static Func<int,int,bool>            lt_int = (left, right) => (left < right);
        public static Func<long,long,bool>         lt_long = (left, right) => (left < right);
        public static Func<short,short,bool>      lt_short = (left, right) => (left < right);
        public static Func<float, float, bool>    lt_float = (left, right) => (left < right);
        public static Func<double, double, bool> lt_double = (left, right) => (left < right);


        public static Func<int,int,bool>           lte = (left, right) => (left <= right); // this is one reason why operators suck
        public static Func<int,int,bool>       lte_int = (left, right) => (left <= right);
        public static Func<long,long,bool>    lte_long = (left, right) => (left <= right);
        public static Func<short,short,bool> lte_short = (left, right) => (left <= right);

        

        public static Func<bool,bool,bool>  or = (left, right) => left || right;
        public static Func<bool,bool,bool> and = (left, right) => left && right;
        public static Func<bool,bool,bool> xor = (left, right) => left != right;
        public static Func<bool,bool,bool> eqv = (left, right) => left == right;
        public static Func<bool,bool> not = x => !x;
        /// <summary>A function given two strings, returns the combined string</summary><returns>A combined string</returns>
        public static Func<string, string, string> add_string = (left, right) => {
            Validate.NonNullArgument(left, LEFT);
            Validate.NonNullArgument(right, RIGHT);
            return left + right;
        };
        /// <summary>A function given two strings, true if they are equal</summary><returns>true if they are equal</returns>
        public static Func<string, string, bool> equ_string = (left, right) => {
            Validate.NonNullArgument(left, LEFT);
            Validate.NonNullArgument(right, RIGHT);
            return left == right;
        };
        /// <summary>A function given two strings, true if they are not equal</summary><returns>true if they are not equal</returns>
        public static Func<string, string, bool> neq_string = (left, right) => {
            Validate.NonNullArgument(left, LEFT);
            Validate.NonNullArgument(right, RIGHT);
            return left != right;
        };
        public static Func<string, char, string> add_char_to_string = (left, c) => {
            Validate.NonNullArgument(left, LEFT);
            return left + c;
        };
        

        public static Func<bool, IEnumerable<bool>> infinite_bool = (b) => F<bool>.forever(b);
        public static Func<bool, IEnumerable<bool>> infinite_bool_toggle = (b) => F<bool>.forever(not, b);


        /// <summary>A function given start, returns an infinite sequence of increasing integers. (warning: integer overflow)</summary><returns>An infinite sequence of increasing integers</returns>
        public static Func<int,IEnumerable<int>> infinite_range = (start) => F<int>.forever((n)=>n+1,start);
        public static IEnumerable<int> range(int start, int end) {
            int step = (F.gt(F.sub(end,start),0)) ? 1 : -1;
            for (int i = start; F.neq(i, end); i=F.add(i,step)) yield return i;
        }
        public static IEnumerable<int> range(int start, int end, int step) {
            int Step = (F.gt(F.sub(end,start),0)) ? Math.Abs(step) : -Math.Abs(step);
            Func<int, int, bool> condition = (F.gt(F.sub(end,start),0)) ? F.lt : F.gt;
            for (int i = start; condition(i, end); i = F.add(i,Step)) yield return i;
        }
        public static IEnumerable<int> range(int end) { return range(0, end); }
        /// <summary>A function given minimum, and maximum, that returns a sequence of random integers</summary><returns>An infinite sequence of random integers between minimum and maximum</returns>
        public static IEnumerable<int> random(int minimum, int maximum) {
            Random r = new Random(DateTime.Now.Millisecond);
            while (true) yield return r.Next(minimum, maximum);
        }
        /// <summary>A function given length, that returns a sequence of random integers</summary><returns>A sequence of random integers</returns>
        public static IEnumerator<int> random(int count) {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; lt(i,count); i=inc(i)) yield return r.Next();
        }
        /// <summary>A function given length, minimum, and maximum, that returns a sequence of random integers</summary><returns>A sequence of random integers between minimum and maximum</returns>
        public static IEnumerable<int> random(int count, int minimum, int maximum) {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; lt(i,count); i=inc(i)) yield return r.Next(minimum, maximum);
        }
        public static Func<string, int> string_to_int = (item) => {
            Validate.NonNullArgument(item, ITEM);
            int result = 0;
            int.TryParse(item, out result);
            return result;
        };
        public static Func<string, long> string_to_long = (item) => {
            Validate.NonNullArgument(item, ITEM);
            long result = 0;
            long.TryParse(item, out result);
            return result;
        };
        public static Func<string, short> string_to_short = (item) => {
            Validate.NonNullArgument(item, ITEM);
            short result = 0;
            short.TryParse(item, out result);
            return result;
        };
        public static Func<string, float> string_to_float = (item) => {
            Validate.NonNullArgument(item, ITEM);
            float result = 0.0f;
            float.TryParse(item, out result);
            return result;
        };
        public static Func<string, double> string_to_double = (item) => {
            Validate.NonNullArgument(item, ITEM);
            double result = 0.0d;
            double.TryParse(item, out result);
            return result;
        };

        public static Func<string, bool> string_to_bool = (item) => {
            Validate.NonNullArgument(item, ITEM);
            return F.equ_string("TRUE", item.ToUpper());
        };

        public static Action<Action<int>,int>          InvokeInt = F<int>.invoke;
        public static Action<Action<long>,long>       InvokeLong = F<long>.invoke;
        public static Action<Action<short>,short>    InvokeShort = F<short>.invoke;
        public static Action<Action<bool>,bool>       InvokeBool = F<bool>.invoke;
        public static Action<Action<char>, char>      InvokeChar = F<char>.invoke;
        public static Action<Action<string>,string> InvokeString = F<string>.invoke;

        public static Func<Func<int,int>,int,int>                ApplyInt = F<int>.apply;
        public static Func<Func<long,long>,long,long>           ApplyLong = F<long>.apply;
        public static Func<Func<short,short>,short,short>      ApplyShort = F<short>.apply;
        public static Func<Func<bool,bool>,bool,bool>           ApplyBool = F<bool>.apply;
        public static Func<Func<char,char>,char,char>           ApplyChar = F<char>.apply;
        public static Func<Func<string,string>,string,string> ApplyString = F<string>.apply;



    }
    public static class F<T>   {
        private const string FILENAME = "filename";
        private const string ITEM = "item";
        private const string FN = "fn";
        private const string ACC = "acc";
        private const string ACTION = "action";
        private const string PREDICATE = "predicate";
        private const string LST = "lst";
        private const string LST1 = "lst1";
        private const string LST2 = "lst2";
        private const string LST3 = "lst3";

        public static Func<T, T> identity = (item) => item;

        public static void invoke(Action<T> action,T t) {
            Validate.NonNullArgument(action, ACTION);
            action.Invoke(t);
        }
        public static void invoke(Action<T,T> action,T t1, T t2) {
            Validate.NonNullArgument(action, ACTION);
            action.Invoke(t1, t2);
        }
        public static void invoke(Action<T,T,T> action, T t1, T t2, T t3) {
            Validate.NonNullArgument(action, ACTION);
            action.Invoke(t1, t2, t3);
        }
        public static T apply(Func<T,T> fn, T t)  {
            Validate.NonNullArgument(fn, FN);
            return fn.Invoke(t);
        }
        public static T apply(Func<T, T, T> fn, T t1, T t2) {
            Validate.NonNullArgument(fn, FN);
            return fn.Invoke(t1, t2);
        }
        public static T apply(Func<T,T,T,T> fn, T t1, T t2, T t3) {
            Validate.NonNullArgument(fn, FN);
            return fn.Invoke(t1, t2, t3);
        }
        /// <summary>Given a function that takes a T and function that takes an T and returns a X, return a function that takes an X</summary><returns>Function that takes an X</returns>
        public static Action<T> transform<X>(Action<X> action, Func<T, X> fn) {
            Validate.NonNullArgument(action, ACTION);
            Validate.NonNullArgument(fn, FN);
            return (n) => action(fn(n)); 
        }
        /// <summary>from a sequence of dictionaries, get all the values that share the key</summary><returns>sequence of items</returns>
        public static IEnumerable<T> items(IEnumerable<IDictionary<string, T>> lst, string item) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(item, ITEM);
            foreach (IDictionary<string, T> dictionary in lst) {
                if (dictionary.Keys.Contains(item)) yield return dictionary[item];
            }
        }
        /// <summary>true if both sequences are the same. Not valid for sequences of functions.</summary><returns>bool</returns>
        public static Func<IEnumerable<T>, IEnumerable<T>, Func<T, T, bool>, bool> same = (lst1, lst2, fn) => {
            Validate.NonNullArgument(lst1, LST1);
            Validate.NonNullArgument(lst2, LST2);
            Validate.NonNullArgument(fn, FN);
            IEnumerator<T> i1 = lst1.GetEnumerator();
            IEnumerator<T> i2 = lst2.GetEnumerator();
            bool result = true;
            bool b1 = i1.MoveNext();
            bool b2 = i2.MoveNext();
            while (F.and(result,F.and(b1,b2))) {
                result = fn(i1.Current, i2.Current);
                b1 = i1.MoveNext();
                b2 = i2.MoveNext();
            }
            return (F.and(result,F.equ_bool(b1,b2)));
        };
        /// <summary>Given a sequence and a predicate, indicates if any elemnt passes the predicate</summary><returns>true if any of the elements pass the predicate function</returns>
        public static Func<IEnumerable<T>, Func<T, bool>, bool> any = (lst, predicate) => {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(predicate, PREDICATE);
            return lst.Any(predicate);
        };
        /// <summary>Given a sequence and a predicate, indicates if every elemnt passes the predicate</summary><returns>true if all the elements pass the predicate function</returns>
        public static Func<IEnumerable<T>, Func<T, bool>, bool> all = (lst, predicate) => {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(predicate, PREDICATE);
            return lst.All(predicate);
        };
        /// <summary>Given a sequence and a predicate, return the filtered sequence</summary><returns>a sequence of T that meets the criteria of the predicate function</returns>
        public static Func<IEnumerable<T>, Func<T, bool>, IEnumerable<T>> filter = (lst, predicate) => {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(predicate, PREDICATE);
            return lst.Where(predicate);
        };
        /// <summary>Given a predicate function fn(x) return !fn(x)</summary><returns>The compliment if the predicate function</returns>
        public static Func<T, bool> compliment(Func<T, bool> fn) {
            Validate.NonNullArgument(fn, FN);
            return (t) => { return !fn(t); }; 
        }
        /// <summary>Swap the order of the parameters. compliment of f(a,b) is f(b,a)</summary><returns>T, the result of the call</returns>
        public static Func<T, T, T> compliment(Func<T, T, T> fn) {
            Validate.NonNullArgument(fn, FN);
            return (x, y) => { return fn(y, x); }; 
        }
        /// <summary>get the first element of a sequence</summary><returns>The first element of an IEnumerable</returns>
        public static Func<IEnumerable<T>, T> first = (lst) => {
            Validate.NonNullArgument(lst, LST);
            return lst.First();
        };
        /// <summary>get the sequence following the first element of a sequence</summary><returns>an IEnermerable following the first element</returns>
        public static Func<IEnumerable<T>, IEnumerable<T>> rest = (lst) => {
            Validate.NonNullArgument(lst, LST);
            return lst.Skip(1);
        };
        /// <summary>find the first item that meets the condition function throws System.InvalidOperationException if no match is found</summary><returns>T or null</returns>
        public static Func<IEnumerable<T>, Func<T, bool>, T> find = (lst, predicate) => {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(predicate, PREDICATE);
            return lst.First(predicate);
        };
        /// <summary>sorts a finite sequnce.</summary><returns>a sequence</returns>
        public static Func<IEnumerable<T>, Func<T, T, int>, IEnumerable<T>> sort = (lst, fn) => {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            T[] x = lst.ToArray();
            Array.Sort(x, new Comparer<T>(fn));
            return x.ToList();
        };
        /// <summary>sorts a sequence (most of the time)</summary><returns>a sorted sequence</returns>
        public static Func<IEnumerable<T>, Func<T, T, int>, IEnumerable<T>> sort_order_by = (lst, fn) => {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            return lst.OrderBy(F<T>.identity, new Comparer<T>(fn));
        };
        /// <summary>Bubble sort a finite sequence.</summary><returns>A sorted sequence</returns>
        public static Func<IEnumerable<T>, Func<T, T, int>, IEnumerable<T>> sort_bubble_sort = (lst, fn) => {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            T[] array = lst.ToArray();
            bool swapped = true;
            while (swapped) {
                swapped = false;
                for (int i = 0; F.lt(i,array.Length - 1); i=F.inc(i)) {
                    if (F.gt(fn(array[i], array[1 + 1]),0)) {
                        swapped = true;
                        T temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
            return array;
        };
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        public static void each(IEnumerable<T> lst,Action<T> fn) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) fn(t); 
        }
        public static void each<U>(IEnumerable<T> lst, Action<T,U> fn, U u) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) fn(t, u); 
        }
        public static void each<U,V>(IEnumerable<T> lst, Action<T,U,V> fn, U u, V v) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) fn(t, u, v); 
        }
        public static void each<U,V,W>(IEnumerable<T> lst, Action<T,U,V,W> fn, U u, V v, W w) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) fn(t, u, v, w); 
        }
        public static void each<U,V,W,X>(IEnumerable<T> lst, Action<T,U,V,W,X> fn, U u, V v, W w, X x) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) fn(t, u, v, w, x); 
        }
        public static void each<U, V>(IEnumerable<T> lst, Action<T, U, V> fn, U u, Func<V, V> acc, V init) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            Validate.NonNullArgument(acc,ACC);
            V current = init;
            foreach (T t in lst) {
                fn(t, u, current);
                current = acc(current);
            }
        }

        /// <summary>runs an accumulatr function as long as the check function is true</summary><returns>a sequence of T</returns>
        public static IEnumerable<T> iterate_while(Func<T, T> fn, Func<T, bool> predicate, T init) {
            Validate.NonNullArgument(fn, FN);
            Validate.NonNullArgument(predicate, PREDICATE);
            T result = init;
            while (predicate(result)) {
                yield return result;
                result = fn(result);
            }
        }
        /// <summary>returns a function that return the input</summary><returns>a Function</returns>
        public static Func<T> always(T t) { return () => t; }

        public static IEnumerable<T> limit(IEnumerable<T> lst, int count) {
            Validate.NonNullArgument(lst, LST);
            Validate.PositiveArgument(count, "count");
            return lst.Take(count); 
        }
        public static IEnumerable<T> forever(T t) { while (true) yield return t; }
        public static IEnumerable<T> forever(Func<T, T> fn, T t) {
            Validate.NonNullArgument(fn, FN);
            T result = t;
            while (true) {
                yield return result;
                result = fn(result);
            }
        }
        /// <summary>returns a sequence that is the result of a sequence transformed by a function</summary><returns>A sequence of objects of type T</returns>
        public static IEnumerable<U> map<U>(IEnumerable<T> lst, Func<T,U> fn) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            return lst.Select(fn); 
        }
        public static IEnumerable<U> map<U,V>(IEnumerable<T> lst, Func<T,V,U> fn, V v) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) yield return fn(t, v);
        }
        public static IEnumerable<U> map<U,V,W>(IEnumerable<T> lst, Func<T,V,W,U> fn, V v, W w) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) yield return fn(t, v, w);
        }
        public static IEnumerable<U> map<U,V,W,X>(IEnumerable<T> lst, Func<T,V,W,X,U> fn, V v, W w, X x) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) yield return fn(t, v, w, x);
        }
        /// <summary>returns a sequence that is fed by two other sequences and a combining function fn</summary><returns>A sequence of objects of type T</returns>
        public static IEnumerable<U> map<U>(IEnumerable<T> lst1, IEnumerable<T> lst2, Func<T, T, U> fn) {
            Validate.NonNullArgument(lst1, LST1);
            IEnumerator<T> one = lst1.GetEnumerator();
            IEnumerator<T> two = lst2.GetEnumerator();
            while ((one.MoveNext()) && (two.MoveNext())) {
                yield return fn(one.Current, two.Current);
            }
        }
        /// <summary>returns a sequence that is fed by three other sequences and a combining function fn</summary><returns>A sequence of objects of type T</returns>
        public static IEnumerable<U> map<U>(IEnumerable<T> lst1, IEnumerable<T> lst2, IEnumerable<T> lst3, Func<T, T, T, U> fn) {
            Validate.NonNullArgument(lst1, LST1);
            Validate.NonNullArgument(lst2, LST2);
            Validate.NonNullArgument(lst3, LST3);
            Validate.NonNullArgument(fn, FN);
            IEnumerator<T> one = lst1.GetEnumerator();
            IEnumerator<T> two = lst2.GetEnumerator();
            IEnumerator<T> three = lst3.GetEnumerator();
            while ((one.MoveNext()) && (two.MoveNext()) && (three.MoveNext())) {
                yield return fn(one.Current, two.Current, three.Current);
            }
        }
        /// <summary>Takes a sequence of objects of type T and a map function that transforms an object of type T to a sequence of objects of type U</summary><returns>A sequence of objects of type U</returns>
        public static IEnumerable<U> flatten<U>(IEnumerable<T> lst, Func<T, IEnumerable<U>> fn) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) {
                foreach (U u in fn(t)) {
                    yield return u;
                }
            }
        }
        /// <summary>Takes a sequence of T and an accumulation function</summary><returns>the accumulation of the sequence</returns>
        public static T reduce(IEnumerable<T> lst,Func<T, T, T> fn) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            return lst.Aggregate(fn);
        }
        /// <summary>Takes an enumeration of T, an accumulation function, and an initial item, and applies the accumulation function acc to all the element.</summary><returns>A U</returns>
        public static T reduce(IEnumerable<T> lst, Func<T, T, T> fn, T item) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            Validate.NonNullArgument(item, ITEM);
            return lst.Aggregate(item, fn); 
        }
        /// <summary>Takes an enumeration of T, and applies the accumulation function acc to all the element.</summary><returns>A U</returns>
        public static U reduce<U>(IEnumerable<T> lst, Func<U, T, U> fn, U item) {
            Validate.NonNullArgument(lst,LST);
            Validate.NonNullArgument(fn,FN);
            Validate.NonNullArgument(item, ITEM);
            return lst.Aggregate<T, U, U>(item, fn, z => z);
        }
        
        /// <summary>Takes an enumeration of T, and applies the accumulation function acc to all the element.</summary>
        /// <param name="initialItem">Initial value</param>
        /// <returns>A U</returns>
        public static U reduce<U>(IEnumerable<T> lst, Func<U, T, T, U> fn, T initialItem, U initialResult) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            U runningResult = initialResult;
            T lastItem = initialItem;
            foreach (T currentItem in lst) {
                runningResult = fn(runningResult, lastItem, currentItem);
                lastItem = currentItem;
            }
            return runningResult;
        }
        public static IEnumerable<KeyValuePair<T, U>> combination<U>(IEnumerable<T> keys, IEnumerable<U> values) {
            foreach (T key in keys) {
                foreach (U value in values) {
                    yield return new KeyValuePair<T, U>(key, value);
                }
            }
        }
        public static Action<T, T[], int> set_array = (item, array, index) => {
            Validate.NonNullArgument(array,"array");
            Validate.PositiveArgument(index, "index");
            if (index >= array.Length) throw new ArgumentOutOfRangeException("index");
            array[index] = item;
        };
        public static Func<T[], int, T> get_array = (array, index) => {
            Validate.NonNullArgument(array, "array");
            Validate.PositiveArgument(index, "index");
            if (index >= array.Length) throw new ArgumentOutOfRangeException("index");
            return array[index];
        };
        public static IChain<T> Run(IChain<T> item, T t) {
            Validate.NonNullArgument(item, ITEM);
            return item.Run(t);
        }
        public static void AddNonNull(IList<T> lst, T t) { 
            Validate.NonNullArgument(lst, LST);
            if (null != t) lst.Add(t); 
        }
        public static void Add(IList<T> lst, T item) {
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(item, ITEM);
            lst.Add(item);
        }
        public static string toString(T item) {
            Validate.NonNullArgument(item, ITEM);
            return item.ToString();
        }
        public static IEnumerable<T> LoadTextFile(string filename, Encoding encoding, Func<string, T> fn) {
            Validate.StringArgument(filename, FILENAME);
            Validate.NonNullArgument(fn, FN);
            using (TextReader sr = new StreamReader(filename, encoding)) {
                string line = sr.ReadLine();
                while (!String.IsNullOrEmpty(line)) {
                    yield return fn(line);
                    line = sr.ReadLine();
                }
            }
        }
        public static void StoreTextFile(string filename, Encoding encoding, IEnumerable<T> item, Func<T, string> fn) {
            Validate.StringArgument(filename, FILENAME);
            Validate.NonNullArgument(item, ITEM);
            Validate.NonNullArgument(fn, FN);
            using (TextWriter sw = new StreamWriter(filename, false, encoding)) {
                F<string>.each(F<T>.map<string>(item, fn), (s) => sw.WriteLine(s));
            }
        }
    }
    public class Chain<T> : IChain<T> {
        private Func<T, bool> fn = null;
        private Chain(T t,Func<T, bool> predicate) {
            this.Item = t;
            this.fn = predicate;
        }
        public T Item { get; private set; }
        public IChain<T> Run(T t) {
            IChain<T> result = null;
            if (this.fn(t)) result = this;
            return result;
        }
        public static IChain<T> Create(T t, Func<T, bool> predicate) { return new Chain<T>(t, predicate); }
    }
    public class Listener<T, U> : IListener<T, U> {
        private const string FUN = "fun";
        private Func<T, U> fn;
        private Listener(Func<T, U> fun) 
        {
            Validate.NonNullArgument(fun, FUN);
            this.fn = fun;
            this.Handle = (t)=>this.fn(t);
        }
        public Func<T,U> Handle { get; private set; }
        public static IListener<T, U> Create(Func<T, U> fun) {
            Validate.NonNullArgument(fun, FUN);
            return new Listener<T, U>(fun);
        }
    }
    public class Default<T> : IDefault<T> where T : class {
        private const string ITEM = "item";
        public Default(T item) {
            Validate.NonNullArgument(item, ITEM);
            this.d = item;
            this.orDefault = (x) =>  (null != x) ? x : this.d;
        }
        private T d = null;
        /// <summary>Function that takes a potentially null object</summary><returns>the original object, or the default object if the original object is null</returns>
        public Func<T,T> orDefault { get; private set; }
    }

    public class Curry1<T, U> : ICurry1<T, U> {
        private const string FUN = "fun";
        private Func<T, U> fn;
        public Curry1(Func<T, U> fun) {
            Validate.NonNullArgument(fun, FUN);
            this.fn = fun;
            this.Create = () => (x) => this.fn(x);
        }
        /// <summary>Creates a curry function object</summary><returns>curry function object</returns>
        public Func<Func<T, U>> Create { get; private set; } 
    }
    public class Curry2<T, U> : ICurry2<T, U> {
        private const string FUN = "fun";
        private Func<T, U, U> fn; // U fn(T t, U u)
        public Curry2(Func<T, U, U> fun) {
            Validate.NonNullArgument(fun, FUN);
            this.fn = fun; 
            this.Create = (t) => (x) => this.fn(t, x);
        }
        /// <summary>Creates a curry function object</summary><returns>curry function object</returns>
        public Func<T,Func<U, U>> Create { get; private set; }
    }
    public class Curry<T> : ICurry<T> { //TODO needs test coverage
        private const string FUN = "fun";
        private enum Which {
            _fn_1_1,
            _fn_2_1,
            _fn_3_1,
            _fn_4_1,
            _fn_5_1,
            _fn_6_1,
            _fn_7_1
        }
        private Which which;
        
        private Func<T,T> fn_1_1;
        private Func<T,T,T> fn_2_1;
        private Func<T,T,T,T> fn_3_1;
        private Func<T,T,T,T,T> fn_4_1;
        private Func<T,T,T,T,T,T> fn_5_1;
        private Func<T,T,T,T,T,T,T> fn_6_1;
        private Func<T, T,T,T,T,T,T,T> fn_7_1;
        public Curry(Func<T,T> fun) {
            Validate.NonNullArgument(fun, FUN);
            this.which = Which._fn_1_1;
            this.fn_1_1 = fun;
        }
        public Curry(Func<T,T,T> fun) {
            Validate.NonNullArgument(fun, FUN);
            this.which = Which._fn_2_1;
            this.fn_2_1 = fun;
        }
        public Curry(Func<T,T,T,T> fun) {
            Validate.NonNullArgument(fun, FUN);
            this.which = Which._fn_3_1;
            this.fn_3_1 = fun;
        }
        public Curry(Func<T,T,T,T,T> fun) {
            Validate.NonNullArgument(fun, FUN);
            this.which = Which._fn_4_1;
            this.fn_4_1 = fun;
        }
        public Curry(Func<T,T,T,T,T,T> fun) {
            Validate.NonNullArgument(fun, FUN);
            this.which = Which._fn_5_1;
            this.fn_5_1 = fun;
        }
        public Curry(Func<T,T,T,T,T,T,T> fun) {
            Validate.NonNullArgument(fun, FUN);
            this.which = Which._fn_6_1;
            this.fn_6_1 = fun;
        }
        public Curry(Func<T,T,T,T,T,T,T,T> fun) {
            Validate.NonNullArgument(fun, FUN);
            this.which = Which._fn_7_1;
            this.fn_7_1 = fun;
        }
        public Action<T> Create() {
            if (this.which != Which._fn_1_1) throw new Exception("invalid");
            return (t) => this.fn_1_1(t);
        }
        public Func<T,T> Create(T t1) {
            if (this.which != Which._fn_2_1) throw new Exception("invalid");
            return (t) => this.fn_2_1(t, t1);
        }
        public Func<T,T> Create(T t1, T t2) {
            if (this.which != Which._fn_3_1) throw new Exception("invalid");
            return (t) => this.fn_3_1(t, t1, t2);
        }
        public Func<T,T> Create(T t1, T t2, T t3) {
            if (this.which != Which._fn_4_1) throw new Exception("invalid");
            return (t) => this.fn_4_1(t, t1, t2, t3);
        }
        public Func<T, T> Create(T t1, T t2, T t3, T t4) {
            if (this.which != Which._fn_5_1) throw new Exception("invalid");
            return (t) => this.fn_5_1(t, t1, t2, t3, t4);
        }
        public Func<T, T> Create(T t1, T t2, T t3,T t4,T t5) {
            if (this.which != Which._fn_6_1) throw new Exception("invalid");
            return (t) => this.fn_6_1(t, t1, t2, t3,t4,t5);
        }
        public Func<T, T> Create(T t1, T t2, T t3,T t4,T t5,T t6) {
            if (this.which != Which._fn_7_1) throw new Exception("invalid");
            return (t) => this.fn_7_1(t, t1, t2, t3, t4, t5, t6);
        }
    }

    /// <summary>A compare object requires by a sort function in the .NET framework</summary><returns>System.Collections.Generic.Comparer&lt;T&gt;</returns>
    public class Comparer<T> : System.Collections.Generic.Comparer<T> {
        private const string X = "x";
        private const string Y = "y";
        private const string FN = "fn";
        private Func<T, T, int> compare;
        public Comparer(Func<T, T, int> fn) {
            Validate.NonNullArgument(fn, FN);
            this.compare = fn; 
        }
        public override int Compare(T x, T y) {
            Validate.NonNullArgument(x, X);
            Validate.NonNullArgument(y, Y);
            return this.compare.Invoke(x, y);
        }
    }
    public static class Validate {
        public static void NonNullArgument(object item, string name) { if (null == item) throw new ArgumentNullException(name); }
        public static void PositiveArgument(int n, string name) { if (n < 0) throw new ArgumentOutOfRangeException(name); }
        public static void PositiveArgument(float f,string name) { if (f<0.0f) throw new ArgumentOutOfRangeException(name); }
        public static void PositiveArgument(double d,string name) { if (d<0.0d) throw new ArgumentOutOfRangeException(name); }
        public static void StringArgument(string s, string name) { if (String.IsNullOrEmpty(s)) throw new ArgumentNullException(name); }
    }
    public static class Utility {
        public static int char_to_digit(char c) {
            int result = 0;
            switch (c) {
                case '0': result = 0; break;
                case '1': result = 1; break;
                case '2': result = 2; break;
                case '3': result = 3; break;
                case '4': result = 4; break;
                case '5': result = 5; break;
                case '6': result = 6; break;
                case '7': result = 7; break;
                case '8': result = 8; break;
                case '9': result = 9; break;
            }
            return result;
        }
        public static char digit_to_char(int d) {
            char result = '0';
            switch (d) {
                case 0: result = '0'; break;
                case 1: result = '1'; break;
                case 2: result = '2'; break;
                case 3: result = '3'; break;
                case 4: result = '4'; break;
                case 5: result = '5'; break;
                case 6: result = '6'; break;
                case 7: result = '7'; break;
                case 8: result = '8'; break;
                case 9: result = '9'; break;
            }
            return result;
        }
    }
    public class ServiceProvider : IServiceProvider {
        
        private const string TYPE = "type";
        private const string SERVICE = "service";
        private readonly IDictionary<Type, object> services = new Dictionary<Type, object>();
        public void AddService(Type type, object service) {
            Validate.NonNullArgument(type, TYPE);
            Validate.NonNullArgument(service, SERVICE);
            if (!type.IsAssignableFrom(service.GetType())) throw new ArgumentException("the service is not the type");
            // TODO: check for collision
            this.services.Add(type, service);
        }
        public object GetService(Type type) {
            Validate.NonNullArgument(type,TYPE);
            return this.services[type]; // TODO verify that it's there first, throw if it isn't
        }
        public void RemoveService(Type type) {
            Validate.NonNullArgument(type, TYPE);
            this.services.Remove(type); // TODO verify that it's there first, throw if it isn't
        }
    }
    public class Singleton<T> {
        private static Singleton<T> instance;
        private static Singleton<T> Instance { 
            get {
                if (null == instance) instance = new Singleton<T>();
                return instance; 
            } 
        }
        private Singleton(){}
    }

}
