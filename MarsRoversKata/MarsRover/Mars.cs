using System.Collections.Generic;

namespace MarsRover {
    public class Mars : Planet {
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public Dictionary<string, string> Map { get; set; }


        public Mars(int latitude, int longitude) {
            Latitude = latitude;
            Longitude = longitude;
            Map = GenerateMap();
        }

        public Dictionary<string, string> GenerateMap() {
            Map = new Dictionary<string, string>();
            for (var longitudeIndex = -Longitude; longitudeIndex <= Longitude; longitudeIndex++) {
                for (var latitudeIndex = Latitude; latitudeIndex >= -Latitude; latitudeIndex--) {
                    Map.Add($"{latitudeIndex},{longitudeIndex}","-");
                }
            }
            return Map;
        }

        public Dictionary<string, string> GetMap() {
            return Map;
        }
    }
}