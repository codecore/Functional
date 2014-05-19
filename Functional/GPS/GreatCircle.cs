using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPS;
namespace GPS {
    public static class GreatCircle {
        public static float DegreesToRadians(float degrees) {
            return degrees * 0.01745329252f;// d * (float)(Math.PI) / 180.0f;
        }
        public static float RadiansToDegrees(float radians) {
            return radians * 57.295779513f; // r * 180.0f / (float)(Math.PI);
        }
        public static float RadiansToNauticalMiles(float radians) {
            return radians * 3437.74677f; // r *60 * 180 / pi
        }
        public static float NauticalMilesToStatuteMiles(float nautical) {
            return nautical * 1.15f;
        }
        public static float StatuteMilesToNauticalMiles(float statute) {
            return statute * 0.8695652174f;
        }
        public static float LatitudeToRadian(ILatitude latitude) {
            return (latitude.Hemisphere == Hemisphere.North) ? (float)(latitude.Degrees + (latitude.Minutes / 60.0f) + (float)(latitude.Seconds / 3600.0d)) :
                (float)(-1.0f * (latitude.Degrees + (latitude.Minutes / 60.0f) + (float)(latitude.Seconds / 3600.0d)));
        }
        public static float LongitudeToRadian(ILongitude longitude) {
            return (longitude.Hemisphere == Hemisphere.East) ? (float)(longitude.Degrees + (longitude.Minutes / 60.0f) + (float)(longitude.Seconds / 3600.0d)) :
                (float)(-1.0f * (longitude.Degrees + (longitude.Minutes / 60.0f) + (float)(longitude.Seconds / 3600.0d)));
        }
    }
}
