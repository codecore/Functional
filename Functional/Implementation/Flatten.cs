using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        /// <summary>Takes a sequence of objects of type T and a map function that transforms an object of type T to a sequence of objects of type U</summary><returns>A sequence of objects of type U</returns>
        [Coverage(TestCoverage.F_flatten_T)]
        public static IEnumerable<U> flatten<T,U>(IEnumerable<T> lst, Func<T, IEnumerable<U>> fn) {
            foreach (T t in lst) 
                foreach (U u in fn(t)) 
                    yield return u;
        }
    }
}