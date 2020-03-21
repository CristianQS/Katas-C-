using System.Collections.Generic;
using MarsRover;
using NUnit.Framework;

namespace MarsRoverTest
{
    [TestFixture]
    public class MarsRoverShould
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void given_a_initial_point_and_direction_for_a_rover() {
            var point = new Point(0,0);
            var direction = Directions.North;

            var rover = new Rover(point, direction);

            Assert.AreEqual(0, rover.Point.x);
            Assert.AreEqual(0, rover.Point.y);
            Assert.AreEqual(Directions.North, rover.Direction);
        }

        [Test]
        public void rover_with_one_command_moves_to_forward() {
            var point = new Point(0, 0);
            var Direction = Directions.North;

            var rover = new Rover(point, Direction);
            var commandsList = new List<Commands>(){Commands.Forward};
            rover.Execute(commandsList);

            Assert.AreEqual(0,rover.Point.x);
            Assert.AreEqual(1,rover.Point.y);
            Assert.AreEqual(Directions.North, rover.Direction );
        }        
        
        [Test]
        public void rover_with_one_command_moves_to_backward() {
            var point = new Point(0, 0);
            var Direction = Directions.North;

            var rover = new Rover(point, Direction);
            var commandsList = new List<Commands>(){Commands.Backward};
            rover.Execute(commandsList);

            Assert.AreEqual(0,rover.Point.x);
            Assert.AreEqual(-1,rover.Point.y);
            Assert.AreEqual(Directions.North, rover.Direction );
        }        
        
        [Test]
        public void rover_with_one_command_moves_to_right() {
            var point = new Point(0, 0);
            var Direction = Directions.North;

            var rover = new Rover(point, Direction);
            var commandsList = new List<Commands>(){Commands.Right};
            rover.Execute(commandsList);

            Assert.AreEqual(0,rover.Point.x);
            Assert.AreEqual(0,rover.Point.y);
            Assert.AreEqual(Directions.East,rover.Direction );
        }        
        
        [Test]
        public void rover_with_one_command_moves_to_left() {
            var point = new Point(0, 0);
            var Direction = Directions.North;

            var rover = new Rover(point, Direction);
            var commandsList = new List<Commands>(){Commands.Left};
            rover.Execute(commandsList);

            Assert.AreEqual(0,rover.Point.x);
            Assert.AreEqual(0,rover.Point.y);
            Assert.AreEqual(Directions.West, rover.Direction );
        } 
        
        [Test]
        public void rover_with_multiple_command_moves_to_left_front() {
            var point = new Point(0, 0);
            var Direction = Directions.North;

            var rover = new Rover(point, Direction);
            var commandsList = new List<Commands>() { Commands.Left, Commands.Forward };
            rover.Execute(commandsList);

            Assert.AreEqual(-1,rover.Point.x);
            Assert.AreEqual(0,rover.Point.y);
            Assert.AreEqual(Directions.West, rover.Direction );
        }
        
        [Test]
        public void rover_with_multiple_command_moves_to_left_front_left_back_left_front_right_back() {
            var point = new Point(0, 0);
            var Direction = Directions.North;

            var rover = new Rover(point, Direction);
            var commandsList = new List<Commands>() { Commands.Left, Commands.Forward, Commands.Left, 
                    Commands.Backward, Commands.Left, Commands.Forward, Commands.Right, Commands.Backward };
            rover.Execute(commandsList);

            Assert.AreEqual(0,rover.Point.x);
            Assert.AreEqual(2,rover.Point.y);
            Assert.AreEqual(Directions.South, rover.Direction );
        }
    }
}