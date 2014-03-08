using System;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>true if the values are near (&lt;0.01)</summary><returns>bool</returns>
        [Coverage(TestCoverage.F_close_double)]
        public static Func<double, double, bool> close_double = (x, y) => {
            // TestCoverage = F, F_close, F_close_double
            return Math.Abs(x - y) < 0.01d;
        };
        /// <summary>true if the values are near (&lt;0.01)</summary><returns>bool</returns>
        [Coverage(TestCoverage.F_close_float)]
        public static Func<float,float,bool> close_float = (x, y) => {
            // TestCoverage = F, F_close, F_close_float
            return Math.Abs(x - y) < 0.01f;
        };
    }
}