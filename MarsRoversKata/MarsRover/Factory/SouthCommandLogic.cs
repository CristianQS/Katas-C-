namespace MarsRover.Factory {
    public class SouthCommandLogic : CommandsLogic {
        private Rover Rover { get; }
        private CommandsValues Command { get; }

        public SouthCommandLogic(Rover rover, CommandsValues command) {
            this.Rover = rover;
            this.Command = command;
        }

        public Rover execute() {
            if (Command.Equals(CommandsValues.Forward)) this.Rover.Point.y--;
            if (Command.Equals(CommandsValues.Backward)) this.Rover.Point.y++;
            if (Command.Equals(CommandsValues.Right)) this.Rover.Direction = Directions.West;
            if (Command.Equals(CommandsValues.Left)) this.Rover.Direction = Directions.East;
            return Rover;
        }
    }
}