using System;
using System.IO;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSpec;

using Functional.Contracts;
using Functional.Implementation;
using Functional.Graph;

namespace Tests {
    public interface ITestSuite {
        void Initialize();
        IEnumerable<test_case> Tests { get; }
        IEnumerable<string> Attributes { get; }
        IEnumerable<string> Constraints { get; }
    }
    public enum TestCoverage {
        bool_And,
        Chain,
        Curry1,
        Cury2,
        F,
        F_add,
        F_and,
        F_Chars,
        F_compare,
        F_equ, //equ_int
        F_equ_char,
        F_equ_int,
        F_eqv,
        F_even,
        F_gt,
        F_lt,
        F_lte,
        F_max,
        F_min,
        F_odd,
        F_or,
        F_random,
        F_range,
        F_sequ,
        F_toString,
        F_T,
        F_T_all,
        F_T_always,
        F_T_any,
        F_T_Chars,
        F_T_each,
        F_T_filter,
        F_T_find,
        F_T_first,
        F_T_flatten,
        F_T_identity,
        F_T_items,
        F_T_iterate_while,
        F_T_map,
        F_T_reduce,
        F_T_rest,
        F_T_same,
        F_T_sort,
        F_T_sort_order_by,
        F_T_sort_bubble,
        F_T_transform,
        Utility,
        Utility_char_to_digit,

    }
    public interface ITestCase {
        int ID { get; }
        string Name { get; }
        string Description { get; }
        Func<bool> Run { get; }
        IEnumerable<TestCoverage> Coverage { get; }
    }
    public class test_case {
        public int ID { get; set; }
        public string Name { get; set; }
        public Func<bool> Run { get; set; }
    };
    public class CountFunctionCalls<T> {
        public int Count { get; set; }
        public void action(T t) { this.Count++; }
        public T func(T t) { this.Count++; return t; }
    }
    public class NSpecTest : nspec {
        void given_a_string_Chars_function_should_return_a_sequence_of_characters() {
            it["Chars('one') should return the sequence <o,n,e>"] =
                () => {
                    FunctionalTests.Test_Functional_String().is_true();
                };
        }
        void given_a_range_boundary_should_execute_the_correct_sequence() {
            it["range(0,3) should result in the sequence <0,1,2>"] =
                () => {
                    FunctionalTests.Test_Functional_Int_Range_Start_Finish().is_true();
                };
        }
        void given_a_range_termination_should_return_a_sequence_starting_at_zero() {
            it["range(3) should result in the sequence <0,1,2>"] =
                () => {
                    FunctionalTests.Test_Functional_Int_Range_Finish().is_true();
                };
        }
        void given_a_range_with_start_greater_than_end_should_return_a_sequence_in_reverse_order() {
            it["range(7,0) should result in the sequence <7,6,5,4,3,2,1>"] = 
                () => {
                    FunctionalTests.Test_Functional_Int_Range_InverseOrder().is_true();
                };
        }
        void given_a_range_with_a_step_should_return_a_sequence_in_order_with_step() {
            it["range(0,17,3) should result in the sequence <0, 3, 6, 9, 13, 16>"] =
                () => {
                    FunctionalTests.Test_Functional_Int_Range_Step().is_true();
                };
        }
        void given_a_range_with_start_greater_than_end_and_a_negative_step_return_a_sequence_in_diminishing_order() {
            it["range(17,0,-3) should result in the sequence <17, 14, 11, 8, 5, 2>"] =
                () => {
                    FunctionalTests.Test_Functional_Int_Range_Inverse_Step().is_true();
                };
        }
        void given_a_range_with_an_incorrect_step_negative_direction_it_steps_in_the_correct_direction_anyway() {
            it["range(5,9,-1) should result in the sequence <5, 6, 7, 8>"] =
                () => {
                    FunctionalTests.Test_Functional_Int_Range_Step_IncorrectStepDirection_Negative().is_true();
                };
        }
        void given_a_range_with_an_incorrect_step_positive_direction_it_steps_in_the_correct_direction_anyway() {
            it["range(19,5,3) should result in the sequence <19, 15, 12, 9, 6>"] = 
                () => {
                    FunctionalTests.Test_Functional_Int_Range_Step_IncorrectStepDirection_Positive().is_true();
                };
        }
        void given_a_sequence_of_dictionaries_and_a_key_should_return_a_sequnce_of_values_for_that_key() {
            it["a sequence of three dictionaries in which two have the value returns a sequence with both values"] =
                () => {
                    FunctionalTests.Test_Functional_items().is_true();
                };
        }
        void given_a_sequence_of_one_type_and_a_function_that_takes_another_type_and_a_type_transform_function_applies_transform_to_the_type_function() {
            it["a sequence of ints and a function that takes string, applies a given string transform function to each int"] =
                () => {
                    FunctionalTests.Test_Functional_transform().is_true();
                };
        }
        void given_a_pair_of_identical_sequences_and_a_function_that_compares_elements_same_should_return_true() {
            it["identical sequences of ints and the equal function returns true"] =
                () => {
                    FunctionalTests.Test_Functional_same_Positive().is_true();
                };
        }
        void given_a_pair_of_sequenes_that_only_differ_in_length_same_should_return_false() {
            it["two sequences of different lengths are different"] =
                () => {
                    FunctionalTests.Test_Functional_same_NegativeLength().is_true();
                };
        }
        void given_a_pair_of_sequences_the_same_length_but_with_different_elements_same_should_return_false() {
            it["two sequences with different elements are different"] =
                () => {
                    FunctionalTests.Test_Functional_same_Negative().is_true();
                };
        }
        void given_a_sequence_with_at_least_one_element_that_meets_a_condition_ANY_should_return_true() {
            it["the sequence <3,7,19> with an any function n == 3 results in true"] =
                () => {
                    FunctionalTests.Test_Functional_any_Positive().is_true();
                };
        }
        void given_a_sequence_with_no_element_that_meets_a_condition_ANY_should_return_false() {
            it["the sequence <3,7,19> with any function n == 4 results in false"] =
                () => {
                    FunctionalTests.Test_Functional_any_Negative().is_true();
                };
        }
        void given_a_sequene_where_every_element_meets_a_condition_ALL_should_return_true() {
            it["every element in the sequence <5,...,18> meets the condition (x > 0) results in true"] =
                () => {
                    FunctionalTests.Test_Functional_all_Positive().is_true();
                };
        }
        void given_a_sequence_where_not_every_element_meets_a_condition_ALL_should_return_false() {
            it["not every element in the sequene <2,...,9> meets the condition (x != 6) results in false"] =
                () => {
                    FunctionalTests.Test_Functional_all_Negative().is_true();
                };
        }
        void given_a_sequence_and_a_prediate_a_sequence_is_returned_that_containes_the_items_from_the_sequence_that_satisfies_the_predicate_condition() {
            it["the sequene <2,...,7> and filter of ((x % 2) == 0) results in the sequence <2, 4, 6>"] =
                () => {
                    FunctionalTests.Test_Functional_filter().is_true();
                };
        }
        void given_a_sequence_first_returns_the_first_element_of_the_squence() {
            it["first sequence<7,...,33> results in '7'"] =
                () => {
                    FunctionalTests.Test_Functional_first().is_true();
                };
        }
        void given_a_sequence_rest_returns_the_sequene_after_the_first_element() {
            it["the rest of the sequence <1,...,7> is sequence <2,...,7>"] =
                () => {
                    FunctionalTests.Test_Functional_rest().is_true();
                };
        }
        void given_a_sequence_and_a_prediate_find_returns_the_first_element_that_meets_the_ondition_of_the_predicate() {
            it["find (x==7) in the sequence <3,...,9> results in '7'"] =
                () => {
                    FunctionalTests.Test_Functional_find().is_true();
                };
        }
        void given_a_sequence_and_a_compare_function_returns_a_sorted_sequene_using_array_sort() {
            it["sort a sequence of random integers using array sort"] =
                () => {
                    FunctionalTests.Test_Functional_sort().is_true();
                };
        }
        void given_a_sequence_and_a_compare_function_returns_a_sorted_sequene_using_linq_order_by() {
            it["sort a sequence of random integers using linq order by"] =
                () => {
                    FunctionalTests.Test_Functional_sort2().is_true();
                };
        }
        void given_a_sequence_of_chars_and_an_action_each_calls_action_with_each_item_in_the_sequence() {
            it["verify an action is called with each item in sequence <h,e,l,l,o>"] =
                () => {
                    FunctionalTests.Test_Functional_each().is_true();
                };
        }
        void given_a_sequence_of_integers_and_an_action_each_calls_action_with_each_item_in_the_sequence() {
            it["verify an action is called with each item in the sequence <0, 1, 2, 3, 4>"] =
                () => {
                    FunctionalTests.Test_Functional_each_repeatedly().is_true();
                };
        }
        void given_a_sequence_of_items_and_a_transforming_map_function_map_returns_a_sequence_of_transofmred_items() {
            it["verify that map a sequence of int to another works"] = 
                () => {
                    FunctionalTests.Test_Functional_map_repeatedly().is_true();
                };
        }
        void given_a_function_and_a_prediate_function_returns_a_sequence_of_the_function_until_the_predicate_condition_is_false() {
            it["verify that starting with 0 and iterating while the calculated value is less than 4 results in the sequence <0',1,2,3>"] =
                () => {
                    FunctionalTests.Test_Functional_iterateWhile().is_true();
                };
        }
        void given_a_value_verify_that_always_creates_a_function_that_returns_that_value() {
            it["verify that always(3) results in a function that returns a 3"] =
                () => {
                    FunctionalTests.Test_Functional_always().is_true();
                };
        }
        void given_a_sequence_of_a_type_and_a_type_transforming_function_results_in_a_sequence_of_the_target_type() {
            it["verify that sequence of ints and a int to string mapping function results in a sequence of strings"] =
                () => {
                    FunctionalTests.Test_Functional_Map_One().is_true();
                };
        }
        void given_a_pair_of_sequences_and_a_type_transforming_function_results_in_a_sequence_of_the_target_type() {
            it["verify that a pair of sequences of integers are summed, the result is a sequence of ints where each value is the sum"] =
                () => {
                    FunctionalTests.Test_Functional_Map_Two().is_true();
                };
        }
        void given_a_set_of_three_sequences_and_a_type_transforming_function_results_in_a_sequence_of_the_target_type() {
            it["verify that 3 sequences of chars can be correctly transformed to a sequence of functions that return a bool"] =
                () => {
                    FunctionalTests.Test_Functional_Map_Three().is_true();
                };
        }
        void given_a_sequence_and_an_accumulation_function_and_an_initial_value_reduce_results_the_correct_value() {
            it["verify that summing the sequence <3,24,17> with an initial value of '6' results in 6+3+24+17"] =
                () => {
                    FunctionalTests.Test_Functional_reduce_Init().is_true();
                };
        }
        void given_a_sequence_and_an_accumulation_function_reduce_results_in_the_corret_value() {
            it["verify that summing the sequence <61,18,-2> results in 61+18-2"] =
                () => {
                    FunctionalTests.Test_Functional_reduce_NoInit().is_true();
                };
        }
        void given_a_sequence_reduce_results_in_a_selected_value() {
            it["from a sequence of ints, verfiy that the minimum and maximum values are returned"] =
                () => {
                    FunctionalTests.Test_Functional_Reduce_One().is_true();
                };
            it["from a sequence of ints, calculate the sum of the items"] =
                () => {
                    FunctionalTests.Test_Functional_Reduce_Two().is_true();
                };
            it["from a sequence of ints, determine that both odd and even values are contained"] =
                () => {
                    FunctionalTests.Test_Functional_Reduce_Three().is_true();
                };
        }
        void given_a_one_parameter_function_curry1_results_in_a_no_configuration_function_factory() {
            it["make a square function factory, and ask for the function that returns the square of the input value"] =
                () => {
                    FunctionalTests.Test_Curry_One().is_true();
                };
        }
        void given_a_two_parameter_function_curry2_results_in_a_configurable_function_factory() {
            it["make a sum function factory, and ask for a function that returns the sum of 10 and an input value"] =
                () => {
                    FunctionalTests.Test_Curry_Two().is_true();
                };
        }
        void given_a_string_and_a_character_return_a_string_that_is_the_original_with_interspersed_characters() {
            it["verify that using reduce to create interspersed objects is possible"] =
                () => {
                    FunctionalTests.Test_Intersperse().is_true();
                };
        }
        void given_a_sequence_of_sequnces_of_ints_returns_a_sequence_of_ints() {
            it["verify that the flatten function works on homogenous type int"] =
                () => {
                    FunctionalTests.Test_flatten_one().is_true();
                };
        }
        void given_a_sequence_of_sequences_of_chars_returns_a_sequence_of_ints() {
            it["verify that the flatten function works on heterogenous types string and int"] =
                () => {
                    FunctionalTests.Test_flatten_two().is_true();
                };
        }
    }
    public class FunctionalTests : ITestSuite {
        public IEnumerable<test_case> Tests { get { return this.test_cases; } }
        public IEnumerable<string> Attributes { get { return this.attributes; } }
        public IEnumerable<string> Constraints { get { return this.constraints; } }
        private IList<test_case> test_cases = new List<test_case>();
        private IList<string> attributes = new List<string>();
        private IList<string> constraints = new List<string>();
        private void initialize() { this.attributes.Add("functional"); }
        public FunctionalTests() { this.initialize(); }
        public void Initialize()
        {
            this.test_cases.Add(new test_case() { ID =  0, Name = "Chars('one') should return <o,n,e>", Run = Test_Functional_String });
            this.test_cases.Add(new test_case() { ID =  1, Name = "range(0,3) should result in the sequence <0, 1, 2>", Run = Test_Functional_Int_Range_Start_Finish });
            this.test_cases.Add(new test_case() { ID =  2, Name = "range(3) should result in the sequence <0, 1, 2>", Run = Test_Functional_Int_Range_Finish });
            this.test_cases.Add(new test_case() { ID =  3, Name = "range(7,0)     should result in sequence <7, 6, 5, 4, 3, 2, 1>", Run = Test_Functional_Int_Range_InverseOrder });
            this.test_cases.Add(new test_case() { ID = 4, Name = "range(0,17,3)  should result in sequence <0, 3, 6, 9, 13, 16>", Run = Test_Functional_Int_Range_Step });
            this.test_cases.Add(new test_case() { ID =  5, Name = "range(17,0,-3) should result in sequence <17, 14, 11, 8, 5, 2>", Run = Test_Functional_Int_Range_Inverse_Step });
            this.test_cases.Add(new test_case() { ID =  6, Name = "range(5,9,-1)  should result in the sequence <5, 6, 7, 8>", Run = Test_Functional_Int_Range_Step_IncorrectStepDirection_Negative });
            this.test_cases.Add(new test_case() { ID =  7, Name = "range(19,5,3)  should result in the sequence <19, 15, 12, 9, 6>", Run = Test_Functional_Int_Range_Step_IncorrectStepDirection_Positive });
            this.test_cases.Add(new test_case() { ID =  8, Name = "a sequence of three dictionaries in which two have the value returns a sequence with both values", Run = Test_Functional_items });
            this.test_cases.Add(new test_case() { ID =  9, Name = "a sequence of ints and a function that takes string, applies a given string transform function to each int", Run = Test_Functional_transform });
            this.test_cases.Add(new test_case() { ID = 10, Name = "identical sequences of ints and the equal function returns true", Run = Test_Functional_same_Positive });
            this.test_cases.Add(new test_case() { ID = 11, Name = "two sequences of different lengths are different", Run = Test_Functional_same_NegativeLength });
            this.test_cases.Add(new test_case() { ID = 12, Name = "two sequences with different elements are different", Run = Test_Functional_same_Negative });
            this.test_cases.Add(new test_case() { ID = 13, Name = "the sequence <3,7,19> with an any function n == 3 results in true", Run = Test_Functional_any_Positive });
            this.test_cases.Add(new test_case() { ID = 14, Name = "the sequence <3,7,19> with an any function n == 4 results in false", Run = Test_Functional_any_Negative });
            this.test_cases.Add(new test_case() { ID = 15, Name = "every element in the sequence <5,...,18> meets the condition (x > 0) results in true", Run = Test_Functional_all_Positive });
            this.test_cases.Add(new test_case() { ID = 16, Name = "not every element in the sequence <2,...,9> meets the condition (x != 6) results in false", Run = Test_Functional_all_Negative });
            this.test_cases.Add(new test_case() { ID = 17, Name = "the sequence <2,...,7> and filter of ((x % 2) == 0) results in the sequence <2, 4, 6>", Run = Test_Functional_filter });
            this.test_cases.Add(new test_case() { ID = 18, Name = "first of the sequence <7,...,33> results in '7'", Run = Test_Functional_first });
            this.test_cases.Add(new test_case() { ID = 19, Name = "the rest of the sequence <1,...7> is the sequence <2,...,7>", Run = Test_Functional_rest });
            this.test_cases.Add(new test_case() { ID = 20, Name = "find (x==7) in the sequence <3,...,9> results in '7'", Run = Test_Functional_find });
            this.test_cases.Add(new test_case() { ID = 21, Name = "sort a sequence of random integers using array sort", Run = Test_Functional_sort });
            this.test_cases.Add(new test_case() { ID = 22, Name = "sort a sequence of random integers using linq order by", Run = Test_Functional_sort2 });

            this.test_cases.Add(new test_case() { ID = 24, Name = "verify an action is called with each item in the sequence <h, e, l, l, o>", Run = Test_Functional_each });
            this.test_cases.Add(new test_case() { ID = 25, Name = "verify an action is called with each item in the sequence <0, 1, 2, 3, 4>", Run = Test_Functional_each_repeatedly });
            this.test_cases.Add(new test_case() { ID = 26, Name = "verify that map a sequence of int to another works", Run = Test_Functional_map_repeatedly });
            this.test_cases.Add(new test_case() { ID = 27, Name = "verify that starting with 0 and iterating while the calculated value is less than 4 results in the sequence '0' '1' '2' '3'", Run = Test_Functional_iterateWhile });
            this.test_cases.Add(new test_case() { ID = 28, Name = "verify that always(3) results in a function that returns a 3", Run = Test_Functional_always });
            this.test_cases.Add(new test_case() { ID = 29, Name = "verify that sequence of ints and a int to string mapping function results in a sequene of strings", Run = Test_Functional_Map_One });
            this.test_cases.Add(new test_case() { ID = 30, Name = "verify that a pair of sequences of integers are summed, the result is a sequence of ints where each value is the sum", Run = Test_Functional_Map_Two });
            this.test_cases.Add(new test_case() { ID = 31, Name = "verify that 3 sequences of chars can be correctly transformed to a sequence of functions that return a bool", Run = Test_Functional_Map_Three });
            this.test_cases.Add(new test_case() { ID = 32, Name = "verify that summing the sequence <3,24,17> with an initial value of '6' results in 6+3+24+17", Run = Test_Functional_reduce_Init });
            this.test_cases.Add(new test_case() { ID = 33, Name = "verify that summing the sequence <61,18,-2> results in 61+18-2", Run = Test_Functional_reduce_NoInit });
            this.test_cases.Add(new test_case() { ID = 34, Name = "from a sequence of ints, verfiy that the minimum and maximum values are returned", Run = Test_Functional_Reduce_One });
            this.test_cases.Add(new test_case() { ID = 35, Name = "from a sequence of ints, calculate the sum of the items", Run = Test_Functional_Reduce_Two });
            this.test_cases.Add(new test_case() { ID = 36, Name = "from a sequence of ints, determine that both odd and even values are contained", Run = Test_Functional_Reduce_Three });
            this.test_cases.Add(new test_case() { ID = 37, Name = "make a square function factory, and ask for the function that returns the square of the input value", Run = Test_Curry_One });
            this.test_cases.Add(new test_case() { ID = 38, Name = "make a sum function factory, and ask for a function that returns the sum of 10 and an input value", Run = Test_Curry_Two });
            this.test_cases.Add(new test_case() { ID = 39, Name = "verify that using reduce to create interspersed objects is possible", Run = Test_Intersperse });
            this.test_cases.Add(new test_case() { ID = 40, Name = "verify that the flatten function works on homogenous type int", Run = Test_flatten_one });
            this.test_cases.Add(new test_case() { ID = 41, Name = "verify that the flatten function works on heterogenous types string and int", Run = Test_flatten_two });


            this.test_cases.Add(new test_case() { ID = 42, Name = "verify that the BinarySearch function works with the default type compare functions", Run = Test_BinarySearch });
            this.test_cases.Add(new test_case() { ID = 43, Name = "verify that the BinarySearch works with a list of string using the default compare function", Run = Test_BinarySearchString });
            this.test_cases.Add(new test_case() { ID = 50, Name = "verify that inserting nodes in to a binary tree results in a correct tree", Run = Test_BinaryTreeInsert });
            this.test_cases.Add(new test_case() { ID = 52, Name = "verify that chain functions work", Run = Test_chain });
        }
        public static Func<bool> Test_Functional_String = () => F<char>.same(new List<char>() { 'o', 'n', 'e' }, F.Chars("one"), (c1, c2) => F.equ_char(c1,c2));
        public static Func<bool> Test_Functional_Int_Range_Start_Finish = () => F<int>.same(new List<int>() { 0, 1, 2 }, F.range(0, 3), (x, y) => F.equ_int(x,y));
        public static Func<bool> Test_Functional_Int_Range_Finish = () => F<int>.same(new List<int>() { 0, 1, 2 }, F.range(3), (x,y) => F.equ_int(x,y));

