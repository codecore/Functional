using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Functional.Contracts {
    public interface IPair<U, V> {
        U Left { get; }
        V Right { get; }
    }
    public delegate IEnumerable<string> GetStrings(StreamReader sr);

    public interface IStatefulChain<T> {
        T Item { get; }
        IStatefulChain<T> Run();
    }
    public interface IStatelessChain<T> {
        IStatelessChain<T> Run(T t);
    }
    public interface IStatelessChain<T, U> {
        IStatelessChain<T, U> Run(T t, U u);
    }
    public interface IStatelessChain<T, U, V> {
        IStatelessChain<T, U, V> Run(T t, U u, V v);
    }
    public interface IListener<T, U> {
        Func<T, U> Handle { get; } 
    }
    public interface ISomething<T> {
        T Item { get; set; }
    }
    public interface ISomethingImmutable<T> {
        T Item { get; }
    }
    public interface IDefault<T> {
        Func<T,T> orDefault { get; }
    }
    public interface ICurry<T> {
        Action<T> Create();
        Func<T, T> Create(T t1);
        Func<T, T> Create(T t1, T t2);
        Func<T, T> Create(T t1, T t2, T t3);
        Func<T, T> Create(T t1, T t2, T t3, T t4);
        Func<T, T> Create(T t1, T t2, T t3, T t4, T t5);
        Func<T, T> Create(T t1, T t2, T t3, T t4, T t5, T t6);
    }
    public interface ICurry<T, U> {
        Func<T,Func<T, U>> Create { get; }
    }
    public interface ICurry1<T, U> {
        Func<Func<T, U>> Create { get; }
    }
    public interface ICurry2<T, U> {
        Func<T,Func<U, U>> Create { get; }
    }
    public interface IOption<T> { // inspired by F# Option
        T Value { get; }
        bool IsSome { get; }
        bool IsNone { get; }
    }
    public enum LoggerKind { Null, Console, File, HttpPost, UI }
    public interface ILogManager {
        IEnumerable<ILogger> Loggers { get; }
        Task Log(string info);
        Task Log(LoggerKind kind, string info);
    }
    public interface ILogger : IDisposable {
        IEnumerable<LoggerKind> Kind { get; }
        Task ConfigureAsync(IDictionary<string, string> config);
        Task LogAsync(string info); 
    }
}
namespace Functional.Test {
    public static class TestCoverage {
        public const int Test_All                = 100;                 // non-leaf
        public const int Test_Integration        = 200;         // non-leaf

        public const int bool_                   = 3000;                    // non-leaf  TestCaseBool
        public const int bool_And                = 3004;          // covered
        public const int bool_Or                 = 3006;           // covered

        public const int Chain                   = 4000; // TODO break this to more items

        public const int Curry                   = 4100;   // non-leaf
        public const int Curry_curry             = 4120;
        public const int Curry_curry1            = 4122;
        public const int Curry_curry2            = 4124;
        public const int Curry_monster           = 4128;

        public const int F                       = 5000;                       // non-leaf

        public const int F_add                   = 5100;                    // non-leaf TestCaseAdd.cs
        public const int F_add_double            = 5110;       // covered
        public const int F_add_float             = 5112;        // covered
        public const int F_add_int               = 5114;          // covered
        public const int F_add_long              = 5116;         // covered
        public const int F_add_short             = 5118;        // covered
        public const int F_add_string            = 5120;       // covered

        public const int F_always                = 5200;                 // non-leaf  TestCaseAlways
        public const int F_always_false          = 5202;     // covered
        public const int F_always_function       = 5304;  // covered
        public const int F_always_true           = 5206;      // covered

        public const int F_bool                  = 5300;                   // non-leaf  TestCaseBool.cs
        public const int F_bool_and              = 5310;         // covered
        public const int F_bool_eqv              = 5312;         // covered
        public const int F_bool_not              = 5314;         // not covered
        public const int F_bool_or               = 5316;          // covered
        public const int F_bool_xor              = 5318;         // covered

        public const int F_chars                 = 5350;            // covered  TestCase.cs

