using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F<T>   {
        private const string INDEX = "index";
        /// <summary>sets an item in an array</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_collection_array_set_item)]
        public static Action<T, T[], int> array_set_item = (item, array, index) => {
            if (index >= array.Length) throw new ArgumentOutOfRangeException(INDEX);
            array[index] = item;
        };
        /// <summary>gets an item from an array</summary><returns>item</returns>
        [Coverage(TestCoverage.F_T_collection_array_get_item)]
        public static Func<T[], int, T> array_get_item = (array, index) => {
            if (index >= array.Length) throw new ArgumentOutOfRangeException(INDEX);
            return array[index];
        };
        /// <summary>adds an item to a list, only if that item is not null</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_collection_list_add_non_null_item)]
        public static void list_add_non_null_item(IList<T> lst, T t) { 
            if (null != t) lst.Add(t); 
        }
        /// <summary>adds an item to a list, even if it's null</summary><returns>nothing</returns>
        [Coverage(TestCoverage.F_T_collection_list_add_item)]
        public static void list_add_item(IList<T> lst, T item) {
            lst.Add(item);
        }
    }
}