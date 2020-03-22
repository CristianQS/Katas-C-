namespace MarsRover.Factory {
    public class EastCommandLogic : CommandsLogic {
        private Rover Rover { get; }
        private CommandsValues Command { get; }

        public EastCommandLogic(Rover rover, CommandsValues command) {
            this.Command = command;
            this.Rover = rover;
        }

        public Rover execute() {
            if (Command.Equals(CommandsValues.Forward)) this.Rover.Point.x++;
            if (Command.Equals(CommandsValues.Backward)) this.Rover.Point.x--;
            if (Command.Equals(CommandsValues.Right)) this.Rover.Direction = Directions.South;
            if (Command.Equals(CommandsValues.Left)) this.Rover.Direction = Directions.North;
            return Rover;
        }
    }
}