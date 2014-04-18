using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_each_naked_T)]
        public static void each<T>(IEnumerable<T> lst,Action<T> fn) {
            foreach (T t in lst) fn(t); 
        }
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_each_TU)]
        public static void each<T,U>(IEnumerable<T> lst, Action<T,U> fn, U u) {
            foreach (T t in lst) fn(t, u); 
        }
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_each_TUV)]
        public static void each<T,U,V>(IEnumerable<T> lst, Action<T,U,V> fn, U u, V v) {
            foreach (T t in lst) fn(t, u, v); 
        }
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_each_TUVW)]
        public static void each<T,U,V,W>(IEnumerable<T> lst, Action<T,U,V,W> fn, U u, V v, W w) {
            foreach (T t in lst) fn(t, u, v, w);
        }
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_each_TUVWX)]
        public static void each<T,U,V,W,X>(IEnumerable<T> lst, Action<T,U,V,W,X> fn, U u, V v, W w, X x) {
            foreach (T t in lst) fn(t, u, v, w, x); 
        }
        /// <summary>Runs a function an each member of a sequence</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_each_TUV_Acc)]
        public static void each<T,U,V>(IEnumerable<T> lst, Action<T,U,V> fn, U u, Func<V,V> acc, V init) {
            V current = init;
            foreach (T t in lst) {
                fn(t, u, current);
                current = acc(current);
            }
        }
    }
}