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
    public interface IOption<T> : IEnumerable<T> { // inspired by F# Option
        T Value { get; }
        bool IsSome { get; }
        bool IsNone { get; }
    }
    public enum LoggerKind { Null, Console, FileName, File, TextWriter, HttpPost, UI }
    public interface ILogManager {
        IEnumerable<ILogger> Loggers { get; }
        Task Log(string info);
        Task Log(LoggerKind kind, string info);
    }
    public interface ILogger : IDisposable {
        IEnumerable<LoggerKind> Kind { get; }
        Task ConfigureAsync(IDictionary<string, object> config);
        Task LogAsync(string info); 
    }
}
namespace Functional.Test {
    public static class TestCoverage {
        public const int Test_All                                             =    100;                 // non-leaf
        public const int Test_Integration                                     =    200;         // non-leaf

        public const int bool_                                                =    500;                    // non-leaf  TestCaseBool
        public const int bool_And                                             =    504;          // covered
        public const int bool_Or                                              =    506;           // covered
        
        public const int Chain                                                =    600; // TODO break this to more items
        public const int Converter_char_to_digit                              =    700;
        public const int Converter_digit_to_char                              =    702;
        public const int Converter_string_to_bool                             =    704;
        public const int Converter_string_to_double                           =    706;
        public const int Converter_string_to_float                            =    708;
        public const int Converter_string_to_int                              =    710;
        public const int Converter_string_to_long                             =    712;
        public const int Converter_string_to_short                            =    714;
        public const int Converter_toString_seq_T                             =    716;
        public const int Converter_toString_T                                 =    718;
        public const int Curry                                                =    800;   // non-leaf
        public const int Curry_curry                                          =    802;
        public const int Curry_curry1                                         =    804;
        public const int Curry_curry2                                         =    806;
        public const int Curry_monster                                        =    808;
        public const int F_ALL_TESTS                                          =   1000;
        public const int F                                                    =   1100;                       // non-leaf
        public const int F_add                                                =   1110;                    // non-leaf TestCaseAdd.cs
        public const int F_add_double                                         =   1112;       // covered
        public const int F_add_float                                          =   1114;        // covered
        public const int F_add_int                                            =   1116;          // covered
        public const int F_add_long                                           =   1118;         // covered
        public const int F_add_short                                          =   1120;        // covered
        public const int F_add_string                                         =   1122;       // covered
        public const int F_all_T                                              =   1200;            // covered
        public const int F_always                                             =   1220;                 // non-leaf  TestCaseAlways
        public const int F_always_false                                       =   1222;     // covered
        public const int F_always_true                                        =   1224;      // covered
        public const int F_always_T                                           =   1226; // covered
        public const int F_any_T                                              =   1230;
        public const int F_bool                                               =   1250;                   // non-leaf  TestCaseBool.cs
        public const int F_bool_and                                           =   1252;         // covered
        public const int F_bool_eqv                                           =   1254;         // covered
        public const int F_bool_not                                           =   1256;         // not covered
        public const int F_bool_or                                            =   1258;          // covered
        public const int F_bool_xor                                           =   1260;         // covered
        public const int F_chars                                              =   1270;            // covered  TestCase.cs
        public const int F_clamp                                              =   1280;            // non-leaf
        public const int F_clamp_float                                        =   1282;      // non-leaf
        public const int F_clamp_float_scaler                                 =   1284;
        public const int F_clamp_float_seq                                    =   1286;
        public const int F_clamp_double                                       =   1288;     // non-leaf
        public const int F_clamp_double_scaler                                =   1290;
        public const int F_clamp_double_seq                                   =   1292;
        public const int F_clamp_int_scaler                                   =   1294;
        public const int F_clamp_int_seq                                      =   1296;
        public const int F_clamp_short_scaler                                 =   1298;
        public const int F_clamp_short_seq                                    =   1300;
        public const int F_clamp_long_scaler                                  =   1302;
        public const int F_clamp_long_seq                                     =   1304;
        public const int F_clamp_ushort_scaler                                =   1306;
        public const int F_clamp_ushort_seq                                   =   1308;
        public const int F_close                                              =   1320;                 // non-leaf  TestCaseClose.cs
        public const int F_close_double                                       =   1322;     // covered
        public const int F_close_float                                        =   1324;      // covered
        public const int F_collection_list                                    =   1340; // non-leaf
        public const int F_collection_array_get_item_T                        =   1342;
        public const int F_collection_array_set_item_T                        =   1344;
        public const int F_collection_list_add_item_T                         =   1346;
        public const int F_collection_list_add_non_duplicate_item_T           =   1348;
        public const int F_collection_list_add_non_duplicate_item_EQUALITY_T  =   1350;
        public const int F_collection_list_add_non_null_item_T                =   1352;
        public const int F_combination                                        =   1360; // non-leaf
        public const int F_combination_combine_TU                             =   1362;
        public const int F_compare                                            =   1364;                // non-leaf  TestCaseCompare.cs
        public const int F_compare_bool                                       =   1366;     // covered
        public const int F_compare_char                                       =   1368;     // covered
        public const int F_compare_int                                        =   1370;      // covered
        public const int F_compare_long                                       =   1372;     // covered
        public const int F_compare_short                                      =   1374;    // covered
        public const int F_compare_string                                     =   1376;   // covered
        public const int F_compare_string_insensative                         =   1378; // covered
        public const int F_compliment_T                                       =   1380; // non-leaf
        public const int F_compliment_not_predicate_T                         =   1382;
        public const int F_compliment_swap_params_T                           =   1384;
        public const int F_compliment_swap_type_TUV                           =   1386;
        public const int F_count                                              =   1390; // not covered
        public const int F_count_filter_T                                     =   1392;
        public const int F_count_naked_T                                      =   1394;
        public const int F_count_predicate_T                                  =   1395;
        public const int F_dictionary                                        =   1396;  // non-leaf
        public const int F_dictionary_extract_values_key_string_T             =   1397;
        public const int F_dictionary_extract_values_key_sequence_T           =   1398;
        public const int F_donothing                                          =   1400; // non-leaf
        public const int F_donothing_0_inputs                                 =   1402;
        public const int F_donothing_1_inputs                                 =   1404;
        public const int F_donothing_2_inputs                                 =   1406;
        public const int F_donothing_3_inputs                                 =   1408;
        public const int F_donothing_4_inputs                                 =   1410;
        public const int F_donothing_sequence                                 =   1412;
        public const int F_donothing_TU                                       =   1414;
        public const int F_donothing_TUV                                      =   1416; 
        public const int F_each_T                                             =   1450;     // non-leaf  TestCaseEach.cs
        public const int F_each_naked_T                                       =   1452;     // covered
        public const int F_each_TU                                            =   1454;
        public const int F_each_TUV                                           =   1456;
        public const int F_each_TUVW                                          =   1458;
        public const int F_each_TUVWX                                         =   1460;
        public const int F_each_TUV_Acc                                       =   1462;
        public const int F_equ                                                =   1480;                    // non-leaf  TestCaseEqu.cs
        public const int F_equ_bool                                           =   1482;         // covered
        public const int F_equ_char                                           =   1484;         // covered
        public const int F_equ_int                                            =   1486;          // covered
        public const int F_equ_long                                           =   1488;         // covered
        public const int F_equ_short                                          =   1490;        // covered
        public const int F_equ_string                                         =   1492;       // covered
        public const int F_even                                               =   1500;
        public const int F_extract                                            =   1510;      // non-leaf
        public const int F_extract_1_T                                        =   1512;  // covered
        public const int F_extract_2_T                                        =   1514;  // covered
        public const int F_extract_3_T                                        =   1516;  // covered
        public const int F_extract_4_T                                        =   1518;  // covered
        public const int F_extract_5_T                                        =   1520;  // covered
        public const int F_extract_6_T                                        =   1522;  // covered
        public const int F_filter_T                                           =   1530;         // covered
        public const int F_find_T                                             =   1540;           // covered
        public const int F_first_T                                            =   1550;          // covered
        public const int F_flatten_T                                          =   1560;        // covered
        public const int F_forever_T                                          =   1562;              // non-leaf
        public const int F_forever_item_T                                     =   1564;      // non-leaf
        public const int F_forever_item_1_T                                   =   1566;
        public const int F_forever_item_2_T                                   =   1568; 
        public const int F_forever_item_3_T                                   =   1570;
        public const int F_forever_item_4_T                                   =   1572;
        public const int F_forever_item_5_T                                   =   1574;
        public const int F_forever_item_6_T                                   =   1576;
        public const int F_forever_sequence_T                                 =   1578;
        public const int F_forever_function_T                                 =   1580;  // non-leaf
        public const int F_forever_function_simple_T                          =   1582;
        public const int F_func_T                                             =   1600; // non-leaf
        public const int F_func_action_T                                      =   1602; // non-leaf
        public const int F_func_action_1_arguments_T                          =   1604;
        public const int F_func_action_2_arguments_T                          =   1606; 
        public const int F_func_action_3_arguments_T                          =   1608;
        public const int F_func_action_4_arguments_T                          =   1610;
        public const int F_func_action_5_arguments_T                          =   1612;
        public const int F_func_action_6_arguments_T                          =   1614;
        public const int F_func_action_sequence_T                             =   1618;
        public const int F_func_action_action_T                               =   1620;
        public const int F_func_func_T                                        =   1622; // non-leaf
        public const int F_func_func_0_arguments_T                            =   1624;
        public const int F_func_func_1_arguments_T                            =   1626;
        public const int F_func_func_2_arguments_T                            =   1628;
        public const int F_func_func_3_arguments_T                            =   1630;
        public const int F_func_func_4_arguments_T                            =   1632;
        public const int F_func_func_5_arguments_T                            =   1634;
        public const int F_func_func_6_arguments_T                            =   1636;
        public const int F_func_func_sequence_T                               =   1638;
        public const int F_func_func_func_T                                   =   1640;
        public const int F_gt                                                 =   1650;                     // non-leaf  TestCaseGt.cs
        public const int F_gt_double                                          =   1652;        // covered
        public const int F_gt_float                                           =   1654;         // covered
        public const int F_gt_int                                             =   1656;           // covered
        public const int F_gt_long                                            =   1658;          // covered
        public const int F_gt_short                                           =   1660;         // covered
        public const int F_gte                                                =   1670;                    // non-leaf  TestCaseGte.cs
        public const int F_gte_int                                            =   1672;          // covered
        public const int F_gte_long                                           =   1674;         // covered
        public const int F_gte_short                                          =   1676;        // covered
        public const int F_identity_T                                         =   1690;
        public const int F_inc                                                =   1700;                    // non-leaf
        public const int F_inc_int                                            =   1702;
        public const int F_inc_long                                           =   1704;          //
        public const int F_inc_short                                          =   1706;
        public const int F_infinite                                           =   1710; // non-leaf
        public const int F_infinite_bool_toggle                               =   1712;
        public const int F_infinite_range                                     =   1714; // non-leaf
        public const int F_infinite_range_int_start_inc                       =   1716;
        public const int F_iterate_while_T                                    =   1720; // covered
        public const int F_limit_T                                            =   1730;
        public const int F_lt                                                 =   1740;                     // non-leaf  TestCaseLt.cs
        public const int F_lt_double                                          =   1742;        // covered
        public const int F_lt_float                                           =   1744;         // covered
        public const int F_lt_int                                             =   1746;           // covered
        public const int F_lt_long                                            =   1748;          // covered
        public const int F_lt_short                                           =   1750;         // covered
        public const int F_lte                                                =   1760;                    // non-leaf  TestCaseLte.cs
        public const int F_lte_int                                            =   1762;          // covered
        public const int F_lte_long                                           =   1764;         // covered
        public const int F_lte_short                                          =   1766;        // covered
        public const int F_map_T                                              =   1770;                  // non-leaf  TestCaseMap
        public const int F_map_TU                                             =   1772;          // covered
        public const int F_map_TUV                                            =   1774;
        public const int F_map_TUVW                                           =   1776;
        public const int F_map_TUVWX                                          =   1778;
        public const int F_map_TU_2_List                                      =   1780;   // covered
        public const int F_map_TU_3_List                                      =   1782;   // covered
        public const int F_max                                                =   1800;                    // non-leaf  TestCaseMax.cs
        public const int F_max_double                                         =   1802;       // covered
        public const int F_max_float                                          =   1804;        // covered
        public const int F_max_int                                            =   1806;          // covered
        public const int F_max_long                                           =   1808;         // covered
        public const int F_max_short                                          =   1810;        // covered
        public const int F_min                                                =   1820;                    // non-leaf  TestCaseMin.cs
        public const int F_min_double                                         =   1822;       // covered
        public const int F_min_float                                          =   1824;        // covered
        public const int F_min_int                                            =   1826;          // covered
        public const int F_min_long                                           =   1828;         // covered
        public const int F_min_short                                          =   1830;        // covered
        public const int F_mult                                               =   1840;                   // non-leaf  TestCaseMult.cs
        public const int F_mult_double                                        =   1842;      // coverage
        public const int F_mult_float                                         =   1844;       // coverage
        public const int F_mult_int                                           =   1846;         // coverage
        public const int F_mult_long                                          =   1848;        // coverage
        public const int F_mult_short                                         =   1850;       // coverage
        public const int F_neg                                                =   1860;       // non-leaf
        public const int F_neg_int                                            =   1862;
        public const int F_neg_long                                           =   1864;
        public const int F_neg_short                                          =   1866;
        public const int F_neg_float                                          =   1868;
        public const int F_neg_double                                         =   1870;
        public const int F_neq                                                =   1880;                    // non-leaf  TestCaseNeq.cs
        public const int F_neq_bool                                           =   1882;         // covered
        public const int F_neq_char                                           =   1884;         // covered
        public const int F_neq_int                                            =   1886;          // covered
        public const int F_neq_long                                           =   1888;         // covered
        public const int F_neq_short                                          =   1890;        // covered
        public const int F_neq_string                                         =   1892;       // covered
        public const int F_odd                                                =   1900;
        public const int F_random                                             =   9000;  // non-leaf
        public const int F_random_range                                       =   9001;
        public const int F_random_count                                       =   9002;
        public const int F_random_range_count                                 =   9003;
        public const int F_range                                              =   9200;                  // non-leaf  TestCaseRange.cs
        public const int F_range_start_end                                    =   9210;      // covered
        public const int F_range_start_end_step                               =   9212; // covered
        public const int F_range_end                                          =   9214;            // covered
        public const int F_reduce                                             =   9300;
        public const int F_reduce_better_TU                                   =   9302;
        public const int F_reduce_init_T                                      =   9304;
        public const int F_reduce_init_TU                                     =   9306;
        public const int F_reduce_naked_T                                     =   9308;
        public const int F_rest_T                                             =   9320;           // covered
        public const int F_same_seq_T                                         =   9330;
        public const int F_same_seq_TU                                        =   9332;
        public const int F_same_TU                                            =   9334;
        public const int F_sequence_T                                         =   9350;  // non-leaf 
        public const int F_sequence_0_items_T                                 =   9352;
        public const int F_sequence_1_items_T                                 =   9354;
        public const int F_sequence_2_items_T                                 =   9356;
        public const int F_sequence_3_items_T                                 =   9358;
        public const int F_sequence_4_items_T                                 =   9360;
        public const int F_sequence_5_items_T                                 =   9362;
        public const int F_sequence_6_items_T                                 =   9364;
        public const int F_sequence_item_sequence_T                           =   9366;
        public const int F_sequence_sequence_item_T                           =   9368;
        public const int F_sequence_1_sequence_T                              =   9370;
        public const int F_sequence_2_sequences_T                             =   9372;
        public const int F_sequence_3_sequences_T                             =   9374;
        public const int F_sequence_4_sequences_T                             =   9376;
        public const int F_sequence_5_sequences_T                             =   9378;
        public const int F_sequence_6_sequences_T                             =   9380;
        public const int F_sequence_seq_of_seq_T                              =   9382;
        public const int F_sequence_seq_of_seq_of_seq_T                       =   9384;
        public const int F_sort_T                                             =   9400;                 // non-leaf  TestCaseSort.cs
        public const int F_sort_naked_T                                       =   9402;     // covered
        public const int F_sort_order_by_T                                    =   9404;  // covered
        public const int F_sort_bubble_T                                      =   9406;
        public const int F_sort_merge_T                                       =   9408;
        public const int F_sqr                                                =   9420;                    // non-leaf  TestCaseSqr.cs
        public const int F_sqr_double                                         =   9422;       // covered
        public const int F_sqr_float                                          =   9424;        // covered
        public const int F_sqr_int                                            =   9426;          // covered
        public const int F_sqr_long                                           =   9428;         // covered
        public const int F_sqr_short                                          =   9430;        // covered
        public const int F_sqrt                                               =   9440;                   // non-leaf
        public const int F_sqrt_double                                        =   9442;
        public const int F_sqrt_float                                         =   9444;
        public const int F_sub                                                =   9450;                    // non-leaf  TestCaseSub.cs
        public const int F_sub_double                                         =   9452;       // covered
        public const int F_sub_float                                          =   9454;        // covered
        public const int F_sub_int                                            =   9456;          // covered
        public const int F_sub_long                                           =   9458;         // covered
        public const int F_sub_short                                          =   9460;        // covered
        public const int F_transform_TU                                       =   9480;
        public const int F_T                                                  =   9500;  // non-leaf


