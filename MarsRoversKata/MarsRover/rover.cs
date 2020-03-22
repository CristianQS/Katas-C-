using System.Collections.Generic;
using MarsRover.Factory;

namespace MarsRover {
    public class Rover {
        public Point Point { get; }
        public Directions Direction { get; set; }

        public Rover(Point point, Directions direction) {
            this.Point = point;
            this.Direction = direction;
        }

        public void Execute(List<CommandsValues> commandsList, Planet mars) {
            var commandLogicFactory = new CommandLogicFactory(this, mars);
            commandsList.ForEach(command => {
                if (this.Direction == Directions.North) {
                    commandLogicFactory.executeRoverNorthCommandLogic(command);
                } else if (this.Direction == Directions.South) {
                    commandLogicFactory.executeRoverSouthCommandLogic(command);
                } else if(this.Direction == Directions.West) {
                    commandLogicFactory.executeRoverWestCommandLogic(command);
                } else if(this.Direction == Directions.East) {
                    commandLogicFactory.executeRoverEastCommandLogic(command);
                }
            });
        }
    }
}