﻿using MarsRover.Enums;

namespace MarsRover.Factory {
    public interface CommandsLogic {

        Rover Execute(Rover rover, CommandsValues command, Planet planet);
    }
}