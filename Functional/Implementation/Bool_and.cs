using System;
using System.Collections.Generic;

using Functional.Implementation;
using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>and</summary><returns>true if all the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_and)]
        public static bool bool_and(bool b) { return b; }
        /// <summary>and</summary><returns>true if all the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_and)]
        public static bool bool_and(bool b1, bool b2) { return (b1 && b2); }
        /// <summary>and</summary><returns>true if all the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_and)]
        public static bool bool_and(bool b1, bool b2, bool b3) { return (b1 && b2 && b3); }
        /// <summary>and</summary><returns>true if all the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_and)]
        public static bool bool_and(bool b1, bool b2, bool b3, bool b4) { return (b1 && b2 && b3 && b4); }
        /// <summary>and</summary><returns>true if all the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_and)]
        public static bool bool_and(bool b1, bool b2, bool b3, bool b4, bool b5) { return (b1 && b2 && b3 && b4 && b5); }
        /// <summary>and</summary><returns>true if all the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_and)]
        public static bool bool_and(bool b1, bool b2, bool b3, bool b4, bool b5, bool b6) { return (b1 && b2 && b3 && b4 && b5 && b6); }
        /// <summary>and a sequence of boolean values</summary><returns>true if all the memers of the sequence is true</returns>
        public static bool bool_and(IEnumerable<bool> items) { return F.reduce<bool>(items, (b1, b2) => b1 && b2, true); }
    }
}