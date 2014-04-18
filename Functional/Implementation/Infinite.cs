using System;
using System.Collections.Generic;

using Functional.Implementation;
using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>Takes a bool and returns an infinite sequence of that bool</summary><returns>an infinite sequence of bools</returns>
        [Coverage(TestCoverage.F_infinite_bool_toggle)]
        public static Func<bool, IEnumerable<bool>> infinite_bool_toggle = (b) => F.forever<bool>((x)=>!x, b);
        /// <summary>A function given start, returns an infinite sequence of increasing integers. (warning: integer overflow)</summary><returns>An infinite sequence of increasing integers</returns>
        [Coverage(TestCoverage.F_infinite_range_int_start_inc)]
        public static Func<int,IEnumerable<int>> infinite_range_start_inc = (start) => F.forever<int>((x)=>x+1,start);
        // there ar more to come
    }
}