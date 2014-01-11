    public class AirTransit {
        public DateTime Departure { get; private set; }
        public TimeSpan TimeInFlight { get; private set; }
        public AirTransit(int year, int month, int day, int hour, int minute, int hours_in_flight, int minutes_in_flight) {
            this.Departure = new DateTime(year, month, day, hour, minute, 0);
            this.TimeInFlight = new TimeSpan(hours_in_flight, minutes_in_flight, 0);
        }
        private static IEnumerable<ICity> ReadCities(string filename) {
            return F<ICity>.LoadTextFile(filename, Encoding.UTF8, StringToICity);
        }
        private static ICity StringToICity(string record) {
            ICity city = null;
            string[] field = record.Split(',');
            if (field.Length >= 5) {
                string name = field[0];
                string country = field[1];
                int priority = int.Parse(field[2]); // todo handle parse error
                float lat = float.Parse(field[3]); // todo handle parse error
                float lon = float.Parse(field[4]); // toso handle parse error
                city = City.Create(name, country, priority, lat, lon);
            }
            return city;
        }
    }
    public interface ICity {
        string Name { get; }
        string Country { get; }
        int Priority { get; }
        float Latitude { get; }
        float Longitude { get; } 
    }
    public class City : ICity {
        public string Name { get; private set; }
        public string Country { get; private set; }
        public int Priority { get; private set; }
        public float Latitude { get; private set; }
        public float Longitude { get; private set; }
        private City(string name, string country, int priority, float latitude, float longitude) {
            this.Name = name;
            this.Country = country;
            this.Priority = priority;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        public static ICity Create(string name, string country, int priority, float latitude, float longitude) {
            return new City(name, country, priority, latitude, longitude);
        }
    }