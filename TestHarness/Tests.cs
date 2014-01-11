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
        Test_All,                 // non-leaf
        Test_Integration,         // non-leaf

        bool_,                    // non-leaf  TestCaseBool
        bool_And,          // covered
        bool_Or,           // covered

        Chain,
        Curry1,
        Curry2,
        F,                        // non-leaf

        F_add,                    // non-leaf TestCaseAdd.cs
        F_add_double,       // covered
        F_add_float,        // covered
        F_add_int,          // covered
        F_add_long,         // covered
        F_add_short,        // covered
        F_add_string,       // covered
           
        F_always,                 // non-leaf  TestCaseAlways
        F_always_false,     // covered
        F_always_function,  // covered
        F_always_true,      // covered

        F_bool,                   // non-leaf  TestCaseBool.cs
        F_bool_and,         // covered
        F_bool_eqv,         // covered
        F_bool_or,          // covered
        F_bool_xor,         // covered
      
        F_chars,            // covered  TestCase.cs

        F_close,                  // non-leaf  TestCaseClose.cs
        F_close_double,     // covered
        F_close_float,      // covered

        F_compare,                // non-leaf  TestCaseCompare.cs
        F_compare_bool,     // covered
        F_compare_char,     // covered
        F_compare_int,      // covered
        F_compare_long,     // covered
        F_compare_short,    // covered
        F_compare_string,   // covered
        F_compare_string_insensative, // covered

        F_equ,                    // non-leaf  TestCaseEqu.cs
        F_equ_bool,         // covered
        F_equ_char,         // covered
        F_equ_int,          // covered
        F_equ_long,         // covered
        F_equ_short,        // covered
        F_equ_string,       // covered

        F_even,
        
        F_gt,                     // non-leaf  TestCaseGt.cs
        F_gt_double,        // covered
        F_gt_float,         // covered
        F_gt_int,           // covered
        F_gt_long,          // covered
        F_gt_short,         // covered

        F_gte,                    // non-leaf  TestCaseGte.cs
        F_gte_int,          // covered
        F_gte_long,         // covered
        F_gte_short,        // covered

        F_inc,                    // non-leaf
        F_inc_int,
        F_inc_long,          //
        F_inc_short,

        F_lt,                     // non-leaf  TestCaseLt.cs
        F_lt_double,        // covered
        F_lt_float,         // covered
        F_lt_int,           // covered
        F_lt_long,          // covered
        F_lt_short,         // covered

        F_lte,                    // non-leaf  TestCaseLte.cs
        F_lte_int,          // covered
        F_lte_long,         // covered
        F_lte_short,        // covered

        F_max,                    // non-leaf  TestCaseMax.cs
        F_max_double,       // covered
        F_max_float,        // covered
        F_max_int,          // covered
        F_max_long,         // covered
        F_max_short,        // covered

        F_min,                    // non-leaf  TestCaseMin.cs
        F_min_double,       // covered
        F_min_float,        // covered
        F_min_int,          // covered
        F_min_long,         // covered
        F_min_short,        // covered

        F_mult,                   // non-leaf  TestCaseMult.cs
        F_mult_double,      // coverage
        F_mult_float,       // coverage
        F_mult_int,         // coverage
        F_mult_long,        // coverage
        F_mult_short,       // coverage

        F_neq,                    // non-leaf  TestCaseNeq.cs
        F_neq_bool,         // covered
        F_neq_char,         // covered
        F_neq_int,          // covered
        F_neq_long,         // covered
        F_neq_short,        // covered
        F_neq_string,       // covered

        F_odd,
        F_random,
        
        F_range,                  // non-leaf  TestCaseRange.cs
        F_range_start_end,      // covered
        F_range_start_end_step, // covered
        F_range_end,            // covered
        
        F_sqr,                    // non-leaf  TestCaseSqr.cs
        F_sqr_double,       // covered
        F_sqr_float,        // covered
        F_sqr_int,          // covered
        F_sqr_long,         // covered
        F_sqr_short,        // covered

        F_sqrt,                   // non-leaf
        F_sqrt_double,
        F_sqrt_float,

        F_sub,                    // non-leaf  TestCaseSub.cs
        F_sub_double,       // covered
        F_sub_float,        // covered
        F_sub_int,          // covered
        F_sub_long,         // covered
        F_sub_short,        // covered

        F_T,                      // non-leaf

        F_T_all,            // covered
        F_T_always,         // covered
        F_T_any,            // covered

        F_T_each,                 // non-leaf  TestCaseEach.cs
        F_T_each_naked,     // covered
        F_T_each_U,
        F_T_each_U_V,
        F_T_each_U_V_W,
        F_T_each_U_V_W_X,
        F_T_each_U_V_Acc,

        F_T_filter,         // covered
        F_T_find,           // covered
        F_T_first,          // covered
        F_T_flatten,        // covered

        F_T_forever,              // non-leaf
        F_T_forever_item,
        F_T_forever_function,

        F_T_identity,
        F_T_items,
        F_T_iterate_while,  // covered
        F_T_limit,

        F_T_map,                  // non-leaf  TestCaseMap
        F_T_map_U,          // covered
        F_T_map_U_V,
        F_T_map_U_V_W,
        F_T_map_U_V_W_X,
        F_T_map_U_2_List,   // covered
        F_T_map_U_3_List,   // covered

        F_T_reduce,               // non-leaf  TestCaseRecude.cs
        F_T_reduce_init,    // covered
        F_T_reduce_naked,   // covered
        F_T_reduce_U_init,  // covered

        F_T_rest,           // covered
        F_T_same,

        F_T_sort,                 // non-leaf  TestCaseSort.cs
        F_T_sort_naked,     // covered
        F_T_sort_order_by,  // covered
        F_T_sort_bubble,

        F_T_toString,
        F_T_transform,

        Utility,                  // non-leaf
        Utility_char_to_digit,

    }
    public interface ITestCase {
        int ID { get; }
        string Name { get; }
        string Description { get; }
        Func<bool> Run { get; }
        IEnumerable<TestCoverage> Feature { get; }
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
            foreach (char c in F.chars(search)) {
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
  }

        
 
    }

};