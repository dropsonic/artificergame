using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class SimulationSpeedDouble
    {
        Simulator _simulator;

        public SimulationSpeedDouble(Simulator simulator)
        {
            _simulator = simulator;
        }

        public string Name
        { get { return "SimulationSpeedDouble"; } }

        public void Execute()
        {
            _simulator.SimulationSpeed = 2.0f;
        }
    }
}
