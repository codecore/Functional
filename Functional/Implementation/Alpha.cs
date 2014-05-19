using System;
using System.Collections.Generic;

using Functional.Implementation;
using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>add a pair of ints</summary><returns>sum of the inputs</returns>
        [Coverage(TestCoverage.F_alpha_char)]
        public static bool alpha_char(char c) { return F.alpha_lower_char(c) || F.alpha_upper_char(c); }
        public static bool alpha_upper_char(char c) { return F.any<char>(F.chars("ABCDEFGHIJKLMNOPQRSTUVWXYZ"), (x) => x == c); }
        public static bool alpha_lower_char(char c) { return F.any<char>(F.chars("abcdefghijklmnopqrstuvwxyz"),(x)=>x==c);}
    }
}
