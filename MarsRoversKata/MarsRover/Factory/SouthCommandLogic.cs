using System;
using MarsRover.Exceptions;

namespace MarsRover.Factory {
    public class SouthCommandLogic : CommandsLogic {
        private const string Obstacule = "X";
        public Rover Rover { get; }
        public CommandsValues Command { get; }
        public Planet Planet { get; }

        public SouthCommandLogic(Rover rover, CommandsValues command, Planet planet) {
            Rover = rover;
            Command = command;
            Planet = planet;
        }

        public Rover execute() {
            if (IsRoverCrossingTheEdge(out var isCrossing)) return isCrossing;

            checkIfThereIsAnObstacule();
            if (Command.Equals(CommandsValues.Forward)) Rover.Point.y--;
            if (Command.Equals(CommandsValues.Backward)) Rover.Point.y++;
            if (Command.Equals(CommandsValues.Right)) Rover.Direction = Directions.West;
            if (Command.Equals(CommandsValues.Left)) Rover.Direction = Directions.East;
            return Rover;
        }

        private void checkIfThereIsAnObstacule() {
            var position = Planet.Map[$"{Rover.Point.x},{Rover.Point.y -1 }"];
            if (Planet.Map[$"{Rover.Point.x},{Rover.Point.y - 1}"].Equals(Obstacule) && (Command.Equals(CommandsValues.Forward)))
                throw new NextPositionHasAnObstaculeException();
            if (Planet.Map[$"{Rover.Point.x},{Rover.Point.y + 1}"].Equals(Obstacule) && (Command.Equals(CommandsValues.Backward)))
                throw new NextPositionHasAnObstaculeException();
        }

        private bool IsRoverCrossingTheEdge(out Rover isCrossing) {
            if ((-Planet.Latitude) == Rover.Point.y && Command.Equals(CommandsValues.Forward)) {
                Rover.Point.y = Planet.Latitude;
                isCrossing = Rover;
                return true;
            }

            isCrossing = null;
            return false;
        }
    }
}