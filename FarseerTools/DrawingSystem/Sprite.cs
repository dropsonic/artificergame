using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FarseerTools
{
    public struct Sprite
    {
        /// <summary>
        /// Center of texture
        /// </summary>
        public Vector2 Origin;

        /// <summary>
        /// Distance between body(body position) and sprite origin
        /// </summary>
        public Vector2 Offset;

        [XMLExtendedSerialization.XMLCustomSerializer(typeof(Texture2DXMLSerializer))]
        public Texture2D Texture;

        public Sprite(Texture2D texture)
        {
            this.Texture = texture;
            this.Origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
            this.Offset = Vector2.Zero;
        }

        public Sprite(Texture2D texture, Vector2 offset)
        {
            this.Texture = texture;
            this.Origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
            this.Offset = offset;
        }

        public Sprite(Texture2D texture, Vector2 offset, Vector2? origin=null)
        {
            this.Texture = texture;
            if (origin == null)
                this.Origin = new Vector2(texture.Width / 2f, texture.Height / 2f);
            else
                this.Origin = (Vector2)origin;
            this.Offset = offset;
        }
        
    }
}