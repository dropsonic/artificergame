﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using FarseerPhysics.Dynamics;
using FarseerTools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditor
{
    public class MainFormController
    {
        public MainFormController(Camera camera, GraphicsDevice graphicsDevice)
        {
            //Создаём PreviewObject
            _previewObject = new GameObject();
            Body body = new Body(_previewObject.World);
            _previewObject.AddPart(new Sprite(null, Vector2.Zero), body);

            //Создаём GameLevel
            _gameLevel = new GameLevel(camera, new SpriteBatch(graphicsDevice));

            //Создаём Simulator
            _simulator = new Simulator(_gameLevel);
        }

        private Simulator _simulator;
        private GameLevel _gameLevel;
        private GameObject _previewObject;

        public Simulator Simulator
        {
            get { return _simulator; }
            set { _simulator = value; }
        }

        public GameLevel GameLevel
        {
            get { return _gameLevel; }
            set { _gameLevel = value; }
        }

        public GameObject PreviewObject
        {
            get { return _previewObject; }
            set { _previewObject = value; }
        }

        public void AddPreviewObject()
        {
            _simulator.GameLevel.AddObject(_previewObject.CopyObjectToWorld(_simulator.GameLevel.World, ConvertUnits.ToSimUnits(_simulator.MousePosition)));
        }
    }
}
