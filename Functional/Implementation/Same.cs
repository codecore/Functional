using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        /// <summary>true if both sequences are the same. Not valid for sequences of functions.</summary><returns>bool</returns>
        [Coverage(TestCoverage.F_same_seq_T)]
        public static bool same<T>(IEnumerable<T> lst1, IEnumerable<T> lst2, Func<T, T, bool> fn) {
            IEnumerator<T> i1 = lst1.GetEnumerator();
            IEnumerator<T> i2 = lst2.GetEnumerator();
            bool result = true;
            bool b1 = i1.MoveNext();
            bool b2 = i2.MoveNext();
            while (result && b1 && b2) {
                result = fn(i1.Current, i2.Current);
                b1 = i1.MoveNext();
                b2 = i2.MoveNext();
            }
            return (result && (b1 == b2));
        }
        [Coverage(TestCoverage.F_same_seq_TU)]
        public static bool same<T,U>(IEnumerable<T> lst1, IEnumerable<U> lst2, Func<T,U,bool> fn) {
            IEnumerator<T> i1 = lst1.GetEnumerator();
            IEnumerator<U> i2 = lst2.GetEnumerator();
            bool result = true;
            bool b1 = i1.MoveNext();
            bool b2 = i2.MoveNext();
            while (result && b1 && b2) {
                result = fn(i1.Current, i2.Current);
                b1 = i1.MoveNext();
                b2 = i2.MoveNext();
            }
            return (result && (b1 == b2));
        }
        // needs coverage
        [Coverage(TestCoverage.F_same_TU)]
        public static bool same<T,U>(T t, U u, Func<T,U,bool> comp) {
            return (comp(t,u));
        }
    }
}