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


namespace LevelEditor
{
    class LevelScreen : GraphicsDeviceControl
    {
        SpriteBatch _spriteBatch;
        GameLevel _gameLevel;
        SpriteFont _font;
        DebugViewXNA _debugView;
        SelectedItemsDisplay _selectedItemsDisplay;
        GridSnap _gridSnap;
        Texture2D _lineTexture;

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
                    _previewGameObject.Camera = new Camera(new Viewport(0, 0, this.Size.Width, this.Size.Height));
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

            _mousePosition = Vector2.Zero;
            DrawCurrentGameObject = false;

            _selectedItemsDisplay = new SelectedItemsDisplay(GraphicsDevice);

            _lineTexture = new Texture2D(GraphicsDevice, 1, 1);
            _lineTexture.SetData<Color>(new Color[] { Color.White });
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

            if (_gridSnap.Enabled)
            {
                int vertCount = this.Size.Height / _gridSnap.GridHeight;
                int horCount = this.Size.Width / _gridSnap.GridWidth;
                _spriteBatch.Begin();
                for (int i = 0; i < vertCount + 1; i++)
                {
                    _spriteBatch.Draw(_lineTexture, new Rectangle(0,i*_gridSnap.GridHeight, this.Size.Width, 1), Color.Gray);
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

            if (_gameLevel != null)
                _gameLevel.Draw(GameTimer.GameTime);


            Matrix simProj = Matrix.CreateOrthographicOffCenter(0, ConvertUnits.ToSimUnits(this.Size.Width), ConvertUnits.ToSimUnits(this.Size.Height), 0, 0, 1);
            Matrix simView = _gameLevel.Camera.GetSimViewMatrix();

            _selectedItemsDisplay.DrawSelectedItems(ref simProj, ref simView);
            if (_debugView != null)
                _debugView.RenderDebugData(ref simProj, ref simView);


            
        }

        protected override void LoadContent()
        {
        }

        public delegate void UpdateDelegate(GameTime gameTime);
        public UpdateDelegate UpdateSubscriber;
        protected override void UpdateFrame()
        {
            if (UpdateSubscriber!=null)
                UpdateSubscriber(GameTimer.GameTime);
        }
    }
}   
