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
        public async Task ConfigureAsync(IDictionary<string, object> config) { await Task.Delay(0); }
        public async Task LogAsync(string info) { await Task.Delay(0); }
        public void Dispose() { }
    }
    [Export(typeof(ILogger))]
    public class LoggerCONSOLE : ILogger {
        private IList<LoggerKind> kind = new List<LoggerKind>();
        public IEnumerable<LoggerKind> Kind { get { return this.kind; } }
        public LoggerCONSOLE() { this.kind.Add(LoggerKind.Console); }
        public async Task ConfigureAsync(IDictionary<string, object> config) { await Task.Delay(0);  }
        public async Task LogAsync(string info) { Console.WriteLine(info); await Task.Delay(0); }
        public void Dispose() { }
    }
    [Export(typeof(ILogger))]
    public class LoggerTextWriter : ILogger {
        private IList<LoggerKind> kind = new List<LoggerKind>();
        private TextWriter textWriter = null;
        public IEnumerable<LoggerKind> Kind { get { return this.kind; } }
        public LoggerTextWriter() { this.kind.Add(LoggerKind.TextWriter); }
        public async Task ConfigureAsync(IDictionary<string, object> config) {
            if (config.Keys.Contains("textwriter")) {
                this.textWriter = (TextWriter)(config["textwriter"]);
            }
            await Task.Delay(0); // stupid work-around
        }
        public async Task LogAsync(string info) {
            // TODO handle textWriter == NULL
            await this.textWriter.WriteLineAsync(info);
        }
        public void Dispose() { }
    }
    [Export(typeof(ILogger))]
    public class LoggerFILENAME : ILogger {
        private IList<LoggerKind> kind = new List<LoggerKind>();
        private TextWriter logfile = null;
        public IEnumerable<LoggerKind> Kind { get { return this.kind; } }
        public LoggerFILENAME() { this.kind.Add(LoggerKind.File); }
        public async Task ConfigureAsync(IDictionary<string, object> config) {
            if (config.Keys.Contains("logfilename")) {
                try {
                    this.logfile = new StreamWriter((string)(config["logfilename"]), false, Encoding.UTF8, 1024);
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