using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;

using TestContracts;
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
            IDictionary<string, string> config = new Dictionary<string, string>();
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
            IDictionary<string, string> config = new Dictionary<string, string>();

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
    public class logger_file : IAsyncTestCase {
        private const string _Name = "logger file";
        private const string _Description = "tests the file logger";
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
            this.logger = new LoggerFILE();
            IDictionary<string, string> config = new Dictionary<string, string>();
            config.Add("logfile",filename);
            Utility.DeleteFile(filename);
            result = result && (false == Utility.FileExists(filename));
            await this.logger.ConfigureAsync(config);
            await this.logger.LogAsync("log this line");
            this.dispose();
            result = result && Utility.FileExists(filename);
            result = result && (18 == Utility.FileLength(filename));
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public logger_file() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.feature.Add(TestCoverage.Logger);
            this.feature.Add(TestCoverage.Logger_File);
            this.coverage.Add(TestCoverage.Logger);
            this.coverage.Add(TestCoverage.Logger_File);
        }
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public IEnumerable<int> Coverage { get { return this.coverage; } }
    }
}
