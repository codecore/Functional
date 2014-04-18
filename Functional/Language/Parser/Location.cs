using System;
//using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;

using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;

namespace Functional.Language.Implimentation {
    public class Location : ILocation {
        public string Filename { get; set; }
        public int Line { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public ILocation Next { get; set; }
        private Location() { }
        private Location(string filename, int line, int start, int length) {
            this.Filename = filename;
            this.Line = line;
            this.Start = start;
            this.Length = length;
            this.Next = null;
        }
        public override string ToString() { return this.Filename + " " + this.Line + " " + this.Start + " " + this.Length; }
        public static ILocation Create(string filename, int line, int start, int length) {
            return new Location(filename, line, start, length);
        }
    }
}
