using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class SimulationSpeedDecreaseCommand : ICommand
    {
        Simulator _simulator;

        public SimulationSpeedDecreaseCommand(Simulator simulator)
        {
            _simulator = simulator;
        }

        public string Name
        { get { return "SimulationSpeedDecrease"; } }

        public void Execute()
        {
            _simulator.SimulationSpeed -= 0.25f;
        }
    }
}
