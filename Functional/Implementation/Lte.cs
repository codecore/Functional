using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>Takes two integers and returns true if the left one is less or equal to the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_lte_int)]
        public static Func<int,int,bool> lte_int = (left, right) => (left <= right); // TestCoverage = F, F_lte, F_lte_int
        /// <summary>Takes two longs and returns true if the left one is less or equal to the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_lte_long)]
        public static Func<long,long,bool> lte_long = (left, right) => (left <= right); // TestCoverage = F, F_lte, F_lte_long
        /// <summary>Takes two shorts and returns true if the left one is less or equal to the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_lte_short)]
        public static Func<short,short,bool> lte_short = (left, right) => (left <= right); // TestCoverage = F, F_lte, F_lte_short
    }
}