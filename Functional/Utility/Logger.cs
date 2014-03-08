using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

using Functional.Contracts;
namespace Functional.Utility {
    [Export(typeof(ILogger))]
    public class LoggerNULL : ILogger {
        private IList<LoggerKind> kind = new List<LoggerKind>();
        public IEnumerable<LoggerKind> Kind { get { return this.kind; } }
        public LoggerNULL() { this.kind.Add(LoggerKind.Null); }
        public async Task ConfigureAsync(IDictionary<string, string> config) { await Task.Delay(0); }
        public async Task LogAsync(string info) { await Task.Delay(0); }
        public void Dispose() { }
    }
    [Export(typeof(ILogger))]
    public class LoggerCONSOLE : ILogger {
        private IList<LoggerKind> kind = new List<LoggerKind>();
        public IEnumerable<LoggerKind> Kind { get { return this.kind; } }
        public LoggerCONSOLE() { this.kind.Add(LoggerKind.Console); }
        public async Task ConfigureAsync(IDictionary<string, string> config) { await Task.Delay(0);  }
        public async Task LogAsync(string info) { Console.WriteLine(info); await Task.Delay(0); }
        public void Dispose() { }
    }
    [Export(typeof(ILogger))]
    public class LoggerFILE : ILogger {
        private IList<LoggerKind> kind = new List<LoggerKind>();
        private TextWriter logfile = null;
        public IEnumerable<LoggerKind> Kind { get { return this.kind; } }
        public LoggerFILE() { this.kind.Add(LoggerKind.File); }
        public async Task ConfigureAsync(IDictionary<string, string> config) {
            if (config.Keys.Contains("logfile")) {
                try {
                    this.logfile = new StreamWriter(config["logfile"], false, Encoding.UTF8, 1024);
                } catch { }
                await Task.Delay(0); // stupid work-around
            }
        }
        public async Task LogAsync(string info) {
            // TODO handle logfile == NULL
            await this.logfile.WriteLineAsync(info);
        }
        public void Dispose() {
            if (null != this.logfile) {
                this.logfile.Dispose();
                this.logfile = null;
            }
        }
    }
}