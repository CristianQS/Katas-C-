using MarsRover.Enums;

namespace MarsRover.Factory {
    public static class CommandLogicFactory {

        public static CommandsLogic executeRoverNorthCommandLogic(CommandsValues command) {
            return new NorthCommandLogic();
        }

        public static CommandsLogic executeRoverSouthCommandLogic(CommandsValues command) {
            return new SouthCommandLogic();
        }

        public static CommandsLogic executeRoverWestCommandLogic(CommandsValues command) {
            return  new WestCommandLogic();
        }

        public static CommandsLogic executeRoverEastCommandLogic(CommandsValues command) {
            return new EastCommandLogic();
        }
    }
}