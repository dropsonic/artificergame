using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class SimulationSpeedDecrease
    {
        Simulator _simulator;

        public SimulationSpeedDecrease(Simulator simulator)
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
