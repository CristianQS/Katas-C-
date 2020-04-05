using System;
using System.Collections.Generic;
using MarsRover.Enums;
using MarsRover.Exceptions;
using MarsRover.Factory;

namespace MarsRover {
    public class Rover {
        public Point Point { get; }
        public Directions Direction { get; set; }
        public Planet planet { get; }
        private const string OBSTACULE = "X";


        public Rover(Point point, Directions direction, Planet mars) {
            Point = point;
            Direction = direction;
            planet  = mars;
        }
        public bool IsRoverCrossingTheVerticalEdge(int latitude) {
            if (latitude != Point.y) return false;
            Point.y = -latitude;
            return true;
        }
        public bool IsRoverCrossingTheHorizontalEdge(int longitude) {
            if (longitude != Point.x) return false;
            Point.x = -longitude;
            return true;
        }

        public void CheckIfThereIsAnObstaculeInTheVerticalAxis() {
            if (planet.Map[$"{Point.x},{Point.y - 1}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
            if (planet.Map[$"{Point.x},{Point.y + 1}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
        }

        public void CheckIfThereIsAnObstaculeInTheHorizontalAxis() {
            if (planet.Map[$"{Point.x - 1},{Point.y}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
            if (planet.Map[$"{Point.x + 1},{Point.y}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
        }

        public void Execute(List<CommandsValues> commandsList) {
            commandsList.ForEach(command => {
                switch (Direction) {
                    case Directions.North:
                        CommandLogicFactory.executeRoverNorthCommandLogic(command).Execute(this, command, planet);
                        break;                  
                    case Directions.South:
                        CommandLogicFactory.executeRoverSouthCommandLogic(command).Execute(this, command, planet);
                        break;                    
                    case Directions.West:
                        CommandLogicFactory.executeRoverWestCommandLogic(command).Execute(this, command, planet);
                        break;                    
                    case Directions.East:
                        CommandLogicFactory.executeRoverEastCommandLogic(command).Execute(this, command, planet);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }
    }
}