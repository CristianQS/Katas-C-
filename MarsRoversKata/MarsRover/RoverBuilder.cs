using MarsRover.Enums;

namespace MarsRover {
    public class RoverBuilder {
        private static Planet Planet;
        private static Point Point;
        private static Directions Direction;

        public RoverBuilder WithPlanet(int latitude, int longitude) {
            Planet = new Mars(latitude, longitude);
            return this;
        }

        public RoverBuilder WithPoint(int x, int y) {
            Point = new Point(x,y);
            return this;
        }

        public RoverBuilder WithDirections(Directions direction) {
            Direction = direction;
            return this;
        }

        public Rover Build() {
            return new Rover(Point, Direction, Planet);
        }
    }
}