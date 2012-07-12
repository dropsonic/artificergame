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

namespace LevelEditor
{
    class PreviewScreen : GraphicsDeviceControl
    {
        SpriteBatch spriteBatch;
        SpriteFont font;
        Sprite sprite;
        string message = "Select Preview";
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

        public void SetCirclePreview(string material, Color color, float materialScale, float radius)
        {
            sprite = new Sprite(ContentService.GetContentService().AssetCreator.CircleTexture(radius, material, color, materialScale));
        }
        public void SetRectanglePreview(string material, Color color, float materialScale, float width, float height)
        {      
            sprite = new Sprite(ContentService.GetContentService().AssetCreator.TextureFromVertices(PolygonTools.CreateRectangle(width, height), material, color, materialScale));
        }
         public void SetGearPreview(string material, Color color, float materialScale, float radius, int numberOfTeeth, float tipPercentage, float toothHeight)
        {      
            sprite = new Sprite(ContentService.GetContentService().AssetCreator.TextureFromVertices(PolygonTools.CreateGear(radius, numberOfTeeth, tipPercentage, toothHeight), material, color, materialScale));
        } 
        public void SetArcPreview(string material, Color color, float materialScale, float degrees, int sides, float radius)
        {      
            sprite = new Sprite(ContentService.GetContentService().AssetCreator.TextureFromVertices(PolygonTools.CreateArc(MathHelper.ToRadians(degrees), sides, radius), material, color, materialScale));
        }
        public void SetEllipsePreview(string material, Color color, float materialScale, float xRadius, float yRadius, int numberOfEdges)
        {
            sprite = new Sprite(ContentService.GetContentService().AssetCreator.TextureFromVertices(PolygonTools.CreateEllipse(xRadius, yRadius, numberOfEdges), material, color, materialScale));
        } 
        public void SetRoundedRectanglePreview(string material, Color color, float materialScale, float width, float height, float xRadius, float yRadius, int segments)
        {
            sprite = new Sprite(ContentService.GetContentService().AssetCreator.TextureFromVertices(PolygonTools.CreateRoundedRectangle(width, height, xRadius, yRadius, segments), material, color, materialScale));
        }
        public void SetCapsulePreview(string material, Color color, float materialScale, float height, float topRadius, int topEdges, float bottomRadius, int bottomEdges)   
        {
            sprite = new Sprite(ContentService.GetContentService().AssetCreator.TextureFromVertices(PolygonTools.CreateCapsule(height, topRadius, topEdges, bottomRadius, bottomEdges), material, color, materialScale));
        }
        
        protected override void UpdateFrame()
        {
            
        }


        protected override void Draw()
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            if (sprite.Texture != null)
            {
                spriteBatch.Draw(sprite.Texture, new Vector2(this.GraphicsDevice.Viewport.Width/2 - sprite.Origin.X, this.GraphicsDevice.Viewport.Height/2 - sprite.Origin.Y), Color.White);
            }
            else
            {
                spriteBatch.DrawString(font, message, Vector2.Zero, Color.Black);
            }
            
            spriteBatch.End();
        }
    }
}
