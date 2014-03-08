using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>Invokes the Function with the int</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_Func_actionInt)]
        public static void actionInt(Action<int> a,int x) { a.Invoke(x); }
        /// <summary>Invokes the Function with the int</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_Func_actionLong)]
        public static void actionLong(Action<long> a,long x) { a.Invoke(x); }
        /// <summary>Invokes the Function with the int</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_Func_actionShort)]
        public static void actionShort(Action<short> a, short x) { a.Invoke(x); }
        /// <summary>Invokes the Function with the int</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_Func_actionBool)]
        public static void actionBool(Action<bool> a, bool x) { a.Invoke(x); }
        /// <summary>Invokes the Function with the int</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_Func_actionChar)]
        public static void actionChar(Action<char> a, char x) { a.Invoke(x); }
        /// <summary>Invokes the Function with the int</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_Func_actionString)]
        public static void actionString(Action<string> a,string x) { a.Invoke(x); }

        /// <summary>Invokes the Function with the int</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_Func_funcInt)]
        public static int funcInt(Func<int, int> fn, int x) { return fn.Invoke(x); }
        /// <summary>Invokes the Function with the int</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_Func_funcLong)]
        public static long funcLong(Func<long, long> fn, long x) { return fn.Invoke(x); }
        /// <summary>Invokes the Function with the int</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_Func_funcShort)]
        public static short funcShort(Func<short, short> fn, short x) { return fn.Invoke(x); }
        /// <summary>Invokes the Function with the int</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_Func_funcBool)]
        public static bool funcBool(Func<bool, bool> fn, bool x) { return fn.Invoke(x); }
        /// <summary>Invokes the Function with the int</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_Func_funcChar)]
        public static char funcChar(Func<char, char> fn, char x) { return fn.Invoke(x); }
        /// <summary>Invokes the Function with the int</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_Func_funcString)]
        public static string funcString(Func<string, string> fn, string x) { return fn.Invoke(x); }
        /// <summary>Invokes the Function with the int</summary><returns>result of the function</returns>
    }
    public static partial class F<T> {
        /// <summary>Invokes the Function with a passed item</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_Func_action_one_item)]
        public static void action(Action<T> a, T t) { a.Invoke(t); }
        /// <summary>Invokes the Function with two passed items</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_Func_action_two_items)]
        public static void action(Action<T, T> a, T t1, T t2) { a.Invoke(t1, t2); }
        /// <summary>Invokes the Function with the passed items</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_Func_action_three_items)]
        public static void action(Action<T, T, T> a, T t1, T t2, T t3) { a.Invoke(t1, t2, t3); }
        /// <summary>Invokes the Function with the passed items</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_Func_action_four_items)]
        public static void action(Action<T, T, T, T> a, T t1, T t2, T t3, T t4) { a.Invoke(t1, t2, t3, t4); }
        /// <summary>Invokes the Function with the passed items</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_Func_action_five_items)]
        public static void action(Action<T, T, T, T, T> a, T t1, T t2, T t3, T t4, T t5) { a.Invoke(t1, t2, t3, t4, t5); }
        /// <summary>Invokes the Function with the passed items</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_Func_action_six_items)]
        public static void action(Action<T, T, T, T, T, T> a, T t1, T t2, T t3, T t4, T t5, T t6) { a.Invoke(t1, t2, t3, t4, t5, t6); }
        /// <summary>Invokes the Function with the passed sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_Func_action_sequence)]
        public static void action(Action<IEnumerable<T>> a, IEnumerable<T> seq) { a.Invoke(seq); }
        /// <summary>Invokes the first Function with the passed second function and the item</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_Func_action_action)]
        public static void action(Action<Action<T>, T> ax, Action<T> a, T t) { ax.Invoke(a, t); } // ouch
        /// <summary>Invokes the Function</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_T_Func_func_no_items)]
        public static T func(Func<T> fn) { return fn.Invoke(); }
        /// <summary>Invokes the Function with a passed item</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_T_Func_func_one_item)]
        public static T func(Func<T, T> fn, T t) { return fn.Invoke(t); }
        /// <summary>Invokes the Function with two passed items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_T_Func_func_two_items)]
        public static T func(Func<T, T, T> fn, T t1, T t2) { return fn.Invoke(t1, t2); }
        /// <summary>Invokes the Function with three passed items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_T_Func_func_three_items)]
        public static T func(Func<T, T, T, T> fn, T t1, T t2, T t3) { return fn.Invoke(t1, t2, t3); }
        /// <summary>Invokes the Function with four passed items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_T_Func_func_four_items)]
        public static T func(Func<T, T, T, T, T> fn, T t1, T t2, T t3, T t4) { return fn(t1, t2, t3, t4); }
        /// <summary>Invokes the Function with five passed items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_T_Func_func_five_items)]
        public static T func(Func<T,T,T,T,T,T> fn,T t1,T t2,T t3,T t4,T t5) { return fn(t1,t2,t3,t4,t5); }
        /// <summary>Invokes the Function with six passed items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_T_Func_func_six_items)]
        public static T func(Func<T, T, T, T, T, T, T> fn, T t1, T t2, T t3, T t4, T t5, T t6) { return fn(t1, t2, t3, t4, t5, t6); }
        /// <summary>Invokes the Function with a passed seqence of items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_T_Func_func_sequence)]
        public static T func(Func<IEnumerable<T>, T> fn, IEnumerable<T> seq) { return fn(seq); } // looks like reduce
        /// <summary>Invokes the first Function with the passed second function and the item</summary><returns>result from the first function</returns>
        [Coverage(TestCoverage.F_T_Func_func_func)]
        public static T func(Func<Func<T, T>, T, T> fx, Func<T, T> f, T t1) { return fx(f, t1); }
    }
}