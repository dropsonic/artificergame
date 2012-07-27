using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class SimulationSpeedNormalCommand : ICommand
    {
        Simulator _simulator;
        
        public SimulationSpeedNormalCommand(Simulator simulator)
        {
            _simulator = simulator;
        }

        public string Name
        { get { return "SimulationSpeedNormal"; } }

        public void Execute()
        {
            _simulator.SimulationSpeed = Simulator.NormalSimulationSpeed;
        }


    }
}
