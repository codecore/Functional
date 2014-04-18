using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Test;

using Functional.Contracts;
namespace Functional.Implementation {

    public static partial class F {

        /// <summary>transform a string to a sequenc of chars</summary><returns>sequence of chars</returns>
        [Coverage(TestCoverage.F_chars)]
        public static Func<string, IEnumerable<char>> chars = (item) => item.AsEnumerable();
        /// <summary>if the int is even, this returns true</summary><returns>int is even</returns>
        [Coverage(TestCoverage.F_even)]    
        public static Func<int,bool> even = (x) => (0 == (x & 0x0001)); // TestCoverage = F, F_even
        /// <summary>if the int is odd, this returns true</summary><returns>int is odd</returns>
        [Coverage(TestCoverage.F_odd)]
        public static Func<int,bool>  odd = (x) => (1 == (x & 0x0001)); // TestCoverage = F, F_odd

        /// <summary>Given a sequence and a predicate, return the filtered sequence</summary><returns>a sequence of T that meets the criteria of the predicate function</returns>
        [Coverage(TestCoverage.F_filter_T)]
        public static IEnumerable<T> filter<T>(IEnumerable<T> lst, Func<T, bool> predicate) { return lst.Where(predicate); }

    }
    public static partial class F<T>   {





   
 
    }
}