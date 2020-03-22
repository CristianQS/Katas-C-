namespace MarsRover.Factory {
    public class WestCommandLogic : CommandsLogic {
        private Rover Rover { get; }
        private CommandsValues Command { get; }

        public WestCommandLogic(Rover rover, CommandsValues command) {
            this.Rover = rover;
            this.Command = command;
        }

        public Rover execute() {
            if (Command.Equals(CommandsValues.Forward)) this.Rover.Point.x--;
            if (Command.Equals(CommandsValues.Backward)) this.Rover.Point.x++;
            if (Command.Equals(CommandsValues.Right)) this.Rover.Direction = Directions.North;
            if (Command.Equals(CommandsValues.Left)) this.Rover.Direction = Directions.South;
            return Rover;
        }
    }
}