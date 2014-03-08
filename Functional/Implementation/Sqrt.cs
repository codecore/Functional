using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>calculate the square root of the number</summary><returns>square root</returns>
        [Coverage(TestCoverage.F_sqrt_float)]
        public static Func<float,float>    sqrt_float = (x) => {
            // TestCoverage = F, F_sqrt, F_sqrt_float
            return (float)Math.Sqrt(x);
        };
        /// <summary>calculate the square root of the number</summary><returns>square root</returns>
        [Coverage(TestCoverage.F_sqrt_double)]
        public static Func<double,double> sqrt_double = (x) => { 
            // TestCoverage = F, F_sqrt, F_sqrt_double
            return (float)Math.Sqrt(x); 
        };
    }
}