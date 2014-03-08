using System;
using System.Collections.Generic;

using Functional.Implementation;
using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>returns a sequence of ints</summary><returns>sequence of ints</returns>
        [Coverage(TestCoverage.F_range_start_end)]
        public static IEnumerable<int> range(int start, int end) {
            // TestCoverage = F. F_range, F_range_start_end
            int step = (F.gt_int(F.sub_int(end,start),0)) ? 1 : -1;
            for (int i = start; F.neq_int(i, end); i=F.add_int(i,step)) yield return i;
        }
        /// <summary>returns a sequence of ints</summary><returns>sequence of ints</returns>
        [Coverage(TestCoverage.F_range_start_end_step)]
        public static IEnumerable<int> range(int start, int end, int step) {
            // TestCoverage = F, F_range, F_range_start_end_step
            int Step = (F.gt_int(F.sub_int(end,start),0)) ? Math.Abs(step) : -Math.Abs(step);
            Func<int, int, bool> condition = (F.gt_int(F.sub_int(end,start),0)) ? F.lt_int : F.gt_int;
            for (int i = start; condition(i, end); i = F.add_int(i,Step)) yield return i;
        }
        /// <summary>returns a sequence of ints</summary><returns>sequence of ints</returns>
        [Coverage(TestCoverage.F_range_end)]
        public static IEnumerable<int> range(int end) {
            // TestCoverage = F, F_range, F_range_end
            return range(0, end); 
        }
    }
}