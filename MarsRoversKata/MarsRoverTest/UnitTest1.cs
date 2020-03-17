using NUnit.Framework;

namespace MarsRoverTest
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void given_a_initial_point_and_direction_for_a_rover() {
            var Point = new Point(0,0);
            var Direction = "N";

            var Rover = new Rover(Point, Direction);

            
            Assert.AreEqual(Rover.Point.x, 0);
            Assert.AreEqual(Rover.Point.y, 0);
            Assert.AreEqual(Rover.Direction, "N");
        }
    }

    public class Rover {
        private Point point;
        private string direction;

        public Rover(Point point, string direction) {
            this.point = point;
            this.direction = direction;
        }

        public Point Point => point;

        public string Direction => direction;
    }

    public class Point {
        public int x;
        public int y;

        public Point(int x, int y) {
            this.x = x;
            this.y = y;
        }
    }
}