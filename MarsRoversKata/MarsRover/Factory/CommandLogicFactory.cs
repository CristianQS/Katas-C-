namespace MarsRover.Factory {
    public class CommandLogicFactory {
        private Rover rover;

        public CommandLogicFactory(Rover rover) {
            this.rover = rover;
        }

        public Rover executeRoverNorthCommandLogic(CommandsValues command) {
            return new NorthCommandLogic(rover, command).execute();
        }

        public Rover executeRoverSouthCommandLogic(CommandsValues command) {
            return new SouthCommandLogic(rover, command).execute();
        }
    }
}