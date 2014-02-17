using System;
using System.IO;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Contracts;
using Functional.Implementation;
using Functional.Graph;

using TestContracts;
namespace Tests {
    public interface ITestSuite {
        void Initialize();
        IEnumerable<ISyncTestCase> Tests { get; }
        IEnumerable<string> Attributes { get; }
        IEnumerable<string> Constraints { get; }
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
    public static class Test {
        private static bool Test_BinarySearch() {
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
            result = result && (null != r);
            // search for the last hing in the list
            ISomethingImmutable<char> K = SomethingImmutable<char>.Create('k');
            r = Graph.BinarySearch<ISomethingImmutable<char>>(list, SomethingImmutable<char>.Compare, K);
            result = result && (null != r);


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

        private static bool Test_BinarySearchString() {
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
            IList<string> search = new List<string>() { "cheese", "coco", "creme", "eggs", "milk", "mushrooms", "mustard" };
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