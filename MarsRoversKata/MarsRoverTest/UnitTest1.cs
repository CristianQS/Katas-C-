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

        [Test]
        private Point point;
        private string direction;

            var rover = new Rover(point, Direction);
            var commandsList = new List<string>(){"F"};
            rover.Execute(commandsList);

            Assert.AreEqual(0,rover.Point.x);
            Assert.AreEqual(1,rover.Point.y);
            Assert.AreEqual(NORTH_DIRECTION,rover.Direction );
        }
    }
}