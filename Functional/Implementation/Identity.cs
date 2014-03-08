using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>Takes an item and returns it back</summary><returns>the item you sent in</returns>
        [Coverage(TestCoverage.F_T_identity)]
        public static Func<T, T> identity = (item) => item;
    }
}