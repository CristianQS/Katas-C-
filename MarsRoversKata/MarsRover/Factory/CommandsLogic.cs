using MarsRover.Enums;

namespace MarsRover.Factory {
    public interface CommandsLogic {
        Rover Rover { get; }
        CommandsValues Command { get; }
        Planet Planet { get; }

        Rover execute();
    }
}