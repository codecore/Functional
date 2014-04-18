using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNamespace {
    public class TestType {
        private static int sCount = 0;
        private int count = 0;
        public int Member;
        public void Method() { this.count++; }
        public int Count { get { return this.count; } }
        public int Something() { return 4; }
        public static void sMethod() { sCount++; }
        public static void ClearCount() { sCount = 0; }
        public static int GetCount() { return sCount; }
        public static int sSomething() { return 7; }
    }
}
