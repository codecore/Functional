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
    public static partial class F   {
        /// <summary>count the number of items in a sequence</summary><returns>number of items in a sequence</returns>
        [Coverage(TestCoverage.F_count_naked_T)]
        public static int count<T>(IEnumerable<T> lst) {
            return F.reducebetter<T,int>(lst, (t, n) => n + 1, 0);
        }
        /// <summary>count the number of items in a filtered sequence</summary><returns>number of items in a sequence</returns>
        [Coverage(TestCoverage.F_count_filter_T)]
        public static int count_filter<T>(IEnumerable<T> lst, Func<T, bool> fn) {
            return F.reducebetter<T,int>(F.filter<T>(lst,fn),(t,n)=>n+1,0);
        }
        /// <summary>count the number of items in a sequence that pass a predicate</summary><returns>number of items in a sequence that pass the predicate</returns>
        [Coverage(TestCoverage.F_count_predicate_T)]
        public static int count_predicate<T>(IEnumerable<T> lst, Func<T, bool> pred) {
            return F.reducebetter<T,int>(lst, (t, n) => (pred(t)) ? n + 1 : n, 0);
        }
    }
}
