using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    [Coverage(TestCoverage.F_T_all)]
    public static partial class F<T>   {
        /// <summary>Given a sequence and a predicate, indicates if every elemnt passes the predicate</summary><returns>true if all the elements pass the predicate function</returns>
        public static Func<IEnumerable<T>, Func<T, bool>, bool> all = (lst, predicate) => lst.All(predicate);
    }
}