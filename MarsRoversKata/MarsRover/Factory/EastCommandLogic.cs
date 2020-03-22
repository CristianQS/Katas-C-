﻿using System;

namespace MarsRover.Factory {
    public class EastCommandLogic : CommandsLogic {
        public Rover Rover { get; }
        public CommandsValues Command { get; }
        public Planet Planet { get; }

        public EastCommandLogic(Rover rover, CommandsValues command, Planet planet) {
            Command = command;
            Planet = planet;
            Rover = rover;
        }

        public Rover execute() {
            if (Planet.Longitude == Math.Abs(Rover.Point.x) && Command.Equals(CommandsValues.Forward)) {
                Rover.Point.x = -Planet.Longitude;
                return Rover;
            }
            if (Command.Equals(CommandsValues.Forward)) Rover.Point.x++;
            if (Command.Equals(CommandsValues.Backward)) Rover.Point.x--;
            if (Command.Equals(CommandsValues.Right)) Rover.Direction = Directions.South;
            if (Command.Equals(CommandsValues.Left)) Rover.Direction = Directions.North;
            return Rover;
        }
    }
}