using System.Collections.Generic;

namespace MarsRover {
    public class Rover {
        private Point point;
        private Directions direction;

        public Rover(Point point, Directions direction) {
            this.point = point;
            this.direction = direction;
        }

        public Point Point => point;

        public Directions Direction => direction;

        public void Execute(List<Commands> commandsList) {
            commandsList.ForEach(command => {
                if (command.Equals(Commands.Forward)) this.point.y++;
                if (command.Equals(Commands.Backward)) this.point.y--;
                if (command.Equals(Commands.Right)) this.direction = Directions.East;
                if (command.Equals(Commands.Left)) this.direction = Directions.West;
            });
        }
    }
}