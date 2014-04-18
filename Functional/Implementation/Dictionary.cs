using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        /// <summary>from a sequence of dictionaries, get all the values that share the key</summary><returns>sequence of items</returns>
        [Coverage(TestCoverage.F_dictionary_extract_values_key_string_T)]
        public static IEnumerable<T> dictionary_extract_values<T>(IEnumerable<IDictionary<string, T>> dictionaries, string key) {
            foreach (IDictionary<string, T> dictionary in dictionaries) {
                if (dictionary.Keys.Contains(key)) yield return dictionary[key];
            }
        }
        /// <summary>from a sequence of dictionaries, and a sequence of keys, get all the values that share the keys</summary><returns>sequence of items</returns>
        [Coverage(TestCoverage.F_dictionary_extract_values_key_sequence_T)]
        public static IEnumerable<T> dictionary_extract_values<T>(IEnumerable<IDictionary<string,T>> dictionaries,IEnumerable<string> keys) {
            foreach(IDictionary<string,T> dictionary in dictionaries) {
                foreach(string key in keys) {
                    if (dictionary.Keys.Contains(key)) yield return dictionary[key];
                }
            }
        }
    }
}