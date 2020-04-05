using MarsRover.Enums;

namespace MarsRover.Factory {
    public class SouthCommandLogic : CommandsLogic {

        public Rover Execute(Rover rover, CommandsValues command, Planet planet) {
            if (rover.IsRoverCrossingTheVerticalEdge(-planet.Latitude)) return rover;
            rover.CheckIfThereIsAnObstaculeInTheVerticalAxis();

            if (command.Equals(CommandsValues.Forward)) rover.Point.y--;
            if (command.Equals(CommandsValues.Backward)) rover.Point.y++;
            if (command.Equals(CommandsValues.Right)) rover.Direction = Directions.West;
            if (command.Equals(CommandsValues.Left)) rover.Direction = Directions.East;
            return rover;
        }

    }
}