        public static bool Test_Functional_Int_Range_InverseOrder() {
            bool success = true;
            int i = 7;
            foreach (int a in F.range(7, 0)) {
                success = success.And(F.equ_int(i,a));
                i--;
            }
            return success;
        }
            public static Func<bool> Test_Functional_Int_Range_Step = () => {
                IEnumerable<int> seq1 = F.range(0, 17, 3);
                IEnumerable<int> seq2 = new List<int>() { 0, 3, 6, 9, 13, 16 };
                return F<int>.same(seq1, seq2, (x, y) => x == y);
            };
        public static Func<bool> Test_Functional_Int_Range_Inverse_Step = () => F<int>.same(new List<int>() { 17, 14, 11, 8, 5, 2 }, F.range(17,0,-3), (x,y) => x==y);
        
        public static bool Test_Functional_Int_Range_Step_IncorrectStepDirection_Negative() {
            bool success = true;
            int i = 5;
            foreach (int a in F.range(5, 9, -1)) {
                success = success.And(F.equ_int(i,a));
                i++;
            }
            return success;
        }
        public static bool Test_Functional_Int_Range_Step_IncorrectStepDirection_Positive() {
            bool success = true;
            int i = 19;
            foreach (int a in F.range(19, 5, 3)) {
                success = success.And(F.equ_int(i,a));
                i-=3;
            }
            return success;
        }
        public static bool Test_Functional_items() {
            bool success = true;
            IDictionary<string, int> d1 = new Dictionary<string, int>();
            IDictionary<string, int> d2 = new Dictionary<string, int>();
            IDictionary<string, int> d3 = new Dictionary<string, int>();
            IList<IDictionary<string, int>> lst = new List<IDictionary<string, int>>();
            d1.Add("xyz", 7); d1.Add("abc", 32);
            d2.Add("xyz", 21); d2.Add("def", 188);
            d3.Add("tuv", 3);
            lst.Add(d1);
            lst.Add(d2);
            lst.Add(d3);
            IList<int> result = F<int>.items(lst, "xyz").ToList();
            success = success.And(result.Contains(7) && result.Contains(21) && (F.equ_int(result.Count,2)));
            return success;
        }
        public static bool Test_Functional_transform() {
            bool success = true;
            int count = 0;
            Action<string> doNothing = (n) => { count++; };
            F<int>.each(F.range(0, 30), F<int>.transform<string>(doNothing, F<int>.toString));
            success = F.equ_int(30,count);
            return success;
        }
        public static Func<bool> Test_Functional_same_Positive = () => F<int>.same(F.range(4, 8), F.range(4, 8), F.equ);
        public static Func<bool> Test_Functional_same_NegativeLength = () => !F<int>.same(F.range(4, 7), F.range(4, 8), F.equ);
        public static Func<bool> Test_Functional_same_Negative = () => !F<int>.same(F.range(3, 7), F.range(4, 8), F.equ);

