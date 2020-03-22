using MarsRover.Exceptions;

namespace MarsRover.Shared {
    public static class RoverPositionHelper {
        private const string Obstacule = "X";

        public static bool IsRoverCrossingTheVerticalEdge(Rover rover, int Latitude, out Rover isCrossing) {
            if (Latitude == rover.Point.y) {
                rover.Point.y = -Latitude;
                isCrossing = rover;
                return true;
            }

            isCrossing = null;
            return false;
        }
        public static bool IsRoverCrossingTheHorizontalEdge(Rover rover, int Longitude, out Rover isCrossing) {
            if (Longitude == rover.Point.x) {
                rover.Point.x = -Longitude;
                isCrossing = rover;
                return true;
            }

            isCrossing = null;
            return false;
        }

        public static void checkIfThereIsAnObstaculeInTheVerticalAxis(Rover rover, Planet planet) {
            if (planet.Map[$"{rover .Point.x},{rover .Point.y - 1}"].Equals(Obstacule))
                throw new NextPositionHasAnObstaculeException();
            if (planet.Map[$"{rover .Point.x},{rover .Point.y + 1}"].Equals(Obstacule))
                throw new NextPositionHasAnObstaculeException();
        }

        public static void checkIfThereIsAnObstaculeInTheHorizontalAxis(Rover rover, Planet planet) {
            if (planet.Map[$"{rover.Point.x - 1},{rover.Point.y}"].Equals(Obstacule))
                throw new NextPositionHasAnObstaculeException();
            if (planet.Map[$"{rover.Point.x + 1},{rover.Point.y}"].Equals(Obstacule))
                throw new NextPositionHasAnObstaculeException();
        }
    }
}