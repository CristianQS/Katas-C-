namespace MarsRover.Factory {
    public class EastCommandLogic : CommandsLogic {
        private Rover rover;
        private CommandsValues command;

        public EastCommandLogic(Rover rover, CommandsValues command) {
            this.command = command;
            this.rover = rover;
        }

        public Rover execute() {
            if (command.Equals(CommandsValues.Forward)) this.rover.Point.x++;
            if (command.Equals(CommandsValues.Backward)) this.rover.Point.x--;
            if (command.Equals(CommandsValues.Right)) this.rover.Direction = Directions.South;
            if (command.Equals(CommandsValues.Left)) this.rover.Direction = Directions.North;
            return rover;
        }
    }
}