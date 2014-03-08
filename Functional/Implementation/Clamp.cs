using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>clamp a float to a upper an lower limit</summary><returns>clamped value</returns>
        [Coverage(TestCoverage.F_clamp_float_scaler)]
        public static float clamp_float(float x, float min, float max) { return (x<min) ? min : (x>max) ? max : x; }
        /// <summary>clamp a sequence of floats to a upper an lower limit</summary><returns>sequence of clamped values</returns>
        [Coverage(TestCoverage.F_clamp_float_seq)]
        public static IEnumerable<float> clamp_float(IEnumerable<float> x, float min, float max) {
            Func<float, float> clamp = (k) => (k > max) ? max : (k < min) ? min : k;
            return F<float>.map<float>(x, clamp);
        }
        /// <summary>clamp a double to a upper an lower limit</summary><returns>clamped value</returns>
        [Coverage(TestCoverage.F_clamp_double_scaler)]
        public static double clamp_double(double x, double min, double max) { return (x<min) ? min : (x>max) ? max : x; }
        /// <summary>clamp a sequence of doubles to a upper an lower limit</summary><returns>sequence of clamped values</returns>
        [Coverage(TestCoverage.F_clamp_double_seq)]
        public static IEnumerable<double> clamp_double(IEnumerable<double> x, double min, double max) {
            Func<double, double> clamp = (k) => (k > max) ? max : (k < min) ? min : k;
            return F<double>.map<double>(x, clamp);
        }
    }
}