using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameLogic
{
    public class ParallaxBackgroundItem : IDrawable
    {
        protected ParallaxBackground _parallaxBackground;

        /// <summary>
        /// Ссылка на родительский объект.
        /// </summary>
        public ParallaxBackground ParallaxBackground
        {
            get { return _parallaxBackground; }
            set { _parallaxBackground = value; }
        }

        protected Camera _camera;
        protected SpriteBatch _spriteBatch;

        protected Sprite _sprite;

        //указываются в SimUnits
        protected Vector2 _position;
        protected Vector2 _size;

        protected Rectangle _rect; //формируется из _position и _size для отрисовки, в DisplayUnits
        protected Vector2 _displaySize; //_size в DisplayUnits

        public Vector2 ParallaxSpeed;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector2 Size
        {
            get { return _size; }
            set 
            { 
                _size = value;
                CalculateRect();
            }
        }

        public Sprite Sprite
        {
            get { return _sprite; }
            set 
            { 
                _sprite = value;
                CalculateRect();
            }
        }

        public ParallaxBackgroundItem(ParallaxBackground parent, Sprite sprite, float xParallaxSpeed, int layer)
            : this(parent, sprite, new Vector2(xParallaxSpeed, 1.0f), layer, Vector2.Zero) { }

        public ParallaxBackgroundItem(ParallaxBackground parent, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position)
            : this(parent, sprite, new Vector2(xParallaxSpeed, 1.0f), layer, position) { }

        public ParallaxBackgroundItem(ParallaxBackground parent, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, Vector2 size)
            : this(parent, sprite, new Vector2(xParallaxSpeed, 1.0f), layer, position, size) { }


        /// <param name="parent">Родительский элемент - фон.</param>
        /// <param name="sprite">Спрайт.</param>
        /// <param name="parallaxSpeed">Скорость параллакса. (1.0f, 1.0f), если параллакса нет.</param>
        /// <param name="layer">Слой.</param>
        /// <param name="defaultSize">true, если принимать размер текстуры за размер объекта.</param>
        protected ParallaxBackgroundItem(ParallaxBackground parent, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, bool defaultSize)
        {
            this._parallaxBackground = parent;
            this._sprite = sprite;
            this.ParallaxSpeed = parallaxSpeed;
            this.DrawOrder = layer;
            this._camera = parent.Camera;
            this._spriteBatch = parent.SpriteBatch;
            this._position = position;

            if (defaultSize)
                //По умолчанию размер равен размеру текстуры в SimUnits
                Size = ConvertUnits.ToSimUnits(sprite.Texture.Width, sprite.Texture.Height);

            Visible = true;
        }


        public ParallaxBackgroundItem(ParallaxBackground parent, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position)
            : this(parent, sprite, parallaxSpeed, layer, position, true) { }

        public ParallaxBackgroundItem(ParallaxBackground parent, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, Vector2 size)
            : this(parent, sprite, parallaxSpeed, layer, position, false)
        {
            Size = size;
        }

        protected virtual void CalculateRect()
        {
            //Рассчитываем прямоугольник для отрисовки
            Vector2 displayPosition = ConvertUnits.ToDisplayUnits(_position);
            _displaySize = ConvertUnits.ToDisplayUnits(_size);
            this._rect = new Rectangle((int)displayPosition.X, (int)displayPosition.Y, (int)_displaySize.X, (int)_displaySize.Y);
        }

        #region IDrawable
        public virtual void Draw(GameTime gameTime)
        {
            if (Visible)
            {
                _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetViewMatrix(ParallaxSpeed));
                _spriteBatch.Draw(_sprite.Texture, _rect, null, Color.White, 0f, _sprite.Origin, SpriteEffects.None, 0);
                //_spriteBatch.Draw(_sprite.Texture, _rect, null, Color.White);
                _spriteBatch.End();
            }
        }

        public int DrawOrder { get; set; }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public bool Visible { get; set; }

        public event EventHandler<EventArgs> VisibleChanged;
        #endregion
    }
}
