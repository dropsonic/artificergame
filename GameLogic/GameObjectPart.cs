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
        private Sprite _sprite;
        private Body _body;

        public Sprite Sprite
        {
            get { return _sprite; }
            set { _sprite = value; }
        }

        public Body Body
        {
            get { return _body; }
        }

        private SpriteBatch _spriteBatch;
        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
            set { _spriteBatch = value; }
        }

        public GameObjectPart(Sprite sprite, Body body)
        {
            _sprite = sprite;
            _body = body;

            Visible = true;
        }

        public GameObjectPart(SpriteBatch spriteBatch, Sprite sprite, Body body)
            : this(sprite, body)
        {
            _spriteBatch = spriteBatch;
        }

        /// <summary>
        /// Создаёт копию GameObjectPart.
        /// </summary>
        /// <param name="world">World, к которому необходимо привязать объект.</param>
        /// <param name="origin">Origin родительского GameObject.</param>
        public GameObjectPart DeepClone(World world, Vector2 origin)
        {
            Body newBody = Body.DeepClone(world);
            newBody.Position += origin;
            return new GameObjectPart(_spriteBatch, Sprite, newBody);
        }

        #region IDrawable
        public void Draw(GameTime gameTime)
        {
            if (_visible)
            {
                _spriteBatch.Draw(Sprite.Texture, ConvertUnits.ToDisplayUnits(Body.Position),
                                               null,
                                               Color.White, Body.Rotation, Sprite.Origin, 1f,
                                               SpriteEffects.None, 0f);
            }
        }

        private int _drawOrder;
        public int DrawOrder
        {
            get { return _drawOrder; }
            set
            {
                _drawOrder = value;
                if (DrawOrderChanged != null)
                    DrawOrderChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler<EventArgs> DrawOrderChanged;

        private bool _visible;
        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                if (VisibleChanged != null)
                    VisibleChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler<EventArgs> VisibleChanged;
        #endregion
    }
}
