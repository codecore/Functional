using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        /// <summary>Takes an item and returns it back</summary><returns>the item you sent in</returns>
        [Coverage(TestCoverage.F_identity_T)]
        public static T identity<T>(T t) { return t; }
    }
}