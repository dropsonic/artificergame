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


namespace LevelEditor
{
    class LevelScreen : GraphicsDeviceControl
    {
        SpriteBatch _spriteBatch;
        GameLevel _gameLevel;
        Camera _camera;
        SpriteFont _font;
        DebugViewXNA _debugView;

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
        }

        public GameLevel GameLevel
        {
            get { return _gameLevel; }
            set 
            { 
                _gameLevel = value;

                if (_gameLevel != null)
                {
                    SetDebugView();
                    _debugView.TranslateDebugPerfomancePair(_absoluteULPoint);
                }
            }
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

        private MouseEventArgs _mouseState;
        public MouseEventArgs MouseState 
        {
            get
            {
                return _mouseState;
            }
            set
            {
                _mouseState = value;
                if (value != null)
                    _mousePosition = new Vector2(value.X, value.Y);
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


        private Vector2 _absoluteULPoint;
        public Vector2 AbsoluteULPoint 
        {
            get
            {
                return _absoluteULPoint;
            }
            
            set
            {
                _absoluteULPoint = value;
                if (_debugView != null) //если null, то это дизайнер пытается присвоить значение при создании формы
                    _debugView.TranslateDebugPerfomancePair(value);
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
        }

        void SetDebugView()
        {
            DebugViewFlags flags = 0;
            if (_debugView != null) { flags = _debugView.Flags;}
            _debugView = new DebugViewXNA(_gameLevel.World);
            _debugView.DefaultShapeColor = Color.White;
            _debugView.SleepingShapeColor = Color.LightGray;
            _debugView.LoadContent(GraphicsDevice, new Viewport(0,0,this.Size.Width,this.Size.Height),Content);
            _debugView.Flags = flags;
        }

        public void SwitchDebugViewFlag(DebugViewFlags flag)
        {
            if ((_debugView.Flags & flag) == flag)
            {
                _debugView.RemoveFlags(flag);
            }
            else
            {
                _debugView.AppendFlags(flag);
            }
        }


        public bool DebugViewHasFlag(DebugViewFlags flag)
        {
            if (_debugView == null)
                return false;

            if ((_debugView.Flags & flag) == flag)
                return true;
            else
                return false;
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

            if (_gameLevel != null)
                _gameLevel.Draw(GameTimer.GameTime);
            
            if (_debugView != null)
            {
                Matrix proj = Matrix.CreateOrthographicOffCenter(0, ConvertUnits.ToSimUnits(this.Size.Width), ConvertUnits.ToSimUnits(this.Size.Height), 0, 0, 1);
                _debugView.RenderDebugData(ref proj);
            }

            var test = GameTimer.GameTime;
        }

        protected override void LoadContent()
        {
        }

        public delegate void UpdateDelegate(GameTime gameTime);
        public UpdateDelegate UpdateSubscriber;
        protected override void UpdateFrame()
        {
            UpdateSubscriber(GameTimer.GameTime);
        }
    }
}   
