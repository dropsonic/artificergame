using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using FarseerPhysics.Dynamics;
using FarseerTools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Common;

namespace LevelEditor
{
    public class ObjectLevelManager
    {
        public ObjectLevelManager(Camera camera, GraphicsDevice graphicsDevice)
        {
            SpriteBatch spriteBatch = new SpriteBatch(graphicsDevice);
            //Создаём PreviewObject
            _previewObject = new GameObject(camera, spriteBatch);
            Body body = new Body(_previewObject.World);
            _previewObject.AddPart(new Sprite(null, Vector2.Zero,Vector2.Zero), body);

            //Создаём GameLevel
            _gameLevel = new GameLevel(camera, spriteBatch);

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
            get { return _simulator.GameLevel; }
            set { _simulator.GameLevel = value; }
        }

        public GameObject PreviewObject
        {
            get { return _previewObject; }
            set { _previewObject = value; }
        }

        public Vertices PreviewVertices
        {
            get;
            set;
        }
    }
}
 