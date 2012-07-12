using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision.Shapes;

namespace LevelEditor
{
    class XnaScreen : GraphicsDeviceControl
    {
        SpriteBatch spriteBatch;
        SpriteFont font;
        public string message = "Empty Message";
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Fonts/Segoe14");
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
            spriteBatch.DrawString(font, message, Vector2.Zero, Color.Black);
            spriteBatch.End();
        }
    }
}
