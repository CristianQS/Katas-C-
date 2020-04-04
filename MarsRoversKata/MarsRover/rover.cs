using System;
using System.Collections.Generic;
using MarsRover.Enums;
using MarsRover.Factory;

namespace MarsRover {
    public class Rover {
        public Point Point { get; }
        public Directions Direction { get; set; }

        public Rover(Point point, Directions direction) {
            this.Point = point;
            this.Direction = direction;
        }
        public bool IsRoverCrossingTheVerticalEdge(int Latitude) {
            if (Latitude != Point.y) return false;
            Point.y = -Latitude;
            return true;
        }
        public bool IsRoverCrossingTheHorizontalEdge(int Longitude) {
            if (Longitude != Point.x) return false;
            Point.x = -Longitude;
            return true;
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