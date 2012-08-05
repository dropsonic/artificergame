using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerTools;
using System.ComponentModel;

namespace GameLogic
{
    public class GameObjectPart : IDrawable
    {
        private List<Sprite> _sprites;
        private Body _body;

        public List<Sprite> Sprites
        {
            get { return _sprites; }
            set { _sprites = value; }
        }

        public Body Body
        {
            get { return _body; }
        }

        [XMLExtendedSerialization.XMLDoNotSerialize]
        private SpriteBatch _spriteBatch;
        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
            set { _spriteBatch = value; }
        }

        public GameObjectPart(Sprite sprite, Body body)
        {
            _sprites = new List<Sprite>();
            _sprites.Add(sprite);
            _body = body;

            Visible = true;
        }

        public GameObjectPart(SpriteBatch spriteBatch, Sprite sprite, Body body)
            : this(sprite, body)
        {
            _spriteBatch = spriteBatch;
        }

        public GameObjectPart(List<Sprite> sprites,Body body)
        {
            _sprites = sprites;
            _body = body;

            Visible = true;
        }

        public GameObjectPart(SpriteBatch spriteBatch,List<Sprite> sprites,Body body)
            :this(sprites,body)
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
            
            return new GameObjectPart(_spriteBatch, new List<Sprite>(_sprites), newBody);
        }


        public void RemoveBody(World world)
        {
            world.RemoveBody(this.Body);
        }

        #region IDrawable
        public void Draw(GameTime gameTime)
        {
            if (_visible)
            {
                foreach (Sprite sprite in _sprites)
                {
                    _spriteBatch.Draw(sprite.Texture, ConvertUnits.ToDisplayUnits(Body.Position),
                                                   null,
                                                   Color.White, Body.Rotation, sprite.Origin+sprite.Offset, 1f,
                                                   SpriteEffects.None, 0f);
                }
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
