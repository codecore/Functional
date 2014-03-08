using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>calculate the square of the number</summary><returns>square</returns>
        [Coverage(TestCoverage.F_sqr_int)]
        public static Func<int,int>           sqr_int = (x) => x * x; // TestCoverage = F, F_sqr, F_sqr_int
        /// <summary>calculate the square of the number</summary><returns>square</returns>
        [Coverage(TestCoverage.F_sqr_long)]
        public static Func<long,long>        sqr_long = (x) => x * x; // TestCoverae = F, F_sqr, F_sqr_long
        /// <summary>calculate the square of the number</summary><returns>square</returns>
        [Coverage(TestCoverage.F_sqr_short)]
        public static Func<short, short>    sqr_short = (x) => (short)(x * x); // TestCoverage = F, F_sqr_short
        /// <summary>calculate the square of the number</summary><returns>square</returns>
        [Coverage(TestCoverage.F_sqr_float)]
        public static Func<float,float>     sqr_float = (x) => x * x; // TestCoverage = F, F_sqr, F_sqr_float
        /// <summary>calculate the square of the number</summary><returns>square</returns>
        [Coverage(TestCoverage.F_sqr_double)]
        public static Func<double,double>  sqr_double = (x) => x * x; // TestCoverage = F, F_sqr, F_sqr_double
    }
}