using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_each_naked)]
        public static void each(IEnumerable<T> lst,Action<T> fn) {
            foreach (T t in lst) fn(t); 
        }
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_each_U)]
        public static void each<U>(IEnumerable<T> lst, Action<T,U> fn, U u) {
            foreach (T t in lst) fn(t, u); 
        }
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_each_U_V)]
        public static void each<U,V>(IEnumerable<T> lst, Action<T,U,V> fn, U u, V v) {
            foreach (T t in lst) fn(t, u, v); 
        }
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_each_U_V_W)]
        public static void each<U,V,W>(IEnumerable<T> lst, Action<T,U,V,W> fn, U u, V v, W w) {
            foreach (T t in lst) fn(t, u, v, w);
        }
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_each_U_V_W_X)]
        public static void each<U,V,W,X>(IEnumerable<T> lst, Action<T,U,V,W,X> fn, U u, V v, W w, X x) {
            foreach (T t in lst) fn(t, u, v, w, x); 
        }
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_each_U_V_Acc)]
        public static void each<U, V>(IEnumerable<T> lst, Action<T, U, V> fn, U u, Func<V, V> acc, V init) {
            V current = init;
            foreach (T t in lst) {
                fn(t, u, current);
                current = acc(current);
            }
        }
    }
}