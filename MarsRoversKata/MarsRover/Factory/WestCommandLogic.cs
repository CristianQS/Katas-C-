namespace MarsRover.Factory {
    public class WestCommandLogic : CommandsLogic {
        private Rover rover { get; }
        private CommandsValues command { get; }

        public WestCommandLogic(Rover rover, CommandsValues command) {
            this.rover = rover;
            this.command = command;
        }

        public Rover execute() {
            if (command.Equals(CommandsValues.Forward)) this.rover.Point.x--;
            if (command.Equals(CommandsValues.Backward)) this.rover.Point.x++;
            if (command.Equals(CommandsValues.Right)) this.rover.Direction = Directions.North;
            if (command.Equals(CommandsValues.Left)) this.rover.Direction = Directions.South;
            return rover;
        }
    }
}