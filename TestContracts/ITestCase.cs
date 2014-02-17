using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestContracts
{
    public static class TestCoverage {
        public const int Test_All =  1;                 // non-leaf
        public const int Test_Integration = 2;         // non-leaf

        public const int bool_ =  30;                    // non-leaf  TestCaseBool
        public const int bool_And = 31;          // covered
        public const int bool_Or = 36;           // covered

        public const int Chain = 40;
        public const int Curry1 = 42;
        public const int Curry2 = 44;

        public const int F = 100;                       // non-leaf

        public const int F_add = 110;                    // non-leaf TestCaseAdd.cs
        public const int F_add_double =  111;       // covered
        public const int F_add_float = 112;        // covered
        public const int F_add_int = 113;          // covered
        public const int F_add_long = 114;         // covered
        public const int F_add_short = 115;        // covered
        public const int F_add_string = 116;       // covered

        public const int F_always = 120;                 // non-leaf  TestCaseAlways
        public const int F_always_false = 121;     // covered
        public const int F_always_function = 122;  // covered
        public const int F_always_true = 123;      // covered

        public const int F_bool = 130;                   // non-leaf  TestCaseBool.cs
        public const int F_bool_and = 131;         // covered
        public const int F_bool_eqv = 132;         // covered
        public const int F_bool_or = 133;          // covered
        public const int F_bool_xor = 134;         // covered

        public const int F_chars = 140;            // covered  TestCase.cs

        public const int F_close = 150;                  // non-leaf  TestCaseClose.cs
        public const int F_close_double = 151;     // covered
        public const int F_close_float = 152;      // covered

        public const int F_compare = 160;                // non-leaf  TestCaseCompare.cs
        public const int F_compare_bool = 161;     // covered
        public const int F_compare_char = 162;     // covered
        public const int F_compare_int = 163;      // covered
        public const int F_compare_long = 164;     // covered
        public const int F_compare_short = 165;    // covered
        public const int F_compare_string = 166;   // covered
        public const int F_compare_string_insensative = 167; // covered

        public const int F_equ = 170;                    // non-leaf  TestCaseEqu.cs
        public const int F_equ_bool = 171;         // covered
        public const int F_equ_char = 172;         // covered
        public const int F_equ_int = 173;          // covered
        public const int F_equ_long = 174;         // covered
        public const int F_equ_short = 175;        // covered
        public const int F_equ_string = 176;       // covered

        public const int F_even = 180;

        public const int F_gt = 190;                     // non-leaf  TestCaseGt.cs
        public const int F_gt_double = 191;        // covered
        public const int F_gt_float = 192;         // covered
        public const int F_gt_int = 193;           // covered
        public const int F_gt_long = 194;          // covered
        public const int F_gt_short = 195;         // covered

        public const int F_gte = 200;                    // non-leaf  TestCaseGte.cs
        public const int F_gte_int = 201;          // covered
        public const int F_gte_long = 202;         // covered
        public const int F_gte_short = 203;        // covered

        public const int F_inc = 210;                    // non-leaf
        public const int F_inc_int = 211;
        public const int F_inc_long = 212;          //
        public const int F_inc_short = 213;

        public const int F_lt = 220;                     // non-leaf  TestCaseLt.cs
        public const int F_lt_double = 221;        // covered
        public const int F_lt_float = 222;         // covered
        public const int F_lt_int = 223;           // covered
        public const int F_lt_long = 224;          // covered
        public const int F_lt_short = 225;         // covered

        public const int F_lte = 230;                    // non-leaf  TestCaseLte.cs
        public const int F_lte_int = 231;          // covered
        public const int F_lte_long = 232;         // covered
        public const int F_lte_short = 233;        // covered

        public const int F_max = 240;                    // non-leaf  TestCaseMax.cs
        public const int F_max_double = 241;       // covered
        public const int F_max_float = 242;        // covered
        public const int F_max_int = 243;          // covered
        public const int F_max_long = 244;         // covered
        public const int F_max_short = 245;        // covered

        public const int F_min = 250;                    // non-leaf  TestCaseMin.cs
        public const int F_min_double = 251;       // covered
        public const int F_min_float = 252;        // covered
        public const int F_min_int = 253;          // covered
        public const int F_min_long = 254;         // covered
        public const int F_min_short = 255;        // covered

        public const int F_mult = 260;                   // non-leaf  TestCaseMult.cs
        public const int F_mult_double = 261;      // coverage
        public const int F_mult_float = 262;       // coverage
        public const int F_mult_int = 263;         // coverage
        public const int F_mult_long = 264;        // coverage
        public const int F_mult_short = 265;       // coverage

        public const int F_neq = 270;                    // non-leaf  TestCaseNeq.cs
        public const int F_neq_bool = 271;         // covered
        public const int F_neq_char = 272;         // covered
        public const int F_neq_int = 273;          // covered
        public const int F_neq_long = 274;         // covered
        public const int F_neq_short = 275;        // covered
        public const int F_neq_string = 276;       // covered

        public const int F_odd = 280;
        public const int F_random = 290;

        public const int F_range = 300;                  // non-leaf  TestCaseRange.cs
        public const int F_range_start_end = 301;      // covered
        public const int F_range_start_end_step = 302; // covered
        public const int F_range_end = 303;            // covered

        public const int F_sqr = 310;                    // non-leaf  TestCaseSqr.cs
        public const int F_sqr_double = 311;       // covered
        public const int F_sqr_float = 312;        // covered
        public const int F_sqr_int = 313;          // covered
        public const int F_sqr_long = 314;         // covered
        public const int F_sqr_short = 315;        // covered

        public const int F_sqrt = 320;                   // non-leaf
        public const int F_sqrt_double = 321;
        public const int F_sqrt_float = 322;

        public const int F_sub = 330;                    // non-leaf  TestCaseSub.cs
        public const int F_sub_double = 331;       // covered
        public const int F_sub_float = 332;        // covered
        public const int F_sub_int = 333;          // covered
        public const int F_sub_long = 334;         // covered
        public const int F_sub_short = 335;        // covered

        public const int F_T = 500;                      // non-leaf

        public const int F_T_all = 510;            // covered
        public const int F_T_always = 520;         // covered
        public const int F_T_any = 520;            // covered

        public const int F_T_each = 530;                 // non-leaf  TestCaseEach.cs
        public const int F_T_each_naked = 531;     // covered
        public const int F_T_each_U = 534;
        public const int F_T_each_U_V = 535;
        public const int F_T_each_U_V_W = 536;
        public const int F_T_each_U_V_W_X = 537;
        public const int F_T_each_U_V_Acc = 538;

        public const int F_T_filter = 550;         // covered
        public const int F_T_find = 560;           // covered
        public const int F_T_first = 570;          // covered
        public const int F_T_flatten = 580;        // covered

        public const int F_T_forever = 590;              // non-leaf
        public const int F_T_forever_item = 600;
        public const int F_T_forever_function = 610;

        public const int F_T_identity = 620;
        public const int F_T_items = 630;
        public const int F_T_iterate_while = 640;  // covered
        public const int F_T_limit = 650;

        public const int F_T_map = 660;                  // non-leaf  TestCaseMap
        public const int F_T_map_U = 661;          // covered
        public const int F_T_map_U_V = 662;
        public const int F_T_map_U_V_W = 663;
        public const int F_T_map_U_V_W_X = 664;
        public const int F_T_map_U_2_List = 666;   // covered
        public const int F_T_map_U_3_List = 667;   // covered

        public const int F_T_reduce = 670;               // non-leaf  TestCaseRecude.cs
        public const int F_T_reduce_init = 671;    // covered
        public const int F_T_reduce_naked = 672;   // covered
        public const int F_T_reduce_U_init = 673;  // covered

        public const int F_T_rest = 680;           // covered
        public const int F_T_same = 700;

        public const int F_T_sort = 730;                 // non-leaf  TestCaseSort.cs
        public const int F_T_sort_naked = 731;     // covered
        public const int F_T_sort_order_by = 732;  // covered
        public const int F_T_sort_bubble = 733;

        public const int F_T_task = 760;
        public const int F_T_toString = 780;
        public const int F_T_transform = 790;

        public const int GPS = 900;
        public const int GPS_NMEA = 910;
        public const int GPS_NMEA_Parse = 940;
        public const int GPS_NMEA_Parse_GPGGA = 941;
        public const int GPS_NMEA_Parse_GPGSA = 942;
        public const int GPS_NMEA_Parse_GPGSV = 943;
        public const int GPS_NMEA_Parse_GPRMC = 944;
        public const int GPS_NMEA_Parse_GPGLL = 945;
        public const int GPS_NMEA_Parse_GPVTG = 946;
        public const int GPS_NMEA_Parse_GPWPL = 947;
        public const int GPS_NMEA_Parse_GPAAM = 948;
        public const int GPS_NMEA_Parse_GPAPB = 949;
        public const int GPS_NMEA_Parse_GPBOD = 950;
        public const int GPS_NMEA_Parse_GPBWC = 951;
        public const int GPS_NMEA_Parse_GPRMB = 952;
        public const int GPS_NMEA_Parse_GPRTE = 953;
        public const int GPS_NMEA_Parse_GPXTE = 954;
        public const int GPS_NMEA_Parse_GPALM = 955;
        public const int GPS_NMEA_Parse_HCHDG = 956;  // garmin compass
        public const int GPS_NMEA_Parse_GPZDA = 957;
        public const int GPS_NMEA_Parse_GPMSK = 958;
        public const int GPS_NMEA_Parse_GPMSS = 959;     // beacon receiver status
        public const int GPS_NMEA_Parse_PGRME = 960;     // garmin 
        public const int GPS_NMEA_Parse_PGRMZ = 961;     // garmin
        public const int GPS_NMEA_Parse_PSLIB = 962;     // starlink. $PSLIB,320.0,200*59 to set the DBR to 320 KHz, 200 b/s.
        public const int GPS_NMEA_Parse_PMGNST = 963;    // magellan
        public const int GPS_NMEA_Parse_PMGNTRK = 964;   // magellin
        public const int GPS_NMEA_Parse_PMOTG = 965;   // motorola
        public const int GPS_NMEA_Parse_PRWIRID = 966;   // rockwell
        public const int GPS_NMEA_Parse_PRWIILOG = 967;  // rockwell
        public const int GPS_NMEA_Parse_PRWIINIT = 968;  // rockwell

        public const int LandMine = 1200; // non-leaf
        public const int LandMine_inc = 1210; // covered

        public const int Lang = 2000;                  // non-leaf
        public const int Lang_Character = 2010;        // covered
        public const int Lang_CharacterStream = 2020;  // covered
        public const int Lang_Editor = 2100;
        public const int Lang_Editor_CodeDocument = 2110;
        public const int Lang_Editor_CodeDocument_AddFirst = 2111;
        public const int Lang_Editor_CodeDocument_AddBefore = 2112;
        public const int Lang_Editor_CodeDocument_AddAfter = 2113;
        public const int Lang_Editor_CodeDocument_MovePrev = 2114;
        public const int Lang_Editor_CodeDocument_MoveNext = 2115;
        public const int Lang_Editor_CodeLine = 2140;  // covered
        public const int Lang_Editor_CodeLine_AddFirst = 2141;
        public const int Lang_Editor_CodeLine_AddBefore = 2142;
        public const int Lang_Editor_CodeLine_AddAfter = 2143;
        public const int Lang_Editor_CodeLine_MovePrev = 2144;
        public const int Lang_Editor_CodeLine_MoveNext = 2145;

        public const int Lang_Editor_Token = 2160;

        public const int Lang_Memory_Manager = 2400;                     // non-leaf
        public const int Lang_Memory_Manager_ICharacter = 2410;          // non-leaf
        public const int Lang_Memory_Manager_ICharacter_New = 2412;
        public const int Lang_Memory_Manager_ICharacter_Delete = 2414;
        public const int Lang_Memory_Manager_IToken = 2420;              // non-leaf
        public const int Lang_Memory_Manager_IToken_New = 2422;
        public const int Lang_Memory_Manager_IToken_Delete = 2424;
        public const int Lang_Memory_Manager_ICodeLine = 2430;           // non-leaf
        public const int Lang_Memory_Manager_ICodeLine_New = 2432;
        public const int Lang_Memory_Manager_ICodeLine_Delete = 2434;
        public const int Lang_Memory_Manager_ILocation = 2440;           // non-leaf
        public const int Lang_Memory_Manager_ILocation_New = 2442;
        public const int Lang_Memory_Manager_ILocation_Delete = 2444;

        public const int Lang_Parser = 3000;                 // non-leaf
        public const int Lang_Parser_Lexer = 3100;           // non-leaf
        public const int Lang_Parser_Lexer_Space = 3110;

        public const int Logger = 12000; // non-leaf
        public const int Logger_Null = 12010;
        public const int Logger_File = 12020;
        public const int Logger_Console = 12030;
        
        public const int Utility = 1000;                  // non-leaf
        public const int Utility_char_to_digit = 1001;
        
    }


    public interface ISyncTestCase {
        int ID { get; }
        string Name { get; }
        string Description { get; }
        string TestFile { get; }
        Func<bool> Run { get; }
        IEnumerable<int> Feature { get; }
        IEnumerable<int> Coverage { get; }
    }
    public interface IAsyncTestCase {
        int ID { get; }
        string Name { get; }
        string Description { get; }
        string TestFile { get; }
        Task<bool> Run();
        IEnumerable<int> Feature { get; }
        IEnumerable<int> Coverage { get; }
    }
}
