using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Functional.Implementation;

namespace GPS {
    public enum NMEA_Sentence { GPGGA, GPVTG, GPGLL, GPGSA, GPGSV, GPRMC }
    public enum Hemisphere { East, West, North, South }
    public enum Deviation { East, West , Data_not_valid }
    public enum ModeIndicator { Autonomous, Differential, Estimated, Data_not_valid }
    public enum FixQuality { invalid, GPS_Fix, DGPS_Fix, PPS_Fix, Real_Time_Kinematic, Float_RTK, estimated, manual_input_mode, simulation_mode }
    public enum FixType { no_fix, _2D_fix, _3D_fix }
    public enum Selection { Unknown, Auto, Manual }
    public enum Dimension { Meters, Feet, Knots, Miles }
    public interface ITime {
        int Hours { get; }
        int Minutes { get; }
        int Seconds { get; }
        int Milliseconds { get; }
    }
    public interface ILatitude {
        Hemisphere Hemisphere { get; }
        int Degrees { get; }
        int Minutes { get; }
        double Seconds { get; }
    }
    public interface ILongitude {
        Hemisphere Hemisphere { get; }
        int Degrees { get; }
        int Minutes { get; }
        double Seconds { get; }
    }

        
    public interface IAltitude {
        float Altitude { get; }
        Dimension Units { get; }
    }
    public interface IGeoid {
        float Height { get; }
        Dimension Units { get; }
    }

    public interface IDate {
        int Day { get; }
        int Month { get; }
        int Year { get; }
    }

    public interface ISateliteView {
        int PRN { get; }
        int Elevation { get; } // degrees 0 - 90 max
        int Azimuth { get; } // degrees from true north, 000 to 359
        bool Tracking { get; }
        int SNR { get; } // 00-99 dB (ignore when not tracking)
    }


    public interface IGPS_GPGGA { // $GPGGA,062829.624,4740.7870,N,12207.3410,W,1,04,1.5,-78.6,M,-17.2,M,,0000*7B
        bool Parse(string nmea_string);
        
        ITime Time { get; }
        ILatitude Latitude { get; }
        ILongitude Longitude { get; }
        FixQuality Fix { get; }
        int Satelites { get; }
        float HDOP { get; }
        IAltitude Altitude { get; }
        IGeoid Geoid { get; }
        float DGPS_Elapsed_Time { get; }
        string DGPS_ID { get; }
        string CheckSum { get; }
        bool Checked { get; }
    }
    public interface IGPS_GPRMC { // $GPRMC,062828.624,A,4740.7869,N,12207.3409,W,0.15,329.42,270214,,,A*7D
        bool Parse(string nmea_string);
        bool Valid { get; }
        ITime Time { get; }
        ILatitude Latitude { get; }
        ILongitude Longitude { get; }
        float Speed { get; }
        float Bearing { get; } // knots
        IDate Date { get; }
        float MagneticVariation { get; }
        Deviation MagneticDeviation { get; }
        ModeIndicator Mode { get; }
        string CheckSum { get; }
        bool Checked { get; }
    }
    public interface IGPS_GPGSA { // $GPGSA,A,3,01,04,28,15,,,,,,,,,3.5,1.5,3.1*39
        bool Parse(string nmea_string);
        Selection Selection { get; }
        FixType Fix { get; }
        int Count { get; }
        IEnumerable<int> Satelites { get; }
        float PDOP { get; }
        float HDOP { get; }
        float VDOP { get; }
        string CheckSum { get; }
        bool Checked { get; }
    }
    public interface IGPS_GPVTG {
        bool Parse(string nmea_string);
        bool TrueCourseValid { get; }
        float TrueTrackMadeGood { get; }
        bool MagneticCourseValid { get; }
        float MagneticTrackMadeGood { get; }
        bool KnotsValid { get; }
        float Knots { get; }
        bool KPHValid { get; }
        float KilometersPerHour { get; }
        string CheckSum { get; }
        bool Checked { get; }
    }
    public interface IGPS_GPGSV {
        bool Parse(string[] nmea_strings); // requires a set of strings
        int Count { get; }
        IEnumerable<ISateliteView> Satelites { get; }
        string[] CheckSum { get; } // one CheckSum per string
        bool Checked { get; }
    }
    // $GPGLL,4740.7870,N,12207.3411,W,062830.624,A,A*4A
    // $GPVTG,325.34,T,,M,0.21,N,0.4,K,A*09
    // $GPGSV,3,1,12,17,72,064,,05,50,292,,27,44,303,,02,40,130,*71
    public static class NMEAHelper {
        public static ISateliteView CreateSateleiteView(string prn,string elevation, string azmuth, string snr) {
            return new SateliteView(prn,elevation,azmuth,snr);
        }
        public static IGPS_GPGGA CreateGGA() { return new NMEAParser_GPGGA(); }
        public static IGPS_GPRMC CreateRMC() { return new NMEAParser_GPRMC(); }
        public static IGPS_GPGSA CreateGSA() { return new NMEAParser_GPGSA(); }
        public static IGPS_GPVTG CreateVTG() { return new NMEAParser_GPVTG(); }
        public static IGPS_GPGSV CreateGSV() { return new NMEAParser_GPGSV(); }
        public static string CalculateChecksum(string s) {
            int sum = 0, index = 0;
            char[] t = s.ToCharArray();
            bool done = false;
            while (!done) {
                char ch = t[index];
                switch (ch) {
                    case '$': index++; break; //ignore the $
                    case '*': done = true; break;
                    default:
                        if (0 == sum) sum = Convert.ToByte(ch);
                        else sum ^= Convert.ToByte(ch);
                        index++;
                        break;
                }
                if (index >= t.Length) done = true;
            }
            return sum.ToString("X2");
        }

