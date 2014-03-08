using System;
namespace Functional.Test {
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class CoverageAttribute : Attribute {
        public int Coverage { get; private set; }
        public CoverageAttribute(int n) { this.Coverage = n; }
        private CoverageAttribute() { }
    }
}
