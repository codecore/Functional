using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>get the sequence following the first element of a sequence</summary><returns>an IEnermerable following the first element</returns>
        [Coverage(TestCoverage.F_T_rest)] // TestCoverage = F_T, F_T_rest
        public static Func<IEnumerable<T>, IEnumerable<T>> rest = (lst) => lst.Skip(1);
    }
}