        private static int crackDegrees(string info) {
            int result = 0;
            try {
                result = int.Parse(info.Substring(0, info.IndexOf('.')-2));
            } catch (System.FormatException) { }
            return result;
        }
        private static int crackMinutes(string info) {
            int result = 0;
            try {
                float temp = float.Parse(info.Substring(info.IndexOf('.') - 2));
                result = (int)(temp);
            } catch (System.FormatException) { }
            return result;
        }
        private static double crackSeconds(string info) {
            double result = 0.0d;
            try {
                double temp = double.Parse(info.Substring(info.IndexOf('.')));
                result = (temp * 60.0d);
            } catch (System.FormatException) { }
            return result;
        }
        public static bool parseValid(string valid_string) {
            bool result = false;
            if (!String.IsNullOrEmpty(valid_string)) {
                if ("A" == valid_string) result = true;
                else if ("V" == valid_string) result = false;
            }
            return result;
        }


        public static Selection parseSelection(string selection_string) {
            Selection result = Selection.Unknown;
            if (!String.IsNullOrEmpty(selection_string)) {
                if (selection_string == "A") result = Selection.Auto;
                else if (selection_string == "M") result = Selection.Manual;
            }
            return result;
        }
        public static FixType parseFixType(string fixtype_string) {
            FixType result = FixType.no_fix;
            if (!String.IsNullOrEmpty(fixtype_string)) {
                if (fixtype_string == "1") result = FixType.no_fix;
                else if (fixtype_string == "2") result = FixType._2D_fix;
                else if (fixtype_string == "3") result = FixType._3D_fix;
            }
            return result;
        }
        public static ITime parseTime(string time_string) { // syvlia change - MASH
            ITime result = null;
            int hours = 0; 
            int minutes = 0; 
            int seconds = 0; 
            int milliseconds = 0; 
            if (time_string.Length >=2) hours = int.Parse(time_string.Substring(0, 2));
            if (time_string.Length >=4) minutes = int.Parse(time_string.Substring(2, 2));
            if (time_string.Length >=6) seconds = int.Parse(time_string.Substring(4, 2));
            if (time_string.Length > 6) milliseconds = (int)(float.Parse(time_string.Substring(6)) * 1000.0f);


            result = time.Create(hours, minutes, seconds, milliseconds);
            return result;
        }
        public static ILongitude parseLongitude(string longitude_string, string hemisphere) {
            ILongitude result = null;
            int degrees = crackDegrees(longitude_string);
            int minutes = crackMinutes(longitude_string);
            double seconds = crackSeconds(longitude_string);
            Hemisphere H = Hemisphere.West;
            switch (hemisphere) {
                case "N": H = Hemisphere.North; break;
                case "S": H = Hemisphere.South; break;
                case "E": H = Hemisphere.East; break;
                case "W": H = Hemisphere.West; break;
            }
            result = longitude.Create(H,degrees, minutes, seconds);
            return result;
        }
        public static ILatitude parseLatitude(string latitude_string, string hemisphere) {
            ILatitude result = null;
            int degrees = crackDegrees(latitude_string);
            int minutes = crackMinutes(latitude_string);
            double seconds = crackSeconds(latitude_string);
            Hemisphere H = Hemisphere.West;
            switch (hemisphere) {
                case "N": H = Hemisphere.North; break;
                case "S": H = Hemisphere.South; break;
                case "E": H = Hemisphere.East; break;
                case "W": H = Hemisphere.West; break;
            }
            result = latitude.Create(H,degrees, minutes, seconds);
            return result;
        }
        public static FixQuality parseFixQuality(string fix_quality_string) {
            FixQuality fq = FixQuality.invalid;
            switch (fix_quality_string) {
                case "0": fq = FixQuality.invalid; break;
                case "1": fq = FixQuality.GPS_Fix; break;
                case "2": fq = FixQuality.DGPS_Fix; break;
                case "3": fq = FixQuality.PPS_Fix; break;
                case "4": fq = FixQuality.Real_Time_Kinematic; break;
                case "5": fq = FixQuality.Float_RTK; break;
                case "6": fq = FixQuality.estimated; break;
                case "7": fq = FixQuality.manual_input_mode; break;
                case "8": fq = FixQuality.simulation_mode; break;
            }
            return fq;
        }
        public static IAltitude parseAltitude(string altitude_string,string unit_string) {
            IAltitude result = null;
            float a = 0.0f;
            Dimension d = Dimension.Meters;
            if (!String.IsNullOrEmpty(altitude_string)) {
                a = float.Parse(altitude_string);
            }
            if (!String.IsNullOrEmpty(unit_string)) {
                switch (unit_string) {
                    case "M": d = Dimension.Meters; break;
                    case "F": d = Dimension.Feet; break;
                }
            }
            result = altitude.Create(a,d);
            return result;
        }
        public static IGeoid parseGeoid(string geoid_string, string unit_string) {
            IGeoid result = null;
            float a = 0.0f;
            Dimension d = Dimension.Meters;
            if (!String.IsNullOrEmpty(geoid_string)) {
                a = float.Parse(geoid_string);
            }
            if (!String.IsNullOrEmpty(unit_string)) {
                switch (unit_string) {
                    case "M": d = Dimension.Meters; break;
                    case "F": d = Dimension.Feet; break;
                }
            }
            result = geoid.Create(a, d);
            return result;
        }
        public static ModeIndicator parseMode(string mode_string) {
            ModeIndicator result = ModeIndicator.Data_not_valid;
            if (!String.IsNullOrEmpty(mode_string)) {
                // (A=Autonomous, D=Differential, E=Estimated, N=Data not valid)
                if (mode_string == "D") result = ModeIndicator.Differential;
                else if (mode_string == "A") result = ModeIndicator.Autonomous;
                else if (mode_string == "E") result = ModeIndicator.Estimated;
                else if (mode_string == "N") result = ModeIndicator.Data_not_valid;
            }
            return result;
        }
        public static IDate parseDate(string date_string) {
            IDate result = null;
            if (!String.IsNullOrEmpty(date_string)) {
                int day = int.Parse(date_string.Substring(0,2));
                int month = int.Parse(date_string.Substring(2,2));
                int yy = int.Parse(date_string.Substring(4));
                int year = (yy>2000)?yy:2000 + yy; // Y3K bug
                result = date.Create(day, month, year);
            }
            return result;
        }
        public static Deviation parseDeviation(string item) {
            Deviation result = Deviation.Data_not_valid;
            if (!String.IsNullOrEmpty(item)) {
                if (item == "W") result = Deviation.West;
                else if (item == "E") result = Deviation.East;
            }
            return result;
        }
        public static int parseInt(string item) {
            int result = 0;
            if (!String.IsNullOrEmpty(item)) {
                result = int.Parse(item);
            }
            return result;
        }
        public static float parseFloat(string item) {
            float result = 0.0f;
            if (!String.IsNullOrEmpty(item)) {
                result = float.Parse(item);
            }
            return result;
        }


