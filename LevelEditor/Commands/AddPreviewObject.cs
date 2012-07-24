using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;

namespace LevelEditor.Commands
{
    public class AddPreviewObject : ICommand
    {
        private MainFormController _controller;

        public string Name
        {
            get { return "AddPreviewObject"; }
        }

        public void Execute()
        {

        }

        public void Unexecute()
        {

        }
    }
}
