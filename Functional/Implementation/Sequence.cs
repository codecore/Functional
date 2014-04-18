using System;
using System.Collections.Generic;

using Functional.Test;

namespace Functional.Implementation {
    public static partial class F   {
        // needs coverage
        /// <summary>sequence with no items</summary><returns>a zero-item sequence</returns>
        [Coverage(TestCoverage.F_sequence_0_items_T)]
        public static IEnumerable<T> sequence<T>() { return new List<T>(); }
        /// <summary>sequence with one item</summary><returns>a one-item sequence</returns>
        [Coverage(TestCoverage.F_sequence_1_items_T)]
        public static IEnumerable<T> sequence<T>(T t1) {
            yield return t1;
        }
        /// <summary>sequence with two items</summary><returns>a two-item sequence</returns>
        [Coverage(TestCoverage.F_sequence_2_items_T)]
        public static IEnumerable<T> sequence<T>(T t1, T t2) {
            yield return t1;
            yield return t2;
        }
        /// <summary>sequence with three items</summary><returns>a three-item sequence</returns>
        [Coverage(TestCoverage.F_sequence_3_items_T)]
        public static IEnumerable<T> sequence<T>(T t1, T t2, T t3) {
            yield return t1;
            yield return t2;
            yield return t3;
        }
        /// <summary>sequence with four items</summary><returns>a four-item sequence</returns>
        [Coverage(TestCoverage.F_sequence_4_items_T)]
        public static IEnumerable<T> sequence<T>(T t1, T t2, T t3, T t4) {
            yield return t1;
            yield return t2;
            yield return t3;
            yield return t4;
        }
        /// <summary>sequence with five items</summary><returns>a five-item sequence</returns>
        [Coverage(TestCoverage.F_sequence_5_items_T)]
        public static IEnumerable<T> sequence<T>(T t1, T t2, T t3, T t4, T t5) {
            yield return t1;
            yield return t2;
            yield return t3;
            yield return t4;
            yield return t5;
        }
        /// <summary>sequence with six items</summary><returns>a six-item sequence</returns>
        [Coverage(TestCoverage.F_sequence_6_items_T)]
        public static IEnumerable<T> sequence<T>(T t1, T t2, T t3, T t4, T t5, T t6) {
            yield return t1;
            yield return t2;
            yield return t3;
            yield return t4;
            yield return t5;
            yield return t6;
        }
        /// <summary>sequence that starts with an item</summary><returns>a sequence beginning with the item</returns>
        [Coverage(TestCoverage.F_sequence_item_sequence_T)]
        public static IEnumerable<T> sequence<T>(T t, IEnumerable<T> seq) {
            yield return t;
            foreach (T x in seq) yield return x;
        }
        /// <summary>sequence that ends with an item</summary><returns>a sequence endin with the item</returns>
        [Coverage(TestCoverage.F_sequence_sequence_item_T)]
        public static IEnumerable<T> sequence<T>(IEnumerable<T> seq, T t) {
            foreach (T x in seq) yield return x;
            yield return t;
        }
        /// <summary>enumerates a sequence</summary><returns>sequence</returns>
        [Coverage(TestCoverage.F_sequence_1_sequence_T)]
        public static IEnumerable<T> sequence<T>(IEnumerable<T> seq) { 
            foreach (T x in seq) yield return x; 
        }
        /// <summary>enumerates two sequences</summary><returns>the enumerated sequences</returns>
        [Coverage(TestCoverage.F_sequence_2_sequences_T)]
        public static IEnumerable<T> sequence<T>(IEnumerable<T> seq1, IEnumerable<T> seq2) {
            foreach (T x in seq1) yield return x;
            foreach (T x in seq2) yield return x;
        }
        /// <summary>enumerates three sequences</summary><returns>the enumerated sequences</returns>
        [Coverage(TestCoverage.F_sequence_3_sequences_T)]
        public static IEnumerable<T> sequence<T>(IEnumerable<T> seq1, IEnumerable<T> seq2, IEnumerable<T> seq3) {
            foreach (T x in seq1) yield return x;
            foreach (T x in seq2) yield return x;
            foreach (T x in seq3) yield return x;
        }
        /// <summary>enumerates four sequences</summary><returns>the enumerated sequences</returns>
        [Coverage(TestCoverage.F_sequence_4_sequences_T)]
        public static IEnumerable<T> sequence<T>(IEnumerable<T> seq1, IEnumerable<T> seq2, IEnumerable<T> seq3, IEnumerable<T> seq4) {
            foreach (T x in seq1) yield return x;
            foreach (T x in seq2) yield return x;
            foreach (T x in seq3) yield return x;
            foreach (T x in seq4) yield return x;
        }
        /// <summary>enumerates five sequences</summary><returns>the enumerated sequences</returns>
        [Coverage(TestCoverage.F_sequence_5_sequences_T)]
        public static IEnumerable<T> sequence<T>(IEnumerable<T> seq1, IEnumerable<T> seq2, IEnumerable<T> seq3, IEnumerable<T> seq4, IEnumerable<T> seq5) {
            foreach (T x in seq1) yield return x;
            foreach (T x in seq2) yield return x;
            foreach (T x in seq3) yield return x;
            foreach (T x in seq4) yield return x;
            foreach (T x in seq5) yield return x;
        }
        /// <summary>enumerates six sequences</summary><returns>the enumerated sequences</returns>
        [Coverage(TestCoverage.F_sequence_6_sequences_T)]
        public static IEnumerable<T> sequence<T>(IEnumerable<T> seq1, IEnumerable<T> seq2, IEnumerable<T> seq3, IEnumerable<T> seq4, IEnumerable<T> seq5, IEnumerable<T> seq6) {
            foreach (T x in seq1) yield return x;
            foreach (T x in seq2) yield return x;
            foreach (T x in seq3) yield return x;
            foreach (T x in seq4) yield return x;
            foreach (T x in seq5) yield return x;
            foreach (T x in seq6) yield return x;
        }
        /// <summary>enumerates a sequence of sequences</summary><returns>the enumerated sequence</returns>
        [Coverage(TestCoverage.F_sequence_seq_of_seq_T)]
        public static IEnumerable<T> sequence<T>(IEnumerable<IEnumerable<T>> sseq) {
            foreach (IEnumerable<T> seq in sseq) 
                foreach(T x in seq)
                    yield return x;
        }
        /// <summary>enumerates a sequence of sequences of sequences</summary><returns>the enumerated sequence</returns>
        [Coverage(TestCoverage.F_sequence_seq_of_seq_of_seq_T)]
        public static IEnumerable<T> sequence<T>(IEnumerable<IEnumerable<IEnumerable<T>>> ssseq) {
            foreach (IEnumerable<IEnumerable<T>> sseq in ssseq)
                foreach (IEnumerable<T> seq in sseq) 
                    foreach (T x in seq)
                        yield return x;
        }
    }
}