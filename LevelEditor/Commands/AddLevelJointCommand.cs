using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using FarseerPhysics.Dynamics.Joints;

namespace LevelEditor.Commands
{
    public class AddLevelJointCommand : ICommand, IUndoRedoCommand
    {
        private GameLevel _gameLevel;
        private Joint _joint;


        /// <summary>
        /// Создаёт новый экземпляр AddPreviewObjectCommand.
        /// </summary>
        /// <param name="objectToAdd">Объект для добавления.</param>
        /// <param name="level">Уровень, в который необходимо добавить объект.</param>
        /// <param name="position">Позиция точки Origin объекта в уровне.</param>
        public AddLevelJointCommand(GameLevel gameLevel, Joint joint)
        {
            _gameLevel = gameLevel;
            _joint = joint;
        }

        public string Name
        {
            get { return "AddJoint"; }
        }

        public void Execute()
        {
            _gameLevel.AddJoint(_joint);
            _gameLevel.World.ProcessChanges();
        }

        public void Unexecute()
        {
            _gameLevel.RemoveJoint(_joint);
            _gameLevel.World.ProcessChanges();
        }
    }
}
