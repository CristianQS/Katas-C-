using System;

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
            if (Planet.Latitude == Rover.Point.y && Command.Equals(CommandsValues.Forward)) {
                Rover.Point.y = -Planet.Latitude;
                return Rover;
            }

            if (Command.Equals(CommandsValues.Forward)) Rover.Point.y++;
            if (Command.Equals(CommandsValues.Backward)) Rover.Point.y--;
            if (Command.Equals(CommandsValues.Right)) Rover.Direction = Directions.East;
            if (Command.Equals(CommandsValues.Left)) Rover.Direction = Directions.West;
            return Rover;
        }
    }
}