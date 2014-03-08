using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>Given a sequence and a predicate, indicates if any elemnt passes the predicate</summary><returns>true if any of the elements pass the predicate function</returns>
        [Coverage(TestCoverage.F_T_any)]
        public static Func<IEnumerable<T>, Func<T, bool>, bool> any = (lst, predicate) => lst.Any(predicate);
    }
}