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

        }

        [Test]
        public void given_a_initial_point_and_direction_for_a_rover() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.North)
                .WithPoint(0, 0).Build();

            Assert.AreEqual(0, Rover.Point.x);
            Assert.AreEqual(0, Rover.Point.y);
            Assert.AreEqual(Directions.North, Rover.Direction);
        }

        [Test]
        public void moves_to_forward_with_one_command() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.North)
                .WithPoint(0, 0).Build();

            var commandsList = new List<CommandsValues>(){CommandsValues.Forward};
            Rover.Execute(commandsList);

            Assert.AreEqual(0,Rover.Point.x);
            Assert.AreEqual(1,Rover.Point.y);
            Assert.AreEqual(Directions.North, Rover.Direction );
        }        
        
        [Test]
        public void moves_to_backward_with_one_command() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.North)
                .WithPoint(0, 0).Build();

            var commandsList = new List<CommandsValues>(){CommandsValues.Backward};
            Rover.Execute(commandsList);

            Assert.AreEqual(0,Rover.Point.x);
            Assert.AreEqual(-1,Rover.Point.y);
            Assert.AreEqual(Directions.North, Rover.Direction );
        }        
        
        [Test]
        public void moves_to_right_with_one_command() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.North)
                .WithPoint(0, 0).Build();

            var commandsList = new List<CommandsValues>(){CommandsValues.Right};
            Rover.Execute(commandsList);

            Assert.AreEqual(0,Rover.Point.x);
            Assert.AreEqual(0,Rover.Point.y);
            Assert.AreEqual(Directions.East,Rover.Direction );
        }        
        
        [Test]
        public void moves_to_left_with_one_command() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.North)
                .WithPoint(0, 0).Build();

            var commandsList = new List<CommandsValues>(){CommandsValues.Left};
            Rover.Execute(commandsList);

            Assert.AreEqual(0,Rover.Point.x);
            Assert.AreEqual(0,Rover.Point.y);
            Assert.AreEqual(Directions.West, Rover.Direction );
        } 
        
        [Test]
        public void moves_to_left_front_with_multiple_command() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.North)
                .WithPoint(0, 0).Build();

            var commandsList = new List<CommandsValues>() { CommandsValues.Left, CommandsValues.Forward };
            Rover.Execute(commandsList);

            Assert.AreEqual(-1,Rover.Point.x);
            Assert.AreEqual(0,Rover.Point.y);
            Assert.AreEqual(Directions.West, Rover.Direction );
        }
        
        [Test]
        public void moves_to_left_front_left_back_left_front_right_back_with_multiple_command() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.North)
                .WithPoint(0, 0).Build();

            var commandsList = new List<CommandsValues>() { CommandsValues.Left, CommandsValues.Forward, CommandsValues.Left, 
                    CommandsValues.Backward, CommandsValues.Left, CommandsValues.Forward, CommandsValues.Right, CommandsValues.Backward };
            Rover.Execute(commandsList);

            Assert.AreEqual(0,Rover.Point.x);
            Assert.AreEqual(2,Rover.Point.y);
            Assert.AreEqual(Directions.South, Rover.Direction );
        }

        [Test]
        public void cross_the_planet_from_west_edge_to_the_east_edge() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.West)
                .WithPoint(-4, 2).Build();

            var commandsList = new List<CommandsValues>() { CommandsValues.Forward };
            Rover.Execute(commandsList);

            Assert.AreEqual(4, Rover.Point.x);
            Assert.AreEqual(2, Rover.Point.y);
            Assert.AreEqual(Directions.West, Rover.Direction);

        }

        [Test]
        public void cross_the_planet_from_east_edge_to_the_west_edge() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.East)
                .WithPoint(4, 2).Build();

            var commandsList = new List<CommandsValues>() { CommandsValues.Forward };
            Rover.Execute(commandsList);

            Assert.AreEqual(-4, Rover.Point.x);
            Assert.AreEqual(2, Rover.Point.y);
            Assert.AreEqual(Directions.East, Rover.Direction);

        }

        [Test]
        public void cross_the_planet_from_north_edge_to_the_south_edge() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.North)
                .WithPoint(4, 2).Build();

            var commandsList = new List<CommandsValues>() { CommandsValues.Forward };
            Rover.Execute(commandsList);

            Assert.AreEqual(4, Rover.Point.x);
            Assert.AreEqual(-2, Rover.Point.y);
            Assert.AreEqual(Directions.North, Rover.Direction);

        }

        [Test]
        public void cross_the_planet_from_south_edge_to_the_north_edge() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.South)
                .WithPoint(4, -2).Build();

            var commandsList = new List<CommandsValues>() { CommandsValues.Forward };
            Rover.Execute(commandsList);

            Assert.AreEqual(4, Rover.Point.x);
            Assert.AreEqual(2, Rover.Point.y);
            Assert.AreEqual(Directions.South, Rover.Direction);

        }

        [Test]
        public void rover_cross() {
            var Rover = new RoverBuilder()
                .WithPlanet(2, 4)
                .WithDirections(Directions.South)
                .WithPoint(1, 2).Build();
            Rover.Planet.Map["1,1"] = "X";

            var commandsList = new List<CommandsValues>() { CommandsValues.Forward };

            Assert.Throws<NextPositionHasAnObstaculeException>(() => Rover.Execute(commandsList));
        }
    }
}