using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

using Functional.Language.Contract.Core;
using Functional.Language.Contract;
using Functional.Contracts;
using Functional.Implementation;

using Functional.Test;

namespace Functional.Language.Core.Expressions.Bindings {
    
    public static class Reflection {
        private const BindingFlags public_static_method = BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod;
        private const BindingFlags public_instance_method = BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod;
        private static object O = null;
        
        public static string PathToExecutingAssembly() {
            string full_assembly_path = Assembly.GetExecutingAssembly().Location;
            string path = full_assembly_path.Substring(0, full_assembly_path.LastIndexOf(System.IO.Path.DirectorySeparatorChar)+1);
            return path;
            // gotcha: this is where the manifest is. OK with C# assemblies, not others.
            // remember that multiple assemblies can share a manifest.
        }

        public static MethodInfo[] GetInstanceMethods(Type t) {
            return t.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        }

        public static MethodInfo[] GetStaticMethods(Type t) {
            return t.GetMethods(BindingFlags.Public | BindingFlags.Static);
        }

        /// <summary>Creates a Typed object if a type is known</summary><returns>instance of T</returns>
        [Coverage(TestCoverage.Lang_Reflection_Create_empty)]
        public static T Create<T>() {
            T item = default(T);
            try {
                item = (T)Reflection.Create(typeof(T));
            } catch (Exception) { }
            return item;
        }

        /// <summary>Creates a Typed object if a type is known</summary><returns>instance of T</returns>
        [Coverage(TestCoverage.Lang_Reflection_Create_param)]
        public static T Create<T>(object[] parameters) {
            return (T)Activator.CreateInstance(typeof(T), parameters);
        }

        // Types must have a ref to their loaded assemblies
        /// <summary>Creates a typed object if a type is known, or a generic object</summary><returns>object</returns>
        [Coverage(TestCoverage.Lang_Reflection_Create_type)]
        public static object Create(Type t) {
            if (null == O) O = new object();
            object o = O;
            try {
                o = Activator.CreateInstance(t);
            } catch (Exception){}
            return o;
        }

        [Coverage(TestCoverage.Lang_Reflection_InvokeInstanceVoidMethod_untyped)]
        public static void Invoke(Type t, object instance, string methodName) { // call public void instance.methodName()
            t.InvokeMember(methodName, public_instance_method, null, instance, null);
        }
        [Coverage(TestCoverage.Lang_Reflection_InvokeInstanceVoidMethod_typed)]
        public static void Invoke<T>(T instance, string methodName) {
            typeof(T).InvokeMember(methodName, public_instance_method, null, instance, null);
        }
        [Coverage(TestCoverage.Lang_Reflection_InvokeInstanceNonVoidMethod_untyped)]
        public static object Result(Type type, object instance, string methodName) { // call public object instance.methodName()
            return type.InvokeMember(methodName,public_instance_method,null,instance,null);
        }
        [Coverage(TestCoverage.Lang_Reflection_InvokeInstanceNonVoidMethod_typed)]
        public static U Result<T,U>(T instance, string methodName) {
            return (U)typeof(T).InvokeMember(methodName, public_instance_method, null, instance, null);
        }

        [Coverage(TestCoverage.Lang_Reflection_InvokeStaticVoidMethod_untyped)]
        public static void Invoke(Type t, string methodName) {
            t.InvokeMember(methodName, public_static_method, null, null, null);
        }
        [Coverage(TestCoverage.Lang_Reflection_InvokeStaticVoidMethod_typed)]
        public static void Invoke<T>(string methodName) {
            typeof(T).InvokeMember(methodName, public_static_method, null, null, null);
        }
        [Coverage(TestCoverage.Lang_Reflection_InvokeStaticNonVoidMethod_untyped)]
        public static object Result(Type t,string methodName) {
            return t.InvokeMember(methodName,public_static_method,null,null,null);
        }
        [Coverage(TestCoverage.Lang_Reflection_InvokeStaticNonVoidMethod_typed)]
        public static U Result<T,U>(string methodName) {
            return (U)typeof(T).InvokeMember(methodName, public_static_method, null, null, null);
        }


        /// <summary>A Type is returned from an assembly and a namespace, if found, else typeof(object)</summary><returns>Type</returns>
        [Coverage(TestCoverage.Lang_Reflection_GetType)]
        public static Type GetType(Assembly assembly, string fullnamespacetype) {
            Type t = typeof(object);
            try {
                t = assembly.GetType(fullnamespacetype);
            } catch (Exception) { }
            return t;
        }

        /// <summary>Loads a anssembly (or null) from a path</summary><returns>assembly</returns>
        [Coverage(TestCoverage.Lang_Reflection_LoadAssembly_bare)]
        public static Assembly LoadAssembly(string fullpath) { 
            // requires full path aka c:\projects\proj1\bin\assem.dll, 
            // just assem.dll doesn't cut it
            Assembly result = null;
            if (File.Exists(fullpath)) {
                try {
                    result = Assembly.LoadFile(fullpath);
                } catch (Exception) { }
            }
            return result;
        }
        
    }
    public class TypeManager {
        private IList<Assembly> assemblies = new List<Assembly>();
        private IList<IPair<Type, Assembly>> knownTypes = new List<IPair<Type, Assembly>>();
        public IPair<Type, Assembly> Find(string typename, string assemblyname) {
            Assembly assembly = null;
            IPair<Type, Assembly> result = null;
            try {
                result = F.find<IPair<Type, Assembly>>(this.knownTypes, (p) => p.Left.Name == typename);
            } catch (System.InvalidOperationException e) {
                // not found
                
            }
            if (null == result) {
                try { 
                    // TODO with all the paths, prepend them, and then, load the assembly
                    assembly = Assembly.LoadFile(assemblyname);
                } catch (Exception e) {
                }
            }
            return result;
        }

        public IEnumerable<Assembly> LoadedAssemblies { get { return this.assemblies; } }
        public void Add(Assembly assembly) {
            if (!this.assemblies.Contains(assembly)) this.assemblies.Add(assembly); 
        }
    }
    public class TypeBinder {
        public string Namespace;
        public string TypeName;
        public Type Kind;
        public object Instance;
        public string AssemblyName;
        public Assembly Assembly = null;
    }
}
