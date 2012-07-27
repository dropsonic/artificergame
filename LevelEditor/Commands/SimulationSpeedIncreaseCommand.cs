using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class SimulationSpeedIncreaseCommand : ICommand
    {
        Simulator _simulator;

        public SimulationSpeedIncreaseCommand(Simulator simulator)
        {
            _simulator = simulator;
        }

        public string Name
        { get { return "SimulationSpeedIncrease"; } }

        public void Execute()
        {
            _simulator.SimulationSpeed += 0.25f;
        }
    }
}
