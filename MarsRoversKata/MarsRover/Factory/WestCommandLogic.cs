﻿using System;
using MarsRover.Enums;

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
            if ((-Planet.Longitude) == Rover.Point.x && Command.Equals(CommandsValues.Forward)) {
                Rover.Point.x = Planet.Longitude;
                return Rover;
            }
            if (Command.Equals(CommandsValues.Forward)) Rover.Point.x--;
            if (Command.Equals(CommandsValues.Backward)) Rover.Point.x++;
            if (Command.Equals(CommandsValues.Right)) Rover.Direction = Directions.North;
            if (Command.Equals(CommandsValues.Left)) Rover.Direction = Directions.South;
            return Rover;
        }
    }
}