using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Contracts;
using Functional.Implementation;
using GPS;
using Tests;

using TestContracts;
namespace Tests {

    /****************************************************/

    //  $GPRMC,081836,A,3751.65,S,14507.36,E,000.0,360.0,130998,011.3,E*62
    // $GPRMC,225446,A,4916.45,N,12311.12,W,000.5,054.7,191194,020.3,E*68
    // $GPRMC,220516,A,5133.82,N,00042.24,W,173.8,231.8,130694,004.2,W*70
    // from http://www.gpsinformation.org/dale/nmea.htmI



    /*
     * From http://playground.arduino.cc/Tutorials/GPS
     * 
     *  eg1. $GPRMC,081836,A,3751.65,S,14507.36,E,000.0,360.0,130998,011.3,E*62
 eg2. $GPRMC,225446,A,4916.45,N,12311.12,W,000.5,054.7,191194,020.3,E*68
           225446       Time of fix 22:54:46 UTC
           A            Navigation receiver warning A = Valid position, V = Warning
           4916.45,N    Latitude 49 deg. 16.45 min. North
           12311.12,W   Longitude 123 deg. 11.12 min. West
           000.5        Speed over ground, Knots
           054.7        Course Made Good, degrees true
           191194       UTC Date of fix, 19 November 1994
           020.3,E      Magnetic variation, 20.3 deg. East
           *68          mandatory checksum
 eg3. $GPRMC,220516,A,5133.82,N,00042.24,W,173.8,231.8,130694,004.2,W*70
              1    2    3    4    5     6    7    8      9     10  11 12
      1   220516     Time Stamp
      2   A          validity - A-ok, V-invalid
      3   5133.82    current Latitude
      4   N          North/South
      5   00042.24   current Longitude
      6   W          East/West
      7   173.8      Speed in knots
      8   231.8      True course
      9   130694     Date Stamp
      10  004.2      Variation
      11  W          East/West
      12  *70        checksum
 eg4. for NMEA 0183 version 3.00 active the Mode indicator field is added
     $GPRMC,hhmmss.ss,A,llll.ll,a,yyyyy.yy,a,x.x,x.x,ddmmyy,x.x,a,m*hh
 Field #
 1    = UTC time of fix
 2    = Data status (A=Valid position, V=navigation receiver warning)
 3    = Latitude of fix
 4    = N or S of longitude
 5    = Longitude of fix
 6    = E or W of longitude
 7    = Speed over ground in knots
 8    = Track made good  True
 9    = UTC date of fix
 10   = Magnetic variation degrees (Easterly var. subtracts from true course)
 11   = E or W of magnetic variation
 12   = Mode indicator, (A=Autonomous, D=Differential, E=Estimated, N=Data not valid)
 13   = Checksum
     * 
     * 
     * $GPGGA,154653,4428.2011,N,00440.5161,W,0,00,,-00044.7,M,051.6,M,,*6C 
 $GPGSA,A,1,,,,,,,,,,,,,,,*1E 
 $GPGSV,3,1,10,02,50,290,003,10,25,24,045,35,27,56,145,00,,,,,,,,*78 
 $GPRMC,154653,V,4428.2011,N,00440.5161,W,000.5,342.8,050407,,,N*7F  
     * */

                // GGA          Global Positioning System Fix Data
            // 123519       Fix taken at 12:35:19 UTC
            // 4807.038,N   Latitude 48 deg 07.038' N
            // 01131.000,E  Longitude 11 deg 31.000' E
            // 1            Fix quality: 0 = invalid
            //                   1 = GPS fix (SPS)
            //                   2 = DGPS fix
            //                   3 = PPS fix
			//                   4 = Real Time Kinematic
			//                   5 = Float RTK
            //                   6 = estimated (dead reckoning) (2.3 feature)
			//                   7 = Manual input mode
			//                   8 = Simulation mode
            // 08           Number of satellites being tracked
            // 0.9          Horizontal dilution of position
            // 545.4,M      Altitude, Meters, above mean sea level
            // 46.9,M       Height of geoid (mean sea level) above WGS84 ellipsoid
            // (empty field) time in seconds since last DGPS update
            // (empty field) DGPS station ID number
            // *47          the checksum data, always begins with *
            //test = "$GPGSA,A,3,04,05,,09,12,,,24,,,,,2.5,1.3,2.1*39";
            // GSA      Satellite status
            // A        Auto selection of 2D or 3D fix (M = manual) 
            // 3        3D fix - values include: 1 = no fix
            //                                   2 = 2D fix
            //                                   3 = 3D fix
            // 04,05... PRNs of satellites used for fix (space for 12)
            // 2.5      PDOP (dilution of precision)
            // 1.3      Horizontal dilution of precision (HDOP)
            // 2.1      Vertical dilution of precision (VDOP)
            // *39      the checksum data, always begins with *

