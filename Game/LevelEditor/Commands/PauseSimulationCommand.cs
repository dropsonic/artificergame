using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelEditor.Commands
{
    public class PauseSimulationCommand : ICommand
    {
        Simulator _simulator;

        public PauseSimulationCommand(Simulator simulator)
        {
            _simulator = simulator;
        }

        public void Execute()
        {
            _simulator.Pause();
        }

        public string Name
        {
            get { return "PauseSimulation"; }
        }
    }
}
