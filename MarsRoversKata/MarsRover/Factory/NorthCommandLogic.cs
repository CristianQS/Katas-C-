namespace MarsRover.Factory {
    public class NorthCommandLogic : CommandsLogic {
        private Rover Rover { get; }
        private CommandsValues Command { get; }

        public NorthCommandLogic(Rover rover, CommandsValues command) {
            this.Rover = rover;
            this.Command = command;
        }

        public Rover execute() {
            if (Command.Equals(CommandsValues.Forward)) this.Rover.Point.y++;
            if (Command.Equals(CommandsValues.Backward)) this.Rover.Point.y--;
            if (Command.Equals(CommandsValues.Right)) this.Rover.Direction = Directions.East;
            if (Command.Equals(CommandsValues.Left)) this.Rover.Direction = Directions.West;
            return Rover;
        }
    }
}