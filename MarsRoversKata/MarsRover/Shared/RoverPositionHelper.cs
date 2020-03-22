using MarsRover.Enums;
using MarsRover.Exceptions;

namespace MarsRover.Shared {
    public static class RoverPositionHelper {
        private const string Obstacule = "X";

        public static bool IsRoverCrossingTheVerticalEdge(Rover rover, int Latitude, CommandsValues command, out Rover isCrossing) {
            if ((-Latitude) == rover.Point.y && command.Equals(CommandsValues.Forward)) {
                rover.Point.y = Latitude;
                isCrossing = rover;
                return true;
            }

            isCrossing = null;
            return false;
        }

        public static void checkIfThereIsAnObstacule(Rover rover, Planet planet, CommandsValues command) {
            if (planet.Map[$"{rover .Point.x},{rover .Point.y - 1}"].Equals(Obstacule) && (command.Equals(CommandsValues.Forward)))
                throw new NextPositionHasAnObstaculeException();
            if (planet.Map[$"{rover .Point.x},{rover .Point.y + 1}"].Equals(Obstacule) && (command.Equals(CommandsValues.Backward)))
                throw new NextPositionHasAnObstaculeException();
        }
    }
}