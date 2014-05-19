using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Language.Contract.Parser;
using Functional.Language.Contract.Editor;
using Functional.Language.Contract;
using Functional.Language.Contract.Core;
using Functional.Language.Implimentation;
using Functional.Implementation;
using Functional.Language.Core.Expressions;
using Functional.Contracts.Utility;

namespace Functional.Language.Implimentation {
    public enum Collision { _none, _keyword, _type, _var }
    public static class TypeVerifier {
        public static bool Verify(string token,IEnumerable<string> keywords, IEnumerable<string> types, IEnumerable<string> variables, ref Collision collision) {
            bool fine = true;
            if (F.any<string>(keywords, (s) => F.equ_string(s,token))) {
                collision = Collision._keyword;
                fine = false;
            } else if (F.any<string>(types, (s) => F.equ_string(s,token))) {
                collision = Collision._type;
                fine = false;
            } else if (F.any<string>(variables, (s) => F.equ_string(s,token))) {
                collision = Collision._var;
                fine = false;
            } else {
                collision = Collision._none;
                fine = F.all<char>(F.chars(token),F.alpha_char); // types names must be all alpha
            }
            return fine;
        }
    
    }
    public static class VariableVerifier {
        public static bool Verify(string token, IEnumerable<string> keywords, IEnumerable<string> types, IEnumerable<string> variables, ref Collision collision) {
            bool fine = true;
            if (F.any<string>(keywords, (s) => F.equ_string(s, token))) {
                collision = Collision._keyword;
                fine = false;
            } else if (F.any<string>(types, (s) => F.equ_string(s, token))) {
                collision = Collision._type;
                fine = false;
            } else if (F.any<string>(variables, (s) => F.equ_string(s, token))) {
                collision = Collision._var;
                fine = false;
            } else {
                collision = Collision._none;
                fine = F.all<char>(F.chars(token), F.alpha_char); // variable names must be all alpha
            }
            return fine;
        }

    }
}
