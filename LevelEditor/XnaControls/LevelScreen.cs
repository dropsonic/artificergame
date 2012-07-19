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
        SpriteBatch spriteBatch;
        SpriteFont font;

        GameLevel simulatedLevel;
        GameLevel initialLevel;
  
        Camera camera;

        private GameObject currentGameObject;
        public GameObject CurrentGameObject
        {
            set
            {
                if (value == null)
                    currentGameObject = null;
                else
                {
                    currentGameObject = value;
                    currentGameObject.Camera = camera;
                    currentGameObject.SpriteBatch = spriteBatch;
                }
            }
        }
        private bool simulate;
        public bool Simulate 
        {
            get
            {
                return simulate;
            }
            set
            {
                if (value == false)
                    ResetLevelTo(initialLevel);
                simulate = value;
            }
        }
        public Vector2 CurrentObjectPosition { get; set; }
        public bool DrawCurrentGameObject { get; set; }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Fonts/Segoe14");

            camera = new Camera(new Viewport(0, 0, ClientSize.Width, ClientSize.Height));
            simulatedLevel = new GameLevel(camera, spriteBatch, new Vector2(1, 1));
            initialLevel = new GameLevel(camera, spriteBatch,new Vector2(1, 1));

            CurrentObjectPosition = Vector2.Zero;
            DrawCurrentGameObject = false;
            Simulate = false;
        }

        public void AddCurrentObject()
        {
            simulatedLevel.AddObject(currentGameObject.CopyObjectToWorld(simulatedLevel.World, ConvertUnits.ToSimUnits(CurrentObjectPosition)));
            if (Simulate == false)
                initialLevel.AddObject(currentGameObject.CopyObjectToWorld(initialLevel.World, ConvertUnits.ToSimUnits(CurrentObjectPosition)));
        }

        void ResetLevelTo(GameLevel levelState)
        {
            if (levelState == null) return;
            simulatedLevel = new GameLevel(camera, spriteBatch, levelState.World.Gravity);
            foreach (GameObject gameObject in levelState)
            {
                simulatedLevel.AddObject(gameObject.CopyObjectToWorld(simulatedLevel.World,Vector2.Zero));
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
            if (Simulate)
                simulatedLevel.World.Step((float)GameTime.ElapsedGameTime.TotalSeconds);
        }

        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (currentGameObject != null && DrawCurrentGameObject)
            {
                currentGameObject.Camera.Position = -CurrentObjectPosition;
                currentGameObject.Draw(GameTime);
                currentGameObject.Camera.Position = Vector2.Zero;
            }
            simulatedLevel.Draw(GameTime);
        }
    }
}
