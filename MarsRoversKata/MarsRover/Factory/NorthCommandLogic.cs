using MarsRover.Enums;

namespace MarsRover.Factory {
    public class NorthCommandLogic : CommandsLogic {


        public Rover Execute(Rover rover , CommandsValues command, Planet planet) {
            if (rover.IsRoverCrossingTheVerticalEdge(planet.Latitude )) return rover;
            rover.CheckIfThereIsAnObstaculeInTheVerticalAxis();

            if (command.Equals(CommandsValues.Forward)) rover.Point.y++;
            if (command.Equals(CommandsValues.Backward)) rover.Point.y--;
            if (command.Equals(CommandsValues.Right)) rover.Direction = Directions.East;
            if (command.Equals(CommandsValues.Left)) rover.Direction = Directions.West;
            return rover;
        }

    }
}