        public static bool Test_Functional_any_Positive() {
            bool success = true;
            IList<int> lst = new List<int>();
            lst.Add(3);
            lst.Add(7);
            lst.Add(19);
            success = success.And(F<int>.any(lst, x => F.equ_int(x,3)));
            return success;
        }
        public static bool Test_Functional_any_Negative() {
            bool success = true;
            IList<int> lst = new List<int>();
            lst.Add(3);
            lst.Add(7);
            lst.Add(19);
            success = success.And(!F<int>.any(lst, x => F.equ_int(x,4)));
            return success;
        }
        public static Func<bool> Test_Functional_all_Positive = () => F<int>.all(F.range(5, 18), x => F.gt(x,0));
        public static Func<bool> Test_Functional_all_Negative = () => !F<int>.all(F.range(2, 9), x => (x != 6));
        public static bool Test_Functional_filter() {
            bool success = true;
            IList<int> result = F<int>.filter(F.range(2, 7), x => ((x % 2) == 0)).ToList<int>(); //even
            success = success.And((result.Contains(2)) && (result.Contains(4)) && (result.Contains(6)) && (F.equ_int(result.Count,3)));
            return success;
        }

        public static Func<bool> Test_Functional_first = () => (7 == F<int>.first(F.range(7,33)));
        public static Func<bool> Test_Functional_rest = () => F<int>.same(F.range(2, 7), F<int>.rest(F.range(1, 7)), F.equ);
        public static Func<bool> Test_Functional_find = () => (7 == F<int>.find(F.range(3, 9), (x) => F.equ(x,7)));
        public static bool Test_Functional_sort() {
            bool success = true;
            IEnumerable<int> result = F<int>.sort(F.random(7, 0, 10), F.compare);
            success = success.And(F<int>.reduce(F<int>.rest(result), (b, x, y) => F.and(b,(x <= y)), F<int>.first(result),true));
            return success;
        }
        public static bool Test_Functional_sort2() {
            bool success = true;
            IEnumerable<int> result = F<int>.sort_order_by(F.random(14, 0, 10), (x, y) => (x == y) ? 0 : (x < y) ? -1 : 1);
            success = success.And(F<int>.reduce(F<int>.rest(result), (b, x, y) => F.and(b,(x <= y)), F<int>.first(result), true));
            return success;
        }
        public static bool Test_Functional_each() {
            bool success = true;
            CountFunctionCalls<char> calls = new CountFunctionCalls<char>();
            calls.Count = 0;
            F<char>.each(F.Chars("hello"), c => calls.action(c));
            success = success.And(calls.Count == ("hello".Length));
            return success;
        }
        public static bool Test_Functional_each_repeatedly() {
            bool success = true;
            CountFunctionCalls<int> calls = new CountFunctionCalls<int>();
            calls.Count = 0;
            F<int>.each(F.range(0, 5), x => calls.action(x));
            success = success.And(calls.Count == 5);
            return success;
        }
        public static Func<bool> Test_Functional_map_repeatedly = () => F<int>.same(F<int>.map<int>(F.range(0, 7), x => F.add(x,5)), F.range(F.add(0,5),F.add(7,5)),F.equ);
        public static bool Test_Functional_iterateWhile() {
            bool success = true;
            Func<int, int, bool> equals = F.equ;
            int f = 0;
            IEnumerable<int> result = F<int>.iterate_while(x => x + 1, x =>  (x < 4), 0);
            foreach (int i in result) f = i;
            success = success.And(equals(f, 3));
            return success;
        }
        public static Func<bool> Test_Functional_always = () => F.equ(3, F<int>.always(3).Invoke());
        public static Func<bool> Test_Functional_Map_One = () => F<string>.same(F<int>.map<string>(F.range(0, 4), x => x.ToString()), new List<string>() { "0", "1", "2", "3" }, F.equ_string);
        public static bool Test_Functional_Map_Two() {
            bool success = true;
            IEnumerable<int> result = F<int>.map<int>(F.range(0, 4), F.range(0, 4), (x, y) => x + y);
            success = success.And(F<int>.same(result, F.range(0, 8, 2), F.equ));
            return success;
        }
        public static bool Test_Functional_Map_Three() {
            bool success = true;
            // t f f t
            IEnumerable<Func<bool>> test = new List<Func<bool>>() { 
                F<bool>.always(true), 
                F<bool>.always(false), 
                F<bool>.always(false), 
                F<bool>.always(true) 
            };
            IEnumerable<char> first  = F.Chars("xoxo");
            IEnumerable<char> second = F.Chars("xxoo");
            IEnumerable<char> third  = F.Chars("xooo");
            IEnumerable<Func<bool>> result = F<char>.map<Func<bool>>(first, second, third, 
                (x, y, z) => F<bool>.always(F.and(F.equ_char(x,y),F.equ_char(y,z))));
            success = success.And(F<Func<bool>>.same(result, test, (x,y) => F.eqv(x(),y())));
            return success;
        }
        public static Func<bool> Test_Functional_reduce_Init = () => F.equ(F<int>.reduce(new List<int> { 3, 24, 17 }, F.add, 6), (6 + 3 + 24 + 17));
        public static Func<bool> Test_Functional_reduce_NoInit = () => F.equ(F<int>.reduce(new List<int>() { 61, 18, -2 }, F.add), (61 + 18 - 2));

