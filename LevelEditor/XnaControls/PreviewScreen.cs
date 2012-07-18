using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision.Shapes;
using FarseerTools;
using FarseerPhysics.Common;
using System.IO;
using System.Collections.Generic;
using GameLogic;

namespace LevelEditor
{
    class PreviewScreen : GraphicsDeviceControl
    {
        SpriteBatch spriteBatch;
        SpriteFont font;
        string message = "Select Preview";

        private GameObjectPart previewGameObject;
        public GameObjectPart PreviewGameObject 
        {
            set
            {
                previewGameObject = value;
            }
        }
        
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>("Fonts/Segoe14");
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
            GraphicsDevice.Clear(Color.Gray);
            if (previewGameObject != null)
            {
                spriteBatch.Begin(SpriteSortMode.Immediate,null,null,null,null,null,Matrix.CreateTranslation(new Vector3(ClientSize.Width/2,ClientSize.Height/2,0)));
                spriteBatch.Draw(previewGameObject.Sprite.Texture, ConvertUnits.ToDisplayUnits(previewGameObject.Body.Position),
                                               null,
                                               Color.White, previewGameObject.Body.Rotation, previewGameObject.Sprite.Origin, 1f,
                                               SpriteEffects.None, 0f);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font, message, Vector2.Zero, Color.Black);
                spriteBatch.End();
            }
        }
    }
}
