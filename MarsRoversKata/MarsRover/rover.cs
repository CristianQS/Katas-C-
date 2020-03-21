using System.Collections.Generic;

namespace MarsRover {
    public class Rover {
        public Point Point { get; }
        public Directions Direction { get; set; }

        public Rover(Point point, Directions direction) {
            this.Point = point;
            this.Direction = direction;
        }


        public void Execute(List<Commands> commandsList) {
            commandsList.ForEach(command => {
                if (this.Direction == Directions.North) {
                    if (command.Equals(Commands.Forward)) this.Point.y++;
                    if (command.Equals(Commands.Backward)) this.Point.y--;
                    if (command.Equals(Commands.Right)) this.Direction = Directions.East;
                    if (command.Equals(Commands.Left)) this.Direction = Directions.West;
                } else if(this.Direction == Directions.West) {
                    if (command.Equals(Commands.Forward)) this.Point.x--;
                    if (command.Equals(Commands.Backward)) this.Point.x++;
                    if (command.Equals(Commands.Right)) this.Direction = Directions.North;
                    if (command.Equals(Commands.Left)) this.Direction = Directions.South;
                }
                
            
            });
        }
    }
}