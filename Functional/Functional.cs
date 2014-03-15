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
        /// <summary>sring an a sequenc of chars</summary><returns>sequence of chars</returns>
        [Coverage(TestCoverage.F_chars)]
        public static Func<string, IEnumerable<char>> chars = (item) => item.AsEnumerable();
        /// <summary>if the int is even, this returns true</summary><returns>int is even</returns>
        [Coverage(TestCoverage.F_even)]    
        public static Func<int,bool> even = (x) => (0 == (x & 0x0001)); // TestCoverage = F, F_even
        /// <summary>if the int is odd, this returns true</summary><returns>int is odd</returns>
        [Coverage(TestCoverage.F_odd)]
        public static Func<int,bool>  odd = (x) => (1 == (x & 0x0001)); // TestCoverage = F, F_odd


    }
    public static partial class F<T>   {

        /// <summary>Given a sequence and a predicate, return the filtered sequence</summary><returns>a sequence of T that meets the criteria of the predicate function</returns>
        [Coverage(TestCoverage.F_T_filter)]
        public static Func<IEnumerable<T>, Func<T, bool>, IEnumerable<T>> filter = (lst, predicate) => lst.Where(predicate);

        /// <summary>runs an accumulatr function as long as the check function is true</summary><returns>a sequence of T</returns>
        [Coverage(TestCoverage.F_T_iterate_while)]
        public static IEnumerable<T> iterate_while(Func<T, T> fn, Func<T, bool> predicate, T init) {
            T result = init;
            while (predicate(result)) {
                yield return result;
                result = fn(result);
            }
        }
        /// <summary>returns a limitted number of elements from a sequence</summary><returns>a sequence</returns>
        [Coverage(TestCoverage.F_T_limit)]
        public static Func<IEnumerable<T>,int,IEnumerable<T>> limit = (lst,count) => lst.Take(count);
   
 
    }
}