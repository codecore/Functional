using System;
namespace Functional.Utility {
    public static class Validate {
        public static void Verify<T, U>(Func<T, U, bool> validate, T t, U u, string format_message) {
            if (!validate(t, u)) throw new Exception(String.Format(format_message, t, u));
        }
        public static void NonNullArgument(object item, string name) { if (null == item) throw new ArgumentNullException(name); }
        public static void PositiveArgument(int n, string name) { if (n < 0) throw new ArgumentOutOfRangeException(name); }
        public static void PositiveArgument(float f,string name) { if (f<0.0f) throw new ArgumentOutOfRangeException(name); }
        public static void PositiveArgument(double d,string name) { if (d<0.0d) throw new ArgumentOutOfRangeException(name); }
        public static void StringArgument(string s, string name) { if (String.IsNullOrEmpty(s)) throw new ArgumentNullException(name); }
    }
}