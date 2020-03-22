namespace MarsRover.Factory {
    public class CommandLogicFactory {
        public Planet Mars { get; }
        private Rover Rover;

        public CommandLogicFactory(Rover rover, Planet mars) {
            Mars = mars;
            Rover = rover;
        }

        public Rover executeRoverNorthCommandLogic(CommandsValues command) {
            return new NorthCommandLogic(Rover, command, Mars).execute();
        }

        public Rover executeRoverSouthCommandLogic(CommandsValues command) {
            return new SouthCommandLogic(Rover, command, Mars).execute();
        }

        public Rover executeRoverWestCommandLogic(CommandsValues command) {
            return  new WestCommandLogic(Rover, command, Mars).execute();
        }

        public Rover executeRoverEastCommandLogic(CommandsValues command) {
            return new EastCommandLogic(Rover, command, Mars).execute();
        }
    }
}