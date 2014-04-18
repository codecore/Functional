using System;
using System.Collections.Generic;
using Functional.Test;
namespace Functional.Utility {
    public static class Converter {
        [Coverage(TestCoverage.Converter_char_to_digit)]
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
        [Coverage(TestCoverage.Converter_digit_to_char)]
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
        [Coverage(TestCoverage.Converter_string_to_int)]
        public static Func<string, int> string_to_int = (item) => {
            int result = 0;
            int.TryParse(item, out result);
            return result;
        };
        [Coverage(TestCoverage.Converter_string_to_long)]
        public static Func<string, long> string_to_long = (item) => {
            long result = 0;
            long.TryParse(item, out result);
            return result;
        };
        [Coverage(TestCoverage.Converter_string_to_short)]
        public static Func<string, short> string_to_short = (item) => {
            short result = 0;
            short.TryParse(item, out result);
            return result;
        };
        [Coverage(TestCoverage.Converter_string_to_float)]
        public static Func<string, float> string_to_float = (item) => {
            float result = 0.0f;
            float.TryParse(item, out result);
            return result;
        };
        [Coverage(TestCoverage.Converter_string_to_double)]
        public static Func<string, double> string_to_double = (item) => {
            double result = 0.0d;
            double.TryParse(item, out result);
            return result;
        };
        [Coverage(TestCoverage.Converter_string_to_bool)]
        public static Func<string, bool> string_to_bool = (item) => {
            return ("TRUE" == item.ToUpper());
        };
        [Coverage(TestCoverage.Converter_toString_T)]
        public static string toString<T>(T item) { return item.ToString(); }
        [Coverage(TestCoverage.Converter_toString_seq_T)]
        public static string toString<T>(IEnumerable<T> x) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (T t in x) sb.Append(t.ToString());
            return sb.ToString();
        }
    }
}