        public const int F_clamp                 = 5400;            // non-leaf
        public const int F_clamp_float           = 5410;      // non-leaf
        public const int F_clamp_float_scaler    = 5412;
        public const int F_clamp_float_seq       = 5414;
        public const int F_clamp_double          = 5420;     // non-leaf
        public const int F_clamp_double_scaler   = 5422;
        public const int F_clamp_double_seq      = 5424;
           
        public const int F_close                 = 5500;                  // non-leaf  TestCaseClose.cs
        public const int F_close_double          = 5502;     // covered
        public const int F_close_float           = 5504;      // covered

        public const int F_combination           = 5600; // non-leaf
        public const int F_combination_combine   = 5602;

        public const int F_compare                    = 5700;                // non-leaf  TestCaseCompare.cs
        public const int F_compare_bool               = 5701;     // covered
        public const int F_compare_char               = 5702;     // covered
        public const int F_compare_int                = 5703;      // covered
        public const int F_compare_long               = 5704;     // covered
        public const int F_compare_short              = 5705;    // covered
        public const int F_compare_string             = 5706;   // covered
        public const int F_compare_string_insensative = 5707; // covered

        public const int F_donothing              = 5900; // non-leaf
        public const int F_donothing_no_inputs    = 5901;
        public const int F_donothing_one_input    = 5902;
        public const int F_donothing_two_inputs   = 5903;
        public const int F_donothing_three_inputs = 5904;
        public const int F_donothing_four_inputs  = 5905;
        public const int F_donothing_sequence     = 5906;
        public const int F_donothing_two_types    = 5907;
        public const int F_donothing_three_types  = 5908;

        public const int F_equ                   = 6000;                    // non-leaf  TestCaseEqu.cs
        public const int F_equ_bool              = 6001;         // covered
        public const int F_equ_char              = 6002;         // covered
        public const int F_equ_int               = 6003;          // covered
        public const int F_equ_long              = 6004;         // covered
        public const int F_equ_short             = 6005;        // covered
        public const int F_equ_string            = 6006;       // covered

        public const int F_even                  = 6100;

        public const int F_Func                  = 6200;  // leaf node
        public const int F_Func_action           = 6210; // leaf-node
        public const int F_Func_actionInt        = 6212;
        public const int F_Func_actionLong       = 6214;
        public const int F_Func_actionShort      = 6216;
        public const int F_Func_actionBool       = 6218;
        public const int F_Func_actionChar       = 6220;
        public const int F_Func_actionString     = 6222;
        public const int F_Func_func             = 6250;    // non-leaf
        public const int F_Func_funcInt          = 6252;
        public const int F_Func_funcLong         = 6254;
        public const int F_Func_funcShort        = 6256;
        public const int F_Func_funcBool         = 6258;
        public const int F_Func_funcChar         = 6260;
        public const int F_Func_funcString       = 6262;


        public const int F_gt                    = 6500;                     // non-leaf  TestCaseGt.cs
        public const int F_gt_double             = 6501;        // covered
        public const int F_gt_float              = 6502;         // covered
        public const int F_gt_int                = 6503;           // covered
        public const int F_gt_long               = 6504;          // covered
        public const int F_gt_short              = 6505;         // covered

        public const int F_gte                   = 6600;                    // non-leaf  TestCaseGte.cs
        public const int F_gte_int               = 6601;          // covered
        public const int F_gte_long              = 6602;         // covered
        public const int F_gte_short             = 6603;        // covered

        public const int F_inc                   = 6900;                    // non-leaf
        public const int F_inc_int               = 6901;
        public const int F_inc_long              = 6901;          //
        public const int F_inc_short             = 6903;

        public const int F_infinite                     = 7100; // non-leaf
        public const int F_infinite_bool                = 7101;
        public const int F_infinite_bool_toggle         = 7102;
        public const int F_infinite_range               = 7103; // non-leaf
        public const int F_infinite_range_int_start_inc = 7104;

