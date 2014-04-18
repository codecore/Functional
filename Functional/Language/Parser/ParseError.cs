using Functional.Language.Contract.Core;

namespace Functional.Language.Contract.Core {
    public class ParseError : IParseError {
        private ParseError() { }
        public bool Error { get; set; }
        public string ErrorInfo { get; set; }
        public static IParseError Create() { return new ParseError(); }
    }
}
