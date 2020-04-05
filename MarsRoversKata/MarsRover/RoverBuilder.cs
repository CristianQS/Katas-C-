using MarsRover.Enums;

namespace MarsRover {
    public class RoverBuilder {
        private Planet Planet;
        private Point Point;
        private Directions Direction;

        public void WithMars(int latitude, int longitude) {
            Planet = new Mars(latitude, longitude);
        }

        public void WithPoint(int x, int y) {
            Point = new Point(x,y);
        }

        public void WithDirections(Directions direction) {
            Direction = direction;
        }

        public Rover Build() {
            return new Rover(Point, Direction, Planet);
        }
    }
}