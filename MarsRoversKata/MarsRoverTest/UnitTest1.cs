using System.Collections.Generic;
using MarsRover;
using NUnit.Framework;

namespace MarsRoverTest
{
    [TestFixture]
    public class Tests
    {
        private const string NORTH_DIRECTION = "N";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void given_a_initial_point_and_direction_for_a_rover() {
            var point = new Point(0,0);
            const string direction = NORTH_DIRECTION;

            var rover = new Rover(point, direction);


            Assert.AreEqual(0, rover.Point.x);
            Assert.AreEqual(0, rover.Point.y);
            Assert.AreEqual(NORTH_DIRECTION, rover.Direction);
        }

        [Test]
        public void rover_with_one_command_moves_to_forward() {
            var point = new Point(0, 0);
            var Direction = NORTH_DIRECTION;

            var rover = new Rover(point, Direction);
            var commandsList = new List<string>(){"F"};
            rover.Execute(commandsList);

            Assert.AreEqual(0,rover.Point.x);
            Assert.AreEqual(1,rover.Point.y);
            Assert.AreEqual(NORTH_DIRECTION,rover.Direction );
        }
    }
}