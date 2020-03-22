using System;
using MarsRover.Enums;
using MarsRover.Shared;
using MarsRover.Exceptions;

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

        public Rover execute() {
            if (RoverPositionHelper.IsRoverCrossingTheVerticalEdge(Rover, -Planet.Latitude, out var isCrossing)) return isCrossing;
            RoverPositionHelper.checkIfThereIsAnObstaculeInTheVerticalAxis(Rover,Planet);

            if (Command.Equals(CommandsValues.Forward)) Rover.Point.y--;
            if (Command.Equals(CommandsValues.Backward)) Rover.Point.y++;
            if (Command.Equals(CommandsValues.Right)) Rover.Direction = Directions.West;
            if (Command.Equals(CommandsValues.Left)) Rover.Direction = Directions.East;
            return Rover;
        }

        
        
    }
}