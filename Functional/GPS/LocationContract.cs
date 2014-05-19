using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS {
    public enum Hemisphere { East, West, North, South }
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
    class LocationContract {
    }
}
