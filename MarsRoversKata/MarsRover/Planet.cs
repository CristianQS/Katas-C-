using System.Collections.Generic;

namespace MarsRover {
    public interface Planet {
        int Latitude { get; set; }
        int Longitude { get; set; }
        Dictionary<string, string> Map { get; set; }

    }
}