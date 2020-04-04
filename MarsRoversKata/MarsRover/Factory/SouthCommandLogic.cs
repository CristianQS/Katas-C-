using MarsRover.Enums;

namespace MarsRover.Factory {
    public class SouthCommandLogic : CommandsLogic {
        public Rover Rover { get; }
        public CommandsValues Command { get; }
        public Planet Planet { get; }

        public SouthCommandLogic(Rover rover, CommandsValues command, Planet planet) {
            Rover = rover;
            Command = command;
            Planet = planet;
        }

        public Rover Execute() {
            if (Rover.IsRoverCrossingTheVerticalEdge(-Planet.Latitude)) return Rover;
            Rover.CheckIfThereIsAnObstaculeInTheVerticalAxis();

            if (Command.Equals(CommandsValues.Forward)) Rover.Point.y--;
            if (Command.Equals(CommandsValues.Backward)) Rover.Point.y++;
            if (Command.Equals(CommandsValues.Right)) Rover.Direction = Directions.West;
            if (Command.Equals(CommandsValues.Left)) Rover.Direction = Directions.East;
            return Rover;
        }

        
        
    }
}