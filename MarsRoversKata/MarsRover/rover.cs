using System;
using System.Collections.Generic;
using MarsRover.Enums;
using MarsRover.Exceptions;
using MarsRover.Factory;

namespace MarsRover {
    public class Rover {
        public Point Point { get; }
        public Directions Direction { get; set; }
        public Planet Planet { get; }
        private const string OBSTACULE = "X";


        public Rover(Point point, Directions direction, Planet mars) {
            Point = point;
            Direction = direction;
            Planet  = mars;
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
            if (Planet.Map[$"{Point.x},{Point.y - 1}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
            if (Planet.Map[$"{Point.x},{Point.y + 1}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
        }

        public void CheckIfThereIsAnObstaculeInTheHorizontalAxis() {
            if (Planet.Map[$"{Point.x - 1},{Point.y}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
            if (Planet.Map[$"{Point.x + 1},{Point.y}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
        }

        public void Execute(List<CommandsValues> commandsList) {
            commandsList.ForEach(command => {
                switch (Direction) {
                    case Directions.North:
                        CommandLogicFactory.GetRoverNorthCommandLogic().Execute(this, command, Planet);
                        break;                  
                    case Directions.South:
                        CommandLogicFactory.GetRoverSouthCommandLogic().Execute(this, command, Planet);
                        break;                    
                    case Directions.West:
                        CommandLogicFactory.GetRoverWestCommandLogic().Execute(this, command, Planet);
                        break;                    
                    case Directions.East:
                        CommandLogicFactory.GetRoverEastCommandLogic().Execute(this, command, Planet);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }
    }
}