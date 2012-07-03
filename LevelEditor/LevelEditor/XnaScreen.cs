using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision.Shapes;

namespace WinFormsGraphicsDevice
{
    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, which allows it to
    /// render using a GraphicsDevice. This control shows how to use ContentManager
    /// inside a WinForms application. It loads a SpriteFont object through the
    /// ContentManager, then uses a SpriteBatch to draw text. The control is not
    /// animated, so it only redraws itself in response to WinForms paint messages.
    /// </summary>
    class XnaScreen : GraphicsDeviceControl
    {
        ContentManager content;
        SpriteBatch spriteBatch;
        SpriteFont font;
        
        private Body rectangle;
        private World world;
        private Texture2D rectangleTexture;
        

        /// <summary>
        /// Initializes the control, creating the ContentManager
        /// and using it to load a SpriteFont.
        /// </summary>
        protected override void Initialize()
        {
            content = new ContentManager(Services, "Content");

            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = content.Load<SpriteFont>("hudFont");
            rectangleTexture = content.Load<Texture2D>("Background");
            world = new World(new Vector2(0,9.8f));
            rectangle = BodyFactory.CreateRectangle(world,50,50,1);
            rectangle.BodyType = BodyType.Dynamic;
        }


        /// <summary>
        /// Disposes the control, unloading the ContentManager.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                content.Unload();
            }

            base.Dispose(disposing);
        }



        /// <summary>
        /// Draws the control, using SpriteBatch and SpriteFont.
        /// </summary>
        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();//(SpriteSortMode.Deferred, null, null, null, null, null, Matrix.Identity);
            //spriteBatch.Draw(rectangleTexture, rectangle.Position, null, Color.White, rectangle.Rotation, new Vector2(rectangleTexture.Width / 2f, rectangleTexture.Height / 2f), 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, "bla", new Vector2(23, 23), Color.White);
            spriteBatch.End();
        }
    }
}
