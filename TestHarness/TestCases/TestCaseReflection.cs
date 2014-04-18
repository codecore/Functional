using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using Functional.Test;
using Functional.Language.Core.Expressions.Bindings;

using Test.Contracts;
using Tests;
namespace Tests {
    [Export(typeof(ISyncTestCase))]
    public class reflection_create : ISyncTestCase {
        private const string _Name = "reflection_create";
        private const string _Description = "prove that you can create an instance of an object through reflection";
        public string TestFile { get { return "TestCaseReflection.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            DateTime dt = (DateTime)Reflection.Create<DateTime>(); // how to verify this
            DateTime dt2 = (DateTime)Reflection.Create<DateTime>(new object[] { 2014, 3, 26 });
            result = result && dt2.Year == 2014;
            result = result && dt2.Month == 3;
            result = result && dt2.Day == 26;
            Assembly assembly = Reflection.LoadAssembly(Reflection.PathToExecutingAssembly()+"TestContracts.dll");
            if (null != assembly) {
                Type t = Reflection.GetType(assembly, "TestNamespace.TestType");
                if (typeof(object) != t) {
                    object o = Reflection.Create(t);
                    result = result && (o.GetType() == t);
                } else result = false;
            } else result = false;
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public reflection_create() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang_Reflection);
            this.feature.Add(TestCoverage.Lang_Reflection_Create_empty);
            this.feature.Add(TestCoverage.Lang_Reflection_Create_param);
            this.feature.Add(TestCoverage.Lang_Reflection_Create_type);

            this.coverage.Add(TestCoverage.Lang_Reflection);
            this.coverage.Add(TestCoverage.Lang_Reflection_Create_empty);
            this.coverage.Add(TestCoverage.Lang_Reflection_Create_param);
            this.coverage.Add(TestCoverage.Lang_Reflection_Create_type);
            this.coverage.Add(TestCoverage.Lang_Reflection_GetType);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly_bare);
            
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class reflection_invoke_instance_void_method : ISyncTestCase {
        private const string _Name = "reflection_invoke_instance_void_method";
        private const string _Description = "verify that you can call a method on an object through reflection";
        public string TestFile { get { return "TestCaseReflection.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Assembly assembly = Reflection.LoadAssembly(Reflection.PathToExecutingAssembly()+"TestContracts.dll");
            if (null != assembly) {
                Type t = Reflection.GetType(assembly, "TestNamespace.TestType");
                if (typeof(object) != t) {
                    object o = Reflection.Create(t);
                    if (o.GetType() == t) {
                        Reflection.Invoke(t, o, "Method"); // how to test that Method() was invoked?
                        if (typeof(TestNamespace.TestType) == t) {
                            Reflection.Invoke<TestNamespace.TestType>((TestNamespace.TestType)(o), "Method");
                            result = (((TestNamespace.TestType)(o)).Count == 2); // that's how
                        } else result = false;
                    } else result = false;
                } else result = false;
            } else result = false;
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public reflection_invoke_instance_void_method() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang_Reflection);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeInstanceMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeInstanceVoidMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeInstanceVoidMethod_untyped);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeInstanceVoidMethod_typed);

