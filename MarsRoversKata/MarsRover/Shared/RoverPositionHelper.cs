using MarsRover.Exceptions;

namespace MarsRover.Shared {
    public static class RoverPositionHelper {
        private const string Obstacule = "X";

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