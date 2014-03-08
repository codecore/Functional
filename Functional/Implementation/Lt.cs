using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>Takes two integers and returns true if the left one is less than the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_lt_int)]
        public static Func<int,int,bool> lt_int = (left, right) => (left < right); // TestCoverage = F, F_lt, F_lt_int
        /// <summary>Takes two longs and returns true if the left one is less than the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_lt_long)]
        public static Func<long,long,bool> lt_long = (left, right) => (left < right); // TestCoverage = F, F_lt, F_lt_long
        /// <summary>Takes two shorts and returns true if the left one is less than the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_lt_short)]
        public static Func<short,short,bool> lt_short = (left, right) => (left < right); // TestCoverage = F, F_lt, F_lt_short
        /// <summary>Takes two floats and returns true if the left one is less than the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_lt_float)]
        public static Func<float,float,bool> lt_float = (left, right) => (left < right); // TestCoverage = F, F_lt, F_lt_float
        /// <summary>Takes two doubles and returns true if the left one is less than the right one</summary><returns>boolean</returns>
        [Coverage(TestCoverage.F_lt_double)]
        public static Func<double,double,bool> lt_double = (left, right) => (left < right); // TestCoverage = F, F_lt, F_lt_double

    }
}