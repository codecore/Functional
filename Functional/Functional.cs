using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

        private class Pair<U,V> : IPair<U,V> {
            public U Left { get; private set; }
            public V Right { get; private set; }
            private Pair() { }
            public Pair(U left, V right) { this.Left = left; this.Right = right; }
        }
        public static IEnumerable<IPair<U, V>> combination<U, V>(IEnumerable<U> Utems, IEnumerable<V> Vtems) {
            foreach (U u in Utems)
                foreach (V v in Vtems)
                    yield return new Pair<U, V>(u, v);
        }
        public static void DoNothing() { }
        public static void DoNothing<T>(T t) { }
        public static void DoNothing<T,U>(T t, U u) { }
        public static void DoNothing<T,U,V>(T t, U u, V v) { }

        public static Func<Action, Task> task_action = (a) => {
            Task task = new Task(a);
            task.Start();
            return task;
        };        

        /// <summary>returns a function that returns either true or false</summary><returns>a Function that returns a bool</returns>
        public static Func<bool> always(bool b) {  // TestCoverage = F, F_always, F_always_function 
            return (b) ? alwaysTrue() : alwaysFalse(); 
        }
        /// <summary>returns a function that returns true</summary><returns>a Function that returns a bool</returns>
        public static Func<Func<bool>> alwaysTrue = () => {  // TestCoverage = F, F_always, F_always_true
            return () => true; 
        };

        /// <summary>returns a function that returns false</summary><returns>a Function that returns a bool</returns>
        public static Func<Func<bool>> alwaysFalse = () => {  // TestCoverage = F, F_alwats, F_always_false
            return () => false; 
        };
        public static Func<bool, Task<bool>> boolAsync = (b) => F<bool>.task(b);
        public static Func<Task<bool>> trueAsync = () => F<bool>.task(true);
        public static Func<Task<bool>> falseAsync = () => F<bool>.task(false);
        public static Func<bool, Task<Func<bool>>> alwaysAsync = (b) => F<Func<bool>>.task(F.always(b));
        public static Func<Task<Func<bool>>> alwaysTrueAsync = () => F<Func<bool>>.task(F.alwaysTrue.Invoke());
        public static Func<Task<Func<bool>>> alwaysFalseAsync = () => F<Func<bool>>.task(F.alwaysFalse.Invoke());

        public static Func<string, IEnumerable<char>> chars = (item) => {
            // TestCoverage = F, F_chars
            Validate.NonNullArgument(item, ITEM);
            return item.AsEnumerable();
        };
        public static Func<IEnumerable<char>,string> CharSequenceToString = (lst) => {
            Validate.NonNullArgument(lst, LST);
            return F<char>.reduce<string>(lst,F.add_char_to_string, String.Empty);
        };
        public static Func<int,bool> even = (x) => (0 == (x & 0x0001)); // TestCoverage = F, F_even
        public static Func<int,bool>  odd = (x) => (1 == (x & 0x0001)); // TestCoverage = F, F_odd

        public static bool And(this bool b1, bool b2) { 
            // TestCoverage = bool_, bool_And
            return F.bool_and(b1, b2); 
        }
        public static bool Or(this bool b1, bool b2) { 
            // TestCoverage = bool_, bool_Or
            return F.bool_or(b1, b2); 
        }
        public static bool bool_and(bool b) { return b; } // TestCoverage = F, F_bool, F_bool_and
        public static bool bool_and(bool b1, bool b2) { return (b1 && b2); }
        public static bool bool_and(bool b1, bool b2, bool b3) { return (b1 && b2 && b3); }
        public static bool bool_and(bool b1, bool b2, bool b3, bool b4) { return (b1 && b2 && b3 && b4); }
        public static bool bool_and(bool b1, bool b2, bool b3, bool b4, bool b5) { return (b1 && b2 && b3 && b4 && b5); }
        public static bool bool_and(bool b1, bool b2, bool b3, bool b4, bool b5, bool b6) { return (b1 && b2 && b3 && b4 && b5 && b6); }
        public static bool bool_or(bool b) { return b; } // TestCoverage = F, F_bool, F_bool_or
        public static bool bool_or(bool b1, bool b2) { return (b1 || b2); }
        public static bool bool_or(bool b1, bool b2, bool b3) { return (b1 || b2 || b3); }
        public static bool bool_or(bool b1, bool b2, bool b3, bool b4) { return (b1 || b2 || b3 || b4); }
        public static bool bool_or(bool b1, bool b2, bool b3, bool b4, bool b5) { return (b1 || b2 || b3 || b4 || b5); }
        public static bool bool_or(bool b1, bool b2, bool b3, bool b4, bool b5, bool b6) { return (b1 || b2 || b3 || b4 || b5 || b6); }

        public static Func<bool, bool, bool> bool_xor = (left, right) => left != right; // TestCoverage = F, F_bool, F_bool_xor
        public static Func<bool, bool, bool> bool_eqv = (left, right) => left == right; // TestCoverage = F, F_bool, F_bool_eqv
        public static Func<bool, bool> bool_not = x => !x; // TestCoverage = F, F-bool, F_bool_not

        public static Func<int,int,int>          compare_int = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1; // TestCoverage = F, F_compare, F_compare_int
        public static Func<long,long,int>       compare_long = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1; // TestCoverage = F, F_compare, F_compare_lomg
        public static Func<short,short,int>    compare_short = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1; // TestCoverage = F, F_compare, F_compare_short
        public static Func<bool,bool,int>       compare_bool = (l, r) => (l == r) ? 0 : (l == false) ? -1 : 1; // TestCoverage = F, F_compare, F_compare_bool
        public static Func<char,char,int>       compare_char = (l, r) => (l == r) ? 0 : (l < r) ? -1 : 1; // TestCoverage = F, F_compare, F_compare_char
        public static Func<string, string, int> compare_string = (left, right) => {
            // TestCoverage = F, F_compare, F_compare_string
            Validate.NonNullArgument(left, LEFT);
            Validate.NonNullArgument(right, RIGHT);
            return String.Compare(left, right);
        };
        public static Func<string,string,int> compare_string_case_insensative = (left, right) => {
            Validate.NonNullArgument(left, LEFT);
            Validate.NonNullArgument(right, RIGHT);
            return String.Compare(left.ToUpper(), right.ToUpper());
        };

        //public static Func<int,int,bool>              equ = (left, right) => (left == right);
        public static Func<int,int,bool>          equ_int = (left, right) => (left == right); // TestCoverage = F, F_equ, F_equ_int
        public static Func<long,long,bool>       equ_long = (left, right) => (left == right); // TestCoverage = F, F_equ, F_equ_long
        public static Func<short,short,bool>    equ_short = (left, right) => (left == right); // TestCoverage = F, F_equ, F_equ_short
        public static Func<bool,bool,bool>       equ_bool = (left, right) => (left == right); // TestCoverage = F, F_equ, F_equ_bool
        public static Func<char,char,bool>       equ_char = (left, right) => (left == right); // TestCoverage = F, F_equ, F_equ_char
        /// <summary>A function given two strings, true if they are equal</summary><returns>true if they are equal</returns>
        public static Func<string, string, bool> equ_string = (left, right) => {
            // TestCoverage = F, F_equ, F_equ_string
            Validate.NonNullArgument(left, LEFT);
            Validate.NonNullArgument(right, RIGHT);
            return left == right;
        };

        //public static Func<int,int,bool>              neq = (left, right) => (left != right);
        public static Func<int,int,bool>        neq_int = (left, right) => (left != right); // TestCoverage = F, F_neq, F_neq_int
        public static Func<long,long,bool>     neq_long = (left, right) => (left != right); // TestCoverage = F, F_neq, F_neq_long
        public static Func<short,short,bool>  neq_short = (left, right) => (left != right); // TestCoverage = F, F_neq, F_neq_short
        public static Func<bool,bool,bool>     neq_bool = bool_xor;                         // TestCoverage = F, F_neq, F_neq_bool
        public static Func<char,char,bool>     neq_char = (left, right) => (left != right); // TestCoverage = F, F_neq, F_neq_char
        /// <summary>A function given two strings, true if they are not equal</summary><returns>true if they are not equal</returns>
        public static Func<string, string, bool> neq_string = (left, right) => {
            // TestCoverage = F, F_neq, F_neq_string
            Validate.NonNullArgument(left, LEFT);
            Validate.NonNullArgument(right, RIGHT);
            return left != right;
        };

        //public static Func<int,int,int>                 add = (x, y) => x + y;
        public static int add_int(int x1, int x2){ return x1 + x2;} // TestCoverage = F, F_add, F_add_int
        public static int add_int(int x1, int x2, int x3) { return x1 + x2 + x3; }
        public static int add_int(int x1, int x2, int x3, int x4) { return x1 + x2 + x3 + x4; }
        public static int add_int(int x1, int x2, int x3, int x4, int x5) { return x1 + x2 + x3 + x4 + x5; }
        public static int add_int(int x1, int x2, int x3, int x4, int x5, int x6) { return x1 + x2 + x3 + x4 + x5 + x6; }
        public static int add_int(IEnumerable<int> seq) { return F<int>.reduce(seq, add_int); }
        public static int add_int(int t, IEnumerable<int> seq) { return F<int>.reduce(seq, add_int, t); }
        public static int add_int(IEnumerable<int> seq, int t) { return F<int>.reduce(seq, add_int, t); }
        public static IEnumerable<int> add_int(IEnumerable<int> seq1, IEnumerable<int> seq2) { return F<int>.map<int>(seq1, seq2, add_int); }
        public static long add_long(long x1, long x2) { return x1 + x2; } // TestCoverage = F, F_add, F_add_long
        public static long add_long(long x1, long x2, long x3) { return x1 + x3 + x3; }
        public static long add_long(long x1, long x2, long x3, long x4) { return x1 + x2 + x3 + x4; }
        public static long add_long(long x1, long x2, long x3, long x4, long x5) { return x1 + x2 + x3 + x4 + x5; }
        public static long add_long(long x1, long x2, long x3, long x4, long x5, long x6) { return x1 + x2 + x3 + x4 + x5 + x6; }
        public static long add_long(IEnumerable<long> seq) { return F<long>.reduce(seq, add_long); }
        public static long add_long(long t, IEnumerable<long> seq) { return F<long>.reduce(seq, add_long, t); }
        public static long add_long(IEnumerable<long> seq, long t) { return F<long>.reduce(seq, add_long, t); }
        public static IEnumerable<long> add_long(IEnumerable<long> seq1, IEnumerable<long> seq2) { return F<long>.map<long>(seq1, seq2, add_long); }
        public static short add_short(short x1, short x2) { return (short)(x1 + x2); } // TestCoverage = F, F_add, F_add_short
        public static short add_short(short x1, short x2, short x3) { return (short)(x1 + x2 + x3); }
        public static short add_short(short x1, short x2, short x3, short x4) { return (short)(x1 + x2 + x3 + x4); }
        public static short add_short(short x1, short x2, short x3, short x4, short x5) { return (short)(x1 + x2 + x3 + x4 + x5); }
        public static short add_short(short x11, short x2, short x3, short x4, short x5, short x6) { return (short)(x11 + x2 + x3 + x4 + x5 + x6); }
        public static short add_short(IEnumerable<short> seq) { return F<short>.reduce(seq, add_short); }
        public static short add_short(IEnumerable<short> seq, short t) { return F<short>.reduce(seq, add_short, t); }
        public static short add_short(short t, IEnumerable<short> seq) { return F<short>.reduce(seq, add_short, t); }
        public static IEnumerable<short> add_short(IEnumerable<short> seq1, IEnumerable<short> seq2) { return F<short>.map<short>(seq1, seq2, add_short); }
        public static float add_float(float x1, float x2) { return x1 + x2; } // TestCoverage = F, F_add, F_add_float
        public static float add_float(float x1, float x2, float x3) { return x1 + x2 + x3; }
        public static float add_float(float x1, float x2, float x3, float x4) { return x1 + x2 + x3 + x4; }
        public static float add_float(float x1, float x2, float x3, float x4, float x5) { return x1 + x2 + x3 + x4 + x5; }
        public static float add_float(float x1, float x2, float x3, float x4, float x5, float x6) { return x1 + x2 + x3 + x4 + x5 + x6; }
        public static float add_float(IEnumerable<float> seq) { return F<float>.reduce(seq, add_float); }
        public static float add_float(IEnumerable<float> seq, float t) { return F<float>.reduce(seq, add_float, t); }
        public static float add_float(float t, IEnumerable<float> seq) { return F<float>.reduce(seq, add_float, t); }
        public static IEnumerable<float> add_float(IEnumerable<float> seq1, IEnumerable<float> seq2) { return F<float>.map<float>(seq1, seq2, add_float); }
        public static double add_double(double x1, double x2) { return x1 + x2; } // TestCoverage = F, F_add, F_add_double
        public static double add_double(double x1, double x2, double x3) { return x1 + x2 + x3; }
        public static double add_double(double x1, double x2, double x3, double x4) { return x1 + x2 + x3 + x4; }
        public static double add_double(double x1, double x2, double x3, double x4, double x5) { return x1 + x2 + x3 + x4 + x5; }
        public static double add_double(double x1, double x2, double x3, double x4, double x5, double x6) { return x1 + x2 + x3 + x4 + x5 + x6; }
        public static double add_double(IEnumerable<double> seq) { return F<double>.reduce(seq, add_double); }
        public static double add_double(IEnumerable<double> seq, double t) { return F<double>.reduce(seq, add_double, t); }
        public static double add_double(double t, IEnumerable<double> seq) { return F<double>.reduce(seq, add_double, t); }
        public static IEnumerable<double> add_double(IEnumerable<double> seq1, IEnumerable<double> seq2) { return F<double>.map<double>(seq1, seq2, add_double); }

        /// <summary>A function given two strings, returns the combined string</summary><returns>A combined string</returns>
        public static string add_string(string s1, string s2) { return s1 + s2; }
        public static string add_string(string s1, string s2, string s3) { return s1 + s2 + s3; }
        public static string add_string(string s1, string s2, string s3, string s4) { return s1 + s2 + s3 + s4; }
        public static string add_string(string s1, string s2, string s3, string s4, string s5) { return s1 + s2 + s3 + s4 + s5; }
        public static string add_string(string s1, string s2, string s3, string s4, string s5, string s6) { return s1 + s2 + s3 + s4 + s5 + s6; }
        public static string add_string(IEnumerable<string> seq) { return F<string>.reduce(seq, add_string); }
        public static string add_string(IEnumerable<string> seq, string s) { return F<string>.reduce(seq, add_string, s); }
        public static string add_string(string s, IEnumerable<string> seq) { return F<string>.reduce(seq, add_string, s); }
        public static IEnumerable<string> add_string(IEnumerable<string> seq1, IEnumerable<string> seq2) { return F<string>.map<string>(seq1, seq2, add_string); }

        //public static Func<int,int,int>                 sub = (x, y) => x - y;
        public static Func<int,int,int>             sub_int = (x, y) => x - y; // TestCoverage = F, F_sub, F_sub_int
        public static Func<long,long,long>         sub_long = (x, y) => x - y; // TestCoverage = F, F_sub, F_sub_long
        public static Func<short,short,short>     sub_short = (x, y) => (short)(x - y); // TestCoverage = F, F_sub, F_sub_short
        public static Func<float, float, float>   sub_float = (x, y) => x - y; // TestCoverage = F, F_sub, F_sub_float
        public static Func<double,double,double> sub_double = (x, y) => x - y; // TestCoverage = F, F_sub, F_sub_double

        // public static Func<int,int,int>                 mult = (x, y) => x * y;
        public static int mult_int(int x1, int x2) { return x1 * x2; } // TestCoverage = F, F_mult, F_mult_int
        public static int mult_int(int x1, int x2, int x3) { return x1 * x2 * x3; }
        public static int mult_int(int x1, int x2, int x3, int x4) { return x1 * x2 * x3 * x4; }
        public static int mult_int(int x1, int x2, int x3, int x4, int x5) { return x1 * x2 * x3 * x4 * x5; }
        public static int mult_int(int x1, int x2, int x3, int x4, int x5, int x6) { return x1 * x2 * x3 * x4 * x5 * x6; }
        public static int mult_int(IEnumerable<int> seq) { return F<int>.reduce(seq, mult_int); }
        public static int mult_int(IEnumerable<int> seq, int x) { return F<int>.reduce(seq, mult_int, x); }
        public static int mult_int(int x, IEnumerable<int> seq) { return F<int>.reduce(seq, mult_int, x); }
        public static IEnumerable<int> mult_int(IEnumerable<int> seq1, IEnumerable<int> seq2) { return F<int>.map<int>(seq1, seq2, mult_int); }

 
        public static long mult_long(long x1, long x2) { return x1 * x2; } // TestCoverage = F, F_mult, F_mult_long
        public static long mult_long(long x1, long x2, long x3) { return x1 * x2 * x3; }
        public static long mult_long(long x1, long x2, long x3, long x4) { return x1 * x2 * x3 * x4; }
        public static long mult_long(long x1, long x2, long x3, long x4, long x5) { return x1 * x2 * x3 * x4 * x5; }
        public static long mult_long(long x1, long x2, long x3, long x4, long x5, long x6) { return x1 * x2 * x3 * x4 * x5 * x6; }
        public static long mult_long(IEnumerable<long> seq) { return F<long>.reduce(seq, mult_long); }
        public static long mult_long(IEnumerable<long> seq, long x) { return F<long>.reduce(seq, mult_long, x); }
        public static long mult_long(long x, IEnumerable<long> seq) { return F<long>.reduce(seq, mult_long, x); }
        public static IEnumerable<long> mult_long(IEnumerable<long> seq1, IEnumerable<long> seq2) { return F<long>.map<long>(seq1, seq2, mult_long); }

        public static short mult_short(short x1, short x2) { return (short)(x1 * x2); }  // TestCoverage = F, F_mult, F_mult_short
        public static short mult_short(short x1, short x2, short x3) { return (short)(x1 * x2 * x3); }
        public static short mult_short(short x1, short x2, short x3, short x4) { return (short)(x1 * x2 * x3 * x4); }
        public static short mult_short(short x1, short x2, short x3, short x4, short x5) { return (short)(x1 * x2 * x3 * x4 * x5); }
        public static short mult_short(short x1, short x2, short x3, short x4, short x5, short x6) { return (short)(x1 * x2 * x3 * x4 * x5 * x6); }
        public static short mult_short(IEnumerable<short> seq) { return F<short>.reduce(seq, mult_short); }
        public static short mult_short(IEnumerable<short> seq, short t) { return F<short>.reduce(seq, mult_short, t); }
        public static short mult_short(short t, IEnumerable<short> seq) { return F<short>.reduce(seq, mult_short, t); }
        public static IEnumerable<short> mult_short(IEnumerable<short> seq1, IEnumerable<short> seq2) { return F<short>.map<short>(seq1, seq2, mult_short); }

        public static float mult_float(float x1, float x2) { return x1 * x2; } // TestCoverage = F, F_mult, F_mult_float
        public static float mult_float(float x1, float x2, float x3) { return x1 * x2 * x3; }
        public static float mult_float(float x1, float x2, float x3, float x4) { return x1 * x2 * x3 * x4; }
        public static float mult_float(float x1, float x2, float x3, float x4, float x5) { return x1 * x2 * x3 * x4 * x5; }
        public static float mult_float(float x1, float x2, float x3, float x4, float x5, float x6) { return x1 * x2 * x3 * x4 * x5 * x6; }
        public static float mult_float(IEnumerable<float> seq) { return F<float>.reduce(seq, mult_float); }
        public static float mult_float(IEnumerable<float> seq, float t) { return F<float>.reduce(seq, mult_float, t); }
        public static float mult_float(float t, IEnumerable<float> seq) { return F<float>.reduce(seq, mult_float, t); }
        public static IEnumerable<float> mult_float(IEnumerable<float> seq1, IEnumerable<float> seq2) { return F<float>.map<float>(seq1, seq2, mult_float); }

        public static double mult_double(double x1, double x2) { return x1 * x2; } // TestCoverage = F, F_mult, F_mult_double
        public static double mult_double(double x1, double x2, double x3) { return x1 * x2 * x3; }
        public static double mult_double(double x1, double x2, double x3, double x4) { return x1 * x2 * x3 * x4; }
        public static double mult_double(double x1, double x2, double x3, double x4, double x5) { return x1 * x2 * x3 * x4 * x5; }
        public static double mult_double(double x1, double x2, double x3, double x4, double x5, double x6) { return x1 * x2 * x3 * x4 * x5 * x6; }
        public static double mult_double(IEnumerable<double> seq) { return F<double>.reduce(seq, mult_double); }
        public static double mult_double(IEnumerable<double> seq, double t) { return F<double>.reduce(seq, mult_double, t); }
        public static double mutl_double(double t, IEnumerable<double> seq) { return F<double>.reduce(seq, mult_double, t); }
        public static IEnumerable<double> mult_double(IEnumerable<double> seq1, IEnumerable<double> seq2) { return F<double>.map<double>(seq1, seq2, mult_double); }


        public static int max_int(int x1, int x2) { return (x1 > x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_max_int
        public static int max_int(int x1, int x2, int x3) { return (x1 > x2) ? ((x1>x3)?x1:x3):((x2>x3)?x2:x3);}
        public static int max_int(int x1, int x2, int x3, int x4) {
            int t1 = (x1 > x2) ? x1 : x2;  int t2 = (x3 > x4) ? x3 : x4;
            return (t1 > t2) ? t1 : t2;
        }
        public static int max_int(int x1, int x2, int x3, int x4, int x5) {
            int t1 = (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3);
            int t2 = (x4 > x5) ? x4 : x5;
            return (t1 > t2) ? t1 : t2;
        }
        public static int max_int(int x1, int x2, int x3, int x4, int x5, int x6) {
            int t1 = (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3);
            int t2 = (x4 > x5) ? ((x4 > x6) ? x4 : x6) : ((x5 > x6) ? x5 : x6);
            return (t1 > t2) ? t1 : t2;
        }
        public static int max_int(IEnumerable<int> seq) {
            int result = F<int>.first(seq);
            foreach (int t in F<int>.rest(seq)) result = max_int(result, t);
            return result;
        }
        public static IEnumerable<int> max_int(IEnumerable<int> seq1, IEnumerable<int> seq2) {
            IEnumerator<int> e1 = seq1.GetEnumerator();
            IEnumerator<int> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return max_int(e1.Current,e2.Current);
            }
        }

        public static long max_long(long x1, long x2) { return (x1 > x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_max_long
        public static long max_long(long x1, long x2, long x3) { return (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3); }
        public static long max_long(long x1, long x2, long x3, long x4) {
            long t1 = (x1 > x2) ? x1 : x2; long t2 = (x3 > x4) ? x3 : x4;
            return (t1 > t2) ? t1 : t2;
        }
        public static long max_long(long x1, long x2, long x3, long x4, long x5) {
            long t1 = (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3);
            long t2 = (x4 > x5) ? x4 : x5;
            return (t1 > t2) ? t1 : t2;
        }
        public static long max_long(long x1, long x2, long x3, long x4, long x5, long x6) {
            long t1 = (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3);
            long t2 = (x4 > x5) ? ((x4 > x6) ? x4 : x6) : ((x5 > x6) ? x5 : x6);
            return (t1 > t2) ? t1 : t2;
        }
        public static long max_long(IEnumerable<long> seq) {
            long result = F<long>.first(seq);
            foreach (long t in F<long>.rest(seq)) result = max_long(result, t);
            return result;
        }
        public static IEnumerable<long> max_long(IEnumerable<long> seq1, IEnumerable<long> seq2) {
            IEnumerator<long> e1 = seq1.GetEnumerator();
            IEnumerator<long> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return max_long(e1.Current,e2.Current);
            }
        }
        
        public static short max_short(short x1, short x2) { return (x1 > x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_max_short
        public static short max_short(short x1, short x2, short x3) { return (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3); }
        public static short max_short(short x1, short x2, short x3, short x4) {
            short t1 = (x1 > x2) ? x1 : x2; short t2 = (x3 > x4) ? x3 : x4;
            return (t1 > t2) ? t1 : t2;
        }
        public static short max_short(short x1, short x2, short x3, short x4, short x5) {
            short t1 = (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3);
            short t2 = (x4 > x5) ? x4 : x5;
            return (t1 > t2) ? t1 : t2;
        }
        public static short max_short(short x1, short x2, short x3, short x4, short x5, short x6) {
            short t1 = (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3);
            short t2 = (x4 > x5) ? ((x4 > x6) ? x4 : x6) : ((x5 > x6) ? x5 : x6);
            return (t1 > t2) ? t1 : t2;
        }
        public static short max_short(IEnumerable<short> seq) {
            short result = F<short>.first(seq);
            foreach (short t in F<short>.rest(seq)) result = max_short(result, t);
            return result;
        }
        public static IEnumerable<short> max_short(IEnumerable<short> seq1, IEnumerable<short> seq2) {
            IEnumerator<short> e1 = seq1.GetEnumerator();
            IEnumerator<short> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return max_short(e1.Current,e2.Current);
            }
        }
        
        
        public static float max_float(float x1, float x2) { return (x1 > x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_max_float
        public static float max_float(float x1, float x2, float x3) { return (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3); }
        public static float max_float(float x1, float x2, float x3, float x4) {
            float t1 = (x1 > x2) ? x1 : x2; float t2 = (x3 > x4) ? x3 : x4;
            return (t1 > t2) ? t1 : t2;
        }
        public static float max_float(float x1, float x2, float x3, float x4, float x5) {
            float t1 = (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3);
            float t2 = (x4 > x5) ? x4 : x5;
            return (t1 > t2) ? t1 : t2;
        }
        public static float max_float(float x1, float x2, float x3, float x4, float x5, float x6) {
            float t1 = (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3);
            float t2 = (x4 > x5) ? ((x4 > x6) ? x4 : x6) : ((x5 > x6) ? x5 : x6);
            return (t1 > t2) ? t1 : t2;
        }
        public static float max_float(IEnumerable<float> seq) {
            float result = F<float>.first(seq);
            foreach (float t in F<float>.rest(seq)) result = max_float(result, t);
            return result;
        }
        public static IEnumerable<float> max_float(IEnumerable<float> seq1, IEnumerable<float> seq2) {
            IEnumerator<float> e1 = seq1.GetEnumerator();
            IEnumerator<float> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return max_float(e1.Current,e2.Current);
            }
        }

        public static double max_double(double x1, double x2) { return (x1 > x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_max_double
        public static double max_double(double x1, double x2, double x3) { return (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3); }
        public static double max_double(double x1, double x2, double x3, double x4) {
            double t1 = (x1 > x2) ? x1 : x2; double t2 = (x3 > x4) ? x3 : x4;
            return (t1 > t2) ? t1 : t2;
        }
        public static double max_double(double x1, double x2, double x3, double x4, double x5) {
            double t1 = (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3);
            double t2 = (x4 > x5) ? x4 : x5;
            return (t1 > t2) ? t1 : t2;
        }
        public static double max_double(double x1, double x2, double x3, double x4, double x5, double x6) {
            double t1 = (x1 > x2) ? ((x1 > x3) ? x1 : x3) : ((x2 > x3) ? x2 : x3);
            double t2 = (x4 > x5) ? ((x4 > x6) ? x4 : x6) : ((x5 > x6) ? x5 : x6);
            return (t1 > t2) ? t1 : t2;
        }
        public static double max_double(IEnumerable<double> seq) {
            double result = F<double>.first(seq);
            foreach (double t in F<double>.rest(seq)) result = max_double(result, t);
            return result;
        }
        public static IEnumerable<double> max_double(IEnumerable<double> seq1, IEnumerable<double> seq2) {
            IEnumerator<double> e1 = seq1.GetEnumerator();
            IEnumerator<double> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return max_double(e1.Current,e2.Current);
            }
        }


        //public static Func<int,int,int>                 min = (x, y) => (F.lt(x,y)) ? x : y;          
        public static int min_int(int x1, int x2) { return (x1 < x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_min_int
        public static int min_int(int x1, int x2, int x3) { return (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3); }
        public static int min_int(int x1, int x2, int x3, int x4) {
            int t1 = (x1 < x2) ? x1 : x2; int t2 = (x3 < x4) ? x3 : x4;
            return (t1 < t2) ? t1 : t2;
        }
        public static int min_int(int x1, int x2, int x3, int x4, int x5) {
            int t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            int t2 = (x4 < x5) ? x4 : x5;
            return (t1 < t2) ? t1 : t2;
        }
        public static int min_int(int x1, int x2, int x3, int x4, int x5, int x6) {
            int t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            int t2 = (x4 < x5) ? ((x4 < x6) ? x4 : x6) : ((x5 < x6) ? x5 : x6);
            return (t1 < t2) ? t1 : t2;
        }
        public static int min_int(IEnumerable<int> seq) {
            int result = F<int>.first(seq);
            foreach (int t in F<int>.rest(seq)) result = min_int(result, t);
            return result;
        }
        public static IEnumerable<int> min_int(IEnumerable<int> seq1, IEnumerable<int> seq2) {
            IEnumerator<int> e1 = seq1.GetEnumerator();
            IEnumerator<int> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return min_int(e1.Current,e2.Current);
            }
        }


        public static long min_long(long x1, long x2) { return (x1 < x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_min_long
        public static long min_long(long x1, long x2, long x3) { return (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3); }
        public static long min_long(long x1, long x2, long x3, long x4) {
            long t1 = (x1 < x2) ? x1 : x2; long t2 = (x3 < x4) ? x3 : x4;
            return (t1 < t2) ? t1 : t2;
        }
        public static long min_long(long x1, long x2, long x3, long x4, long x5) {
            long t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            long t2 = (x4 < x5) ? x4 : x5;
            return (t1 < t2) ? t1 : t2;
        }
        public static long min_long(long x1, long x2, long x3, long x4, long x5, long x6) {
            long t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            long t2 = (x4 < x5) ? ((x4 < x6) ? x4 : x6) : ((x5 < x6) ? x5 : x6);
            return (t1 < t2) ? t1 : t2;
        }
        public static long min_long(IEnumerable<long> seq) {
            long result = F<long>.first(seq);
            foreach (long t in F<long>.rest(seq)) result = min_long(result, t);
            return result;
        }
        public static IEnumerable<long> min_long(IEnumerable<long> seq1, IEnumerable<long> seq2) {
            IEnumerator<long> e1 = seq1.GetEnumerator();
            IEnumerator<long> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return min_long(e1.Current,e2.Current);
            }
        }

        public static short min_short(short x1, short x2) { return (x1 < x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_min_short
        public static short min_short(short x1, short x2, short x3) { return (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3); }
        public static short min_short(short x1, short x2, short x3, short x4) {
            short t1 = (x1 < x2) ? x1 : x2; short t2 = (x3 < x4) ? x3 : x4;
            return (t1 < t2) ? t1 : t2;
        }
        public static int min_short(short x1, short x2, short x3, short x4, short x5) {
            short t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            short t2 = (x4 < x5) ? x4 : x5;
            return (t1 < t2) ? t1 : t2;
        }
        public static short min_short(short x1, short x2, short x3, short x4, short x5, short x6) {
            short t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            short t2 = (x4 < x5) ? ((x4 < x6) ? x4 : x6) : ((x5 < x6) ? x5 : x6);
            return (t1 < t2) ? t1 : t2;
        }
        public static short min_short(IEnumerable<short> seq) {
            short result = F<short>.first(seq);
            foreach (short t in F<short>.rest(seq)) result = min_short(result, t);
            return result;
        }
        public static IEnumerable<short> min_short(IEnumerable<short> seq1, IEnumerable<short> seq2) {
            IEnumerator<short> e1 = seq1.GetEnumerator();
            IEnumerator<short> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return min_short(e1.Current,e2.Current);
            }
        }

        public static float min_float(float x1, float x2) { return (x1 < x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_min_float
        public static float min_float(float x1, float x2, float x3) { return (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3); }
        public static float min_float(float x1, float x2, float x3, float x4) {
            float t1 = (x1 < x2) ? x1 : x2; float t2 = (x3 < x4) ? x3 : x4;
            return (t1 < t2) ? t1 : t2;
        }
        public static float min_float(float x1, float x2, float x3, float x4, float x5) {
            float t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            float t2 = (x4 < x5) ? x4 : x5;
            return (t1 < t2) ? t1 : t2;
        }
        public static float min_float(float x1, float x2, float x3, float x4, float x5, float x6) {
            float t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            float t2 = (x4 < x5) ? ((x4 < x6) ? x4 : x6) : ((x5 < x6) ? x5 : x6);
            return (t1 < t2) ? t1 : t2;
        }
        public static float min_float(IEnumerable<float> seq) {
            float result = F<float>.first(seq);
            foreach (float t in F<float>.rest(seq)) result = min_float(result, t);
            return result;
        }
        public static IEnumerable<float> min_float(IEnumerable<float> seq1, IEnumerable<float> seq2) {
            IEnumerator<float> e1 = seq1.GetEnumerator();
            IEnumerator<float> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return min_float(e1.Current,e2.Current);
            }
        }

        public static double min_double(double x1, double x2) { return (x1 < x2) ? x1 : x2; }         // TestCoverage = F, F_max, F_min_double
        public static double min_doule(double x1, double x2, double x3) { return (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3); }
        public static double min_double(double x1, double x2, double x3, double x4) {
            double t1 = (x1 < x2) ? x1 : x2; double t2 = (x3 < x4) ? x3 : x4;
            return (t1 < t2) ? t1 : t2;
        }
        public static double min_double(double x1, double x2, double x3, double x4, double x5) {
            double t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            double t2 = (x4 < x5) ? x4 : x5;
            return (t1 < t2) ? t1 : t2;
        }
        public static double min_double(double x1, double x2, double x3, double x4, double x5, double x6) {
            double t1 = (x1 < x2) ? ((x1 < x3) ? x1 : x3) : ((x2 < x3) ? x2 : x3);
            double t2 = (x4 < x5) ? ((x4 < x6) ? x4 : x6) : ((x5 < x6) ? x5 : x6);
            return (t1 < t2) ? t1 : t2;
        }
        public static double min_double(IEnumerable<double> seq) {
            double result = F<double>.first(seq);
            foreach (double t in F<double>.rest(seq)) result = min_double(result, t);
            return result;
        }
        public static IEnumerable<double> min_double(IEnumerable<double> seq1, IEnumerable<double> seq2) {
            IEnumerator<double> e1 = seq1.GetEnumerator();
            IEnumerator<double> e2 = seq2.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext()) {
                yield return min_double(e1.Current,e2.Current);
            }
        }

        public static Func<int,int>          neg_int = (x) => -x;           // TestCoverage = F, F_neg, F_neg_int
        public static Func<long,long>       neg_long = (x) => -x;           // TestCoverage = F, F_neg, F_neg_long
        public static Func<short,short>    neg_short = (x) => (short)(-x);  // TestCoverage = F, F_neg, F_neg_short
        public static Func<float,float>    neg_float = (x) => -x;           // TestCoverage = F, F_neg, F_neg_float
        public static Func<double,double> neg_double = (x) => -x;           // TestCoverage = F, F_neg, F_neg_double


        public static Func<int,int>       inc_int = (x) => F.add_int(x, 1);  // TestCoverage = F, F_add, F_add_int
        public static Func<long,long>    inc_long = (x) => F.add_long(x,1L); // TestCoverage = F, F_add, F_add_long
        public static Func<short,short> inc_short = (x) => (short)(x + 1);   // TestCoverage = F, F_add, F_add_short

        
        public static Func<double, double, bool> close_double = (x, y) => {
            // TestCoverage = F, F_close, F_close_double
            return (F.lt_double(Math.Abs(F.sub_double(x, y)), 0.01d));
        };
        public static Func<float,float,bool> close_float = (x, y) => {
            // TestCoverage = F, F_close, F_close_float
            return (F.lt_float(Math.Abs(F.sub_float(x, y)), 0.01f));
        };

        public static float clamp_float(float x, float min, float max) { return (x<min) ? min : (x>max) ? max : x; }
        public static IEnumerable<float> clamp_float(IEnumerable<float> x, float min, float max) {
            Func<float, float> clamp = (k) => (k > max) ? max : (k < min) ? min : k;
            return F<float>.map<float>(x, clamp);
        }
        public static double clamp_double(double x, double min, double max) { return (x<min) ? min : (x>max) ? max : x; }
        public static IEnumerable<double> clamp_double(IEnumerable<double> x, double min, double max) {
            Func<double, double> clamp = (k) => (k > max) ? max : (k < min) ? min : k;
            return F<double>.map<double>(x, clamp);
        }
        public static Func<int,int>           sqr_int = (x) => x * x; // TestCoverage = F, F_sqr, F_sqr_int
        public static Func<long,long>        sqr_long = (x) => x * x; // TestCoverae = F, F_sqr, F_sqr_long
        public static Func<short, short>    sqr_short = (x) => (short)(x * x); // TestCoverage = F, F_sqr_short
        public static Func<float,float>     sqr_float = (x) => x * x; // TestCoverage = F, F_sqr, F_sqr_float
        public static Func<double,double>  sqr_double = (x) => x * x; // TestCoverage = F, F_sqr, F_sqr_double

        public static Func<float,float>    sqrt_float = (x) => {
            // TestCoverage = F, F_sqrt, F_sqrt_float
            Validate.PositiveArgument(x, X);
            return (float)Math.Sqrt(x);
        };
        public static Func<double,double> sqrt_double = (x) => { 
            // TestCoverage = F, F_sqrt, F_sqrt_double
            Validate.PositiveArgument(x, X);
            return (float)Math.Sqrt(x); 
        };
        
        public static Func<int,int,bool>            gt_int = (left, right) => (left > right); // TestCoverage = F, F_gt, F_gt_int
        public static Func<long,long,bool>         gt_long = (left, right) => (left > right); // TestCoverage = F, F_gt, F_gt_long
        public static Func<short,short,bool>      gt_short = (left, right) => (left > right); // TestCoverage = F, F_gt, F_gt_short
        public static Func<float,float,bool>      gt_float = (left, right) => (left > right); // TestCoverage = F, F_gt, F_gt_float
        public static Func<double,double,bool>   gt_double = (left, right) => (left > right); // TestCoverage = F, F_gt, F_gt_double

        public static Func<int,int,bool>       gte_int = (left, right) => (left >= right); // TestCoverage = F, F_gte, F_gte_int
        public static Func<long,long,bool>    gte_long = (left, right) => (left >= right); // TestCoverage = F, F_gte, F_gte_long
        public static Func<short,short,bool> gte_short = (left, right) => (left >= right); // TestCoverage = F, F_gte, F_gte_short

        public static Func<int,int,bool>            lt_int = (left, right) => (left < right); // TestCoverage = F, F_lt, F_lt_int
        public static Func<long,long,bool>         lt_long = (left, right) => (left < right); // TestCoverage = F, F_lt, F_lt_long
        public static Func<short,short,bool>      lt_short = (left, right) => (left < right); // TestCoverage = F, F_lt, F_lt_short
        public static Func<float,float,bool>      lt_float = (left, right) => (left < right); // TestCoverage = F, F_lt, F_lt_float
        public static Func<double,double,bool>   lt_double = (left, right) => (left < right); // TestCoverage = F, F_lt, F_lt_double


        // this is one reason why operators suck
        public static Func<int,int,bool>       lte_int = (left, right) => (left <= right); // TestCoverage = F, F_lte, F_lte_int
        public static Func<long,long,bool>    lte_long = (left, right) => (left <= right); // TestCoverage = F, F_lte, F_lte_long
        public static Func<short,short,bool> lte_short = (left, right) => (left <= right); // TestCoverage = F, F_lte, F_lte_short






        public static Func<string, char, string> add_char_to_string = (left, c) => {
            Validate.NonNullArgument(left, LEFT);
            return left + c;
        };
        

        public static Func<bool, IEnumerable<bool>> infinite_bool = (b) => F<bool>.forever(b);
        public static Func<bool, IEnumerable<bool>> infinite_bool_toggle = (b) => F<bool>.forever(F.bool_not, b);


        /// <summary>A function given start, returns an infinite sequence of increasing integers. (warning: integer overflow)</summary><returns>An infinite sequence of increasing integers</returns>
        public static Func<int,IEnumerable<int>> infinite_range = (start) => F<int>.forever(F.inc_int,start);

        public static IEnumerable<int> range(int start, int end) {
            // TestCoverage = F. F_range, F_range_start_end
            int step = (F.gt_int(F.sub_int(end,start),0)) ? 1 : -1;
            for (int i = start; F.neq_int(i, end); i=F.add_int(i,step)) yield return i;
        }
        public static IEnumerable<int> range(int start, int end, int step) {
            // TestCoverage = F, F_range, F_range_start_end_step
            int Step = (F.gt_int(F.sub_int(end,start),0)) ? Math.Abs(step) : -Math.Abs(step);
            Func<int, int, bool> condition = (F.gt_int(F.sub_int(end,start),0)) ? F.lt_int : F.gt_int;
            for (int i = start; condition(i, end); i = F.add_int(i,Step)) yield return i;
        }
        public static IEnumerable<int> range(int end) {
            // TestCoverage = F, F_range, F_range_end
            return range(0, end); 
        }
        /// <summary>A function given minimum, and maximum, that returns a sequence of random integers</summary><returns>An infinite sequence of random integers between minimum and maximum</returns>
        public static IEnumerable<int> random(int minimum, int maximum) {
            Random r = new Random(DateTime.Now.Millisecond);
            while (true) yield return r.Next(minimum, maximum);
        }
        /// <summary>A function given length, that returns a sequence of random integers</summary><returns>A sequence of random integers</returns>
        public static IEnumerator<int> random(int count) {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; F.lt_int(i,count); i=F.inc_int(i)) yield return r.Next();
        }
        /// <summary>A function given length, minimum, and maximum, that returns a sequence of random integers</summary><returns>A sequence of random integers between minimum and maximum</returns>
        public static IEnumerable<int> random(int count, int minimum, int maximum) {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; F.lt_int(i,count); i=inc_int(i)) yield return r.Next(minimum, maximum);
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

        public static Func<T, Func<T>> func = (t) => { return () => t; };
        public static Func<Func<T>, T> evaluate = (f) => f.Invoke();
        public static Func<T, Task<T>> task = (t) => {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(t);
            return tcs.Task;
        };
        public static Func<T, T> identity = (item) => item;
        

        public static IEnumerable<T> sequence(T t1) {
            yield return t1;
        }
        public static IEnumerable<T> sequence(T t1, T t2) {
            yield return t1;
            yield return t2;
        }
        public static IEnumerable<T> sequence(T t1, T t2, T t3) {
            yield return t1;
            yield return t2;
            yield return t3;
        }
        public static IEnumerable<T> sequence(T t1, T t2, T t3, T t4) {
            yield return t1;
            yield return t2;
            yield return t3;
            yield return t4;
        }
        public static IEnumerable<T> sequence(T t1, T t2, T t3, T t4, T t5) {
            yield return t1;
            yield return t2;
            yield return t3;
            yield return t4;
            yield return t5;
        }
        public static IEnumerable<T> sequence(T t1, T t2, T t3, T t4, T t5, T t6) {
            yield return t1;
            yield return t2;
            yield return t3;
            yield return t4;
            yield return t5;
            yield return t6;
        }
        public static IEnumerable<T> sequence(T t, IEnumerable<T> seq) {
            yield return t;
            foreach (T x in seq) yield return x;
        }
        public static IEnumerable<T> sequence(IEnumerable<T> seq, T t) {
            foreach (T x in seq) yield return x;
            yield return t;
        }
        public static IEnumerable<T> sequence(IEnumerable<T> seq) { 
            foreach (T x in seq) yield return x; 
        }
        public static IEnumerable<T> sequence(IEnumerable<T> seq1, IEnumerable<T> seq2) {
            foreach (T x in seq1) yield return x;
            foreach (T x in seq2) yield return x;
        }
        public static IEnumerable<T> sequence(IEnumerable<T> seq1, IEnumerable<T> seq2, IEnumerable<T> seq3) {
            foreach (T x in seq1) yield return x;
            foreach (T x in seq2) yield return x;
            foreach (T x in seq3) yield return x;
        }
        public static IEnumerable<T> sequence(IEnumerable<T> seq1, IEnumerable<T> seq2, IEnumerable<T> seq3, IEnumerable<T> seq4) {
            foreach (T x in seq1) yield return x;
            foreach (T x in seq2) yield return x;
            foreach (T x in seq3) yield return x;
            foreach (T x in seq4) yield return x;
        }
        public static IEnumerable<T> sequence(IEnumerable<T> seq1, IEnumerable<T> seq2, IEnumerable<T> seq3, IEnumerable<T> seq4, IEnumerable<T> seq5) {
            foreach (T x in seq1) yield return x;
            foreach (T x in seq2) yield return x;
            foreach (T x in seq3) yield return x;
            foreach (T x in seq4) yield return x;
            foreach (T x in seq5) yield return x;
        }
        public static IEnumerable<T> sequence(IEnumerable<T> seq1, IEnumerable<T> seq2, IEnumerable<T> seq3, IEnumerable<T> seq4, IEnumerable<T> seq5, IEnumerable<T> seq6) {
            foreach (T x in seq1) yield return x;
            foreach (T x in seq2) yield return x;
            foreach (T x in seq3) yield return x;
            foreach (T x in seq4) yield return x;
            foreach (T x in seq5) yield return x;
            foreach (T x in seq6) yield return x;
        }
        public static IEnumerable<T> sequence(IEnumerable<IEnumerable<T>> sseq) {
            foreach (IEnumerable<T> seq in sseq) 
                foreach(T x in seq)
                    yield return x;
        }
        public static IEnumerable<T> sequence(IEnumerable<IEnumerable<IEnumerable<T>>> ssseq) {
            foreach (IEnumerable<IEnumerable<T>> sseq in ssseq)
                foreach (IEnumerable<T> seq in sseq) 
                    foreach (T x in seq)
                        yield return x;
        }
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
            while (F.bool_and(result,F.bool_and(b1,b2))) {
                result = fn(i1.Current, i2.Current);
                b1 = i1.MoveNext();
                b2 = i2.MoveNext();
            }
            return (F.bool_and(result,F.equ_bool(b1,b2)));
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
            // TestCoverage = F_T, F_T_first
            Validate.NonNullArgument(lst, LST);
            return lst.First();
        };
        /// <summary>get the sequence following the first element of a sequence</summary><returns>an IEnermerable following the first element</returns>
        public static Func<IEnumerable<T>, IEnumerable<T>> rest = (lst) => {
            // TestCoverage = F_T, F_T_rest
            Validate.NonNullArgument(lst, LST);
            return lst.Skip(1);
        };
        /// <summary>find the first item that meets the condition function throws System.InvalidOperationException if no match is found</summary><returns>T or null</returns>
        public static Func<IEnumerable<T>, Func<T, bool>, T> find = (lst, predicate) => {
            // TestCoverage = F_T, F_T_find
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(predicate, PREDICATE);
            return lst.First(predicate);
        };
        /// <summary>sorts a finite sequnce.</summary><returns>a sequence</returns>
        public static Func<IEnumerable<T>, Func<T, T, int>, IEnumerable<T>> sort = (lst, fn) => {
            // TestCoverage = F_T, F_T_sort
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            T[] x = lst.ToArray();
            Array.Sort(x, new Comparer<T>(fn));
            return x.ToList();
        };
        /// <summary>sorts a sequence (most of the time)</summary><returns>a sorted sequence</returns>
        public static Func<IEnumerable<T>, Func<T, T, int>, IEnumerable<T>> sort_order_by = (lst, fn) => {
            // TestCoverage = F_T, F_T_sort_order_by
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            return lst.OrderBy(F<T>.identity, new Comparer<T>(fn));
        };
        /// <summary>Bubble sort a finite sequence.</summary><returns>A sorted sequence</returns>
        public static Func<IEnumerable<T>, Func<T, T, int>, IEnumerable<T>> sort_bubble_sort = (lst, fn) => {
            // TestCoverage = F_T, F_T_sort_bubble
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            T[] array = lst.ToArray();
            bool swapped = true;
            while (swapped) {
                swapped = false;
                for (int i = 0; F.lt_int(i,array.Length - 1); i=F.inc_int(i)) {
                    if (F.gt_int(fn(array[i], array[1 + 1]),0)) {
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
            // TestCoverage = F_T, F_T_each, F_T_each_naked
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) fn(t); 
        }
        public static void each<U>(IEnumerable<T> lst, Action<T,U> fn, U u) {
            // TestCoverage = F_T, F_T_each, F_T_each_U
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) fn(t, u); 
        }
        public static void each<U,V>(IEnumerable<T> lst, Action<T,U,V> fn, U u, V v) {
            // TestCoverage = F_T, F_T_each, F_T_each_U_V
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) fn(t, u, v); 
        }
        public static void each<U,V,W>(IEnumerable<T> lst, Action<T,U,V,W> fn, U u, V v, W w) {
            // TestCoverage = F_T, F_T_each, F_T_each_U_V_W
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) fn(t, u, v, w);
        }
        public static void each<U,V,W,X>(IEnumerable<T> lst, Action<T,U,V,W,X> fn, U u, V v, W w, X x) {
            // TestCoverage = F_T, F_T_each, F_T_each_U_V_W_X
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) fn(t, u, v, w, x); 
        }
        public static void each<U, V>(IEnumerable<T> lst, Action<T, U, V> fn, U u, Func<V, V> acc, V init) {
            // TestCoverage = F_T, F_T_each, F_T_each_U_V_Acc
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
            // TestCoverage = F_T, F_T_iterate_while
            Validate.NonNullArgument(fn, FN);
            Validate.NonNullArgument(predicate, PREDICATE);
            T result = init;
            while (predicate(result)) {
                yield return result;
                result = fn(result);
            }
        }
        /// <summary>returns a function that return the input</summary><returns>a Function</returns>
        public static Func<T> always(T t) { 
            // TestCoverage = F_T, F_T_always
            return () => t; 
        }

        public static IEnumerable<T> limit(IEnumerable<T> lst, int count) {
            // TestCoverage = F_T, F_T_limit
            Validate.NonNullArgument(lst, LST);
            Validate.PositiveArgument(count, "count");
            return lst.Take(count); 
        }
        public static IEnumerable<T> forever(T t) {
            // TestCoverage = F_T, F_T_forever, F_T_forever_item
            while (true) yield return t; 
        }
        public static IEnumerable<T> forever(T t1, T t2) {
            while (true) {
                yield return t1;
                yield return t2;
            }
        }
        public static IEnumerable<T> forever(T t1, T t2, T t3) {
            while (true) foreach(T t in F<T>.sequence(t1,t2,t3)) yield return t;
        }
        public static IEnumerable<T> forever(T t1, T t2, T t3, T t4) {
            while (true) foreach(T t in F<T>.sequence(t1,t2,t3,t4)) yield return t;
        }
        public static IEnumerable<T> forever(T t1, T t2, T t3, T t4, T t5) {
            while (true) foreach (T t in F<T>.sequence(t1, t2, t3, t4, t5)) yield return t;
        }
        public static IEnumerable<T> forever(T t1, T t2, T t3, T t4, T t5, T t6) {
            while (true) foreach (T t in F<T>.sequence(t1, t2, t3, t4, t5, t6)) yield return t;
        }
        public static IEnumerable<T> forever(IEnumerable<T> e) {
            while (true) foreach (T t in e) yield return t;
        }
        public static IEnumerable<T> forever(Func<T, T> fn, T t) {
            // TestCoverage = F_T, F_T_forever, F_T_forever_function
            Validate.NonNullArgument(fn, FN);
            T result = t;
            while (true) {
                yield return result;
                result = fn(result);
            }
        }
        /// <summary>returns a sequence that is the result of a sequence transformed by a function</summary><returns>A sequence of objects of type T</returns>
        public static IEnumerable<U> map<U>(IEnumerable<T> lst, Func<T,U> fn) {
            // TestCoverage = F_T, F_T_map, F_T_map_U
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            return lst.Select(fn); 
        }
        public static IEnumerable<U> map<U,V>(IEnumerable<T> lst, Func<T,V,U> fn, V v) {
            // TestCoverage = F_T, F_T_map, F_T_map_U_V
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) yield return fn(t, v);
        }
        public static IEnumerable<U> map<U,V,W>(IEnumerable<T> lst, Func<T,V,W,U> fn, V v, W w) {
            // TestCoverage = F_T, F_T_map, F_T_map_U_V_W
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) yield return fn(t, v, w);
        }
        public static IEnumerable<U> map<U,V,W,X>(IEnumerable<T> lst, Func<T,V,W,X,U> fn, V v, W w, X x) {
            // TestCoverage = F_T_map_U_V_W_X
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) yield return fn(t, v, w, x);
        }
        /// <summary>returns a sequence that is fed by two other sequences and a combining function fn</summary><returns>A sequence of objects of type T</returns>
        public static IEnumerable<U> map<U>(IEnumerable<T> lst1, IEnumerable<T> lst2, Func<T, T, U> fn) {
            // TestCoverage = F_T, F_T_map, F_T_map_U_2_List
            Validate.NonNullArgument(lst1, LST1);
            IEnumerator<T> one = lst1.GetEnumerator();
            IEnumerator<T> two = lst2.GetEnumerator();
            while ((one.MoveNext()) && (two.MoveNext())) {
                yield return fn(one.Current, two.Current);
            }
        }
        /// <summary>returns a sequence that is fed by three other sequences and a combining function fn</summary><returns>A sequence of objects of type T</returns>
        public static IEnumerable<U> map<U>(IEnumerable<T> lst1, IEnumerable<T> lst2, IEnumerable<T> lst3, Func<T, T, T, U> fn) {
            // TestCoverage = F_T, F_T_map, F_T_map_U_3_List
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
            // TestCoverage = F_T, F_T_flatten
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            foreach (T t in lst) 
                foreach (U u in fn(t)) 
                    yield return u;
        }
        /// <summary>Takes a sequence of T and an accumulation function</summary><returns>the accumulation of the sequence</returns>
        public static T reduce(IEnumerable<T> lst,Func<T, T, T> fn) {
            // TestCoverage = F_T, F_T_reduce, F_T_reduce_naked
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            return lst.Aggregate(fn);
        }
        /// <summary>Takes an enumeration of T, an accumulation function, and an initial item, and applies the accumulation function acc to all the element.</summary><returns>A U</returns>
        public static T reduce(IEnumerable<T> lst, Func<T, T, T> fn, T item) {
            // TestCoverage = F_T, F_T_reduce, F_T_reduce_init
            Validate.NonNullArgument(lst, LST);
            Validate.NonNullArgument(fn, FN);
            Validate.NonNullArgument(item, ITEM);
            return lst.Aggregate(item, fn); 
        }
        /// <summary>Takes an enumeration of T, and applies the accumulation function acc to all the element.</summary><returns>A U</returns>
        public static U reduce<U>(IEnumerable<T> lst, Func<U, T, U> fn, U item) {
            // TestCoverage = F_T, F_T_reduce, F_T_reduce_U_init
            Validate.NonNullArgument(lst,LST);
            Validate.NonNullArgument(fn,FN);
            Validate.NonNullArgument(item, ITEM);
            return lst.Aggregate<T, U, U>(item, fn, F<U>.identity);
        }
        
        public static IEnumerable<KeyValuePair<T, U>> combination<U>(IEnumerable<T> keys, IEnumerable<U> values) {
            foreach (T key in keys) 
                foreach (U value in values) 
                    yield return new KeyValuePair<T, U>(key, value);
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
        public static IStatelessChain<T> Run(IStatelessChain<T> item, T t) {
            Validate.NonNullArgument(item, ITEM);
            return item.Run(t);
        }
        public static IStatefulChain<T> Run(IStatefulChain<T> item) {
            Validate.NonNullArgument(item, ITEM);
            return item.Run();
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
    public class StatelessChain<T> : IStatelessChain<T> {
        // TestCoverage = Chain
        private Action<T> action = F.DoNothing<T>;
        private Func<T, bool> predicate = null;
        private StatelessChain(Func<T, bool> pred, Action<T> a = null) {
            this.action = (a != null)?a:F.DoNothing<T>;
            this.predicate = pred;
        }
        /// <summary>Run action(t) if predicate(t)</summary><returns>IStatelessChain if predicate(t) is true, else null</returns>in.
        public IStatelessChain<T> Run(T t) {
            bool do_this = this.predicate(t);
            if (do_this) this.action(t);
            return (do_this) ? this : null;
        }

        /// <summary>Takes a predicate ans an optional action</summary><returns>IStatelessChain</returns>
        public static IStatelessChain<T> Create(Func<T,bool> predicate, Action<T> a = null) { return new StatelessChain<T>(predicate,a); }

    }
    public class StatefulChain<T> : IStatefulChain<T> {
        private Action<T> action = null;
        private Func<T, T> trans = null;
        private Func<T, bool> predicate = null;

        public T Item { get; private set; }
        private StatefulChain(Func<T, bool> pred, Action<T> a, Func<T, T> tr, T t) {
            this.action = a;
            this.predicate = pred;
            this.trans = tr;
            this.Item = t;
        }
        /// <summary>if predicate(state) calls action, and updates state</summary><returns>IStatefulChain if predicate(state), else null</returns>
        public IStatefulChain<T> Run() {
            IStatefulChain<T> result = null;
            if (null != this.trans) {
                bool do_this = this.predicate(this.Item);
                if (do_this) {
                    this.action(this.Item);
                    this.Item = this.trans(this.Item);
                    result = this;
                }
            }
            return result; 
        }
        /// <summary>Takes a predicate and an action and a transform and an initial item of T</summary><returns>IStatelessChain</returns>
        public static IStatefulChain<T> Create(Func<T, bool> predicate, Action<T> a, Func<T, T> tr, T item) {
            return new StatefulChain<T>(predicate, a, tr, item);
        }
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
        // TestCoverage = Curry1
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
        // TestCoverage = Curry2
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
        public static void DeleteFile(string filename) {
            if (File.Exists(filename)) {
                File.Delete(filename);
            }
        }
        public static bool FileExists(string filename) {
            return File.Exists(filename);
        }
        public static long FileLength(string filename) {
            long length = 0L;
            FileStream fs = File.Open(filename, FileMode.Open);
            length = fs.Length;
            fs.Dispose();
            return length;
        }
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
    public class Singleton<I,T> where T:I, new() {
        private static I instance;
        public static I Instance { 
            get {
                if (null == instance) instance = new T();
                return instance; 
            } 
        }
        private Singleton(){}
    }
    
    [Export(typeof(ILogger))]
    public class LoggerNULL : ILogger {
        private IList<LoggerKind> kind = new List<LoggerKind>();
        public IEnumerable<LoggerKind> Kind { get { return this.kind; } }
        public LoggerNULL() { this.kind.Add(LoggerKind.Null); }
        public Task Configure(IDictionary<string, string> config) { return F.task_action(F.DoNothing); }
        public Task Log(string info) { return F.task_action(() => { }); }
        public void Dispose() { }
    }
    [Export(typeof(ILogger))]
    public class LoggerCONSOLE : ILogger {
        private IList<LoggerKind> kind = new List<LoggerKind>();
        public IEnumerable<LoggerKind> Kind { get { return this.kind; } }
        public LoggerCONSOLE() { this.kind.Add(LoggerKind.Console); }
        public Task Configure(IDictionary<string, string> config) { return F.task_action(F.DoNothing); }
        public Task Log(string info) { return F.task_action(()=> Console.WriteLine(info)); }
        public void Dispose() { }
    }
    [Export(typeof(ILogger))]
    public class LoggerFILE : ILogger {
        private IList<LoggerKind> kind = new List<LoggerKind>();
        private TextWriter logfile = null;
        public IEnumerable<LoggerKind> Kind { get { return this.kind; } }
        public LoggerFILE() { this.kind.Add(LoggerKind.File); }
        public Task Configure(IDictionary<string, string> config) {
            if (config.Keys.Contains("logfile")) {
                try {
                    this.logfile = new StreamWriter(config["logfile"], false, Encoding.UTF8, 1024);
                } catch { }
            }
            return F.task_action(F.DoNothing); 
        }
        public Task Log(string info) {
            Task task = null;
            if (null != this.logfile) {
                task = this.logfile.WriteLineAsync(info);
            } else task = F.task_action(F.DoNothing);
            return task; 
        }
        public void Dispose() {
            if (null != this.logfile) {
                this.logfile.Dispose();
                this.logfile = null;
            }
        }
    }
}