using System.Collections.Generic;

namespace MarsRover {
    public class Rover {
        private Point point;
        private string direction;

        public Rover(Point point, string direction) {
            this.point = point;
            this.direction = direction;
        }

        public Point Point => point;

        public string Direction => direction;

        public void Execute(List<string> commandsList) {
            commandsList.ForEach(command => {
                if (command.Equals("F")) this.point.y++;
            });
        }
    }
}