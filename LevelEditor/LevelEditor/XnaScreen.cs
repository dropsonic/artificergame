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


        /// <summary>
        /// Initializes the control, creating the ContentManager
        /// and using it to load a SpriteFont.
        /// </summary>
        protected override void Initialize()
        {
            content = new ContentManager(Services, "Content");

            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = content.Load<SpriteFont>("Segoe14");
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

        void Update()
        {

        }

        /// <summary>
        /// Draws the control, using SpriteBatch and SpriteFont.
        /// </summary>
        protected override void Draw()
        {
            Update();
            GraphicsDevice.Clear(Color.CornflowerBlue);

        }
    }
}
