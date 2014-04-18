using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {


        // A better cross-type reducer
        /// <summary>applies a acc function to items in seq of T. fn(x,y)  x is the accumulation, y is the item from the sequence, and an initial item, and applies the accumulation function acc to all the element.</summary><returns>A U</returns>
        [Coverage(TestCoverage.F_reduce_better_TU)]
        public static U reducebetter<T,U>(IEnumerable<T> seq, Func<T, U, U> fn, U init) {
            U u = init;
            foreach (T t in seq) u = fn(t, u);
            return u;
        }
        /// <summary>Takes an enumeration of T, an accumulation function. fn(x,y)  x is the accumulation, y is the item from the sequence, and an initial item, and applies the accumulation function acc to all the element.</summary><returns>A U</returns>
        [Coverage(TestCoverage.F_reduce_init_T)]
        public static T reduce<T>(IEnumerable<T> lst, Func<T,T,T> fn, T item) {
            // fn(x,y)  x is the accumulation, y is the item from the sequence
            return lst.Aggregate(item, fn);
        }
        /// <summary>Takes a sequence of T and an accumulation function. fn(x,y)  x is the accumulation, y is the item from the sequence</summary><returns>the accumulation of the sequence</returns>
        [Coverage(TestCoverage.F_reduce_naked_T)]
        public static T reduce<T>(IEnumerable<T> lst, Func<T, T, T> fn) {
            return lst.Aggregate(fn);
        }

        /// <summary>Takes an enumeration of T, and applies the accumulation function acc to all the element.fn(x,y)  x is the accumulation, y is the item from the sequence</summary><returns>A U</returns>
        [Coverage(TestCoverage.F_reduce_init_TU)]
        public static U reduce<T,U>(IEnumerable<T> lst, Func<U,T,U> fn, U item) {
            return lst.Aggregate<T,U,U>(item, fn, F.identity<U>);
        }
    }
}