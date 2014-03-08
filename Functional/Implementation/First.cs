using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>get the first element of a sequence</summary><returns>The first element of an IEnumerable</returns>
        [Coverage(TestCoverage.F_T_first)]
        public static Func<IEnumerable<T>, T> first = (lst) => lst.First();
    }
}