        public static Func<bool> Test_Functional_Reduce_One = () => F.and(F.equ(1, F<int>.reduce(new List<int>() { 1, 6, 3 }, F.min)), F.equ(6, F<int>.reduce(new List<int>() { 1, 6, 3 }, F.max)));
        public static Func<bool> Test_Functional_Reduce_Two = () => F.equ(F<int>.reduce(new List<int>() { 1, 6, 3, 2, 4, 3, 3, 5 }, F.add, 0), 1 + 6 + 3 + 2 + 4 + 3 + 3 + 5);
        public static bool Test_Functional_Reduce_Three() {
            bool success = true;
            bool containsEven = false;
            bool containsOdd = false;
            IEnumerable<int> test = new List<int>() { 1, 6, 3, 2, 4, 3, 3, 5 };
            containsEven = F<int>.reduce<bool>(test, (b, x) => F.or(b,F.even(x)), false);
            containsOdd  = F<int>.reduce<bool>(test, (b, x) => F.or(b,F.odd(x)), false);
            success = F.and(containsEven,containsOdd);
            return success;
        }






        public static bool Test_Curry_One() {
            bool success = true;
            Curry1<int, int> sqr = new Curry1<int, int>((x) => { return x * x; });
            Func<int, int> noConfig = sqr.Create();
            int r = noConfig(5);
            success = success.And(F.equ(25,r));
            return success;
        }
        public static bool Test_Curry_Two() {
            bool success = true;
            Curry2<int, int> add = new Curry2<int, int>(F.add);
            Func<int, int> add10 = add.Create(10);
            int r = add10(6); // 16
            success = success.And(16 == r);
            return success;
        }
        public static bool Test_Intersperse() {
            bool success = true;
            Func<char, string, string> intersperse = (c, s) => {
                IEnumerable<char> seq = F.Chars(s);
                string result = F<char>.reduce<string>(F<char>.rest(seq), (st, ch) => st + c + ch, F<char>.toString(F<char>.first(seq)));
                return result;
            };
            Func<string, string> swedish = (s) => {
                return intersperse('f', s);
            };
            string swedisHello = swedish("Hello");
            success = F<char>.same(F.Chars(swedisHello), F.Chars("Hfeflflfo"), F.equ_char);
            return success;
        }
        public static bool Test_flatten_one() {
            IEnumerable<IEnumerable<int>> llist = new List<IEnumerable<int>>() { new List<int>() { 2, 3, 6 }, new List<int>() { 5, 2, 2, 1 } };
            IEnumerable<int> flat = F<IEnumerable<int>>.flatten<int>(llist, x => x);
            IEnumerable<int> check = new List<int>() { 2, 3, 6, 5, 2, 2, 1 };
            return F<int>.same(check, flat, F.equ_int);
        }
        public static bool Test_flatten_two() {
            IEnumerable<string> numbers = new List<string>() { "25783", "1072", "8403" };
            IEnumerable<int> flat = F<string>.flatten<int>(numbers, (s) => F<char>.map<int>(F.Chars(s), Utility.char_to_digit));
            IEnumerable<int> check = new List<int>() { 2, 5, 7, 8, 3, 1, 0, 7, 2, 8, 4, 0, 3 };
            return F<int>.same(check, flat, F.equ_int);
        }