        public const int FileUtility_DeleteFile                               =   9600;
        public const int FileUtility_FileExists                               =   9602;
        public const int FileUtility_FileLength                                =  9604;






        public const int F_T_dictionary                                       = 10400;     // non-leaf
        public const int F_T_dictionary_extract_values_key_string             = 10410;
        public const int F_T_dictionary_extract_values_key_sequence           = 10412;













        public const int F_task_T                                             = 12700;  // non-leaf
        public const int F_task_task_T                                      = 12710;

        public const int F_T_transform                                        = 12800;
        public const int F_task                                               = 12900; // non-leaf
        public const int F_task_action                                        = 12903;

        public const int GPS                                                  = 14000;  // non-leaf
        public const int GPS_NMEA                                             = 14010;  // non-leaf
        public const int GPS_NMEA_Parse                                       = 14040;  // non-leaf
        public const int GPS_NMEA_Parse_GPGGA                                 = 14041;  // covered
        public const int GPS_NMEA_Parse_GPGSA                                 = 14042; // covered
        public const int GPS_NMEA_Parse_GPGSV                                 = 14043; // covered
        public const int GPS_NMEA_Parse_GPRMC                                 = 14044; // covered
        public const int GPS_NMEA_Parse_GPGLL                                 = 14045;
        public const int GPS_NMEA_Parse_GPVTG                                 = 14046;
        public const int GPS_NMEA_Parse_GPWPL                                 = 14047;
        public const int GPS_NMEA_Parse_GPAAM                                 = 14048;
        public const int GPS_NMEA_Parse_GPAPB                                 = 14049;
        public const int GPS_NMEA_Parse_GPBOD                                 = 14050;
        public const int GPS_NMEA_Parse_GPBWC                                 = 14051;
        public const int GPS_NMEA_Parse_GPRMB                                 = 14052;
        public const int GPS_NMEA_Parse_GPRTE                                 = 14053;
        public const int GPS_NMEA_Parse_GPXTE                                 = 14054;
        public const int GPS_NMEA_Parse_GPALM                                 = 14055;
        public const int GPS_NMEA_Parse_HCHDG                                 = 14056;  // garmin compass
        public const int GPS_NMEA_Parse_GPZDA                                 = 14057;
        public const int GPS_NMEA_Parse_GPMSK                                 = 14058;
        public const int GPS_NMEA_Parse_GPMSS                                 = 14059;     // beacon receiver status
        public const int GPS_NMEA_Parse_PGRME                                 = 14060;     // garmin 
        public const int GPS_NMEA_Parse_PGRMZ                                 = 14061;     // garmin
        public const int GPS_NMEA_Parse_PSLIB                                 = 14062;     // starlink. $PSLIB,320.0,200*59 to set the DBR to 320 KHz, 200 b/s.
        public const int GPS_NMEA_Parse_PMGNST                                = 14063;    // magellan
        public const int GPS_NMEA_Parse_PMGNTRK                               = 14064;   // magellin
        public const int GPS_NMEA_Parse_PMOTG                                 = 14065;   // motorola
        public const int GPS_NMEA_Parse_PRWIRID                               = 14066;   // rockwell
        public const int GPS_NMEA_Parse_PRWIILOG                              = 14067;  // rockwell
        public const int GPS_NMEA_Parse_PRWIINIT                              = 14068;  // rockwell

