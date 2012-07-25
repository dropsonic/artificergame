using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class StopSimulationCommand : ICommand
    {
        Simulator _simulator;

        public StopSimulationCommand(Simulator simulator)
        {
            _simulator = simulator;
        }

        public void Execute()
        {
            _simulator.Stop();
        }

        public string Name
        {
            get { return "StopSimulation"; }
        }
    }
}