    [Export(typeof(ITestCase))]
    public class gps_nmea_parse_gpgga : ITestCase {
        private const string _Name = "gps_nmea_parse_gpgga";
        private const string _Description = "verify that tge NMEAParser can parse NMEA GPGGA strings";
        public string TestFile { get { return "TestCaseGPS.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            string NMEA_String = String.Empty;
                //
            // 
            // from http://www.gpsinformation.org/dale/nmea.htmI
            IGPS_GPGGA x = NMEAHelper.CreateGGA();
            NMEA_String = "$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47";
            x.Parse(NMEA_String);
            
            result = result && (x.Time.Hours == 12);
            result = result && (x.Time.Minutes == 35);
            result = result && (x.Time.Seconds == 19);
            result = result && (x.Time.Milliseconds == 0);

            result = result && (x.Latitude.Degrees == 48);
            result = result && (x.Latitude.Minutes == 7);
            result = result && (F.close_double(x.Latitude.Seconds, (60.0d * 0.038d)));
            result = result && (x.Latitude.Hemisphere == Hemisphere.North);

            result = result && (x.Longitude.Degrees == 11);
            result = result && (x.Longitude.Minutes == 31);
            result = result && (F.close_double(x.Longitude.Seconds, 0.0d));
            result = result && (x.Longitude.Hemisphere == Hemisphere.East);

            result = result && (x.Fix == FixQuality.GPS_Fix);
            result = result && (x.Satelites == 8);
            result = result && (F.close_float(x.HDOP, 0.9f));
            result = result && (F.close_float(x.Altitude.Altitude, 545.4f));
            result = result && (x.Altitude.Units == Dimension.Meters);
            result = result && (F.close_float(x.Geoid.Height, 46.9f));
            result = result && (x.Geoid.Units == Dimension.Meters);

            result = result && (F.close_float(x.DGPS_Elapsed_Time,0.0f));
            result = result && (x.DGPS_ID == String.Empty);

            NMEA_String = "$GPGGA,180718.02,4531.3740,N,12255.4599,W,1,07,1.4,50.6,M,-21.4,M,,*63";
            x.Parse(NMEA_String);

            result = result && (x.Time.Hours == 18);
            result = result && (x.Time.Minutes == 7);
            result = result && (x.Time.Seconds == 18);
            //result = result && (x.Time.Milliseconds == 0); TODO

            result = result && (x.Latitude.Degrees == 45);
            result = result && (x.Latitude.Minutes ==31);
            result = result && (F.close_double(x.Latitude.Seconds, (60.0d * 0.3740d)));
            result = result && (x.Latitude.Hemisphere == Hemisphere.North);

            result = result && (x.Longitude.Degrees == 122);
            result = result && (x.Longitude.Minutes == 55);
            result = result && (F.close_double(x.Longitude.Seconds, (60.0d* 0.4599d)));
            result = result && (x.Longitude.Hemisphere == Hemisphere.West);

            result = result && (x.Fix == FixQuality.GPS_Fix);
            result = result && (x.Satelites == 7);
            result = result && (F.close_float(x.HDOP, 1.4f));
            result = result && (F.close_float(x.Altitude.Altitude, 50.6f));
            result = result && (x.Altitude.Units == Dimension.Meters);
            result = result && (F.close_float(x.Geoid.Height, -21.4f));
            result = result && (x.Geoid.Units == Dimension.Meters);

            result = result && (F.close_float(x.DGPS_Elapsed_Time, 0.0f));
            result = result && (x.DGPS_ID == String.Empty);

            NMEA_String = "$GPGGA,203008.78,4524.9729,N,12246.9580,W,1,03,3.8,00133,M,,,,*39";
            x.Parse(NMEA_String);
            //TODO Verify
            NMEA_String = "$GPGGA,075519,4531.254,N,12259.400,W,1,3,0,0.0,M,0,M,,*55";
            x.Parse(NMEA_String);
            // TODO Verify
            NMEA_String = "$GPGGA,183324.518,4533.0875,N,12254.5939,W,2,04,3.4,48.6,M,-19.6,M,1.2,0000*74";
            x.Parse(NMEA_String);
            result = result && (F.close_float(x.DGPS_Elapsed_Time, 1.2f));
            result = result && (x.DGPS_ID == "0000");
            // TODO more Verify
            
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public gps_nmea_parse_gpgga() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.GPS);
            this.feature.Add(TestCoverage.GPS_NMEA);
            this.feature.Add(TestCoverage.GPS_NMEA_Parse);
            this.feature.Add(TestCoverage.GPS_NMEA_Parse_GPGGA);

            this.coverage.Add(TestCoverage.GPS);
            this.coverage.Add(TestCoverage.GPS_NMEA);
            this.coverage.Add(TestCoverage.GPS_NMEA_Parse);
            this.coverage.Add(TestCoverage.GPS_NMEA_Parse_GPGGA);
            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_float);
            this.coverage.Add(TestCoverage.F_close_double);
                
        }
    }

    [Export(typeof(ITestCase))]
    public class gps_nmea_parse_gprmc : ITestCase {
        private const string _Name = "gps_nmea_parse_gprmc";
        private const string _Description = "verify that tge NMEAParser can parse NMEA GPRMC strings";
        public string TestFile { get { return "TestCaseGPS.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            string NMEA_String = String.Empty;
            
            IGPS_GPRMC x = NMEAHelper.CreateRMC();

            NMEA_String = "$GPRMC,154653,V,4428.2011,N,00440.5161,W,000.5,342.8,050407,,,N*7F";
            x.Parse(NMEA_String);

            result = result && (x.Time.Hours == 15);
            result = result && (x.Time.Minutes == 46);
            result = result && (x.Time.Seconds == 53);

            result = result && !x.Valid;
            result = result && (x.Latitude.Degrees == 44);
            result = result && (x.Latitude.Minutes == 28);
            result = result && (F.close_double(x.Latitude.Seconds, (60.0d * 0.2011)));
            result = result && (x.Latitude.Hemisphere == Hemisphere.North);
            
            result = result && (x.Longitude.Degrees == 4);
            result = result && (x.Longitude.Minutes == 40);
            result = result && (F.close_double(x.Longitude.Seconds, (60.0d * 0.5161d)));
            result = result && (x.Longitude.Hemisphere == Hemisphere.West);

            result = result && (F.close_float(x.Speed, 0.5f));
            result = result && (F.close_float(x.Bearing, 342.8f));
            result = result && (x.Date.Year == 2007);
            result = result && (x.Date.Month == 4);
            result = result && (x.Date.Day == 5);

            result = result && (x.CheckSum == "7F");





            NMEA_String = "$GPRMC,225446,A,4916.45,N,12311.12,W,000.5,054.7,191194,020.3,E*68";
            x.Parse(NMEA_String);

            result = result && (x.Time.Hours == 22);
            result = result && (x.Time.Minutes == 54);
            result = result && (x.Time.Seconds == 46);

            result = result && (x.Valid);
            result = result && (x.Latitude.Degrees == 49);
            result = result && (x.Latitude.Minutes == 16);
            result = result && (F.close_double(x.Latitude.Seconds,(60.0d*0.45d)));
            result = result && (x.Latitude.Hemisphere == Hemisphere.North);

            result = result && (x.Longitude.Degrees == 123);
            result = result && (x.Longitude.Minutes == 11);
            result = result && (F.close_double(x.Longitude.Seconds,(60.0d*0.12d)));
            result = result && (x.Longitude.Hemisphere == Hemisphere.West);

            result = result && (F.close_float(x.Speed,0.5f));
            result = result && (F.close_float(x.Bearing,54.7f));
            result = result && (x.Date.Year == 2094); // we don't do 19xx
            result = result && (x.Date.Month == 11);
            result = result && (x.Date.Day == 19);
            result = result && (F.close_float(x.MagneticVariation,20.3f));
            result = result && (x.MagneticDeviation == Deviation.East);

            NMEA_String = "$GPRMC,220516,A,5133.82,N,00042.24,W,173.8,231.8,130694,004.2,W*70";
            x.Parse(NMEA_String);

            result = result && (x.Time.Hours == 22);
            result = result && (x.Time.Minutes == 5);
            result = result && (x.Time.Seconds == 16);

            result = result && x.Valid;
            result = result && (x.Latitude.Degrees == 51);
            result = result && (x.Latitude.Minutes == 33);
            result = result && (F.close_double(x.Latitude.Seconds,(60.0d*0.82d)));
            result = result && (x.Latitude.Hemisphere == Hemisphere.North);

            result = result && (x.Longitude.Degrees == 0);
            result = result && (x.Longitude.Minutes == 42);
            result = result && (F.close_double(x.Longitude.Seconds,(60.0d*0.24d)));
            result = result && (x.Longitude.Hemisphere == Hemisphere.West);

            result = result && (F.close_float(x.Speed,173.8f)); // knots. that's fast!
            result = result && (F.close_float(x.Bearing,231.8f));
            result = result && (x.Date.Year == 2094); // we don't do 19xx
            result = result && (x.Date.Month == 6);
            result = result && (x.Date.Day == 13);

            result = result && (F.close_float(x.MagneticVariation,4.2f));
            result = result && (x.MagneticDeviation == Deviation.West);
            

            NMEA_String = "$GPRMC,081836,A,3751.65,S,14507.36,E,000.0,360.0,130998,011.3,E*62";
            x.Parse(NMEA_String);

            result = result && (x.Time.Hours == 8);
            result = result && (x.Time.Minutes == 18);
            result = result && (x.Time.Seconds == 36);

            result = result && x.Valid;
            result = result && (x.Latitude.Degrees == 37);
            result = result && (x.Latitude.Minutes == 51);
            result = result && (F.close_double(x.Latitude.Seconds,(60.0d*0.65d)));
            result = result && (x.Latitude.Hemisphere == Hemisphere.South);

            result = result && (x.Longitude.Degrees == 145);
            result = result && (x.Longitude.Minutes == 7);
            result = result && (F.close_double(x.Longitude.Seconds,(60.0d*0.36d)));
            result = result && (x.Longitude.Hemisphere == Hemisphere.East);
            result = result && (F.close_float(x.Speed,0.0f));
            result = result && (F.close_float(x.Bearing,360.0f));

            result = result && (x.Date.Year == 2098); // we dont do 19xx
            result = result && (x.Date.Month == 9);
            result = result && (x.Date.Day == 13);
            result = result && (F.close_float(x.MagneticVariation,11.3f));
            result = result && (x.MagneticDeviation == Deviation.East);

            NMEA_String = "$GPRMC,010922,A,4603.6695,N,07307.3033,W,0.6,66.8,060508,16.1,W,A*1D";
            x.Parse(NMEA_String);
            result = result && (x.Time.Hours == 1); //010922
            result = result && (x.Time.Minutes == 9);
            result = result && (x.Time.Seconds == 22);

            result = result && x.Valid;  // A
            result = result && (x.Latitude.Degrees == 46); // 4603.6695
            result = result && (x.Latitude.Minutes == 3);
            result = result && (F.close_double(x.Latitude.Seconds, (60.0d * 0.6695)));
            result = result && (x.Latitude.Hemisphere == Hemisphere.North);

            result = result && (x.Longitude.Degrees == 73); // 07307.3033
            result = result && (x.Longitude.Minutes == 7);
            result = result && (F.close_double(x.Longitude.Seconds,(60.0d*0.3033)));
            result = result && (x.Longitude.Hemisphere == Hemisphere.West);

            result = result && (F.close_float(x.Speed,0.6f));
            result = result && (F.close_float(x.Bearing,66.0f));
            result = result && (x.Date.Year == 2008);  // 060508
            result = result && (x.Date.Month == 6);
            result = result && (x.Date.Day == 5);
            // TODO more Verify

            NMEA_String = "$GPRMC,215348,A,4529.3672,N,12253.2060,W,0.0,353.8,030508,17.5,E,D*3C";
            x.Parse(NMEA_String);
            // TODO Verify
            NMEA_String = "$GPRMC,074919.04,A,4524.9698,N,12246.9520,W,00.0,000.0,260508,19.,E*79";
            x.Parse(NMEA_String);
            // TODO Verify
            NMEA_String = "$GPRMC,123449.089,A,3405.1123,N,08436.4301,W,000.0,000.0,021208,,,A*71";
            x.Parse(NMEA_String);
            // TODO Verify
            NMEA_String = "$GPRMC,230710,A,2748.1414,N,08238.5556,W,000.0,033.1,111208,004.3,W*77";
            x.Parse(NMEA_String);
            // TODO Verify
            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public gps_nmea_parse_gprmc() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.GPS);
            this.feature.Add(TestCoverage.GPS_NMEA);
            this.feature.Add(TestCoverage.GPS_NMEA_Parse);
            this.feature.Add(TestCoverage.GPS_NMEA_Parse_GPRMC);

            this.coverage.Add(TestCoverage.GPS);
            this.coverage.Add(TestCoverage.GPS_NMEA);
            this.coverage.Add(TestCoverage.GPS_NMEA_Parse);
            this.coverage.Add(TestCoverage.GPS_NMEA_Parse_GPRMC);
            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_float);
            this.coverage.Add(TestCoverage.F_close_double);
        }
    }

    [Export(typeof(ITestCase))]
    public class gps_nmea_parse_gpgsa : ITestCase {
        private const string _Name = "gps_nmea_parse_gpgsa";
        private const string _Description = "verify that tge NMEAParser can parse NMEA GPRMC strings";
        public string TestFile { get { return "TestCaseGPS.cs"; } }
        public Func<bool> Run { get; private set; }
        private static bool _Run() {
            bool result = true;
            string NMEA_String = String.Empty;
            
            IGPS_GPGSA x = NMEAHelper.CreateGSA();

            NMEA_String = "$GPGSA,A,3,04,05,,09,12,,,24,,,,,2.5,1.3,2.1*39";
            x.Parse(NMEA_String);
            result = result && (x.Selection == Selection.Auto);
            result = result && (x.Fix == FixType._3D_fix);
            result = result && (x.Count == 5);
            result = result && (x.Satelites.Contains(4));
            result = result && (x.Satelites.Contains(5));
            result = result && (x.Satelites.Contains(9));
            result = result && (x.Satelites.Contains(12));
            result = result && (x.Satelites.Contains(24));
            result = result && (F.close_float(x.PDOP, 2.5f));
            result = result && (F.close_float(x.HDOP, 1.3f));
            result = result && (F.close_float(x.VDOP, 2.1f));
            result = result && (x.CheckSum == "39");
            result = result && x.Checked;

            NMEA_String = "$GPGSA,A,1,,,,,,,,,,,,,,,*1E";
            x.Parse(NMEA_String);
            result = result && (x.Selection == Selection.Auto);
            result = result && (x.Fix == FixType.no_fix);
            result = result && (x.Count == 0);
            result = result && (F.close_float(x.PDOP, 0.0f));
            result = result && (F.close_float(x.HDOP, 0.0f));
            result = result && (F.close_float(x.VDOP, 0.0f));
            result = result && (x.CheckSum == "1E");
            result = result && x.Checked;

            return result;
        }
        private IList<int> coverage = new List<int>();
        private IList<int> feature = new List<int>();
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IEnumerable<int> Coverage { get { return this.coverage; } }
        public IEnumerable<int> Feature { get { return this.feature; } }
        public gps_nmea_parse_gpgsa() {
            this.ID = 0;
            this.Name = _Name;
            this.Description = _Description;
            this.Run = _Run;

            this.feature.Add(TestCoverage.Test_All);
            this.feature.Add(TestCoverage.GPS);
            this.feature.Add(TestCoverage.GPS_NMEA);
            this.feature.Add(TestCoverage.GPS_NMEA_Parse);
            this.feature.Add(TestCoverage.GPS_NMEA_Parse_GPGSA);

            this.coverage.Add(TestCoverage.GPS);
            this.coverage.Add(TestCoverage.GPS_NMEA);
            this.coverage.Add(TestCoverage.GPS_NMEA_Parse);
            this.coverage.Add(TestCoverage.GPS_NMEA_Parse_GPGSA);
            this.coverage.Add(TestCoverage.F);
            this.coverage.Add(TestCoverage.F_close);
            this.coverage.Add(TestCoverage.F_close_float);
        }
    }
}
