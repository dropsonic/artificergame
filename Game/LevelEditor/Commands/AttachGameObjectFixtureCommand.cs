﻿using System;
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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FarseerTools;
using LevelEditor.Helpers;

namespace LevelEditor.Commands
{
    public class AttachGameObjectFixtureCommand : ICommand, IUndoRedoCommand
    {
        private GameObject _gameObject;
        private Body _body;
        private List<Shape> _shapes;
        private List<Fixture> _createdFixtures;
        private Sprite _sprite;
        private GameObjectPart _objectPart;

        public AttachGameObjectFixtureCommand(GameObject gameObject, Body body, List<Shape> shapes, Sprite sprite)
        {
            _gameObject = gameObject;
            _body = body;
            _shapes = shapes;
            _createdFixtures = new List<Fixture>(_shapes.Count);
            _sprite = sprite;
        }

        public string Name
        {
            get { return "AttachFixture"; }
        }

        public void Execute()
        {
            foreach (Shape shape in _shapes)
                _createdFixtures.Add(_body.CreateFixture(shape));

            _objectPart = CommonHelpers.FindGameObjectPart(_gameObject, _body);
            _objectPart.Sprites.Add(_sprite);

            _gameObject.World.ProcessChanges();
        }

        public void Unexecute()
        {
            foreach (Fixture fix in _createdFixtures)
            {
                _body.FixtureList.Remove(fix);
            }
            _objectPart.Sprites.Remove(_sprite);
            _gameObject.World.ProcessChanges();
        }
    }
}
