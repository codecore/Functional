using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        // <summary>calculate the difference of two numbers</summary><returns>difference</returns>
        [Coverage(TestCoverage.F_sub_int)]
        public static Func<int,int,int> sub_int = (x, y) => x - y; // TestCoverage = F, F_sub, F_sub_int
        // <summary>calculate the difference of two numbers</summary><returns>difference</returns>
        [Coverage(TestCoverage.F_sub_long)]
        public static Func<long,long,long> sub_long = (x, y) => x - y; // TestCoverage = F, F_sub, F_sub_long
        // <summary>calculate the difference of two numbers</summary><returns>difference</returns>
        [Coverage(TestCoverage.F_sub_short)]
        public static Func<short,short,short> sub_short = (x, y) => (short)(x - y); // TestCoverage = F, F_sub, F_sub_short
        // <summary>calculate the difference of two numbers</summary><returns>difference</returns>
        [Coverage(TestCoverage.F_sub_float)]
        public static Func<float, float, float> sub_float = (x, y) => x - y; // TestCoverage = F, F_sub, F_sub_float
        // <summary>calculate the difference of two numbers</summary><returns>difference</returns>
        public static Func<double,double,double> sub_double = (x, y) => x - y; // TestCoverage = F, F_sub, F_sub_double
    }
}