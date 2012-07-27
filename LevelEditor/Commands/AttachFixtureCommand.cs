using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Common;
using FarseerPhysics.Factories;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Collision.Shapes;

namespace LevelEditor.Commands
{
    public class AttachFixtureCommand : ICommand, IUndoRedoCommand
    {
        private GameLevel _gameLevel;
        private Body _body;
        private List<Shape> _shapes;
        private List<Fixture> _createdFixtures;


        /// <summary>
        /// Создаёт новый экземпляр AddPreviewObjectCommand.
        /// </summary>
        /// <param name="objectToAdd">Объект для добавления.</param>
        /// <param name="level">Уровень, в который необходимо добавить объект.</param>
        /// <param name="position">Позиция точки Origin объекта в уровне.</param>
        public AttachFixtureCommand(GameLevel gameLevel, Body body, List<Shape> shapes)
        {
            _gameLevel = gameLevel;
            _body = body;
            _shapes = shapes;
            _createdFixtures = new List<Fixture>(_shapes.Count);
        }

        public string Name
        {
            get { return "AttachFixture"; }
        }

        public void Execute()
        {
            foreach (Shape shape in _shapes)
            {
                _createdFixtures.Add(_body.CreateFixture(shape));
            }
            _gameLevel.World.ProcessChanges();
        }

        public void Unexecute()
        {
            foreach (Fixture fix in _createdFixtures)
            {
                _body.FixtureList.Remove(fix);
            }
            _gameLevel.World.ProcessChanges();
        }
    }
}
