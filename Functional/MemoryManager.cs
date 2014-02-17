using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Language.Contract;
using Functional.Language.Implimentation;

namespace Functional.Language.Implimentation {
    public static class MemoryManager {
        public static IToken Avail_Token() { return avail_token; }
        public static ICodeLine Avail_CodeLine() { return avail_codeline; }
        public static ILocation Avail_Location() { return avail_location; }
        public static ICharacter Avail_Character() { return avail_character; }
        private static IToken avail_token = null;
        private static ICodeLine avail_codeline = null;
        private static ILocation avail_location = null;
        private static ICharacter avail_character = null;
        public static ILocation New(string filename, int line, int start, int length) {
            ILocation result = null;
            if (null != avail_location) {
                result = avail_location;
                avail_location = avail_location.Next;
                result.Filename = filename;
                result.Line = line;
                result.Start = start;
                result.Length = length;
                result.Next = null;
            } else result = new Location(filename, line, start, length);
            return result;
        }
        public static void Delete(ILocation location) {
            location.Next = avail_location;
            avail_location = location;
        }
        public static IToken New(ILocation location, string info, TokenKind kind) {
            IToken result = null;
            if (null != avail_token) {
                result = avail_token;
                avail_token = avail_token.Next;
                result.Location = location;
                result.Info = info;
                result.Kind = kind;
                result.Next = null;
            } else result = new Token(location, info, kind);
            return result;
        }
        public static void Delete(IToken token) {
            if (null != token.Location) {
                Delete(token.Location);
                token.Location = null;
            }
            token.Next = avail_token;
            avail_token = token;
        }
        public static ICodeLine New(ICodeDocument codedocument) {
            ICodeLine result = null;
            if (null != avail_codeline) {
                result = avail_codeline;
                avail_codeline = avail_codeline.Next;
                result.Document = codedocument;
            } else result = new CodeLine(codedocument);
            result.Next = null;
            return result;
        }
        public static void Delete(ICodeLine codeline) {
            codeline.FreeMemory();
            codeline.Next = avail_codeline;
            avail_codeline = codeline;
        }
        public static ICharacter New(char c,bool eof=false) {
            ICharacter result = null;
            if (null != avail_character) {
                result = avail_character;
                avail_character = avail_character.Next;
                result.Info = c;
                result.Next = null;
                result.Kind = (eof) ? CharKind.NULL : LanguageService.Crack(c);
            } else result = new Character(c, eof);
            return result;
        }
        public static void Delete(ICharacter ch) {
            ch.Next = avail_character;
            avail_character = ch;
        }
        public static void FreeMemory() {
            ILocation next_location = null;
            while (null != avail_location) {
                next_location = avail_location.Next;
                avail_location = null; // drop ref
                avail_location = next_location;
            }
            IToken next_token = null;
            while (null != avail_token) {
                next_token = avail_token.Next;
                avail_token = null;
                avail_token = next_token;
            }
            ICodeLine next_codeline = null;
            while (null != avail_codeline) {
                next_codeline = avail_codeline.Next;
                avail_codeline = null;
                avail_codeline = next_codeline;
            }
            ICharacter next_character = null;
            while (null != avail_character) {
                next_character = avail_character.Next;
                avail_character = null;
                avail_character = next_character;
            }
        }
    }
}
