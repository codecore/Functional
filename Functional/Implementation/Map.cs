using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        /// <summary>returns a sequence that is the result of a sequence transformed by a function</summary><returns>A sequence of objects of type T</returns>
        [Coverage(TestCoverage.F_map_TU)]
        public static IEnumerable<U> map<T,U>(IEnumerable<T> lst, Func<T,U> fn) {
            return lst.Select(fn); 
        }
        /// <summary>given a sequence and a function and a utility-item (of type V), returns a sequence of transformed items</summary><returns>A sequence of objects of type U</returns>
        [Coverage(TestCoverage.F_map_TUV)]
        public static IEnumerable<U> map<T,U,V>(IEnumerable<T> lst, Func<T,V,U> fn, V v) {
            foreach (T t in lst) yield return fn(t, v);
        }

        [Coverage(TestCoverage.F_map_TUVW)]
        public static IEnumerable<U> map<T,U,V,W>(IEnumerable<T> lst, Func<T,V,W,U> fn, V v, W w) {
            foreach (T t in lst) yield return fn(t, v, w);
        }

        [Coverage(TestCoverage.F_map_TUVWX)]
        public static IEnumerable<U> map<T,U,V,W,X>(IEnumerable<T> lst, Func<T,V,W,X,U> fn, V v, W w, X x) {
            foreach (T t in lst) yield return fn(t, v, w, x);
        }
        /// <summary>returns a sequence that is fed by two other sequences and a combining function fn</summary><returns>A sequence of objects of type T</returns>
        [Coverage(TestCoverage.F_map_TU_2_List)]
        public static IEnumerable<U> map<T,U>(IEnumerable<T> lst1, IEnumerable<T> lst2, Func<T, T, U> fn) {
            IEnumerator<T> one = lst1.GetEnumerator();
            IEnumerator<T> two = lst2.GetEnumerator();
            while ((one.MoveNext()) && (two.MoveNext())) {
                yield return fn(one.Current, two.Current);
            }
        }
        /// <summary>returns a sequence that is fed by three other sequences and a combining function fn</summary><returns>A sequence of objects of type T</returns>
        [Coverage(TestCoverage.F_map_TU_3_List)]
        public static IEnumerable<U> map<T,U>(IEnumerable<T> lst1, IEnumerable<T> lst2, IEnumerable<T> lst3, Func<T, T, T, U> fn) {
            IEnumerator<T> one = lst1.GetEnumerator();
            IEnumerator<T> two = lst2.GetEnumerator();
            IEnumerator<T> three = lst3.GetEnumerator();
            while ((one.MoveNext()) && (two.MoveNext()) && (three.MoveNext())) {
                yield return fn(one.Current, two.Current, three.Current);
            }
        }
    }
}