        private static string FixQuality_ToString(FixQuality fq) {
            string result = String.Empty;
            switch (fq) {
                case FixQuality.invalid:   result = "invalid"; break;
                case FixQuality.GPS_Fix:   result = "GPS fix (SPS)"; break;
                case FixQuality.DGPS_Fix:  result = "DGPS fix"; break;
                case FixQuality.PPS_Fix:   result = "PPS fix"; break;
                case FixQuality.Real_Time_Kinematic: result = "Real Time Kinematic"; break;
                case FixQuality.Float_RTK: result  = "Float RTK"; break;
                case FixQuality.estimated: result = "estimated (dead reckoning)"; break;
                case FixQuality.manual_input_mode: result = "Manual input mode"; break;
                case FixQuality.simulation_mode: result = "Simulation mode"; break;
            }
            return result;
        }
        private class time : ITime {
            public bool Valid { get; private set; }
            public int Hours { get; private set; }
            public int Minutes { get; private set; }
            public int Seconds { get; private set; }
            public int Milliseconds { get; private set; }
            private time(int hours, int minutes, int seconds, int milliseconds) {
                this.Hours = hours;
                this.Minutes = minutes;
                this.Seconds = seconds;
                this.Milliseconds = milliseconds;
            }
            public override string ToString() { 
                return this.Hours + " hours\n" 
                    + this.Minutes + " minutes\n" 
                    + this.Seconds + " seconds\n" 
                    + this.Milliseconds + " milliseconds\n";
            }
            private time() { }
            public static ITime Create(int hours, int minutes, int seconds, int milliseconds) {
                return new time(hours, minutes, seconds, milliseconds);
            }
        }
        private class longitude : ILongitude {
            public Hemisphere Hemisphere { get; private set; }
            public int Degrees { get; private set; }
            public int Minutes { get; private set; }
            public double Seconds { get; private set; }