            this.coverage.Add(TestCoverage.Lang_Reflection);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeInstanceMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeInstanceVoidMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeInstanceVoidMethod_untyped);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeInstanceVoidMethod_typed);
            this.coverage.Add(TestCoverage.Lang_Reflection_Create_type);
            this.coverage.Add(TestCoverage.Lang_Reflection_GetType);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly_bare);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class reflection_invoke_instance_non_void_method : ISyncTestCase {
        private const string _Name = "reflection_invoke_instance_non_void_method";
        private const string _Description = "verify that you can call a method that returns something on an object through reflection";
        public string TestFile { get { return "TestCaseReflection.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            
            Assembly assembly = Reflection.LoadAssembly(Reflection.PathToExecutingAssembly() + "TestContracts.dll");
            if (null != assembly) {
                Type t = Reflection.GetType(assembly, "TestNamespace.TestType");
                if (typeof(object) != t) {
                    object o = Reflection.Create(t);
                    if (o.GetType() == t) {
                        object item1 = Reflection.Result(t, o, "Something"); // returns a int
                        if (typeof(TestNamespace.TestType) == t) {
                            int item2 = Reflection.Result<TestNamespace.TestType,int>((TestNamespace.TestType)(o), "Something");
                            result = ((int)(item1) == 4);
                            result = result && (item2 == 4);
                        } else result = false;
                    } else result = false;
                } else result = false;
            } else result = false;
             
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public reflection_invoke_instance_non_void_method() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang_Reflection);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeInstanceMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeInstanceNonVoidMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeInstanceNonVoidMethod_untyped);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeInstanceNonVoidMethod_typed);

            this.coverage.Add(TestCoverage.Lang_Reflection);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeInstanceMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeInstanceNonVoidMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeInstanceNonVoidMethod_untyped);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeInstanceNonVoidMethod_typed);
            this.coverage.Add(TestCoverage.Lang_Reflection_Create_type);
            this.coverage.Add(TestCoverage.Lang_Reflection_GetType);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly_bare);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class reflection_invoke_static_non_void_method : ISyncTestCase {
        private const string _Name = "reflection_invoke_static_non_void_method";
        private const string _Description = "verify that you can call a method on an type through reflection and get a result back";
        public string TestFile { get { return "TestCaseReflection.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Assembly assembly = Reflection.LoadAssembly(Reflection.PathToExecutingAssembly() + "TestContracts.dll");
            if (null != assembly) {
                Type t = Reflection.GetType(assembly, "TestNamespace.TestType");
                if (typeof(object) != t) {
                    if (typeof(TestNamespace.TestType) == t) {
                        TestNamespace.TestType.ClearCount();
                        object item1 = Reflection.Result(t, "sSomething"); // TestCoverage.Lang_Reflection_InvokeStaticNonVoidMethod_untyped
                        int item2 = Reflection.Result<TestNamespace.TestType,int>("sSomething"); // TestCoverage.Lang_Reflection_InvokeStaticNonVoidMethod_typed
                        result = ((int)(item1)==7);
                        result = result && (item2 == 7);
                    } else result = false;
                } else result = false;
            } else result = false;
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public reflection_invoke_static_non_void_method() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang_Reflection);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeStaticMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeStaticNonVoidMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeStaticNonVoidMethod_untyped);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeStaticNonVoidMethod_typed);

            this.coverage.Add(TestCoverage.Lang_Reflection);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeStaticMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeStaticNonVoidMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeStaticNonVoidMethod_untyped);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeStaticNonVoidMethod_typed);
            this.coverage.Add(TestCoverage.Lang_Reflection_GetType);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly_bare);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class reflection_invoke_static_void_method : ISyncTestCase {
        private const string _Name = "reflection_invoke_static_void_method";
        private const string _Description = "verify that you can call a method on an type through reflection";
        public string TestFile { get { return "TestCaseReflection.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Assembly assembly = Reflection.LoadAssembly(Reflection.PathToExecutingAssembly()+"TestContracts.dll");
            if (null != assembly) {
                Type t = Reflection.GetType(assembly, "TestNamespace.TestType");
                if (typeof(object) != t) {
                    if (typeof(TestNamespace.TestType) == t) {
                        TestNamespace.TestType.ClearCount();
                        Reflection.Invoke(t,"sMethod"); // TestCoverage.Lang_Reflection_InvokeStaticVoidMethod_untyped
                        Reflection.Invoke<TestNamespace.TestType>("sMethod"); // TestCoverage.Lang_Reflection_InvokeStaticVoidMethod_typed
                        result = (2 == TestNamespace.TestType.GetCount());
                    } else result = false;
                } else result = false;
            } else result = false;
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public reflection_invoke_static_void_method() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang_Reflection);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeStaticMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeStaticVoidMethod);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeStaticVoidMethod_untyped);
            this.feature.Add(TestCoverage.Lang_Reflection_InvokeStaticVoidMethod_typed);

            this.coverage.Add(TestCoverage.Lang_Reflection);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeStaticMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeStaticVoidMethod);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeStaticVoidMethod_untyped);
            this.coverage.Add(TestCoverage.Lang_Reflection_InvokeStaticVoidMethod_typed);
            this.coverage.Add(TestCoverage.Lang_Reflection_GetType);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly_bare);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class reflection_loadassembly : ISyncTestCase {
        private const string _Name = "reflection_loadassembly";
        private const string _Description = "prove that you can load an assembly through reflection";
        public string TestFile { get { return "TestCaseReflection.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Assembly assembly = Reflection.LoadAssembly(Reflection.PathToExecutingAssembly()+"TestContracts.dll");
            result = (null != assembly);
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public reflection_loadassembly() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang_Reflection);
            this.feature.Add(TestCoverage.Lang_Reflection_LoadAssembly);
            this.feature.Add(TestCoverage.Lang_Reflection_LoadAssembly_bare);

            this.coverage.Add(TestCoverage.Lang_Reflection);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly);
            this.coverage.Add(TestCoverage.Lang_Reflection_LoadAssembly_bare);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class reflection_gettype : ISyncTestCase {
        private const string _Name = "reflection_gettype";
        private const string _Description = "prove that you can get a type from an assembly through reflection";
        public string TestFile { get { return "TestCaseReflection.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            Assembly assembly = Reflection.LoadAssembly(Reflection.PathToExecutingAssembly()+"TestContracts.dll");
            if (null != assembly) {
                Type t = Reflection.GetType(assembly, "Test.TestType");
                result = t != typeof(object);
            } else result = false;
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public reflection_gettype() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.Lang_Reflection);
            this.feature.Add(TestCoverage.Lang_Reflection_GetType);

            this.coverage.Add(TestCoverage.Lang_Reflection);
            this.coverage.Add(TestCoverage.Lang_Reflection_GetType);
        }
    }
}
