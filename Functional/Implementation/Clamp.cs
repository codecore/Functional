using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        // TODO add test coverage
        [Coverage(TestCoverage.F_clamp_int_scaler)]
        public static int clamp_int(int x, int min, int max) { return (x < min) ? min : (x > max) ? max : x; }
        [Coverage(TestCoverage.F_clamp_int_seq)]
        public static IEnumerable<int> clamp_int(IEnumerable<int> x, int min, int max) {
            return F.map<int,int>(x, (k) => (k < min) ? min : (k > max) ? max : k);
        }
        [Coverage(TestCoverage.F_clamp_short_scaler)]
        public static short clamp_short(short x, short min, short max) { return (x < min) ? min : (x > max) ? max : x; }
        [Coverage(TestCoverage.F_clamp_short_seq)]
        public static IEnumerable<short> clamp_short(IEnumerable<short> x, short min, short max) {
            return F.map<short,short>(x,(k)=>(k<min)?min:(k>max)?max:k);
        }
        [Coverage(TestCoverage.F_clamp_long_scaler)]
        public static long clamp_long(long x,long min,long max) {  return (x<min)?min:(x>max)?max:x; }
        [Coverage(TestCoverage.F_clamp_long_seq)]
        public static IEnumerable<long> clamp_long(IEnumerable<long> x, long min, long max) {
            return F.map<long,long>(x, (k) => (k < min) ? min : (k > max) ? max : k);
        }
        [Coverage(TestCoverage.F_clamp_ushort_scaler)]
        public static ushort clamp_ushort(ushort x, ushort min, ushort max) {
            return (x < min) ? min : (x > max) ? max : x;
        }
        [Coverage(TestCoverage.F_clamp_ushort_seq)]
        public static IEnumerable<ushort> clamp_ushort(IEnumerable<ushort> x, ushort min, ushort max) {
            return F.map<ushort,ushort>(x, (k) => (k < min) ? min : (k > max) ? max : k);
        }
        /// <summary>clamp a float to a upper an lower limit</summary><returns>clamped value</returns>
        [Coverage(TestCoverage.F_clamp_float_scaler)]
        public static float clamp_float(float x, float min, float max) { return (x<min) ? min : (x>max) ? max : x; }
        /// <summary>clamp a sequence of floats to a upper an lower limit</summary><returns>sequence of clamped values</returns>
        [Coverage(TestCoverage.F_clamp_float_seq)]
        public static IEnumerable<float> clamp_float(IEnumerable<float> x, float min, float max) {
            Func<float, float> clamp = (k) => (k > max) ? max : (k < min) ? min : k;
            return F.map<float,float>(x, clamp);
        }
        /// <summary>clamp a double to a upper an lower limit</summary><returns>clamped value</returns>
        [Coverage(TestCoverage.F_clamp_double_scaler)]
        public static double clamp_double(double x, double min, double max) { return (x < min) ? min : (x > max) ? max : x; }
        /// <summary>clamp a sequence of doubles to a upper an lower limit</summary><returns>sequence of clamped values</returns>
        [Coverage(TestCoverage.F_clamp_double_seq)]
        public static IEnumerable<double> clamp_double(IEnumerable<double> x, double min, double max) {
            Func<double, double> clamp = (k) => (k > max) ? max : (k < min) ? min : k;
            return F.map<double,double>(x, clamp);
        }

    }
}