            private longitude(Hemisphere h,int degrees, int minutes, double seconds) {
                this.Hemisphere = h;
                this.Degrees = degrees;
                this.Minutes = minutes;
                this.Seconds = seconds;
            }
            private longitude() { }
            public override string ToString() {
                return this.Degrees + " degrees\n"
                    + this.Minutes + " minutes\n"
                    + this.Seconds + " seconds\n"
                    + ((this.Hemisphere == GPS.Hemisphere.East) ? "East\n" : "West\n");
            }
            public static ILongitude Create(Hemisphere h, int degree, int minutes, double seconds) {
                return new longitude(h, degree, minutes, seconds);
            }
        }
        private class latitude : ILatitude {
            public Hemisphere Hemisphere { get; private set; }
            public int Degrees { get; private set; }
            public int Minutes { get; private set; }
            public double Seconds { get; private set; }

            private latitude(Hemisphere h, int degrees, int minutes, double seconds) {
                this.Hemisphere = h;
                this.Degrees = degrees;
                this.Minutes = minutes;
                this.Seconds = seconds;
            }
            private latitude() { }
            public override string ToString() {
                return this.Degrees + " degrees\n"
                    + this.Minutes + " minutes\n"
                    + this.Seconds + " seconds\n"
                    + ((this.Hemisphere == GPS.Hemisphere.North) ? "North\n" : "South\n");
            }
            public static ILatitude Create(Hemisphere h, int degree, int minutes, double seconds) {
                return new latitude(h, degree, minutes, seconds);
            }
        }

        private class altitude : IAltitude {
            public float Altitude { get; private set; }
            public Dimension Units { get; private set; }
            private altitude(float a, Dimension d) { this.Altitude = a; this.Units = d; }
            private altitude() { }
            public override string ToString() { return "Altitude " + this.Altitude + ((this.Units == Dimension.Meters) ? " Meters" : " Feet"); }
            public static IAltitude Create(float a, Dimension d) { return new altitude(a, d); }
        }
        private class geoid : IGeoid {
            public float Height { get; private set; }
            public Dimension Units { get; private set; }
            private geoid(float h, Dimension d) { this.Height = h; this.Units = d; }
            private geoid() { }
            public override string ToString() { return "Geoid " + this.Height + ((this.Units == Dimension.Meters) ? " Meters" : " Feet");}
            
            public static IGeoid Create(float h, Dimension d) { return new geoid(h, d); }
        }

        
        private class date : IDate {
            public bool Valid { get; private set; }
            public int Day { get; private set; }
            public int Month { get; private set; }
            public int Year { get; private set; }
            private date(int day, int month, int year) {
                this.Day = day;
                this.Month = month;
                this.Year = year;
            }
            private date() { }
            public override string ToString() { return this.Day+"|"+this.Month+"|"+this.Year; }
            public static IDate Create(int day, int month, int year) {
                return new date(day, month, year);
            }
        }
        private class NMEAParser_GPGSA : IGPS_GPGSA {
            //  "$GPGSA,A,3,04,05,,09,12,,,24,,,,,2.5,1.3,2.1*39";
            //        0,1,2,(space for 12)          6,  7,  8
            public const int INDEX_GPGSA = 0;
            public const int INDEX_SELECTION = 1;
            public const int INDEX_FIXTYPE = 2;
            public const int INDEX_SAT__1 = 3;
            public const int INDEX_SAT__2 = 4;
            public const int INDEX_SAT__3 = 5;
            public const int INDEX_SAT__4 = 6;
            public const int INDEX_SAT__5 = 7;
            public const int INDEX_SAT__6 = 8;
            public const int INDEX_SAT__7 = 9;
            public const int INDEX_SAT__8 = 10;
            public const int INDEX_SAT__9 = 11;
            public const int INDEX_SAT_10 = 12;
            public const int INDEX_SAT_11 = 13;
            public const int INDEX_SAT_12 = 14;
            public const int INDEX_PDOP = 15;
            public const int INDEX_HDOP = 16;
            public const int INDEX_VDOP = 17;

            public const char NMEADelimiter = ',';

            private string NMEAString;
            private IList<int> satelites = new List<int>();

            public Selection Selection { get; private set; }
            public FixType Fix { get; private set; }
            public int Count { get; private set; }
            public IEnumerable<int> Satelites { get { return this.satelites; } }
            public float PDOP { get; private set; }
            public float HDOP { get; private set; }
            public float VDOP { get; private set; }
            public string CheckSum { get; private set; }
            public bool Checked { get; private set; }

            private static bool AddSatelite(IList<int> sats, string id) {
                bool result = false;
                if (!String.IsNullOrEmpty(id)) {
                    sats.Add(int.Parse(id));
                    result = true;
                }
                return result;
            }

