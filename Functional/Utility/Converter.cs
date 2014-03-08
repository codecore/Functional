using System;
using System.Collections.Generic;
namespace Functional.Utility {
    public static class Converter {
        public static int char_to_digit(char c) {
            int result = 0;
            switch (c) {
                case '0': result = 0; break;
                case '1': result = 1; break;
                case '2': result = 2; break;
                case '3': result = 3; break;
                case '4': result = 4; break;
                case '5': result = 5; break;
                case '6': result = 6; break;
                case '7': result = 7; break;
                case '8': result = 8; break;
                case '9': result = 9; break;
            }
            return result;
        }
        public static char digit_to_char(int d) {
            char result = '0';
            switch (d) {
                case 0: result = '0'; break;
                case 1: result = '1'; break;
                case 2: result = '2'; break;
                case 3: result = '3'; break;
                case 4: result = '4'; break;
                case 5: result = '5'; break;
                case 6: result = '6'; break;
                case 7: result = '7'; break;
                case 8: result = '8'; break;
                case 9: result = '9'; break;
            }
            return result;
        }
        public static Func<string, int> string_to_int = (item) => {
            int result = 0;
            int.TryParse(item, out result);
            return result;
        };
        public static Func<string, long> string_to_long = (item) => {
            long result = 0;
            long.TryParse(item, out result);
            return result;
        };
        public static Func<string, short> string_to_short = (item) => {
            short result = 0;
            short.TryParse(item, out result);
            return result;
        };
        public static Func<string, float> string_to_float = (item) => {
            float result = 0.0f;
            float.TryParse(item, out result);
            return result;
        };
        public static Func<string, double> string_to_double = (item) => {
            double result = 0.0d;
            double.TryParse(item, out result);
            return result;
        };

        public static Func<string, bool> string_to_bool = (item) => {
            return ("TRUE" == item.ToUpper());
        };
        public static string toString<T>(T item) { return item.ToString(); }
        // TestCoverage = F, F_chars
        public static string toString(IEnumerable<char> x) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char c in x) sb.Append(c);
            return sb.ToString();
        }
    }
}