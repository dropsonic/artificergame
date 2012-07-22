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
        SpriteFont _font;

        GameLevel _simulatedLevel;
        GameLevel _initialLevel;
  
        Camera _camera;
        TimeSpan _worldTime = TimeSpan.Zero;

        FixedMouseJoint _mouseJoint;
        DebugViewXNA _debugView;

        public string message = "";
        private GameObject _currentGameObject;
        [Browsable(false)]
        public GameObject CurrentGameObject
        {
            set
            {
                if (value == null)
                    _currentGameObject = null;
                else
                {
                    _currentGameObject = value;
                    _currentGameObject.Camera = _camera;
                    _currentGameObject.SpriteBatch = _spriteBatch;
                }
            }
        }
        private bool _simulate;
        public bool Simulate 
        {
            get
            {
                return _simulate;
            }
            set
            {
                _simulate = value;
                OnSimulateChanged();
            }
        }

        public event EventHandler SimulateChanged;

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
        private MouseEventArgs _mouseState;
        private Vector2 _mousePosition;

        private Vector2 _upperLeftLocalPoint;
        public Vector2 UpperLeftLocalPoint 
        {
            get
            {
                return _upperLeftLocalPoint;
            }
            
            set
            {
                _upperLeftLocalPoint = value;
                if (_debugView != null) //если null, то это дизайнер пытается присвоить значение при создании формы
                    _debugView.TranslateDebugPerfomancePair(value);
            }
        }

        public bool DrawCurrentGameObject { get; set; }

        public const float NormalSimulationSpeed = 1.0f;
        private float _simulationSpeed;

        public float SimulationSpeed
        {
            get { return _simulationSpeed; }
            set { _simulationSpeed = value; }
        }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Fonts/Segoe14");

            _camera = new Camera(new Viewport(0, 0, ClientSize.Width, ClientSize.Height));
            _simulatedLevel = new GameLevel(_camera, _spriteBatch, new Vector2(10, 10));
            _initialLevel = new GameLevel(_camera, _spriteBatch,new Vector2(10, 10));

            _simulationSpeed = NormalSimulationSpeed;
            _mousePosition = Vector2.Zero;
            DrawCurrentGameObject = false;
            
            _simulate = false;
            SetDebugView();
            _debugView.TranslateDebugPerfomancePair(_upperLeftLocalPoint);
        }

        void SetDebugView()
        {
            DebugViewFlags flags = 0;
            if (_debugView != null) { flags = _debugView.Flags;}
            _debugView = new DebugViewXNA(_simulatedLevel.World);
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
            if ((_debugView.Flags & flag) == flag)
                return true;
            else
                return false;
        }

        protected void OnSimulateChanged()
        {
            if (_simulate == false)
                ResetLevelTo(_initialLevel);

            GameTimer.Enabled = _simulate;
            _worldTime = TimeSpan.Zero;

            if (SimulateChanged != null)
                SimulateChanged(this, EventArgs.Empty);
        }

        public void AddCurrentObject()
        {
            _simulatedLevel.AddObject(_currentGameObject.CopyObjectToWorld(_simulatedLevel.World, ConvertUnits.ToSimUnits(_mousePosition)));
            if (Simulate == false)
                _initialLevel.AddObject(_currentGameObject.CopyObjectToWorld(_initialLevel.World, ConvertUnits.ToSimUnits(_mousePosition)));
        }

        void ResetLevelTo(GameLevel levelState)
        {
            if (levelState == null) return;
            _simulatedLevel = new GameLevel(_camera, _spriteBatch, levelState.World.Gravity);
            foreach (GameObject gameObject in levelState)
            {
                _simulatedLevel.AddObject(gameObject.CopyObjectToWorld(_simulatedLevel.World,Vector2.Zero));
            }
        }
        protected override void LoadContent()
        {
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Content.Unload();
            }

            base.Dispose(disposing);
        }

        
        protected override void UpdateFrame()
        {
            if (_simulate)
            {
                UpdateMouseJoint();
                if (_worldTime == TimeSpan.Zero && _simulationSpeed <= 0)
                    throw new Exception("Попытка запустить симуляцию с отрицательным значением шага");
                TimeSpan elapsed = TimeSpan.FromMilliseconds(GameTimer.GameTime.ElapsedGameTime.TotalMilliseconds * _simulationSpeed);
                _worldTime += elapsed;
                if (_worldTime <= TimeSpan.Zero)
                {
                    Simulate = false;
                    return;
                }
                if (_simulationSpeed == NormalSimulationSpeed)
                    _simulatedLevel.Update(GameTimer.GameTime);
                else
                    _simulatedLevel.Update(new GameTime(GameTimer.GameTime.TotalGameTime, elapsed));
            }
        }

        public void CreateMouseJoint()
        {
            if (_mouseJoint == null)
            {
                Fixture savedFixture = _simulatedLevel.World.TestPoint(ConvertUnits.ToSimUnits(_mousePosition));
                if (savedFixture != null)
                {
                    Body body = savedFixture.Body;
                    _mouseJoint = new FixedMouseJoint(body, ConvertUnits.ToSimUnits(_mousePosition));
                    _mouseJoint.MaxForce = 1000.0f * body.Mass;
                    _simulatedLevel.World.AddJoint(_mouseJoint);
                    body.Awake = true;
                }
            }
        }
        public void RemoveMouseJoint()
        {
            if (_mouseJoint != null)
            {
                _simulatedLevel.World.RemoveJoint(_mouseJoint);
                _mouseJoint = null;
            }
        }
        public void UpdateMouseJoint()
        {
            if (_mouseJoint != null)
            {
                _mouseJoint.WorldAnchorB = ConvertUnits.ToSimUnits(_mousePosition);
            }
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (_currentGameObject != null && DrawCurrentGameObject)
            {
                _currentGameObject.Camera.Position = -_mousePosition;
                _currentGameObject.Draw(GameTimer.GameTime);
                _currentGameObject.Camera.Position = Vector2.Zero;
            }
            _simulatedLevel.Draw(GameTimer.GameTime);

            
            Matrix proj = Matrix.CreateOrthographicOffCenter(0, ConvertUnits.ToSimUnits(this.Size.Width), ConvertUnits.ToSimUnits(this.Size.Height), 0, 0, 1);
            _debugView.RenderDebugData(ref proj);
        }
    }
}   