            public bool Parse(string nmea_string) {
                bool result = false;
                this.satelites.Clear();
                this.Count = 0;

                this.NMEAString = nmea_string;

                string raw_string = nmea_string.Substring(0, nmea_string.IndexOf('*'));
                this.CheckSum = nmea_string.Substring(nmea_string.IndexOf('*') + 1);
                string calculated = NMEAHelper.CalculateChecksum(nmea_string);
                this.Checked = (calculated == this.CheckSum);

                string[] field = raw_string.Split(NMEADelimiter);
                this.Selection = NMEAHelper.parseSelection(field[INDEX_SELECTION]);
                this.Fix = NMEAHelper.parseFixType(field[INDEX_FIXTYPE]);
                bool b = false;
                b = AddSatelite(this.satelites, field[INDEX_SAT__1]);
                b = AddSatelite(this.satelites, field[INDEX_SAT__2]);
                b = AddSatelite(this.satelites, field[INDEX_SAT__3]);
                b = AddSatelite(this.satelites, field[INDEX_SAT__4]);
                b = AddSatelite(this.satelites, field[INDEX_SAT__5]);
                b = AddSatelite(this.satelites, field[INDEX_SAT__6]);
                b = AddSatelite(this.satelites, field[INDEX_SAT__7]);
                b = AddSatelite(this.satelites, field[INDEX_SAT__8]);
                b = AddSatelite(this.satelites, field[INDEX_SAT__9]);
                b = AddSatelite(this.satelites, field[INDEX_SAT_10]);
                b = AddSatelite(this.satelites, field[INDEX_SAT_11]);
                b = AddSatelite(this.satelites, field[INDEX_SAT_12]);
                this.Count = this.satelites.Count();
                this.PDOP = NMEAHelper.parseFloat(field[INDEX_PDOP]);
                this.HDOP = NMEAHelper.parseFloat(field[INDEX_HDOP]);
                this.VDOP = NMEAHelper.parseFloat(field[INDEX_VDOP]);


                return result;
            }

        }

        private class NMEAParser_GPGGA : IGPS_GPGGA {
            public const int H = 0;
            // "$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47"
            //       0,     1,       2,3,        4,5,6, 7,  8,    9,0,   1,2,3,4
            public const int INDEX_GPGGA = 0;
            public const int INDEX_TIME = 1;
            public const int INDEX_LATITUDE = 2;
            public const int INDEX_LATITUDE_HEMISPHERE = 3;
            public const int INDEX_LONGITUDE = 4;
            public const int INDEX_LONGITUDE_HEMISPHERE = 5;
            public const int INDEX_FIX_QUALITY = 6;
            public const int INDEX_SATLITES = 7;
            public const int INDEX_HDOP = 8;
            public const int INDEX_ALTITUDE = 9;
            public const int INDEX_ALTITUDE_DIMENSIONS = 10;
            public const int INDEX_GEOID = 11;
            public const int INDEX_GEOID_DIMENSIONS = 12;
            public const int INDEX_DGPS_UPDATE = 13;
            public const int INDEX_DGPS_ID = 14;
            public const int INDEX = 0;


            public const char NMEADelimiter = ',';


            private string NMEAString;
            public bool Valid { get; private set; }
            public ITime Time { get; private set; }
            public ILongitude Longitude { get; private set; }
            public ILatitude Latitude { get; private set; }
            public FixQuality Fix { get; private set; }
            public int Satelites { get; private set; }
            public float HDOP { get; private set; }
            public IAltitude Altitude { get; private set; }
            public IGeoid Geoid { get; private set; }
            public float DGPS_Elapsed_Time { get; private set; }
            public string DGPS_ID { get; private set; }
            public string CheckSum { get; private set; }
            public bool Checked { get; private set; }

