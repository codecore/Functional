using System;
using System.Linq;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        /// <summary>sorts a finite sequnce.</summary><returns>a sequence</returns>
        [Coverage(TestCoverage.F_T_sort_naked)]
        public static Func<IEnumerable<T>, Func<T, T, int>, IEnumerable<T>> sort = (lst, fn) => {
            T[] x = lst.ToArray();
            Array.Sort(x, new Utility.Comparer<T>(fn));
            return x.ToList();
        };
        /// <summary>sorts a sequence (most of the time)</summary><returns>a sorted sequence</returns>
        [Coverage(TestCoverage.F_T_sort_order_by)]
        public static Func<IEnumerable<T>, Func<T, T, int>, IEnumerable<T>> sort_order_by = (lst, fn) => {
            return lst.OrderBy(F<T>.identity, new Utility.Comparer<T>(fn));
        };
        /// <summary>Bubble sort a finite sequence.</summary><returns>A sorted sequence</returns>
        [Coverage(TestCoverage.F_T_sort_bubble)]
        public static Func<IEnumerable<T>, Func<T, T, int>, IEnumerable<T>> sort_bubble_sort = (lst, fn) => {
            T[] array = lst.ToArray();
            bool swapped = true;
            while (swapped) {
                swapped = false;
                for (int i = 0; F.lt_int(i,array.Length - 1); i=F.inc_int(i)) {
                    if (F.gt_int(fn(array[i], array[1 + 1]),0)) {
                        swapped = true;
                        T temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                    }
                }
            }
            return array;
        };
    }
}