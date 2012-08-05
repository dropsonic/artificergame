using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using Microsoft.Xna.Framework;
using FarseerTools;

namespace LevelEditor.Commands
{
    public class AddObjectPartCommand : ICommand, IUndoRedoCommand
    {
        private GameObject _objectToAdd;
        private List<GameObjectPart> _addedObjects;
        private GameObject _goalObject;
        private Vector2 _position;

        public AddObjectPartCommand(GameObject objectToAdd, GameObject goalObject, Vector2 position)
        {
            _objectToAdd = objectToAdd;
            _goalObject = goalObject;
            _position = position;
            _addedObjects = new List<GameObjectPart>();
        }

        public string Name
        {
            get { return "AddObjectPartCommand"; }
        }

        public void Execute()
        {
            foreach (GameObjectPart part in _objectToAdd)
            {
                if (part.Sprites[0].Texture == null)
                    throw new NullReferenceException("Texture cannot be null.");
                GameObjectPart tempPart = part.DeepClone(_goalObject.World, _position);
                _addedObjects.Add(tempPart);
                _goalObject.AddPart(tempPart);
            }
            _goalObject.World.ProcessChanges();
        }

        public void Unexecute()
        {
            foreach (GameObjectPart addedPart in _addedObjects)
                _goalObject.RemovePart(addedPart);
            _goalObject.World.ProcessChanges();
        }
    }
}
