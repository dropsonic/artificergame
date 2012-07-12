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
        AssetCreator assetCreator;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Sprite sprite;
        string message = "Select Preview";
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Fonts/Segoe14");

            assetCreator = new AssetCreator(this.GraphicsDevice);
            List<string> materials = new List<string>();
            foreach (string material in Directory.GetFiles("Content\\" + ContentService.GetMaterial()))
            {
                materials.Add(System.IO.Path.GetFileName(material).Split('.')[0]);
            }
            assetCreator.LoadContent(ContentService.GetContentService().Content, materials);
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

        public void SetPreview(ObjectType objectType, string material, Color color, float materialScale)
        {
            float radius = 1;
            switch (objectType)
            {
                case ObjectType.Circle:
                    sprite = new Sprite(assetCreator.CircleTexture(radius, material, color, 0.8f));
                    break;
                case ObjectType.Rectangle:
                    sprite = new Sprite(assetCreator.TextureFromVertices(PolygonTools.CreateRectangle(radius / 2f, radius / 2f), material, color, materialScale));
                    break;
                 case ObjectType.Gear:
                    sprite = new Sprite(assetCreator.TextureFromVertices(PolygonTools.CreateGear(radius, 10, 100f, 1f), material, color, materialScale));
                    break;
                case ObjectType.Arc:
                    sprite = new Sprite(assetCreator.TextureFromVertices(PolygonTools.CreateArc(MathHelper.ToRadians(270), 100, radius), material, color, materialScale));
                    break;
                case ObjectType.Ellipse:
                    sprite = new Sprite(assetCreator.TextureFromVertices(PolygonTools.CreateEllipse(radius * 1.5f, radius / 1.5f, 100), material, color, materialScale));
                    break;
                case ObjectType.RoundedRectangle:
                    sprite = new Sprite(assetCreator.TextureFromVertices(PolygonTools.CreateRoundedRectangle(radius, radius, 0.1f, 0.1f, 100), material, color, materialScale));
                    break;
                case ObjectType.Capsule:
                    sprite = new Sprite(assetCreator.TextureFromVertices(PolygonTools.CreateCapsule(radius, radius / 2.5f, 100, radius / 2.5f, 100), material, color, materialScale));
                    break;

            }
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
