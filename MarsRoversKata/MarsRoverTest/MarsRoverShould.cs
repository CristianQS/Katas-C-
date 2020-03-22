using System.Collections.Generic;
using MarsRover;
using MarsRover.Enums;
using MarsRover.Exceptions;
using NUnit.Framework;

namespace MarsRoverTest
{
    [TestFixture]
    public class MarsRoverShould {
        public Mars Mars;
        public Rover Rover;

        [SetUp]
        public void Setup() {
            Mars = new Mars(2,4);
            var point = new Point(0, 0);
            var Direction = Directions.North;
            Rover = new Rover(point, Direction);
        }

        [Test]
        public void given_a_initial_point_and_direction_for_a_rover() {
            //var point = Rover.Direction(0,0);
           
            Assert.AreEqual(0, Rover.Point.x);
            Assert.AreEqual(0, Rover.Point.y);
            Assert.AreEqual(Directions.North, Rover.Direction);
        }

        [Test]
        public void rover_with_one_command_moves_to_forward() {

            var commandsList = new List<CommandsValues>(){CommandsValues.Forward};
            Rover.Execute(commandsList,Mars);

            Assert.AreEqual(0,Rover.Point.x);
            Assert.AreEqual(1,Rover.Point.y);
            Assert.AreEqual(Directions.North, Rover.Direction );
        }        
        
        [Test]
        public void rover_with_one_command_moves_to_backward() {

            var commandsList = new List<CommandsValues>(){CommandsValues.Backward};
            Rover.Execute(commandsList, Mars);

            Assert.AreEqual(0,Rover.Point.x);
            Assert.AreEqual(-1,Rover.Point.y);
            Assert.AreEqual(Directions.North, Rover.Direction );
        }        
        
        [Test]
        public void rover_with_one_command_moves_to_right() {
            var commandsList = new List<CommandsValues>(){CommandsValues.Right};
            Rover.Execute(commandsList, Mars);

            Assert.AreEqual(0,Rover.Point.x);
            Assert.AreEqual(0,Rover.Point.y);
            Assert.AreEqual(Directions.East,Rover.Direction );
        }        
        
        [Test]
        public void rover_with_one_command_moves_to_left() {
            var commandsList = new List<CommandsValues>(){CommandsValues.Left};
            Rover.Execute(commandsList, Mars);

            Assert.AreEqual(0,Rover.Point.x);
            Assert.AreEqual(0,Rover.Point.y);
            Assert.AreEqual(Directions.West, Rover.Direction );
        } 
        
        [Test]
        public void rover_with_multiple_command_moves_to_left_front() {

            var commandsList = new List<CommandsValues>() { CommandsValues.Left, CommandsValues.Forward };
            Rover.Execute(commandsList, Mars);

            Assert.AreEqual(-1,Rover.Point.x);
            Assert.AreEqual(0,Rover.Point.y);
            Assert.AreEqual(Directions.West, Rover.Direction );
        }
        
        [Test]
        public void rover_with_multiple_command_moves_to_left_front_left_back_left_front_right_back() {

            var commandsList = new List<CommandsValues>() { CommandsValues.Left, CommandsValues.Forward, CommandsValues.Left, 
                    CommandsValues.Backward, CommandsValues.Left, CommandsValues.Forward, CommandsValues.Right, CommandsValues.Backward };
            Rover.Execute(commandsList, Mars);

            Assert.AreEqual(0,Rover.Point.x);
            Assert.AreEqual(2,Rover.Point.y);
            Assert.AreEqual(Directions.South, Rover.Direction );
        }

        [Test]
        public void rover_cross_the_planet_from_west_edge_to_the_east_edge() {
            var point = new Point(-4,2);
            var direction = Directions.West;
            var rover = new Rover(point, direction);

            var commandsList = new List<CommandsValues>() { CommandsValues.Forward };
            rover.Execute(commandsList, Mars);

            Assert.AreEqual(4, rover.Point.x);
            Assert.AreEqual(2, rover.Point.y);
            Assert.AreEqual(Directions.West, rover.Direction);

        }

        [Test]
        public void rover_cross_the_planet_from_east_edge_to_the_west_edge() {
            var point = new Point(4,2);
            var direction = Directions.East;
            var rover = new Rover(point, direction);

            var commandsList = new List<CommandsValues>() { CommandsValues.Forward };
            rover.Execute(commandsList, Mars);

            Assert.AreEqual(-4, rover.Point.x);
            Assert.AreEqual(2, rover.Point.y);
            Assert.AreEqual(Directions.East, rover.Direction);

        }

        [Test]
        public void rover_cross_the_planet_from_north_edge_to_the_south_edge() {
            var point = new Point(4,2);
            var direction = Directions.North;
            var rover = new Rover(point, direction);

            var commandsList = new List<CommandsValues>() { CommandsValues.Forward };
            rover.Execute(commandsList, Mars);

            Assert.AreEqual(4, rover.Point.x);
            Assert.AreEqual(-2, rover.Point.y);
            Assert.AreEqual(Directions.North, rover.Direction);

        }

        [Test]
        public void rover_cross_the_planet_from_south_edge_to_the_north_edge() {
            var point = new Point(4,-2);
            var direction = Directions.South;
            var rover = new Rover(point, direction);

            var commandsList = new List<CommandsValues>() { CommandsValues.Forward };
            rover.Execute(commandsList, Mars);

            Assert.AreEqual(4, rover.Point.x);
            Assert.AreEqual(2, rover.Point.y);
            Assert.AreEqual(Directions.South, rover.Direction);

        }

        [Test]
        public void rover_cross() {
            var point = new Point(1, 2);
            var direction = Directions.South;
            Mars.Map["1,1"] = "X";

            var rover = new Rover(point, direction);

            var commandsList = new List<CommandsValues>() { CommandsValues.Forward };

            Assert.Throws<NextPositionHasAnObstaculeException>(() => rover.Execute(commandsList, Mars));
        }
    }
}