        public const int F_lt                    = 7400;                     // non-leaf  TestCaseLt.cs
        public const int F_lt_double             = 7401;        // covered
        public const int F_lt_float              = 7402;         // covered
        public const int F_lt_int                = 7403;           // covered
        public const int F_lt_long               = 7404;          // covered
        public const int F_lt_short              = 7405;         // covered

        public const int F_lte                   = 7500;                    // non-leaf  TestCaseLte.cs
        public const int F_lte_int               = 7501;          // covered
        public const int F_lte_long              = 7502;         // covered
        public const int F_lte_short             = 7503;        // covered

        public const int F_max                   = 7800;                    // non-leaf  TestCaseMax.cs
        public const int F_max_double            = 7801;       // covered
        public const int F_max_float             = 7802;        // covered
        public const int F_max_int               = 7803;          // covered
        public const int F_max_long              = 7804;         // covered
        public const int F_max_short             = 7805;        // covered

        public const int F_min                   = 8000;                    // non-leaf  TestCaseMin.cs
        public const int F_min_double            = 8001;       // covered
        public const int F_min_float             = 8002;        // covered
        public const int F_min_int               = 8003;          // covered
        public const int F_min_long              = 8004;         // covered
        public const int F_min_short             = 8005;        // covered

        public const int F_mult                  = 8400;                   // non-leaf  TestCaseMult.cs
        public const int F_mult_double           = 8401;      // coverage
        public const int F_mult_float            = 8402;       // coverage
        public const int F_mult_int              = 8403;         // coverage
        public const int F_mult_long             = 8404;        // coverage
        public const int F_mult_short            = 8405;       // coverage

        public const int F_neg                   = 8600;       // non-leaf
        public const int F_neg_int               = 8601;
        public const int F_neg_long              = 8602;
        public const int F_neg_short             = 8603;
        public const int F_neg_float             = 8604;
        public const int F_neg_double            = 8605;

        public const int F_neq                   = 8800;                    // non-leaf  TestCaseNeq.cs
        public const int F_neq_bool              = 8801;         // covered
        public const int F_neq_char              = 8802;         // covered
        public const int F_neq_int               = 8803;          // covered
        public const int F_neq_long              = 8804;         // covered
        public const int F_neq_short             = 8805;        // covered
        public const int F_neq_string            = 8806;       // covered

        public const int F_odd                   = 8900;

        public const int F_random                = 9000;  // non-leaf
        public const int F_random_range          = 9001;
        public const int F_random_count          = 9002;
        public const int F_random_range_count    = 9003;

        public const int F_range                 = 9200;                  // non-leaf  TestCaseRange.cs
        public const int F_range_start_end       = 9210;      // covered
        public const int F_range_start_end_step  = 9212; // covered
        public const int F_range_end             = 9214;            // covered

        public const int F_sqr                   = 9400;                    // non-leaf  TestCaseSqr.cs
        public const int F_sqr_double            = 9401;       // covered
        public const int F_sqr_float             = 9402;        // covered
        public const int F_sqr_int               = 9403;          // covered
        public const int F_sqr_long              = 9404;         // covered
        public const int F_sqr_short             = 9405;        // covered

        public const int F_sqrt                  = 9500;                   // non-leaf
        public const int F_sqrt_double           = 9501;
        public const int F_sqrt_float            = 9502;

        public const int F_sub                   = 9600;                    // non-leaf  TestCaseSub.cs
        public const int F_sub_double            = 9601;       // covered
        public const int F_sub_float             = 9602;        // covered
        public const int F_sub_int               = 9603;          // covered
        public const int F_sub_long              = 9604;         // covered
        public const int F_sub_short             = 9605;        // covered

        public const int F_T                     = 9800;                      // non-leaf

        public const int F_T_all                 = 9900;            // covered
        public const int F_T_always              = 9910;         // covered
        public const int F_T_any                 = 9920;              // covered

        public const int F_T_collection                        = 10000;   // non-leaf
        public const int F_T_collection_array                  = 10001; // non-leaf
        public const int F_T_collection_array_set_item         = 10002;
        public const int F_T_collection_array_get_item         = 10003;
        public const int F_T_collection_list                   = 10004; // non-leaf
        public const int F_T_collection_list_add_non_null_item = 10005;
        public const int F_T_collection_list_add_item          = 10006;