        public static bool Test_chain() {
            bool result = true;
            int current = 0;
            int last = 0;
            IChain<int> chain = Chain<int>.Create(0,(n) => n < 3).Run(current);
            while(null != chain) {
                last = current;
                current++;
                chain = chain.Run(current);
            }
            result = result.And(F.equ_int(last, 2));
            return result;
        }
        
        private bool Test_BinarySearch() {
            bool result = true;
            SomethingImmutable<char>.compare = F.compare_char;
            IList<ISomethingImmutable<char>> list = new List<ISomethingImmutable<char>>() { 
                SomethingImmutable<char>.Create('b'),
                SomethingImmutable<char>.Create('c'),
                SomethingImmutable<char>.Create('d'),
                SomethingImmutable<char>.Create('e'),
                SomethingImmutable<char>.Create('f'),
                SomethingImmutable<char>.Create('g'),

                SomethingImmutable<char>.Create('i'),
                SomethingImmutable<char>.Create('j'),
                SomethingImmutable<char>.Create('k')
            };
            ISomethingImmutable<char> r = null;

            // search for each item in the list
            string search = "cdefgij";
            foreach (char c in F.Chars(search)) {
                ISomethingImmutable<char> current = SomethingImmutable<char>.Create(c);
                r = Graph.BinarySearch<ISomethingImmutable<char>>(list, SomethingImmutable<char>.Compare, current);
                result = result.And(null != r);
                if (null != r) result = result && (current.Item == r.Item);
            }
            // search for the first thing  in the list
            ISomethingImmutable<char> B = SomethingImmutable<char>.Create('b');
            r = Graph.BinarySearch<ISomethingImmutable<char>>(list, SomethingImmutable<char>.Compare, B);
            result = result.And(null != r);
            // search for the last hing in the list
            ISomethingImmutable<char> K = SomethingImmutable<char>.Create('k');
            r = Graph.BinarySearch<ISomethingImmutable<char>>(list, SomethingImmutable<char>.Compare, K);
            result = result.And(null != r);


            // search for something not in the list (lower)
            ISomethingImmutable<char> A = SomethingImmutable<char>.Create('a');
            r = Graph.BinarySearch<ISomethingImmutable<char>>(list, SomethingImmutable<char>.Compare, A);
            result = result.And(null == r);
            // search for something not in the list (middle)
            ISomethingImmutable<char> H = SomethingImmutable<char>.Create('h');
            r = Graph.BinarySearch<ISomethingImmutable<char>>(list, SomethingImmutable<char>.Compare, H);
            result = result.And(null == r);
            // search for something not in the list (higher)
            ISomethingImmutable<char> W = SomethingImmutable<char>.Create('w');
            r = Graph.BinarySearch<ISomethingImmutable<char>>(list, SomethingImmutable<char>.Compare, W);
            result = result.And(null == r);
            
            return result;
        }

