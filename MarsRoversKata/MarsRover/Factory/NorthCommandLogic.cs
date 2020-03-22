namespace MarsRover.Factory {
    public class NorthCommandLogic : CommandsLogic {
        private Rover rover;
        private CommandsValues command;

        public NorthCommandLogic(Rover rover, CommandsValues command) {
            this.rover = rover;
            this.command = command;
        }

        public Rover execute() {
            if (command.Equals(CommandsValues.Forward)) this.rover.Point.y++;
            if (command.Equals(CommandsValues.Backward)) this.rover.Point.y--;
            if (command.Equals(CommandsValues.Right)) this.rover.Direction = Directions.East;
            if (command.Equals(CommandsValues.Left)) this.rover.Direction = Directions.West;
            return rover;
        }
    }
}