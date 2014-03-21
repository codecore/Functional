using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Language.Contract;
using Functional.Language.Contract.Parser;
using Functional.Language.Implimentation;

namespace Functional.Language.Implimentation {
    public class Character : ICharacter {
        public char Info { get; set; }
        public CharKind Kind { get; set; }
        public Character(char c, bool eof = false) {
            this.Info = c;
            this.Kind = (eof) ? CharKind.NULL : LanguageService.Crack(c);      
        }
        public ICharacter Next { get; set; }
        public override string ToString() { return this.Info.ToString()+":"+this.Kind.ToString(); }
    }
}
