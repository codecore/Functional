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
    public class lt_double : ITestCase {
        private const string _Name = "lt double,F_gt_double";
        private const string _Description = "F.lt_double(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (true  == F.lt_double( 0.000d, 1.000d));
            result = result && (true  == F.lt_double(-1.000d, 0.000d));
            result = result && (true  == F.lt_double( 0.000d, 0.001d));
            result = result && (false == F.lt_double( 0.000d, 0.000d));
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
        public lt_double() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_lt);
            this.feature.Add(TestCoverage.F_lt_double);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_lt);
            this.coverage.Add(TestCoverage.F_lt_double);
        }
    }

    [Export(typeof(ITestCase))]
    public class lt_float : ITestCase {
        private const string _Name = "lt float,F_lt_float";
        private const string _Description = "F.lt_float(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (true  == F.lt_float( 0.000f, 1.000f));
            result = result && (true  == F.lt_float(-1.000f, 0.000f));
            result = result && (true  == F.lt_float( 0.000f, 0.001f));
            result = result && (false == F.lt_float( 0.000f, 0.000f));
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
        public lt_float() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_lt);
            this.feature.Add(TestCoverage.F_lt_float);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_lt);
            this.coverage.Add(TestCoverage.F_lt_float);
        }
    }
    [Export(typeof(ITestCase))]
    public class lt_int : ITestCase {
        private const string _Name = "lt int,F_lt_int";
        private const string _Description = "F.lt_int(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (true  == F.lt_int( 0, 1));
            result = result && (true  == F.lt_int(-1, 0));
            result = result && (false == F.lt_int( 1, 0));
            result = result && (false == F.lt_int( 0, 0));
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
        public lt_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_lt);
            this.feature.Add(TestCoverage.F_lt_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_lt);
            this.coverage.Add(TestCoverage.F_lt_int);
        }
    }

    [Export(typeof(ITestCase))]
    public class lt_long : ITestCase {
        private const string _Name = "lt long,F_lt_long";
        private const string _Description = "F.lt_long(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (true == F.lt_long( 0L, 1L));
            result = result && (true == F.lt_long(-1L, 0L));
            result = result && (false == F.lt_long(1L, 0L));
            result = result && (false == F.lt_long(0L, 0L));
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
        public lt_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_lt);
            this.feature.Add(TestCoverage.F_lt_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_lt);
            this.coverage.Add(TestCoverage.F_lt_long);
        }
    }
    [Export(typeof(ITestCase))]
    public class lt_short : ITestCase {
        private const string _Name = "lt short,F_lt_short";
        private const string _Description = "F.lt_short(left,right) works correctly";
        private static Func<bool> _Run = () => {
            bool result = true;
            result = result && (true == F.lt_short(0, 1));
            result = result && (true == F.lt_short(-1, 0));
            result = result && (false == F.lt_short(1, 0));
            result = result && (false == F.lt_short(0, 0));
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
        public lt_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_lt);
            this.feature.Add(TestCoverage.F_lt_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_lt);
            this.coverage.Add(TestCoverage.F_lt_short);
        }
    }
}

