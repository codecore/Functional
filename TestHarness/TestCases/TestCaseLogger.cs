using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Utility;
using Functional.Test;

using Test.Contracts;
using Tests;
namespace Tests {
    [Export(typeof(IAsyncTestCase))]
    public class logger_null : IAsyncTestCase {
        private const string _Name = "logger null";
        private const string _Description = "tests the null logger";
        public string TestFile { get { return "TestCaseLogger.cs";}}
        private ILogger logger = null;
        private void dispose() { 
            if (null != this.logger) { 
                this.logger.Dispose(); 
                this.logger = null; 
            }
        }
        public async Task<bool> RunAsync() {
            this.logger = new LoggerNULL();
            IDictionary<string, object> config = new Dictionary<string, object>();
            await this.logger.ConfigureAsync(config);
            await this.logger.LogAsync("log this line");
            this.dispose();
            return true;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public logger_null() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.feature.Add(TestCoverage.Logger);
            this.feature.Add(TestCoverage.Logger_Null);
            this.coverage.Add(TestCoverage.Logger);
            this.coverage.Add(TestCoverage.Logger_Null);
        }
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
    }

    [Export(typeof(IAsyncTestCase))]
    public class logger_console : IAsyncTestCase {
        private const string _Name = "logger console";
        private const string _Description = "tests the console logger";
        public string TestFile { get { return "TestCaseLogger.cs"; } }
        private ILogger logger = null;
        private void dispose() { 
            if (null != this.logger) {
                this.logger.Dispose();
                this.logger = null; 
            } 
        }
        public async Task<bool> RunAsync() {
            this.logger = new LoggerCONSOLE();
            IDictionary<string, object> config = new Dictionary<string, object>();
            await this.logger.ConfigureAsync(config);
            await this.logger.LogAsync("log this line");
            this.dispose();
            return true;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public logger_console() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.feature.Add(TestCoverage.Logger);
            this.feature.Add(TestCoverage.Logger_Console);
            this.coverage.Add(TestCoverage.Logger);
            this.coverage.Add(TestCoverage.Logger_Console);
        }
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
    }

    [Export(typeof(IAsyncTestCase))]
    public class logger_filename : IAsyncTestCase {
        private const string _Name = "logger filename";
        private const string _Description = "tests the filename logger";
        public string TestFile { get { return "TestCaseLogger.cs"; } }
        private ILogger logger = null;
        private void dispose() { 
            if (null != this.logger) {
                this.logger.Dispose(); 
                this.logger = null; 
            }
        }
        public async Task<bool> RunAsync() {
            string filename = "C:\\Temp\\logfile.txt";
            bool result = true;
            this.logger = new LoggerFILENAME();
            IDictionary<string, object> config = new Dictionary<string, object>();
            config.Add("logfilename",filename);
            FileUtility.DeleteFile(filename);
            result = result && (false == FileUtility.FileExists(filename));
            await this.logger.ConfigureAsync(config);
            await this.logger.LogAsync("log this line");
            this.dispose();
            result = result && FileUtility.FileExists(filename);
            result = result && (18 == FileUtility.FileLength(filename));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public logger_filename() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.feature.Add(TestCoverage.Logger);
            this.feature.Add(TestCoverage.Logger_Filename);
            this.coverage.Add(TestCoverage.Logger);
            this.coverage.Add(TestCoverage.Logger_Filename);
        }
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
    }
}
