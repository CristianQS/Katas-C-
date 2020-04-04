using System;
using System.Collections.Generic;
using MarsRover.Enums;
using MarsRover.Exceptions;
using MarsRover.Factory;

namespace MarsRover {
    public class Rover {
        public Point Point { get; }
        public Directions Direction { get; set; }
        private const string OBSTACULE = "X";


        public Rover(Point point, Directions direction) {
            this.Point = point;
            this.Direction = direction;
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

        public void CheckIfThereIsAnObstaculeInTheVerticalAxis(Planet planet) {
            if (planet.Map[$"{Point.x},{Point.y - 1}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
            if (planet.Map[$"{Point.x},{Point.y + 1}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
        }

        public void CheckIfThereIsAnObstaculeInTheHorizontalAxis(Planet planet) {
            if (planet.Map[$"{Point.x - 1},{Point.y}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
            if (planet.Map[$"{Point.x + 1},{Point.y}"].Equals(OBSTACULE))
                throw new NextPositionHasAnObstaculeException();
        }

        public void Execute(List<CommandsValues> commandsList, Planet mars) {
            var commandLogicFactory = new CommandLogicFactory(this, mars);
            commandsList.ForEach(command => {
                switch (Direction) {
                    case Directions.North:
                        commandLogicFactory.executeRoverNorthCommandLogic(command).execute();
                        break;                  
                    case Directions.South:
                        commandLogicFactory.executeRoverSouthCommandLogic(command).execute();
                        break;                    
                    case Directions.West:
                        commandLogicFactory.executeRoverWestCommandLogic(command).execute();
                        break;                    
                    case Directions.East:
                        commandLogicFactory.executeRoverEastCommandLogic(command).execute();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
        }
    }
}