        public const int F_T_combination         = 10200; // non-leaf
        public const int F_T_combination_combine = 10210;

        public const int F_T_compliment               = 10300; // non-leaf
        public const int F_T_compliment_not_predicate = 10302;
        public const int F_T_compliment_swap_params   = 10304;

        public const int F_T_dictionary                             = 10400;     // non-leaf
        public const int F_T_dictionary_extract_values_key_string   = 10410;
        public const int F_T_dictionary_extract_values_key_sequence = 10412;

        public const int F_T_each                = 10500;                 // non-leaf  TestCaseEach.cs
        public const int F_T_each_naked          = 10502;     // covered
        public const int F_T_each_U              = 10504;
        public const int F_T_each_U_V            = 10506;
        public const int F_T_each_U_V_W          = 10508;
        public const int F_T_each_U_V_W_X        = 10510;
        public const int F_T_each_U_V_Acc        = 10512;

        public const int F_T_filter              = 10600;         // covered
        public const int F_T_find                = 10700;           // covered
        public const int F_T_first               = 10800;          // covered
        public const int F_T_flatten             = 10900;        // covered

        public const int F_T_forever                 = 11100;              // non-leaf
        public const int F_T_forever_item            = 11110;      // non-leaf
        public const int F_T_forever_item_one        = 11112;
        public const int F_T_forever_item_two        = 11114;
        public const int F_T_forever_item_three      = 11116;
        public const int F_T_forever_item_four       = 11118;
        public const int F_T_forever_item_five       = 11120;
        public const int F_T_forever_item_six        = 11122;
        public const int F_T_forever_sequence        = 11124;
        public const int F_T_forever_function        = 11200;  // non-leaf
        public const int F_T_forever_function_simple = 11201;

        public const int F_T_Func                    = 11300; // non-leaf
        public const int F_T_Func_action             = 11310; // non-leaf
        public const int F_T_Func_action_one_item    = 11312;
        public const int F_T_Func_action_two_items   = 11314;
        public const int F_T_Func_action_three_items = 11316;
        public const int F_T_Func_action_four_items  = 11318;
        public const int F_T_Func_action_five_items  = 11320;
        public const int F_T_Func_action_six_items   = 11322;
        public const int F_T_Func_action_sequence    = 11324;
        public const int F_T_Func_action_action      = 11326;
        public const int F_T_Func_func               = 11400; // non-leaf
        public const int F_T_Func_func_no_items      = 11410;
        public const int F_T_Func_func_one_item      = 11412;
        public const int F_T_Func_func_two_items     = 11414;
        public const int F_T_Func_func_three_items   = 11416;
        public const int F_T_Func_func_four_items    = 11418;
        public const int F_T_Func_func_five_items    = 11420;
        public const int F_T_Func_func_six_items     = 11422;
        public const int F_T_Func_func_sequence      = 11424;
        public const int F_T_Func_func_func          = 11426;

        public const int F_T_identity            = 11500;
        public const int F_T_iterate_while       = 11600;  // covered
        public const int F_T_limit               = 11700;

        public const int F_T_map                 = 12000;                  // non-leaf  TestCaseMap
        public const int F_T_map_U               = 12002;          // covered
        public const int F_T_map_U_V             = 12004;
        public const int F_T_map_U_V_W           = 12006;
        public const int F_T_map_U_V_W_X         = 12008;
        public const int F_T_map_U_2_List        = 12010;   // covered
        public const int F_T_map_U_3_List        = 12012;   // covered

        public const int F_T_reduce              = 12100;               // non-leaf  TestCaseRecude.cs
        public const int F_T_reduce_init         = 12102;    // covered
        public const int F_T_reduce_naked        = 12104;   // covered
        public const int F_T_reduce_U_init       = 12106;  // covered

        public const int F_T_rest                = 12200;           // covered
        public const int F_T_same                = 12300;