            public bool Parse(string nmea_string) {
                bool result = false;
                this.NMEAString = nmea_string;

                string raw_string = nmea_string.Substring(0, nmea_string.IndexOf('*'));
                this.CheckSum = nmea_string.Substring(nmea_string.IndexOf('*') + 1);
                string calculated = NMEAHelper.CalculateChecksum(nmea_string);
                this.Checked = (calculated == this.CheckSum);

                string[] field = raw_string.Split(NMEADelimiter);
                this.Time = NMEAHelper.parseTime(field[INDEX_TIME]);
                this.Longitude = NMEAHelper.parseLongitude(field[INDEX_LONGITUDE], field[INDEX_LONGITUDE_HEMISPHERE]);
                this.Latitude = NMEAHelper.parseLatitude(field[INDEX_LATITUDE], field[INDEX_LATITUDE_HEMISPHERE]);
                this.Fix = NMEAHelper.parseFixQuality(field[INDEX_FIX_QUALITY]);
                this.Satelites = NMEAHelper.parseInt(field[INDEX_SATLITES]);
                this.HDOP = NMEAHelper.parseFloat(field[INDEX_HDOP]);
                this.Altitude = NMEAHelper.parseAltitude(field[INDEX_ALTITUDE], field[INDEX_ALTITUDE_DIMENSIONS]);
                this.Geoid = NMEAHelper.parseGeoid(field[INDEX_GEOID], field[INDEX_GEOID_DIMENSIONS]);
                this.DGPS_Elapsed_Time = NMEAHelper.parseFloat(field[INDEX_DGPS_UPDATE]);
                this.DGPS_ID = field[INDEX_DGPS_ID];
                return result;
            }
        }
        private class NMEAParser_GPRMC : IGPS_GPRMC {
            public const int H = 0;
            // "$GPRMC,220516,A,5133.82,N,00042.24,W,173.8,231.8,130694,004.2,W*70"
            //       0,     1,2,      3,4,       5,6,    7,    8,     9,    0,1(,2)
            public const int INDEX_GPRMC = 0;
            public const int INDEX_TIME = 1;
            public const int INDEX_VALID = 2;
            public const int INDEX_LATITUDE = 3;
            public const int INDEX_LATITUDE_HEMISPHERE = 4;
            public const int INDEX_LONGITUDE = 5;
            public const int INDEX_LONGITUDE_HEMISPHERE = 6;
            public const int INDEX_SPEED = 7;
            public const int INDEX_BEARING = 8;
            public const int INDEX_DATE = 9;
            public const int INDEX_MAG_VARI = 10;
            public const int INDEX_MAG_DEV = 11;
            public const int INDEX_MODE = 12; // for NMEA 0183 version 3.00 active the Mode indicator field is added

            public const char NMEADelimiter = ',';


            private string NMEAString;
            public bool Valid { get; private set; }
            public ITime Time { get; private set; }
            public ILatitude Latitude { get; private set; }
            public ILongitude Longitude { get; private set; }
            public float Speed { get; private set; }
            public float Bearing { get; private set; } // knots
            public IDate Date { get; private set; }
            public float MagneticVariation { get; private set; }
            public Deviation MagneticDeviation { get; private set; }
            public ModeIndicator Mode { get; private set; }
            public bool Checked { get; private set; }

            public string CheckSum { get; private set; }
            public bool Parse(string nmea_string) {
                bool result = false;
                this.NMEAString = nmea_string;

                string raw_string = nmea_string.Substring(0, nmea_string.IndexOf('*'));
                this.CheckSum = nmea_string.Substring(nmea_string.IndexOf('*') + 1);
                string calculated = NMEAHelper.CalculateChecksum(nmea_string);
                this.Checked = (calculated == this.CheckSum);

                string[] field = raw_string.Split(NMEADelimiter);
                this.Time = NMEAHelper.parseTime(field[INDEX_TIME]);
                this.Valid = NMEAHelper.parseValid(field[INDEX_VALID]);
                this.Latitude = NMEAHelper.parseLatitude(field[INDEX_LATITUDE], field[INDEX_LATITUDE_HEMISPHERE]);
                this.Longitude = NMEAHelper.parseLongitude(field[INDEX_LONGITUDE], field[INDEX_LONGITUDE_HEMISPHERE]);

                this.Speed = NMEAHelper.parseFloat(field[INDEX_SPEED]);
                this.Bearing = NMEAHelper.parseFloat(field[INDEX_BEARING]);
                this.Date = NMEAHelper.parseDate(field[INDEX_DATE]);

                this.MagneticVariation = NMEAHelper.parseFloat(field[INDEX_MAG_VARI]);
                this.MagneticDeviation = NMEAHelper.parseDeviation(field[INDEX_MAG_DEV]);
                this.Mode = (field.Count() > INDEX_MODE) ? NMEAHelper.parseMode(field[INDEX_MODE]) : ModeIndicator.Data_not_valid;
                return result;
            }
        }
        private class NMEAParser_GPVTG : IGPS_GPVTG {
            public const int INDEX_GPVTG = 0;
            public const int TRUE_TRACK = 1;
            public const int T = 2;
            public const int MAGNETIC_TRACK = 3;
            public const int M = 4;
            public const int KNOTS = 5;
            public const int N = 6;
            public const int KPH = 7;
            public const int K = 8;
            public const char NMEADelimiter = ',';

