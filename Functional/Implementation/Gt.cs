using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>Takes two integers and returns true if the left one is greater than the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_gt_int)]
        public static Func<int,int,bool> gt_int = (left, right) => (left > right); // TestCoverage = F, F_gt, F_gt_int
        /// <summary>Takes two longs and returns true if the left one is greater than the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_gt_long)]
        public static Func<long,long,bool> gt_long = (left, right) => (left > right); // TestCoverage = F, F_gt, F_gt_long
        /// <summary>Takes two shorts and returns true if the left one is greater than the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_gt_short)]
        public static Func<short,short,bool> gt_short = (left, right) => (left > right); // TestCoverage = F, F_gt, F_gt_short
        /// <summary>Takes two floats and returns true if the left one is greater than the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_gt_float)]
        public static Func<float,float,bool> gt_float = (left, right) => (left > right); // TestCoverage = F, F_gt, F_gt_float
        /// <summary>Takes two doubles and returns true if the left one is greater than the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_gt_double)]
        public static Func<double,double,bool> gt_double = (left, right) => (left > right); // TestCoverage = F, F_gt, F_gt_double
    }
}