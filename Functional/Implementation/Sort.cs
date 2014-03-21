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
        // requires array length == 2^n
        public static void merge_sort(Func<T,T,int> fn,T[] target, T[] source) {
            T[] temp1 = new T[target.Length];
            T[] temp2 = new T[target.Length];
            int half = target.Length >> 1;
            T[] s = source;
            T[] d = temp1;
            // first sort in to two-item arrays (optimize)
            F<int>.each(F.range(0, half), (n) => _sort_2(fn, d, s, n << 1, (n << 1) + 1));
            s = d;
            d = temp2;

            foreach (int stride in F<int>.iterate_while((n) => (n << 1), (n) => n < half, 2)) {
                // 2 4 8 16 32 ..
                int count = stride;
                int two_stride = stride << 1;
                F<int>.each(F.range(0, target.Length, two_stride),(n)=>_merge_sort(fn,d,n,s,n,s,n+count,count));
                T[] temp = s;
                s = d;
                d = temp;
            }
            // put the results of the final pass in to the target array
            _merge_sort(fn, target, 0, s, 0, s, half, half);
        }
        // count is the length of the source arrays, AKA half the length of the target array
        private static void _merge_sort(Func<T, T, int> fn, T[] target, int target_index, T[] source1, int source1_index, T[] source2, int source2_index, int count) {
            int count1 = count;
            int count2 = count;

            while ((count1 > 0) || (count2 > 0)) {
                if ((count1 > 0) && (count2 > 0)) {
                    T Left = source1[source1_index];
                    T Right = source2[source2_index];
                    if (fn(Left, Right) == 1) {
                        target[target_index] = Left;
                        target_index++;
                        source1_index++;
                        count1--;
                    } else {
                        target[target_index] = Right;
                        target_index++;
                        source2_index++;
                        count2--;
                    }
                } else {
                    while (count1 > 0) {
                        target[target_index] = source1[source1_index];
                        target_index++;
                        source1_index++;
                        count1--;
                    }
                    while (count2 > 0) {
                        target[target_index] = source2[source2_index];
                        target_index++;
                        source2_index++;
                        count2--;
                    }
                }
            }

        }
        private static void _sort_2(Func<T, T, int> fn,T[] target, T[] source, int index_left, int index_right) {
            if (fn(source[index_left], source[index_right]) == 1) {
                target[index_left] = source[index_left];
                target[index_right] = source[index_right];
            } else {
                target[index_left] = source[index_right];
                target[index_right] = source[index_left];
            }
        }
    }
}