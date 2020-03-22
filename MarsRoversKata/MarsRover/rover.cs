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
                    if (command.Equals(Commands.Forward)) this.Point.y--;
                    if (command.Equals(Commands.Backward)) this.Point.y++;
                    if (command.Equals(Commands.Right)) this.Direction = Directions.West;
                    if (command.Equals(Commands.Left)) this.Direction = Directions.East;
                } else if(this.Direction == Directions.West) {
                    if (command.Equals(Commands.Forward)) this.Point.x--;
                    if (command.Equals(Commands.Backward)) this.Point.x++;
                    if (command.Equals(Commands.Right)) this.Direction = Directions.North;
                    if (command.Equals(Commands.Left)) this.Direction = Directions.South;
                } else if(this.Direction == Directions.East) {
                    if (command.Equals(Commands.Forward)) this.Point.x++;
                    if (command.Equals(Commands.Backward)) this.Point.x--;
                    if (command.Equals(Commands.Right)) this.Direction = Directions.South;
                    if (command.Equals(Commands.Left)) this.Direction = Directions.North;
                }
            });
        }
    }
}