        public const int F_T_sequence                   = 12400;  // non-leaf
        public const int F_T_sequence_one_item          = 12402;
        public const int F_T_sequence_two_items         = 12404;
        public const int F_T_sequence_three_items       = 12406;
        public const int F_T_sequence_four_items        = 12408;
        public const int F_T_sequence_five_items        = 12410;
        public const int F_T_sequence_six_items         = 12412;
        public const int F_T_sequence_item_sequence     = 12414;
        public const int F_T_sequence_sequence_item     = 12416;
        public const int F_T_sequence_one_sequence      = 12418;
        public const int F_T_sequence_two_sequences     = 12420;
        public const int F_T_sequence_three_sequences   = 12422;
        public const int F_T_sequence_four_sequences    = 12424;
        public const int F_T_sequence_five_sequences    = 12426;
        public const int F_T_sequence_six_sequences     = 12428;
        public const int F_T_sequence_seq_of_seq        = 12430;
        public const int F_T_sequence_seq_of_seq_of_seq = 12432;


        public const int F_T_sort                = 12500;                 // non-leaf  TestCaseSort.cs
        public const int F_T_sort_naked          = 12510;     // covered
        public const int F_T_sort_order_by       = 12520;  // covered
        public const int F_T_sort_bubble         = 12530;

        public const int F_T_task                = 12700;  // non-leaf
        public const int F_T_task_task           = 12710;
        public const int F_T_toString            = 12720;
        public const int F_T_transform           = 12800;

        public const int F_task                    = 12900; // non-leaf
        public const int F_task_action             = 12910;
        public const int F_task_bool_async         = 12912;
        public const int F_task_true_async         = 12914;
        public const int F_task_false_async        = 12916;
        public const int F_task_always_async       = 12918;
        public const int F_task_always_true_async  = 12920;
        public const int F_task_always_false_async = 12922;

        public const int GPS                     = 14000;  // non-leaf
        public const int GPS_NMEA                = 14010;  // non-leaf
        public const int GPS_NMEA_Parse          = 14040;  // non-leaf
        public const int GPS_NMEA_Parse_GPGGA    = 14041;
        public const int GPS_NMEA_Parse_GPGSA    = 14042;
        public const int GPS_NMEA_Parse_GPGSV    = 14043;
        public const int GPS_NMEA_Parse_GPRMC    = 14044;
        public const int GPS_NMEA_Parse_GPGLL    = 14045;
        public const int GPS_NMEA_Parse_GPVTG    = 14046;
        public const int GPS_NMEA_Parse_GPWPL    = 14047;
        public const int GPS_NMEA_Parse_GPAAM    = 14048;
        public const int GPS_NMEA_Parse_GPAPB    = 14049;
        public const int GPS_NMEA_Parse_GPBOD    = 14050;
        public const int GPS_NMEA_Parse_GPBWC    = 14051;
        public const int GPS_NMEA_Parse_GPRMB    = 14052;
        public const int GPS_NMEA_Parse_GPRTE    = 14053;
        public const int GPS_NMEA_Parse_GPXTE    = 14054;
        public const int GPS_NMEA_Parse_GPALM    = 14055;
        public const int GPS_NMEA_Parse_HCHDG    = 14056;  // garmin compass
        public const int GPS_NMEA_Parse_GPZDA    = 14057;
        public const int GPS_NMEA_Parse_GPMSK    = 14058;
        public const int GPS_NMEA_Parse_GPMSS    = 14059;     // beacon receiver status
        public const int GPS_NMEA_Parse_PGRME    = 14060;     // garmin 
        public const int GPS_NMEA_Parse_PGRMZ    = 14061;     // garmin
        public const int GPS_NMEA_Parse_PSLIB    = 14062;     // starlink. $PSLIB,320.0,200*59 to set the DBR to 320 KHz, 200 b/s.
        public const int GPS_NMEA_Parse_PMGNST   = 14063;    // magellan
        public const int GPS_NMEA_Parse_PMGNTRK  = 14064;   // magellin
        public const int GPS_NMEA_Parse_PMOTG    = 14065;   // motorola
        public const int GPS_NMEA_Parse_PRWIRID  = 14066;   // rockwell
        public const int GPS_NMEA_Parse_PRWIILOG = 14067;  // rockwell
        public const int GPS_NMEA_Parse_PRWIINIT = 14068;  // rockwell

