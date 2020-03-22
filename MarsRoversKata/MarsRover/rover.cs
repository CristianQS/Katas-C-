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

        public void Execute(List<CommandsValues> commandsList) {
            var commandLogicFactory = new CommandLogicFactory(this);
            commandsList.ForEach(command => {
                if (this.Direction == Directions.North) {
                    commandLogicFactory.executeRoverNorthCommandLogic(command);
                } else if (this.Direction == Directions.South) {
                    commandLogicFactory.executeRoverSouthCommandLogic(command);
                }
                else if(this.Direction == Directions.West) {
                    executeWestCommandsLogic(command);
                } else if(this.Direction == Directions.East) {
                    executeEastCommandsLogic(command);
                }
            });
        }

        private void executeEastCommandsLogic(CommandsValues commandValues) {
            if (commandValues.Equals(CommandsValues.Forward)) this.Point.x++;
            if (commandValues.Equals(CommandsValues.Backward)) this.Point.x--;
            if (commandValues.Equals(CommandsValues.Right)) this.Direction = Directions.South;
            if (commandValues.Equals(CommandsValues.Left)) this.Direction = Directions.North;
        }

        private void executeWestCommandsLogic(CommandsValues commandValues) {
            if (commandValues.Equals(CommandsValues.Forward)) this.Point.x--;
            if (commandValues.Equals(CommandsValues.Backward)) this.Point.x++;
            if (commandValues.Equals(CommandsValues.Right)) this.Direction = Directions.North;
            if (commandValues.Equals(CommandsValues.Left)) this.Direction = Directions.South;
        }



    }
}