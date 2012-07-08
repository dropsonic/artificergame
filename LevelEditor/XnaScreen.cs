﻿using Microsoft.Xna.Framework;
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
        public Texture2D texture;
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Segoe14");
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

            if (texture != null)
            {
                spriteBatch.Draw(texture, Vector2.Zero, Color.White);
            }
            else
            {
                spriteBatch.DrawString(font, "EmptyMessage", Vector2.Zero, Color.Red);
            }
            
            spriteBatch.End();
        }
    }
}