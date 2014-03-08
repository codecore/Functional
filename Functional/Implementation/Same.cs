using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>true if both sequences are the same. Not valid for sequences of functions.</summary><returns>bool</returns>
        [Coverage(TestCoverage.F_T_same)]
        public static Func<IEnumerable<T>, IEnumerable<T>, Func<T, T, bool>, bool> same = (lst1, lst2, fn) => {
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
        };
    }
}