using System;
using System.Collections.Generic;

using Functional.Implementation;
using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>or</summary><returns>true if any the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_or)]
        public static bool bool_or(bool b) { return b; }
        /// <summary>or</summary><returns>true if any the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_or)]
        public static bool bool_or(bool b1, bool b2) { return (b1 || b2); }
        /// <summary>or</summary><returns>true if any the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_or)]
        public static bool bool_or(bool b1, bool b2, bool b3) { return (b1 || b2 || b3); }
        /// <summary>or</summary><returns>true if any the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_or)]
        public static bool bool_or(bool b1, bool b2, bool b3, bool b4) { return (b1 || b2 || b3 || b4); }
        /// <summary>or</summary><returns>true if any the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_or)]
        public static bool bool_or(bool b1, bool b2, bool b3, bool b4, bool b5) { return (b1 || b2 || b3 || b4 || b5); }
        /// <summary>or</summary><returns>true if any the inputs are true</returns>
        [Coverage(TestCoverage.F_bool_or)]
        public static bool bool_or(bool b1, bool b2, bool b3, bool b4, bool b5, bool b6) { return (b1 || b2 || b3 || b4 || b5 || b6); }
        /// <summary>or sequence</summary><returns>true if any the members of the boolean sequence is true</returns>
        public static bool bool_or(IEnumerable<bool> items) { return F.reduce<bool>(items, (b1, b2) => b1 || b2, false); }
    }
}