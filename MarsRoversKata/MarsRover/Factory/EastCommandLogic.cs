using System;
using MarsRover.Enums;

namespace MarsRover.Factory {
    public class EastCommandLogic : CommandsLogic {

        public Rover Execute(Rover rover, CommandsValues command, Planet planet) {
            if (rover.IsRoverCrossingTheHorizontalEdge(planet.Longitude)) return rover;
            rover.CheckIfThereIsAnObstaculeInTheHorizontalAxis();
           
            if (command.Equals(CommandsValues.Forward)) rover.Point.x++;
            if (command.Equals(CommandsValues.Backward)) rover.Point.x--;
            if (command.Equals(CommandsValues.Right)) rover.Direction = Directions.South;
            if (command.Equals(CommandsValues.Left)) rover.Direction = Directions.North;
            return rover;
        }
    }
}