using System.Collections.Generic;

namespace MarsRover {
    public class Mars : Planet {
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public Mars(int latitude, int longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Dictionary<string, string> GetMap() {
            var map = new Dictionary<string, string>();
            for (var longitudeIndex = -Longitude; longitudeIndex <= Longitude; longitudeIndex++) {
                for (var latitudeIndex = Latitude; latitudeIndex >= -Latitude; latitudeIndex--) {
                    map.Add($"{latitudeIndex},{longitudeIndex}","-");
                }
            }
            return map;
        }
    }
}