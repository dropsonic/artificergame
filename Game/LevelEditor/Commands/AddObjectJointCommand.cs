using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using FarseerPhysics.Dynamics.Joints;

namespace LevelEditor.Commands
{
    public class AddObjectJointCommand : ICommand, IUndoRedoCommand
    {
        private GameObject _gameObject;
        private Joint _joint;


        /// <summary>
        /// Создаёт новый экземпляр AddPreviewObjectCommand.
        /// </summary>
        /// <param name="objectToAdd">Объект для добавления.</param>
        /// <param name="level">Уровень, в который необходимо добавить объект.</param>
        /// <param name="position">Позиция точки Origin объекта в уровне.</param>
        public AddObjectJointCommand(GameObject gameObject, Joint joint)
        {
            _gameObject = gameObject;
            _joint = joint;
        }

        public string Name
        {
            get { return "AddObjectJoint"; }
        }

        public void Execute()
        {
            _gameObject.AddJoint(_joint);
            _gameObject.World.ProcessChanges();
        }

        public void Unexecute()
        {
            _gameObject.RemoveJoint(_joint);
            _gameObject.World.ProcessChanges();
        }
    }
}
