using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision.Shapes;
using FarseerTools;
using GameLogic;
using System;


namespace LevelEditor
{
    class LevelScreen : GraphicsDeviceControl
    {
        SpriteBatch _spriteBatch;
        SpriteFont _font;

        GameLevel _simulatedLevel;
        GameLevel _initialLevel;
  
        Camera _camera;
        TimeSpan _worldTime = new TimeSpan();
        private GameObject _currentGameObject;
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
        protected void OnSimulateChanged()
        {
            if (SimulateChanged != null)
                SimulateChanged(this, EventArgs.Empty);
        }

        public Vector2 CurrentObjectPosition { get; set; }
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

            SimulateChanged+=new EventHandler(LevelScreen_SimulateChanged);
            _camera = new Camera(new Viewport(0, 0, ClientSize.Width, ClientSize.Height));
            _simulatedLevel = new GameLevel(_camera, _spriteBatch, new Vector2(10, 10));
            _initialLevel = new GameLevel(_camera, _spriteBatch,new Vector2(10, 10));

            _simulationSpeed = NormalSimulationSpeed;

            CurrentObjectPosition = Vector2.Zero;
            DrawCurrentGameObject = false;
            Simulate = false;
        }

        void LevelScreen_SimulateChanged(object obj, EventArgs e)
        {
            if(_simulate == false)
                ResetLevelTo(_initialLevel);
            GameTimer.Enabled = _simulate;
            _worldTime = new TimeSpan();
        }

        public void AddCurrentObject()
        {
            _simulatedLevel.AddObject(_currentGameObject.CopyObjectToWorld(_simulatedLevel.World, ConvertUnits.ToSimUnits(CurrentObjectPosition)));
            if (Simulate == false)
                _initialLevel.AddObject(_currentGameObject.CopyObjectToWorld(_initialLevel.World, ConvertUnits.ToSimUnits(CurrentObjectPosition)));
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
                TimeSpan elapsed = TimeSpan.FromMilliseconds(GameTimer.GameTime.ElapsedGameTime.TotalMilliseconds * _simulationSpeed);
                _worldTime += elapsed;
                if (_worldTime == elapsed && elapsed <= TimeSpan.Zero)
                    //это неверное условие для выдачи исключения(оно может возникнуть и в случае окончания симуляции по приходу к начальному состоянию).
                    //правильным будет уведомлять пользователя при попытки запуска.
                    throw new Exception("Попытка запустить симуляцию с отрицательным значением шага");
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

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (_currentGameObject != null && DrawCurrentGameObject)
            {
                _currentGameObject.Camera.Position = -CurrentObjectPosition;
                _currentGameObject.Draw(GameTimer.GameTime);
                _currentGameObject.Camera.Position = Vector2.Zero;
            }
            _simulatedLevel.Draw(GameTimer.GameTime);
        }
    }
}
