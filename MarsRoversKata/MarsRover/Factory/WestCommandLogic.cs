using System;
using MarsRover.Enums;
using MarsRover.Shared;

namespace MarsRover.Factory {
    public class WestCommandLogic : CommandsLogic {
        public Rover Rover { get; }
        public CommandsValues Command { get; }
        public Planet Planet { get; }

        public WestCommandLogic(Rover rover, CommandsValues command, Planet planet) {
            Rover = rover;
            Command = command;
            Planet = planet;
        }

        public Rover execute() {
            if (Rover.IsRoverCrossingTheHorizontalEdge(-Planet.Longitude)) return Rover;
            RoverPositionHelper.checkIfThereIsAnObstaculeInTheHorizontalAxis(Rover, Planet);

            if (Command.Equals(CommandsValues.Forward)) Rover.Point.x--;
            if (Command.Equals(CommandsValues.Backward)) Rover.Point.x++;
            if (Command.Equals(CommandsValues.Right)) Rover.Direction = Directions.North;
            if (Command.Equals(CommandsValues.Left)) Rover.Direction = Directions.South;
            return Rover;
        }
    }
}