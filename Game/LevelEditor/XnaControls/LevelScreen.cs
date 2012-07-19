using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision.Shapes;
using FarseerTools;
using GameLogic;


namespace LevelEditor
{
    class LevelScreen : GraphicsDeviceControl
    {
        SpriteBatch _spriteBatch;
        SpriteFont _font;

        GameLevel _simulatedLevel;
        GameLevel _initialLevel;
  
        Camera _camera;

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
                if (value == false)
                    ResetLevelTo(_initialLevel);
                _simulate = value;
            }
        }
        public Vector2 CurrentObjectPosition { get; set; }
        public bool DrawCurrentGameObject { get; set; }

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("Fonts/Segoe14");

            _camera = new Camera(new Viewport(0, 0, ClientSize.Width, ClientSize.Height));
            _simulatedLevel = new GameLevel(_camera, _spriteBatch, new Vector2(1, 1));
            _initialLevel = new GameLevel(_camera, _spriteBatch,new Vector2(1, 1));

            CurrentObjectPosition = Vector2.Zero;
            DrawCurrentGameObject = false;
            Simulate = false;
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
                _simulatedLevel.Update(GameTime);
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (_currentGameObject != null && DrawCurrentGameObject)
            {
                _currentGameObject.Camera.Position = -CurrentObjectPosition;
                _currentGameObject.Draw(GameTime);
                _currentGameObject.Camera.Position = Vector2.Zero;
            }
            _simulatedLevel.Draw(GameTime);
        }
    }
}