        public const int LandMine                = 15000; // non-leaf
        public const int LandMine_inc            = 15010; // covered

        public const int Lang                               = 17000;                  // non-leaf
        public const int Lang_Character                     = 17100;        // covered
        public const int Lang_CharacterStream               = 17110;  // covered
        public const int Lang_Editor                        = 17400;
        public const int Lang_Editor_CodeDocument           = 17410;
        public const int Lang_Editor_CodeDocument_AddFirst  = 17412;
        public const int Lang_Editor_CodeDocument_AddBefore = 17414;
        public const int Lang_Editor_CodeDocument_AddAfter  = 17416;
        public const int Lang_Editor_CodeDocument_MovePrev  = 17418;
        public const int Lang_Editor_CodeDocument_MoveNext  = 17420;
        public const int Lang_Editor_CodeLine               = 17500;  // covered
        public const int Lang_Editor_CodeLine_AddFirst      = 17502;
        public const int Lang_Editor_CodeLine_AddBefore     = 17504;
        public const int Lang_Editor_CodeLine_AddAfter      = 17506;
        public const int Lang_Editor_CodeLine_MovePrev      = 17508;
        public const int Lang_Editor_CodeLine_MoveNext      = 17510;



        public const int Lang_Editor_Token       = 17600;

        public const int Lang_Editor_AutoComplete          = 17700;  // non-leaf
        public const int Lang_Editor_AutoComplete_Add_Item = 17710;
        // no removal of items

        public const int Lang_Memory_Manager                   = 18000 ;                     // non-leaf
        public const int Lang_Memory_Manager_ICharacter        = 18100;          // non-leaf
        public const int Lang_Memory_Manager_ICharacter_New    = 18102;
        public const int Lang_Memory_Manager_ICharacter_Delete = 18104;
        public const int Lang_Memory_Manager_IToken            = 18106;              // non-leaf
        public const int Lang_Memory_Manager_IToken_New        = 18108;
        public const int Lang_Memory_Manager_IToken_Delete     = 18110;
        public const int Lang_Memory_Manager_ICodeLine         = 18200;           // non-leaf
        public const int Lang_Memory_Manager_ICodeLine_New     = 18202;
        public const int Lang_Memory_Manager_ICodeLine_Delete  = 18204;
        public const int Lang_Memory_Manager_ILocation         = 18300;           // non-leaf
        public const int Lang_Memory_Manager_ILocation_New     = 18302;
        public const int Lang_Memory_Manager_ILocation_Delete  = 18304;

        public const int Lang_Parser                           = 19000;                 // non-leaf
        public const int Lang_Parser_Lexer                     = 19100;           // non-leaf
        public const int Lang_Parser_Lexer_Token               = 19200;     // non=leaf

        public const int Lang_Parser_Lexer_Token_Unknown                   = 19210;
        public const int Lang_Parser_Lexer_Token_Dot                       = 19212;
        public const int Lang_Parser_Lexer_Token_Dash                      = 19214;
        public const int Lang_Parser_Lexer_Token_Comma                     = 19216;
        public const int Lang_Parser_Lexer_Token_Open_Paren                = 19218;
        public const int Lang_Parser_Lexer_Token_Close_Paren               = 19220;
        public const int Lang_Parser_Lexer_Token_Open_Sq                   = 19222;
        public const int Lang_Parser_Lexer_Token_Close_Sq                  = 19224;
        public const int Lang_Parser_Lexer_Token_Punctuation               = 19226;
        public const int Lang_Parser_Lexer_Token_UnquotedWord              = 19228;
        public const int Lang_Parser_Lexer_Token_LiteralInteger            = 19230;
        public const int Lang_Parser_Lexer_Token_LiteralInteger_Negative   = 19232;
        public const int Lang_Parser_Lexer_Token_LiteralFloat              = 19234;
        public const int Lang_Parser_Lexer_Token_LiteralFloat_Negative     = 19236;
        public const int Lang_Parser_Lexer_Token_LiteralString             = 19238;
        public const int Lang_Parser_Lexer_Token_OneOrMoreSpace            = 19240;
        public const int Lang_Parser_Lexer_Token_OneOrMoreSpace_OneSpace   = 19242;
        public const int Lang_Parser_Lexer_Token_OneOrMoreSpace_TwoSpace   = 19244;
        public const int Lang_Parser_Lexer_Token_OneOrMoreSpace_ThreeSpace = 19246;
        public const int Lang_Parser_Lexer_Token_CarrageReturn             = 19248;
        public const int Lang_Parser_Lexer_Token_LineFeed                  = 19250;
        public const int Lang_Parser_Lexer_Token_NULL                      = 19252;