            private string NMEAString;
            public bool Parse(string nmea_string) {
                bool result = false;
                this.NMEAString = nmea_string;
                string raw_string = nmea_string.Substring(0, nmea_string.IndexOf('*'));
                this.CheckSum = nmea_string.Substring(nmea_string.IndexOf('*') + 1);
                string calculated = NMEAHelper.CalculateChecksum(nmea_string);
                this.Checked = (calculated == this.CheckSum);

                string[] field = raw_string.Split(NMEADelimiter);
                if (field.Count() >= 9) {
                    result = true;
                    if ((String.Empty != (field[TRUE_TRACK])) && (field[T] == "T")) {
                        this.TrueTrackMadeGood = float.Parse(field[TRUE_TRACK]);
                        this.TrueCourseValid = true;
                    } else this.TrueCourseValid = false;
                    if ((String.Empty != (field[MAGNETIC_TRACK])) && (field[M] == "M")) {
                        this.MagneticTrackMadeGood = float.Parse(field[MAGNETIC_TRACK]);
                        this.MagneticCourseValid = true;
                    } else this.MagneticCourseValid = false;

                    if ((String.Empty != (field[KNOTS])) && (field[N] == "N")) {
                        this.Knots = float.Parse(field[KNOTS]);
                        this.KnotsValid = true;
                    } else this.KnotsValid = false;
                    
                    if ((String.Empty != (field[KPH])) && (field[K] == "K")) {
                        this.KilometersPerHour = float.Parse(field[KPH]);
                        this.KPHValid = true;
                    } else this.KPHValid = false;
                }
                return result;
            }
            public bool TrueCourseValid { get; private set; }
            public float TrueTrackMadeGood { get; private set; }
            public bool MagneticCourseValid { get; private set; }
            public float MagneticTrackMadeGood { get; private set; }
            public bool KnotsValid { get; private set; }
            public float Knots { get; private set; }
            public bool KPHValid { get; private set; }
            public float KilometersPerHour { get; private set; }
            public string CheckSum { get; private set; }
            public bool Checked { get; private set; }

        }
        private class NMEAParser_GPGSV : IGPS_GPGSV {
            public const int INDEX_GPGSV = 0;
            public const int TOTAL_MESSAGES = 1;
            public const int CURRENT_MESSAGE = 2;
            public const int SATELITES_IN_VIEW = 3;
            public const int PRN_1 = 4;
            public const int ELEVATION_1 = 5;
            public const int AZMUTH_1 = 6;
            public const int SNR_1 = 7;
            public const int PRN_2 = 8;
            public const int ELEVATION_2 = 9;
            public const int AZMUTH_2 = 10;
            public const int SNR_2 = 11;
            public const int PRN_3 = 12;
            public const int ELEVATION_3 = 13;
            public const int AZMUTH_3 = 14;
            public const int SNR_3 = 15;
            public const int PRN_4 = 16;
            public const int ELEVATION_4 = 17;
            public const int AZMUTH_4 = 18;
            public const int SNR_4 = 19;
            public const int PRN_5 = 20; // no sentence found with this many satlites. insurance just in case
            public const int ELEVATION_5 = 21;
            public const int AZMUTH_5 = 22;
            public const int SNR_5 = 23;
            public const int PRN_6 = 24; // ditto
            public const int ELEVATION_6 = 25;
            public const int AZMUTH_6 = 26;
            public const int SNR_6 = 27;

            public const char NMEADelimiter = ',';
            private IList<ISateliteView> satelites = new List<ISateliteView>();
            public bool Parse(string[] nmea_strings) { // requires a set of strings
                
                this.NMEAStrings = new string[nmea_strings.Count()];
                this.CheckSum = new string[nmea_strings.Count()];
                this.Checked = true;
                this.satelites.Clear(); this.Count = 0;
                for (int i = 0; i < nmea_strings.Count(); ++i) {
                    this.NMEAStrings[i] = nmea_strings[i];
                    this.CheckSum[i] = nmea_strings[i].Substring(nmea_strings[i].IndexOf('*') + 1);
                    string calculated = NMEAHelper.CalculateChecksum(nmea_strings[i]);
                    this.Checked = this.Checked && (calculated == this.CheckSum[i]);
                    string raw_string = nmea_strings[i].Substring(0, nmea_strings[i].IndexOf('*'));
                    string[] field = raw_string.Split(NMEADelimiter);
                    if (field.Count() > 7) {
                        if (String.Empty != field[PRN_1]) {
                            this.satelites.Add(NMEAHelper.CreateSateleiteView(field[PRN_1], field[ELEVATION_1], field[AZMUTH_1], field[SNR_1]));
                            ++this.Count;
                        }
                    }
                    if (field.Count() > 11) {
                        if (String.Empty != field[PRN_2]) {
                            this.satelites.Add(NMEAHelper.CreateSateleiteView(field[PRN_2], field[ELEVATION_2], field[AZMUTH_2], field[SNR_2]));
                            ++this.Count;
                        }
                    }
                    if (field.Count() > 15) {
                        if (String.Empty != field[PRN_3]) {
                            this.satelites.Add(NMEAHelper.CreateSateleiteView(field[PRN_3], field[ELEVATION_3], field[AZMUTH_3], field[SNR_3]));
                            ++this.Count;
                        }
                    }
                    if (field.Count() > 19) {
                        if (String.Empty != field[PRN_4]) {
                            this.satelites.Add(NMEAHelper.CreateSateleiteView(field[PRN_4], field[ELEVATION_4], field[AZMUTH_4], field[SNR_4]));
                            ++this.Count;
                        }
                    }
                    if (field.Count() > 23) {
                        if (String.Empty != field[PRN_5]) {
                            this.satelites.Add(NMEAHelper.CreateSateleiteView(field[PRN_5], field[ELEVATION_5], field[AZMUTH_5], field[SNR_5]));
                            ++this.Count;
                        }
                    }
                    if (field.Count() > 27) {
                        if (String.Empty != field[PRN_6]) {
                            this.satelites.Add(NMEAHelper.CreateSateleiteView(field[PRN_6], field[ELEVATION_6], field[AZMUTH_6], field[SNR_6]));
                            ++this.Count;
                        }
                    }
                }
                return true; 
            }
            public string[] NMEAStrings { get; private set; }
            public int Count { get; private set; }
            public IEnumerable<ISateliteView> Satelites { get { return this.satelites; } }
            public string[] CheckSum { get; private set; } // one CheckSum per string
            public bool Checked { get; private set; }
        }

