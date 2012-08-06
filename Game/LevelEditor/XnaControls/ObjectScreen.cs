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
        Texture2D _lineTexture;
        DebugViewXNA _jointView;

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

            _lineTexture = new Texture2D(GraphicsDevice, 1, 1);
            _lineTexture.SetData<Color>(new Color[] { Color.White });

            _jointView = new DebugViewXNA(_gameObject.World);
            _jointView.DefaultShapeColor = Color.White;
            _jointView.SleepingShapeColor = Color.LightGray;
            _jointView.LoadContent(GraphicsDevice, new Viewport(0, 0, this.Size.Width, this.Size.Height), Content);
            _jointView.AppendFlags(DebugViewFlags.Joint);
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

            if (_gridSnap.Enabled)
            {
                int vertCount = this.Size.Height / _gridSnap.GridHeight;
                int horCount = this.Size.Width / _gridSnap.GridWidth;
                _spriteBatch.Begin();
                for (int i = 0; i < vertCount + 1; i++)
                {
                    _spriteBatch.Draw(_lineTexture, new Rectangle(0, i * _gridSnap.GridHeight, this.Size.Width, 1), Color.Gray);
                }
                for (int i = 0; i < horCount + 1; i++)
                {
                    _spriteBatch.Draw(_lineTexture, new Rectangle(i * _gridSnap.GridWidth, 0, 1, this.Size.Height), Color.Gray);
                }
                _spriteBatch.End();
            }

            if (_previewGameObject != null && DrawCurrentGameObject)
            {
                _previewGameObject.Camera.Position = -_mousePosition;
                _previewGameObject.Draw(GameTimer.GameTime);
                _previewGameObject.Camera.Position = Vector2.Zero;
            }

            if (_gameObject != null)
                _gameObject.Draw(GameTimer.GameTime);

            Matrix simProj = Matrix.CreateOrthographicOffCenter(0, ConvertUnits.ToSimUnits(this.Size.Width), ConvertUnits.ToSimUnits(this.Size.Height), 0, 0, 1);
            Matrix simView = _camera.GetSimViewMatrix();

            _selectedItemsDisplay.DrawSelectedItems(ref simProj, ref simView);
            _jointView.RenderDebugData(ref simProj, ref simView);
          
        }

        protected override void LoadContent()
        {
        }

        protected override void UpdateFrame()
        {

        }
    }
}   
