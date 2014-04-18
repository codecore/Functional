using System;
using System.Collections.Generic;
using System.Linq;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F {
        /// <summary>sets an item in an array</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_collection_array_set_item_T)]
        public static void array_set_item<T>(T item, T[] array, int index) {
            if (index >= array.Length) throw new ArgumentOutOfRangeException();
            array[index] = item;
        }

        /// <summary>gets an item from an array</summary><returns>item</returns>
        [Coverage(TestCoverage.F_collection_array_get_item_T)]
        public static T array_get_item<T>(T[] array, int index) {
            if (index >= array.Length) throw new ArgumentOutOfRangeException();
            return array[index];
        }

        /// <summary>adds an item to a list, only if that item is not null</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_collection_list_add_non_null_item_T)]
        public static void list_add_non_null_item<T>(IList<T> lst, T t) {
            if (null != t) lst.Add(t);
        }

        /// <summary>adds an item to a list, even if it's null</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_collection_list_add_item_T)]
        public static void list_add_item<T>(IList<T> lst, T item) {
            lst.Add(item);
        }

        /// <summary>adds an item to a list, unless it's alread in the list</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_collection_list_add_non_duplicate_item_T)]
        public static void list_add_non_duplicate_item<T>(IList<T> lst, T item, Func<T, T, bool> eq = null) {
            bool contains = false;
            if (null != eq) {
                IEqualityComparer<T> equality_comparer = Functional.Utility.EqualityComparer<T>.Create(eq);
                contains = lst.Contains(item, equality_comparer);
            } else {
                contains = lst.Contains(item);
            }
            if (!contains) lst.Add(item);
        }
        [Coverage(TestCoverage.F_collection_list_add_non_duplicate_item_EQUALITY_T)]
        public static void list_add_non_duplicate_item<T>(IList<T> lst, T item, IEqualityComparer<T> equality_comparer) {
            if (!lst.Contains(item, equality_comparer)) lst.Add(item);
        }
    }
}