        private class SateliteView : ISateliteView {
            public int PRN { get; private set; }
            public int Elevation { get; private set; } // degrees 0 - 90 max
            public int Azimuth { get; private set; } // degrees from true north, 000 to 359
            public bool Tracking { get; private set; }
            public int SNR { get; private set; } // 00-99 dB (ignore when not tracking)
            public SateliteView(string prn, string elevation, string azmuth, string snr) {
                if (!String.IsNullOrEmpty(prn)) this.PRN = int.Parse(prn);
                if (!String.IsNullOrEmpty(elevation)) this.Elevation = int.Parse(elevation);
                if (!String.IsNullOrEmpty(azmuth)) this.Azimuth = int.Parse(azmuth);
                if (String.Empty != snr) {
                    this.SNR = int.Parse(snr);
                    this.Tracking = true;
                } else {
                    this.SNR = 0;
                    this.Tracking = false;
                }
            }
            public override string ToString() {
                return String.Format("PRN:{0} Elv:{1} Azm:{2} Tk:{3} SNR:{4}", this.PRN, this.Elevation, this.Azimuth, this.Tracking, this.SNR);
            }
        }
    }
}
//        public const int SPEED_INDEX = 7;
//        public const int BEARING_INDEX = 8;

/*
    def _from_NMEA_GPGGA(self, string):
        string = string.replace('\r', ' ')
        string = string.replace('\n', ' ') 
        try:
            self._parse_GPGGA(string)
        except Exception, e:
            import traceback
            import sys
            traceback.print_exc(file=sys.stdout)
            print "Invalid GPS data: %s" % e
            self.valid = False

    def _parse_GPGGA(self, string):
        elements = string.split(",", 14)
        if len(elements) < 15:
            raise Exception("Unable to split GPGGA" % len(elements))

        t = time.strftime("%m%d%y") + elements[1]
        if "." in t:
            t = t.split(".")[0]
        self.date = parse_date(t, "%m%d%y%H%M%S")

        self.latitude = nmea2deg(float(elements[2]), elements[3])
        self.longitude = nmea2deg(float(elements[4]), elements[5])

        print "%f,%f" % (self.latitude, self.longitude)

        self.satellites = int(elements[7])
        self.altitude = float(elements[9])

        m = re.match("^([0-9]*)(\*[A-z0-9]{2})\r?\n?(.*)$", elements[14])
        if not m:
            raise Exception("No checksum (%s)" % elements[14])

        csum = m.group(2)
        if "," in m.group(3):
            sta, com = m.group(3).split(",", 1)
            if not sta.strip().startswith("$"):
                self.station = utils.filter_to_ascii(sta.strip()[0:8])
                self.comment = utils.filter_to_ascii(com.strip()[0:20])
                self._original_comment = self.comment

        if len(self.comment) >=7 and "*" in self.comment[-3:-1]:
            self._parse_dprs_comment()

        self.valid = self._test_checksum(string, csum)

 * 
def dm2deg(deg, min):
    return deg + (min / 60.0)

def deg2dm(decdeg):
    deg = int(decdeg)
    min = (decdeg - deg) * 60.0

    return deg, min

def nmea2deg(nmea, dir="N"):
    deg = int(nmea) / 100
    try:
        min = nmea % (deg * 100)
    except ZeroDivisionError, e:
        min = int(nmea)

    if dir == "S" or dir == "W":
        m = -1
    else:
        m = 1

    return dm2deg(deg, min) * m
 * 
 * 
def NMEA_checksum(string):
    checksum = 0
    for i in string:
        checksum ^= ord(i)

    return "*%02x" % checksum
*/