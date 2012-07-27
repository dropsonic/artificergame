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
        private GameObject _objectToAdd;
        private GameObject _addedObject;
        private GameLevel _level;
        private Vector2 _position;

        /// <summary>
        /// ������ ����� ��������� AddPreviewObjectCommand.
        /// </summary>
        /// <param name="objectToAdd">������ ��� ����������.</param>
        /// <param name="level">�������, � ������� ���������� �������� ������.</param>
        /// <param name="position">������� ����� Origin ������� � ������.</param>
        public AddPreviewObjectCommand(GameObject objectToAdd, GameLevel level, Vector2 position)
        {
            _objectToAdd = objectToAdd;
            _level = level;
            _position = position;
        }

        public string Name
        {
            get { return "AddPreviewObject"; }
        }

        public void Execute()
        {
            foreach (GameObjectPart part in _objectToAdd)
                if (part.Sprite.Texture == null)
                    throw new NullReferenceException("Texture cannot be null.");
            _addedObject = _objectToAdd.CopyObjectToWorld(_level.World, ConvertUnits.ToSimUnits(_position));
            _level.AddObject(_addedObject);
            _level.World.ProcessChanges();
        }

        public void Unexecute()
        {
            _level.RemoveObject(_addedObject);
            _level.World.ProcessChanges();
        }
    }
}
