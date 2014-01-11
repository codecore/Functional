﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;

using Tests;
namespace Tests {
    [Export(typeof(ITestCase))]
    public class lte_int : ITestCase {
        private const string _Name = "lte int,F_lte_int";
        private const string _Description = "F.lte_int(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (false == F.lte_int(1,0));
            result = result && (true  == F.lte_int(0,0));
            result = result && (true  == F.lte_int(0,1));
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
        public lte_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_lte);
            this.feature.Add(TestCoverage.F_lte_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_lte);
            this.coverage.Add(TestCoverage.F_lte_int);
        }
    }


    [Export(typeof(ITestCase))]
    public class lte_long : ITestCase {
        private const string _Name = "lte long,F_lte_long";
        private const string _Description = "F.lte_long(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (false == F.lte_long(1L,0L));
            result = result && (true  == F.lte_long(0L,0L));
            result = result && (true  == F.lte_long(0L,1L));
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
        public lte_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_lte);
            this.feature.Add(TestCoverage.F_lte_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_lte);
            this.coverage.Add(TestCoverage.F_lte_long);
        }
    }


    [Export(typeof(ITestCase))]
    public class lte_short : ITestCase {
        private const string _Name = "lte short,F_lte_short";
        private const string _Description = "F.lte_short(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (false == F.lte_short(1,0));
            result = result && (true  == F.lte_short(0,0));
            result = result && (true  == F.lte_short(0,1));
            return result;
        };
        private IList<TestCoverage> coverage = new List<TestCoverage>();
        private IList<TestCoverage> feature = new List<TestCoverage>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public Func<bool> Run { get; private set; }
        public IEnumerable<TestCoverage> Coverage { get { return this.coverage; } }
        public IEnumerable<TestCoverage> Feature { get { return this.feature; } }
        public lte_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_lte);
            this.feature.Add(TestCoverage.F_lte_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_lte);
            this.coverage.Add(TestCoverage.F_lte_short);
        }
    }
}

