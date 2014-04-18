using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class C<T> where T : class {
        public static void action_if_not_null(T t, Action<T> a) {
            if (null != t) a(t);
        }
        public static void action_if_not_null<U>(Action<T, Func<T, U>, Action<U>> doThis, T t, Func<T, U> tx, Action<U> a) {
            if (null != t) doThis(t, tx, a);
        }
        public static IEnumerable<U> sequence_if_not_null<U>(Func<T, Func<T, U>, IEnumerable<U>> fseq, T t, Func<T, U> tx) {
            if (null != t) foreach (U u in fseq(t, tx)) yield return u;
        }
    }
    public static partial class Meta<U,T> where U : class {
        
    }
    public static partial class F {
        /// <summary>Invokes the Function with a passed item</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_func_action_1_arguments_T)]
        public static void action<T>(Action<T> a, T t) { a.Invoke(t); }
        /// <summary>Invokes the Function with two passed items</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_func_action_2_arguments_T)]
        public static void action<T>(Action<T,T> a, T t1, T t2) { a.Invoke(t1, t2); }
        /// <summary>Invokes the Function with the passed items</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_func_action_3_arguments_T)]
        public static void action<T>(Action<T,T,T> a, T t1, T t2, T t3) { a.Invoke(t1, t2, t3); }
        /// <summary>Invokes the Function with the passed items</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_func_action_4_arguments_T)]
        public static void action<T>(Action<T,T,T,T> a, T t1, T t2, T t3, T t4) { a.Invoke(t1, t2, t3, t4); }
        /// <summary>Invokes the Function with the passed items</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_func_action_5_arguments_T)]
        public static void action<T>(Action<T,T,T,T,T> a, T t1, T t2, T t3, T t4, T t5) { a.Invoke(t1, t2, t3, t4, t5); }
        /// <summary>Invokes the Function with the passed items</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_func_action_6_arguments_T)]
        public static void action<T>(Action<T,T,T,T,T,T> a, T t1, T t2, T t3, T t4, T t5, T t6) { a.Invoke(t1, t2, t3, t4, t5, t6); }
        /// <summary>Invokes the Function with the passed sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_func_action_sequence_T)]
        public static void action<T>(Action<IEnumerable<T>> a, IEnumerable<T> seq) { a.Invoke(seq); }
        /// <summary>Invokes the first Function with the passed second function and the item</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_func_action_action_T)]
        public static void action<T>(Action<Action<T>, T> ax, Action<T> a, T t) { ax.Invoke(a, t); } // ouch
        /// <summary>Invokes the Function</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_func_func_0_arguments_T)]
        public static T func<T>(Func<T> fn) { return fn.Invoke(); }
        /// <summary>Invokes the Function with a passed item</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_func_func_1_arguments_T)]
        public static T func<T>(Func<T,T> fn, T t) { return fn.Invoke(t); }
        /// <summary>Invokes the Function with two passed items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_func_func_2_arguments_T)]
        public static T func<T>(Func<T,T,T> fn, T t1, T t2) { return fn.Invoke(t1, t2); }
        /// <summary>Invokes the Function with three passed items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_func_func_3_arguments_T)]
        public static T func<T>(Func<T,T,T,T> fn, T t1, T t2, T t3) { return fn.Invoke(t1, t2, t3); }
        /// <summary>Invokes the Function with four passed items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_func_func_4_arguments_T)]
        public static T func<T>(Func<T,T,T,T,T> fn, T t1, T t2, T t3, T t4) { return fn(t1, t2, t3, t4); }
        /// <summary>Invokes the Function with five passed items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_func_func_5_arguments_T)]
        public static T func<T>(Func<T,T,T,T,T,T> fn,T t1,T t2,T t3,T t4,T t5) { return fn(t1,t2,t3,t4,t5); }
        /// <summary>Invokes the Function with six passed items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_func_func_6_arguments_T)]
        public static T func<T>(Func<T,T,T,T,T,T,T> fn, T t1, T t2, T t3, T t4, T t5, T t6) { return fn(t1, t2, t3, t4, t5, t6); }
        /// <summary>Invokes the Function with a passed seqence of items</summary><returns>result of the function</returns>
        [Coverage(TestCoverage.F_func_func_sequence_T)]
        public static T func<T>(Func<IEnumerable<T>,T> fn, IEnumerable<T> seq) { return fn(seq); } // looks like reduce
        /// <summary>Invokes the first Function with the passed second function and the item</summary><returns>result from the first function</returns>
        [Coverage(TestCoverage.F_func_func_func_T)]
        public static T func<T>(Func<Func<T,T>,T,T> fx, Func<T,T> f, T t1) { return fx(f, t1); }
    }
}