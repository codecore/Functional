using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>Takes two integers and returns true if the left one is greater or equal to the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_gte_int)]
        public static Func<int,int,bool> gte_int = (left, right) => (left >= right); // TestCoverage = F, F_gte, F_gte_int
        /// <summary>Takes two longs and returns true if the left one is greater or equal to the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_gte_long)]
        public static Func<long,long,bool> gte_long = (left, right) => (left >= right); // TestCoverage = F, F_gte, F_gte_long
        /// <summary>Takes two shorts and returns true if the left one is greater or equal to the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_gte_short)]
        public static Func<short,short,bool> gte_short = (left, right) => (left >= right); // TestCoverage = F, F_gte, F_gte_short
    }
}