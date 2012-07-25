using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class SimulationSpeedHalf
    {
        Simulator _simulator;

        public SimulationSpeedHalf(Simulator simulator)
        {
            _simulator = simulator;
        }

        public string Name
        { get { return "SimulationSpeedHalf"; } }

        public void Execute()
        {
            _simulator.SimulationSpeed = 0.5f;
        }
    }
}
