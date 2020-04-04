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
            if (Latitude == Point.y) {
                Point.y = -Latitude;
                return true;
            }

            return false;
        }
        public bool IsRoverCrossingTheHorizontalEdge(int Longitude) {
            if (Longitude == Point.x) {
                Point.x = -Longitude;
                return true;
            }
            return false;
        }

        public void Execute(List<CommandsValues> commandsList, Planet mars) {
            var commandLogicFactory = new CommandLogicFactory(this, mars);
            commandsList.ForEach(command => {
                if (this.Direction == Directions.North) {
                    commandLogicFactory.executeRoverNorthCommandLogic(command).execute();
                } else if (this.Direction == Directions.South) {
                    commandLogicFactory.executeRoverSouthCommandLogic(command).execute();
                } else if(this.Direction == Directions.West) {
                    commandLogicFactory.executeRoverWestCommandLogic(command).execute();
                } else if(this.Direction == Directions.East) {
                    commandLogicFactory.executeRoverEastCommandLogic(command).execute();
                }
            });
        }
    }
}