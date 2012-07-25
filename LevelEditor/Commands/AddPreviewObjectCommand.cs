using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using Microsoft.Xna.Framework;
using FarseerTools;

namespace LevelEditor.Commands
{
    public class AddPreviewObjectCommand : ICommand, IUndoRedoCommand
    {
        private ObjectLevelManager _objectLevelManager;
        private GameObject _object;

        public AddPreviewObjectCommand(ObjectLevelManager objectLevelManager)
        {
            _objectLevelManager = objectLevelManager;
        }

        public string Name
        {
            get { return "AddPreviewObject"; }
        }

        public void Execute()
        {
            Simulator simulator = _objectLevelManager.Simulator;
            GameObject _object = _objectLevelManager.PreviewObject.CopyObjectToWorld(simulator.GameLevel.World, ConvertUnits.ToSimUnits(simulator.MousePosition));
            simulator.GameLevel.AddObject(_object);
        }

        public void Unexecute()
        {
            _objectLevelManager.Simulator.GameLevel.RemoveObject(_object);
        }
    }
}