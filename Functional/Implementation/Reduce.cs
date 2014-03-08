using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>Takes a sequence of T and an accumulation function</summary><returns>the accumulation of the sequence</returns>
        [Coverage(TestCoverage.F_T_reduce_naked)] /// // TestCoverage = F_T, F_T_reduce, F_T_reduce_naked
        public static T reduce(IEnumerable<T> lst,Func<T, T, T> fn) {
            return lst.Aggregate(fn);
        }
        /// <summary>Takes an enumeration of T, an accumulation function, and an initial item, and applies the accumulation function acc to all the element.</summary><returns>A U</returns>
        [Coverage(TestCoverage.F_T_reduce_init)] /// // TestCoverage = F_T, F_T_reduce, F_T_reduce_init
        public static T reduce(IEnumerable<T> lst, Func<T, T, T> fn, T item) {
            return lst.Aggregate(item, fn); 
        }
        /// <summary>Takes an enumeration of T, and applies the accumulation function acc to all the element.</summary><returns>A U</returns>
        [Coverage(TestCoverage.F_T_reduce_U_init)] /// // TestCoverage = F_T, F_T_reduce, F_T_reduce_U_init
        public static U reduce<U>(IEnumerable<T> lst, Func<U, T, U> fn, U item) {
            return lst.Aggregate<T, U, U>(item, fn, F<U>.identity);
        }
    }
}