        public const int LandMine                                             = 15000; // non-leaf
        public const int LandMine_inc                                         = 15010; // covered

        public const int Lang                                                 = 17000;                  // non-leaf
        public const int Lang_Character                                       = 17100;        // covered
        public const int Lang_CharacterStream                                 = 17110;  // covered
        public const int Lang_Editor                                          = 17400;
        public const int Lang_Editor_CodeDocument                             = 17410;
        public const int Lang_Editor_CodeDocument_AddFirst                    = 17412;
        public const int Lang_Editor_CodeDocument_AddBefore                   = 17414;
        public const int Lang_Editor_CodeDocument_AddAfter                    = 17416;
        public const int Lang_Editor_CodeDocument_MovePrev                    = 17418;
        public const int Lang_Editor_CodeDocument_MoveNext                    = 17420;
        public const int Lang_Editor_CodeLine                                 = 17500;  // covered
        public const int Lang_Editor_CodeLine_AddFirst                        = 17502;
        public const int Lang_Editor_CodeLine_AddBefore                       = 17504;
        public const int Lang_Editor_CodeLine_AddAfter                        = 17506;
        public const int Lang_Editor_CodeLine_MovePrev                        = 17508;
        public const int Lang_Editor_CodeLine_MoveNext                        = 17510;
        public const int Lang_Editor_Token                                    = 17600;
        public const int Lang_Editor_AutoComplete                             = 17700;  // non-leaf
        public const int Lang_Editor_AutoComplete_Add_Item                    = 17710; // no removal of items
        public const int Lang_Parser                                          = 19000;                 // non-leaf
        public const int Lang_Parser_Tokenizer                                = 19100;           // non-leaf
        public const int Lang_Parser_Tokenizer_Token                          = 19200;     // non=leaf
        public const int Lang_Parser_Tokenizer_Token_Unknown                  = 19210;
        public const int Lang_Parser_Tokenizer_Token_Dot                      = 19212;
        public const int Lang_Parser_Tokenizer_Token_Dash                     = 19214;
        public const int Lang_Parser_Tokenizer_Token_Comma                    = 19216;
        public const int Lang_Parser_Tokenizer_Token_Open_Paren               = 19218;
        public const int Lang_Parser_Tokenizer_Token_Close_Paren              = 19220;
        public const int Lang_Parser_Tokenizer_Token_Open_Sq                  = 19222;
        public const int Lang_Parser_Tokenizer_Token_Close_Sq                 = 19224;
        public const int Lang_Parser_Tokenizer_Token_Punctuation              = 19226;
        public const int Lang_Parser_Tokenizer_Token_UnquotedWord             = 19228;
        public const int Lang_Parser_Tokenizer_Token_LiteralInteger           = 19230;
        public const int Lang_Parser_Tokenizer_Token_LiteralInteger_Negative  = 19232;
        public const int Lang_Parser_Tokenizer_Token_LiteralFloat             = 19234;
        public const int Lang_Parser_Tokenizer_Token_LiteralFloat_Negative    = 19236;
        public const int Lang_Parser_Tokenizer_Token_LiteralString            = 19238;
        public const int Lang_Parser_Tokenizer_Token_OneOrMoreSpace           = 19240;
        public const int Lang_Parser_Tokenizer_Token_OneOrMoreSpace_1_Space   = 19242;
        public const int Lang_Parser_Tokenizer_Token_OneOrMoreSpace_2_Space   = 19244;
        public const int Lang_Parser_Tokenizer_Token_OneOrMoreSpace_3_Space   = 19246;
        public const int Lang_Parser_Tokenizer_Token_CarrageReturn            = 19248;
        public const int Lang_Parser_Tokenizer_Token_LineFeed                 = 19250;
        public const int Lang_Parser_Tokenizer_Token_NULL                     = 19252;
        public const int Lang_Parser_Parser                                   = 19300; // non-leaf
        public const int Lang_Parser_Parser_ParseFile                         = 19310;
        public const int Lang_Parser_Expression                               = 19320;
        public const int Lang_Parser_Expression_Comment                       = 19330;
        public const int Lang_Reflection                                      = 21000; // non-leaf
        public const int Lang_Reflection_Create_empty                         = 21030;
        public const int Lang_Reflection_Create_param                         = 21035;
        public const int Lang_Reflection_Create_type                          = 21060;
        public const int Lang_Reflection_GetMethod                            = 21062;
        public const int Lang_Reflection_GetType                              = 21070;
        public const int Lang_Reflection_InvokeMethod                         = 21100; // non-leaf
        public const int Lang_Reflection_InvokeInstanceMethod                 = 21105; // non-leaf
        public const int Lang_Reflection_InvokeInstanceNonVoidMethod          = 215040; // non-leaf
        public const int Lang_Reflection_InvokeInstanceNonVoidMethod_untyped  = 21107;
        public const int Lang_Reflection_InvokeInstanceNonVoidMethod_typed    = 1;
        public const int Lang_Reflection_InvokeInstanceVoidMethod             = 22000; // non-leaf
        public const int Lang_Reflection_InvokeInstanceVoidMethod_untyped     = 21120;
        public const int Lang_Reflection_InvokeInstanceVoidMethod_typed       = 21130;
        public const int Lang_Reflection_InvokeStaticMethod                   = 21200;  // non-leaf
        public const int Lang_Reflection_InvokeStaticNonVoidMethod            = 21210;  // non-leaf
        public const int Lang_Reflection_InvokeStaticNonVoidMethod_untyped    = 21220;
        public const int Lang_Reflection_InvokeStaticNonVoidMethod_typed      = 21230;
        public const int Lang_Reflection_InvokeStaticVoidMethod               = 21200;  // non-leaf
        public const int Lang_Reflection_InvokeStaticVoidMethod_untyped       = 21210;
        public const int Lang_Reflection_InvokeStaticVoidMethod_typed         = 21220;
        public const int Lang_Reflection_LoadAssembly                         = 21300; // non-leaf
        public const int Lang_Reflection_LoadAssembly_bare                    = 21310;
        public const int Lang_Tokenizer                                       = 22000; // non leaf
        public const int Lang_Tokenizer_File                                  = 22010;

