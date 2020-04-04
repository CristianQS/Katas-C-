using System;
using MarsRover.Enums;
using MarsRover.Shared;

namespace MarsRover.Factory {
    public class NorthCommandLogic : CommandsLogic {
        public Rover Rover { get; }
        public CommandsValues Command { get; }
        public Planet Planet { get; }

        public NorthCommandLogic(Rover rover, CommandsValues command, Planet planet) {
            Rover = rover;
            Command = command;
            Planet = planet;
        }

        public Rover execute() {
            if (Rover.IsRoverCrossingTheVerticalEdge(Planet.Latitude )) return Rover;
            RoverPositionHelper.checkIfThereIsAnObstaculeInTheVerticalAxis(Rover, Planet);

            if (Command.Equals(CommandsValues.Forward)) Rover.Point.y++;
            if (Command.Equals(CommandsValues.Backward)) Rover.Point.y--;
            if (Command.Equals(CommandsValues.Right)) Rover.Direction = Directions.East;
            if (Command.Equals(CommandsValues.Left)) Rover.Direction = Directions.West;
            return Rover;
        }

    }
}