using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>given a number this return the negative</summary><returns>the negative of the input</returns>
        [Coverage(TestCoverage.F_neg_int)]
        public static Func<int,int> neg_int = (x) => -x;           // TestCoverage = F, F_neg, F_neg_int
        /// <summary>given a number this return the negative</summary><returns>the negative of the input</returns>
        [Coverage(TestCoverage.F_neg_long)]
        public static Func<long,long> neg_long = (x) => -x;           // TestCoverage = F, F_neg, F_neg_long
        /// <summary>given a number this return the negative</summary><returns>the negative of the input</returns>
        [Coverage(TestCoverage.F_neg_short)]
        public static Func<short,short> neg_short = (x) => (short)(-x);  // TestCoverage = F, F_neg, F_neg_short
        /// <summary>given a number this return the negative</summary><returns>the negative of the input</returns>
        [Coverage(TestCoverage.F_neg_float)]
        public static Func<float,float> neg_float = (x) => -x;           // TestCoverage = F, F_neg, F_neg_float
        /// <summary>given a number this return the negative</summary><returns>the negative of the input</returns>
        [Coverage(TestCoverage.F_neg_double)]
        public static Func<double,double> neg_double = (x) => -x;           // TestCoverage = F, F_neg, F_neg_double
    }
}