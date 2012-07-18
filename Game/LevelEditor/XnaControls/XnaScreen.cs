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
    class XnaScreen : GraphicsDeviceControl
    {
        SpriteBatch spriteBatch;
        SpriteFont font;

        GameLevel gameLevel;
        World world;
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
        public Vector2 CurrentObjectPosition { get; set; }
        public bool DrawCurrentGameObject { get; set; }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Fonts/Segoe14");

            CurrentObjectPosition = Vector2.Zero;
            DrawCurrentGameObject = false;

            world = new World(new Vector2(1,1));
            camera = new Camera(new Viewport(0, 0, ClientSize.Width, ClientSize.Height));
            gameLevel = new GameLevel(camera, spriteBatch,world);
        }

        public void AddCurrentObject()
        {
            gameLevel.AddObject(currentGameObject.CopyObjectToWorld(gameLevel.World, ConvertUnits.ToSimUnits(CurrentObjectPosition)));
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
            world.Step((float)GameTime.ElapsedGameTime.TotalSeconds);
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
            gameLevel.Draw(GameTime);
        }
    }
}
