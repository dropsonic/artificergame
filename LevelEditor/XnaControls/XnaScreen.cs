using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision.Shapes;
using FarseerTools;

namespace LevelEditor
{
    class XnaScreen : GraphicsDeviceControl
    {
        SpriteBatch spriteBatch;
        SpriteFont font;

        public string message = "Empty Message";


        public Texture2D CurrentTexture
        {
            set
            {
                if (value != null)
                    currentSprite = new Sprite(value);
                else
                {
                    currentSprite = new Sprite();
                    currentSprite.Texture = null;
                }
            }
        }

        private Sprite currentSprite;
        public Vector2 CurrentTexturePosition { get; set; }
        public bool DrawPreview { get; set; }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Fonts/Segoe14");
            CurrentTexturePosition = Vector2.Zero;
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
            
        }


        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (currentSprite.Texture != null && DrawPreview)
                spriteBatch.Draw(currentSprite.Texture, CurrentTexturePosition, null, Color.White, 0f, currentSprite.Origin, 1f, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}
