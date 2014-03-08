using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>Takes an integer and returns the increment of it</summary><returns>input + 1</returns>
        [Coverage(TestCoverage.F_inc_int)]
        public static Func<int,int> inc_int = (x) => F.add_int(x, 1);  // TestCoverage = F, F_add, F_add_int
        /// <summary>Takes a long and returns the increment of it</summary><returns>input + 1</returns>
        [Coverage(TestCoverage.F_inc_long)]
        public static Func<long,long> inc_long = (x) => F.add_long(x,1L); // TestCoverage = F, F_add, F_add_long
        /// <summary>Takes a short and returns the increment of it</summary><returns>input + 1</returns>
        [Coverage(TestCoverage.F_inc_short)]
        public static Func<short,short> inc_short = (x) => (short)(x + 1);   // TestCoverage = F, F_add, F_add_short
    }
}