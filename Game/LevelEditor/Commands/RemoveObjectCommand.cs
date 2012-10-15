using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using Microsoft.Xna.Framework;
using FarseerTools;
using FarseerPhysics.Dynamics;

namespace LevelEditor.Commands
{
    public class RemoveObjectCommand : ICommand, IUndoRedoCommand
    {
        private GameObject _objectToDelete;
        private GameObject _deletedObject;
        private GameLevel _level;


        /// <summary>
        /// ������ ����� ��������� AddPreviewObjectCommand.
        /// </summary>
        /// <param name="objectToAdd">������ ��� ����������.</param>
        /// <param name="level">�������, � ������� ���������� �������� ������.</param>
        /// <param name="position">������� ����� Origin ������� � ������.</param>
        public RemoveObjectCommand(GameObject objectToDelete, GameLevel level)
        {
            _objectToDelete = objectToDelete;
            _level = level;
        }

        public string Name
        {
            get { return "RemoveObject"; }
        }

        public void Execute()
        {
            //������ ������ - ����� �� �������� �������� ��� ��������, ��� �������
            _deletedObject = _objectToDelete.CopyObjectToWorld(new World(Vector2.Zero), Vector2.Zero);
            _level.RemoveObject(_objectToDelete);
            _level.World.ProcessChanges();
        }

        public void Unexecute()
        {
            _level.AddObject(_deletedObject.CopyObjectToWorld(_level.World, Vector2.Zero));
            _level.World.ProcessChanges();
        }
    }
}