        public const int Logger                                               = 26000; // non-leaf
        public const int Logger_Null                                          = 26010;
        public const int Logger_Filename                                      = 26020;
        public const int Logger_Console                                       = 26030;

        public const int Option                                               = 26100; // non-leaf
        public const int Option_bind                                          = 26110;
        public const int Option_count                                         = 26120;
        public const int Option_exists                                        = 26130;
        public const int Option_forall                                        = 26140;
        public const int Option_get                                           = 26150;
        public const int Option_iter                                          = 26160;
        public const int Option_None                                          = 26170;
        public const int Option_Some                                          = 26180;
        public const int Option_toArray                                       = 26190;
        public const int Option_toList                                        = 26200;

        public const int Task_Manager                                         = 26500; // non-leaf
        public const int Task_Manager_Throttle                                = 265010;

        public const int Tuple                                                = 27000; // non-leaf
        public const int Tuple_A_B                                            = 27010; // non-leaf
        public const int Tuple_A_B_first                                      = 27011;   // covered
        public const int Tuple_A_B_second                                     = 27012;   // covered
        public const int Tuple_A_B_Extract                                    = 27013;   // covered
        public const int Tuple_A_B_C                                          = 27020; // non-leaf
        public const int Tuple_A_B_C_first                                    = 27021;   // covered
        public const int Tuple_A_B_C_second                                   = 27022;   // covered
        public const int Tuple_A_B_C_third                                    = 27023;   // covered
        public const int Tuple_A_B_C_Extract                                  = 27024;   // covered
        public const int Tuple_A_B_C_D                                        = 27030; // non-leaf
        public const int Tuple_A_B_C_D_first                                  = 27031;   // covered
        public const int Tuple_A_B_C_D_second                                 = 27032;   // covered
        public const int Tuple_A_B_C_D_third                                  = 27033;   // covered
        public const int Tuple_A_B_C_D_fourth                                 = 27034;   // covered
        public const int Tuple_A_B_C_D_Extract                                = 27035;   // covered
        public const int Tuple_A_B_C_D_E                                      = 27040; // non-leaf
        public const int Tuple_A_B_C_D_E_first                                = 27041;   // covered
        public const int Tuple_A_B_C_D_E_second                               = 27042;   // covered
        public const int Tuple_A_B_C_D_E_third                                = 27043;   // covered
        public const int Tuple_A_B_C_D_E_fourth                               = 27044;   // covered
        public const int Tuple_A_B_C_D_E_fifth                                = 27045;   // covered
        public const int Tuple_A_B_C_D_E_Extract                              = 27046;   // covered
        public const int Tuple_A_B_C_D_E_F                                    = 27050; // non-leaf
        public const int Tuple_A_B_C_D_E_F_first                              = 27051;   // covered
        public const int Tuple_A_B_C_D_E_F_second                             = 27052;   // covered
        public const int Tuple_A_B_C_D_E_F_third                              = 27053;   // covered
        public const int Tuple_A_B_C_D_E_F_fourth                             = 27054;   // covered
        public const int Tuple_A_B_C_D_E_F_fifth                              = 27055;   // covered
        public const int Tuple_A_B_C_D_E_F_sixth                              = 27056;   // covered
        public const int Tuple_A_B_C_D_E_F_Extract                            = 27057;   // covered

        public const int Utility                                              = 28000;                  // non-leaf
        public const int Utility_char_to_digit                                = 28010;
        public const int Utility_crc16                                        = 28020;
        public const int Utility_crc16_func                                   = 28030;

    }
}