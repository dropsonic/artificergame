using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerTools;

namespace GameLogic
{
    public class GameObjectPart : IDrawable
    {
        public Sprite Sprite;
        public Body Body;

        private GameObject _parent;

        public GameObjectPart(GameObject parent, Sprite sprite, Body body)
        {
            _parent = parent;

            Sprite = sprite;
            Body = body;

            Visible = true;
        }

        /// <summary>
        /// Создаёт копию GameObjectPart.
        /// </summary>
        /// <param name="parent">Родительский GameObject.</param>
        /// <param name="world">World, к которому необходимо привязать объект.</param>
        /// <param name="origin">Origin родительского GameObject.</param>
        public GameObjectPart DeepClone(GameObject parent, World world, Vector2 origin)
        {
            Body newBody = Body.DeepClone(world);
            newBody.Position += origin;
            return new GameObjectPart(parent, Sprite, newBody);
        }

        #region IDrawable
        public void Draw(GameTime gameTime)
        {
            _parent.SpriteBatch.Draw(Sprite.Texture, ConvertUnits.ToDisplayUnits(Body.Position),
                                           null,
                                           Color.White, Body.Rotation, Sprite.Origin, 1f,
                                           SpriteEffects.None, 0f);
        }

        public int DrawOrder { get; set; }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public bool Visible { get; set; }

        public event EventHandler<EventArgs> VisibleChanged;
        #endregion
    }
}