        public const int Logger                  = 26000; // non-leaf
        public const int Logger_Null             = 26010;
        public const int Logger_File             = 26020;
        public const int Logger_Console          = 26030;

        public const int Option                  = 26100; // non-leaf
        public const int Option_bind             = 26110;
        public const int Option_count            = 26120;
        public const int Option_exists           = 26130;
        public const int Option_forall           = 26140;
        public const int Option_get              = 26150;
        public const int Option_iter             = 26160;
        public const int Option_None             = 26170;
        public const int Option_Some             = 26180;
        public const int Option_toArray          = 26190;
        public const int Option_toList           = 26200;

        public const int Tuple                      = 27000; // non-leaf
        public const int Tuple_A_B                  = 27010; // non-leaf
        public const int Tuple_A_B_first            = 27011;   // covered
        public const int Tuple_A_B_second           = 27012;   // covered
        public const int Tuple_A_B_Extract          = 27013;   // covered
        public const int Tuple_A_B_C                = 27020; // non-leaf
        public const int Tuple_A_B_C_first          = 27021;   // covered
        public const int Tuple_A_B_C_second         = 27022;   // covered
        public const int Tuple_A_B_C_third          = 27023;   // covered
        public const int Tuple_A_B_C_Extract        = 27024;   // covered
        public const int Tuple_A_B_C_D              = 27030; // non-leaf
        public const int Tuple_A_B_C_D_first        = 27031;   // covered
        public const int Tuple_A_B_C_D_second       = 27032;   // covered
        public const int Tuple_A_B_C_D_third        = 27033;   // covered
        public const int Tuple_A_B_C_D_fourth       = 27034;   // covered
        public const int Tuple_A_B_C_D_Extract      = 27035;   // covered
        public const int Tuple_A_B_C_D_E            = 27040; // non-leaf
        public const int Tuple_A_B_C_D_E_first      = 27041;   // covered
        public const int Tuple_A_B_C_D_E_second     = 27042;   // covered
        public const int Tuple_A_B_C_D_E_third      = 27043;   // covered
        public const int Tuple_A_B_C_D_E_fourth     = 27044;   // covered
        public const int Tuple_A_B_C_D_E_fifth      = 27045;   // covered
        public const int Tuple_A_B_C_D_E_Extract    = 27046;   // covered
        public const int Tuple_A_B_C_D_E_F          = 27050; // non-leaf
        public const int Tuple_A_B_C_D_E_F_first    = 27051;   // covered
        public const int Tuple_A_B_C_D_E_F_second   = 27052;   // covered
        public const int Tuple_A_B_C_D_E_F_third    = 27053;   // covered
        public const int Tuple_A_B_C_D_E_F_fourth   = 27054;   // covered
        public const int Tuple_A_B_C_D_E_F_fifth    = 27055;   // covered
        public const int Tuple_A_B_C_D_E_F_sixth    = 27056;   // covered
        public const int Tuple_A_B_C_D_E_F_Extract  = 27057;   // covered




        public const int Utility                 = 28000;                  // non-leaf
        public const int Utility_char_to_digit   = 28010;

    }
}