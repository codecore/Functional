﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {
    [Export(typeof(ISyncTestCase))]
    public class gt_double : ISyncTestCase {
        private const string _Name = "gt double,F_gt_double";
        private const string _Description = "F.gt_double(left,right) works correctly";
        public string TestFile { get { return "TestCaseGt.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.gt_double( 1.000d, 0.000d));
            result = result && (true  == F.gt_double( 0.000d,-1.000d));
            result = result && (true  == F.gt_double( 0.001d, 0.000d));
            result = result && (false == F.gt_double( 0.000d, 0.000d));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public gt_double() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_gt);
            this.feature.Add(TestCoverage.F_gt_double);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_gt);
            this.coverage.Add(TestCoverage.F_gt_double);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class gt_float : ISyncTestCase {
        private const string _Name = "gt float,F_gt_float";
        private const string _Description = "F.gt_float(left,right) works correctly";
        public string TestFile { get { return "TestCaseGt.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.gt_float( 1.000f, 0.000f));
            result = result && (true  == F.gt_float( 0.000f,-1.000f));
            result = result && (true  == F.gt_float( 0.001f, 0.000f));
            result = result && (false == F.gt_float( 0.000f, 0.000f));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public gt_float() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_gt);
            this.feature.Add(TestCoverage.F_gt_float);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_gt);
            this.coverage.Add(TestCoverage.F_gt_float);
        }
    }
    [Export(typeof(ISyncTestCase))]
    public class gt_int : ISyncTestCase {
        private const string _Name = "gt int,F_gt_int";
        private const string _Description = "F.gt_int(left,right) works correctly";
        public string TestFile { get { return "TestCaseGt.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.gt_int( 1, 0));
            result = result && (true  == F.gt_int( 0, -1));
            result = result && (false == F.gt_int( 0, 1));
            result = result && (false == F.gt_int( 0, 0));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public gt_int() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_gt);
            this.feature.Add(TestCoverage.F_gt_int);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_gt);
            this.coverage.Add(TestCoverage.F_gt_int);
        }
    }

    [Export(typeof(ISyncTestCase))]
    public class gt_long : ISyncTestCase {
        private const string _Name = "gt long,F_gt_long";
        private const string _Description = "F.gt_long(left,right) works correctly";
        public string TestFile { get { return "TestCaseGt.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.gt_long( 1L, 0L));
            result = result && (true  == F.gt_long( 0L,-1L));
            result = result && (false == F.gt_long( 0L, 1L));
            result = result && (false == F.gt_long( 0L, 0L));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public gt_long() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_gt);
            this.feature.Add(TestCoverage.F_gt_long);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_gt);
            this.coverage.Add(TestCoverage.F_gt_long);
        }
    }
    [Export(typeof(ISyncTestCase))]
    public class gt_short : ISyncTestCase {
        private const string _Name = "gt short,F_gt_short";
        private const string _Description = "F.gt_short(left,right) works correctly";
        public string TestFile { get { return "TestCaseGt.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            result = result && (true  == F.gt_short( 1, 0));
            result = result && (true  == F.gt_short( 0,-1));
            result = result && (false == F.gt_short( 0, 1));
            result = result && (false == F.gt_short( 0, 0));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public gt_short() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.F);
            this.feature.Add(TestCoverage.F_gt);
            this.feature.Add(TestCoverage.F_gt_short);

            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_gt);
            this.coverage.Add(TestCoverage.F_gt_short);
        }
    }
}