        private bool Test_BinarySearchString() {
            bool result = true;
            SomethingImmutable<string>.compare = F.compare_string_case_insensative;
            IList<ISomethingImmutable<string>> list = new List<ISomethingImmutable<string>>() { 
                SomethingImmutable<string>.Create("butter"),
                SomethingImmutable<string>.Create("cheese"),
                SomethingImmutable<string>.Create("coco"),
                SomethingImmutable<string>.Create("creme"),
                SomethingImmutable<string>.Create("eggs"),
                SomethingImmutable<string>.Create("milk"),
                SomethingImmutable<string>.Create("mushrooms"),
                SomethingImmutable<string>.Create("mustard")

            };
            ISomethingImmutable<string> r = null;

            // search for each item in the list
            IList<string> search = new List<string>(){ "cheese","coco","creme","eggs","milk","mushrooms","mustard"};
            foreach (string s in search) {
                ISomethingImmutable<string> current = SomethingImmutable<string>.Create(s);
                r = Graph.BinarySearch<ISomethingImmutable<string>>(list, SomethingImmutable<string>.Compare, current);
                result = result && (null != r);
                if (null != r) result = result && (current.Item == r.Item);
            }
            // search for the first thing  in the list
            ISomethingImmutable<string> Butter = SomethingImmutable<string>.Create("butter");
            r = Graph.BinarySearch<ISomethingImmutable<string>>(list, SomethingImmutable<string>.Compare, Butter);
            result = result.And(null != r);
            // search for the last thing in the list
            ISomethingImmutable<string> Mustard = SomethingImmutable<string>.Create("mustard");
            r = Graph.BinarySearch<ISomethingImmutable<string>>(list, SomethingImmutable<string>.Compare, Mustard);
            result = result.And(null != r);


            // search for something not in the list (lower)
            ISomethingImmutable<string> Apples = SomethingImmutable<string>.Create("apples");
            r = Graph.BinarySearch<ISomethingImmutable<string>>(list, SomethingImmutable<string>.Compare, Apples);
            result = result.And(null == r);
            // search for something not in the list (middle)
            ISomethingImmutable<string> Flour = SomethingImmutable<string>.Create("flour");
            r = Graph.BinarySearch<ISomethingImmutable<string>>(list, SomethingImmutable<string>.Compare, Flour);
            result = result.And(null == r);
            // search for something not in the list (higher)
            ISomethingImmutable<string> Sugar = SomethingImmutable<string>.Create("sugar");
            r = Graph.BinarySearch<ISomethingImmutable<string>>(list, SomethingImmutable<string>.Compare, Sugar);
            result = result.And(null == r);

            return result;
        }
//        private static void Add(IList<INode<ICity>> n,
        private static bool Test_BinaryTreeInsert() {
            bool result = true;
            IBNode<string> arkansas = Tree.CreateBNode<string>("arkansas");
            IBNode<string> california = Tree.CreateBNode<string>("california");
            IBNode<string> colorado = Tree.CreateBNode<string>("colorado");
            IBNode<string> montana = Tree.CreateBNode<string>("montana");
            IBNode<string> nevada = Tree.CreateBNode<string>("nevada");
            IBNode<string> new_mexico = Tree.CreateBNode<string>("new mexico");
            IBNode<string> new_york = Tree.CreateBNode<string>("new york");
            IBNode<string> tennessee = Tree.CreateBNode<string>("tennessee");
            IBNode<string> texas = Tree.CreateBNode<string>("texas");
            IBNode<string> washington = Tree.CreateBNode<string>("washington");
            IBNode<string> wisconsin = Tree.CreateBNode<string>("wisconsin");
            
            
            //             Root:nevada
            //                  L:colorado
            //                    L:california
            //                      L:arkansas
            //                      R:montana
            //                  R:tennessee
            //                    L:new york
            //                      L:new mexico
            //                    R:washington
            //                      L:texas
            //                      R:wisconsin
            
            IBNode<string> current = nevada;
            IBNode<string> root = nevada;

            Tree.InsertBNode<string>(root, colorado, F.compare_string_case_insensative);
            current = root.Left;
            result = result.And(null != current);
            result = result.And((null != current) ? (current.Name == colorado.Name) : false);

            Tree.InsertBNode<string>(root, montana, F.compare_string_case_insensative);
            current = root.Left; // colorado
            if (null != current) current = current.Right; // montana
            result = result.And(null != current);
            result = result.And((null != current) ? (current.Name == montana.Name) : false);

            Tree.InsertBNode<string>(root, california, F.compare_string_case_insensative);
            current = root.Left; // colorado
            if (null != current) current = current.Left; // california
            result = result.And(null != current);
            result = result.And((null != current) ? (current.Name == california.Name) : false);

            Tree.InsertBNode<string>(root, arkansas, F.compare_string_case_insensative);
            current = root.Left; // colorado
            if (null != current) current = current.Left; // california
            if (null != current) current = current.Left; // arkansas
            result = result.And(null != current);
            result = result.And((null != current) ? (current.Name == arkansas.Name) : false);

            //tennessee (spelling)
            Tree.InsertBNode<string>(root, tennessee, F.compare_string_case_insensative);
            current = root.Right; // tennessee
            result = result.And(null != current);
            result = result.And((null != current) ? (current.Name == tennessee.Name) : false);

            //new york
            Tree.InsertBNode<string>(root, new_york, F.compare_string_case_insensative);
            current = root.Right; // tennessee
            if (null != current) current = current.Left; // new york
            result = result.And(null != current);
            result = result.And((null != current) ? (current.Name == new_york.Name) : false);

            //new mexico
            Tree.InsertBNode<string>(root, new_mexico, F.compare_string_case_insensative);
            current = root.Right; // tennessee
            if (null != current) current = current.Left; // new york
            if (null != current) current = current.Left; // new mexico
            result = result.And(null != current);
            result = result.And((null != current) ? (current.Name == new_mexico.Name) : false);
                        
            //washington
            Tree.InsertBNode<string>(root, washington, F.compare_string_case_insensative);
            current = root.Right; // tennessee
            if (null != current) current = current.Right; // washington
            result = result.And(null != current);
            result = result.And((null != current) ? (current.Name == washington.Name) : false);
            
            //texas
            Tree.InsertBNode<string>(root, texas, F.compare_string_case_insensative);
            current = root.Right; // tennessee
            if (null != current) current = current.Right; // washington
            if (null != current) current = current.Left; // texas
            result = result.And(null != current);
            result = result.And((null != current) ? (current.Name == texas.Name) : false);
            
            //wisconsin
            Tree.InsertBNode<string>(root, wisconsin, F.compare_string_case_insensative);
            current = root.Right; // tennessee
            if (null != current) current = current.Right; // washington
            if (null != current) current = current.Right; // wisconsin
            result = result.And(null != current);
            result = result.And((null != current) ? (current.Name == wisconsin.Name) : false);

            return result;
        }
        private static IEnumerable<ICity> ReadCities(string filename) {
            return F<ICity>.LoadTextFile(filename, Encoding.UTF8, StringToICity);
        }
        private static ICity StringToICity(string record) {
            ICity city = null;
            string[] field = record.Split(',');
            if (field.Length >= 5) {
                string name = field[0];
                string country = field[1];
                int priority = int.Parse(field[2]); // todo handle parse error
                float lat = float.Parse(field[3]); // todo handle parse error
                float lon = float.Parse(field[4]); // toso handle parse error
                city = City.Create(name, country, priority, lat, lon);
            }
            return city;
        }
    }
    public class AirTransit {
        public DateTime Departure { get; private set; }
        public TimeSpan TimeInFlight { get; private set; }
        public AirTransit(int year, int month, int day, int hour, int minute, int hours_in_flight, int minutes_in_flight) {
            this.Departure = new DateTime(year, month, day, hour, minute, 0);
            this.TimeInFlight = new TimeSpan(hours_in_flight, minutes_in_flight, 0);
        }
    }
    public interface ICity {
        string Name { get; }
        string Country { get; }
        int Priority { get; }
        float Latitude { get; }
        float Longitude { get; } 
    }
    public class City : ICity {
        public string Name { get; private set; }
        public string Country { get; private set; }
        public int Priority { get; private set; }
        public float Latitude { get; private set; }
        public float Longitude { get; private set; }
        private City(string name, string country, int priority, float latitude, float longitude) {
            this.Name = name;
            this.Country = country;
            this.Priority = priority;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        public static ICity Create(string name, string country, int priority, float latitude, float longitude) {
            return new City(name, country, priority, latitude, longitude);
        }

    }
};
