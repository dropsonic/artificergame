using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using Microsoft.Xna.Framework;

namespace LevelEditor.Commands
{
    public class AddPreviewObject : ICommand
    {
        private MainFormController _controller;
        private GameObject _tempObject;

        public string Name
        {
            get { return "AddPreviewObject"; }
        }

        public void Execute()
        {
            _tempObject = _controller.PreviewObject.CopyObjectToWorld(new FarseerPhysics.Dynamics.World(Vector2.Zero), Vector2.Zero);
            _controller.AddPreviewObject();

        }

        public void Unexecute()
        {
            _controller.PreviewObject = _tempObject;
        }
    }
}
