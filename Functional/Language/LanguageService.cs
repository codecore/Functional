using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Language.Contract;

namespace Functional.Language.Implimentation {
    public static class LanguageService {
        public const char DOT = '.';
        public const char DASH = '-';
        public const char COMMA = ',';
        public const char OPEN_PAREN = '(';
        public const char CLOSE_PAREN = ')';
        public const char OPEN_SQ = '{';
        public const char CLOSE_SQ = '}';
        public const string PUNCTUATION = "~?+=!@#$%^&*_><';:[]\\|/'`";
        public const string LETTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string DIGITS = "0123456789";
        public const char SPACE = ' ';
        public const char CARRAGERETURN = '\n';
        public const char LINEFEED = '\r';
        public const char QUOTE = '\"';
        public const char NULL = '\0';
        public static CharKind Crack(char ch) {
            CharKind result = CharKind.UNKNOWN;
            if (LanguageService.QUOTE == ch) result = CharKind.QUOTE;
            else if (LanguageService.LETTERS.Contains(ch)) result = CharKind.ALPHA;
            else if (LanguageService.DIGITS.Contains(ch)) result = CharKind.DIGIT;
            else if (LanguageService.SPACE == ch) result = CharKind.SPACE;
            else if (LanguageService.DOT == ch) result = CharKind.DOT;
            else if (LanguageService.DASH == ch) result = CharKind.DASH;
            else if (LanguageService.COMMA == ch) result = CharKind.COMMA;
            else if (LanguageService.OPEN_PAREN == ch) result = CharKind.OPEN_PAREN;
            else if (LanguageService.CLOSE_PAREN == ch) result = CharKind.CLOSE_PAREN;
            else if (LanguageService.OPEN_SQ == ch) result = CharKind.OPEN_SQ;
            else if (LanguageService.CLOSE_SQ == ch) result = CharKind.CLOSE_SQ;
            else if (LanguageService.LINEFEED == ch) result = CharKind.LINEFEED;
            else if (LanguageService.CARRAGERETURN == ch) result = CharKind.CARRAGERETURN;
            else if (LanguageService.PUNCTUATION.Contains(ch)) result = CharKind.PUNCTUATION;
            else if (LanguageService.NULL == ch) result = CharKind.NULL;
            return result;
        }
    }
}
