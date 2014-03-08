using System;
namespace Functional.Utility {
    public class Singleton<I,T> where T:I, new() {
        private static I instance;
        public static I Instance { 
            get {
                if (null == instance) instance = new T();
                return instance; 
            } 
        }
        private Singleton(){}
    }
}