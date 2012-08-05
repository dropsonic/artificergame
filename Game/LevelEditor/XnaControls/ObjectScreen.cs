using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision.Shapes;
using FarseerTools;
using GameLogic;
using System;
using System.Windows.Forms;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.DebugViews;
using FarseerPhysics;
using System.ComponentModel;
using LevelEditor.Helpers;
using FarseerPhysics.Common;


namespace LevelEditor
{
    class ObjectScreen : GraphicsDeviceControl
    {
        SpriteBatch _spriteBatch;
        GameObject _gameObject;
        Camera _camera;
        SpriteFont _font;
        SelectedItemsDisplay _selectedItemsDisplay;
        GridSnap _gridSnap;

        public GridSnap GridSnap
        {
            get
            {
                return _gridSnap;
            }
            set
            {
                _gridSnap = value;
            }
        }

        public SelectedItemsDisplay SelectedItemsDisplay
        {
            get
            {
                return _selectedItemsDisplay;
            }
        }

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
        }

        public GameObject GameObject
        {
            get { return _gameObject; }
            set { _gameObject = value; }
        }

        public Camera Camera
        {
            get { return _camera; }
            set { _camera = value; }
        }

        private GameObject _previewGameObject;

        [Browsable(false)]
        public GameObject PreviewGameObject
        {
            set
            {
                if (value == null)
                    _previewGameObject = null;
                else
                {
                    _previewGameObject = value;
                    _previewGameObject.Camera = _camera;
                    _previewGameObject.SpriteBatch = _spriteBatch;
                }
            }
        }

        private Vector2 _mousePosition;
        public new Vector2 MousePosition
        {
            get
            {
                return _mousePosition;
            }
            set
            {
                _mousePosition = value;
            }
        }

        public bool DrawCurrentGameObject { get; set; }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Fonts/Segoe14");

            _camera = new Camera(new Viewport(0, 0, ClientSize.Width, ClientSize.Height));

            _mousePosition = Vector2.Zero;
            DrawCurrentGameObject = false;

            _selectedItemsDisplay = new SelectedItemsDisplay(GraphicsDevice);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Content.Unload();
            }

            base.Dispose(disposing);
        }

        protected override void Draw()
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (_previewGameObject != null && DrawCurrentGameObject)
            {
                _previewGameObject.Camera.Position = -_mousePosition;
                _previewGameObject.Draw(GameTimer.GameTime);
                _previewGameObject.Camera.Position = Vector2.Zero;
            }

            if (_gameObject != null)
                _gameObject.Draw(GameTimer.GameTime);

            Matrix proj = Matrix.CreateOrthographicOffCenter(0, ConvertUnits.ToSimUnits(this.Size.Width), ConvertUnits.ToSimUnits(this.Size.Height), 0, 0, 1);
            _selectedItemsDisplay.DrawSelectedItems(ref proj);
          
        }

        protected override void LoadContent()
        {
        }

        protected override void UpdateFrame()
        {

        }
    }
}   
