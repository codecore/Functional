using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>Takes a sequence of objects of type T and a map function that transforms an object of type T to a sequence of objects of type U</summary><returns>A sequence of objects of type U</returns>
        [Coverage(TestCoverage.F_T_flatten)]
        public static IEnumerable<U> flatten<U>(IEnumerable<T> lst, Func<T, IEnumerable<U>> fn) {
            foreach (T t in lst) 
                foreach (U u in fn(t)) 
                    yield return u;
        }
    }
}