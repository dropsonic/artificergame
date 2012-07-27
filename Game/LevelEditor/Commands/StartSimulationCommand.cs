using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class StartSimulationCommand : ICommand
    {
        Simulator _simulator;

        public StartSimulationCommand(Simulator simulator)
        {
            _simulator = simulator;
        }

        public void Execute()
        {
            _simulator.Start();
        }

        public string Name
        {
            get { return "StartSimulation"; }
        }
    }
}
