using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Contracts;
namespace Functional.Implementation {

    public static partial class F {


        public static Func<string, IEnumerable<char>> chars = (item) => item.AsEnumerable();
            
        public static Func<int,bool> even = (x) => (0 == (x & 0x0001)); // TestCoverage = F, F_even
        public static Func<int,bool>  odd = (x) => (1 == (x & 0x0001)); // TestCoverage = F, F_odd


    }
    public static partial class F<T>   {

        /// <summary>Given a sequence and a predicate, return the filtered sequence</summary><returns>a sequence of T that meets the criteria of the predicate function</returns>
        public static Func<IEnumerable<T>, Func<T, bool>, IEnumerable<T>> filter = (lst, predicate) => lst.Where(predicate);

        /// <summary>runs an accumulatr function as long as the check function is true</summary><returns>a sequence of T</returns>
        /// // TestCoverage = F_T, F_T_iterate_while
        public static IEnumerable<T> iterate_while(Func<T, T> fn, Func<T, bool> predicate, T init) {
            T result = init;
            while (predicate(result)) {
                yield return result;
                result = fn(result);
            }
        }

        // TestCoverage = F_T, F_T_limit
        public static Func<IEnumerable<T>,int,IEnumerable<T>> limit = (lst,count) => lst.Take(count);
   
 
    }
}