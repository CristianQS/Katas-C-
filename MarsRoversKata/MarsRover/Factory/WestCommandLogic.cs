using MarsRover.Enums;

namespace MarsRover.Factory {
    public class WestCommandLogic : CommandsLogic {

        public Rover Execute(Rover rover, CommandsValues command, Planet planet) {
            if (rover.IsRoverCrossingTheHorizontalEdge(-planet.Longitude)) return rover;
            rover.CheckIfThereIsAnObstaculeInTheHorizontalAxis();

            if (command.Equals(CommandsValues.Forward)) rover.Point.x--;
            if (command.Equals(CommandsValues.Backward)) rover.Point.x++;
            if (command.Equals(CommandsValues.Right)) rover.Direction = Directions.North;
            if (command.Equals(CommandsValues.Left)) rover.Direction = Directions.South;
            return rover;
        }
    }
}