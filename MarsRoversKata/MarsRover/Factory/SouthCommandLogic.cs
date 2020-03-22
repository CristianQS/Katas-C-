namespace MarsRover.Factory {
    public class SouthCommandLogic : CommandsLogic {
        private Rover rover { get; }
        private CommandsValues command { get; }

        public SouthCommandLogic(Rover rover, CommandsValues command) {
            this.rover = rover;
            this.command = command;
        }

        public Rover execute() {
            if (command.Equals(CommandsValues.Forward)) this.rover.Point.y--;
            if (command.Equals(CommandsValues.Backward)) this.rover.Point.y++;
            if (command.Equals(CommandsValues.Right)) this.rover.Direction = Directions.West;
            if (command.Equals(CommandsValues.Left)) this.rover.Direction = Directions.East;
            return rover;
        }
    }
}