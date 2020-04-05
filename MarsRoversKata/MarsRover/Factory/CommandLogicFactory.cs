using MarsRover.Enums;

namespace MarsRover.Factory {
    public static class CommandLogicFactory {

        public static CommandsLogic GetRoverNorthCommandLogic() {
            return new NorthCommandLogic();
        }

        public static CommandsLogic GetRoverSouthCommandLogic() {
            return new SouthCommandLogic();
        }

        public static CommandsLogic GetRoverWestCommandLogic() {
            return  new WestCommandLogic();
        }

        public static CommandsLogic GetRoverEastCommandLogic() {
            return new EastCommandLogic();
        }
    }
}