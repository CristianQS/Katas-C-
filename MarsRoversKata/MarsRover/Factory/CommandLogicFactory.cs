using MarsRover.Enums;

namespace MarsRover.Factory {
    public class CommandLogicFactory {
        public Planet Mars { get; }
        private Rover Rover;

        public CommandLogicFactory(Rover rover, Planet mars) {
            Mars = mars;
            Rover = rover;
        }

        public CommandsLogic executeRoverNorthCommandLogic(CommandsValues command) {
            return new NorthCommandLogic(Rover, command, Mars);
        }

        public CommandsLogic executeRoverSouthCommandLogic(CommandsValues command) {
            return new SouthCommandLogic(Rover, command, Mars);
        }

        public CommandsLogic executeRoverWestCommandLogic(CommandsValues command) {
            return  new WestCommandLogic(Rover, command, Mars);
        }

        public CommandsLogic executeRoverEastCommandLogic(CommandsValues command) {
            return new EastCommandLogic(Rover, command, Mars);
        }
    }
}