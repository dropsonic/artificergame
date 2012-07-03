using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameLogic
{
    public partial class ParallaxBackground
    {
        #region ParallaxBackgroundItem
        private class ParallaxBackgroundItem : IVisualComponent
        {
            protected string _textureName;
            protected SpriteBatch _spriteBatch;
            protected Texture2D _texture;

            //указываются в SimUnits
            protected Vector2 _position;
            protected Vector2 _size;

            protected Rectangle _rect; //формируется из _position и _size для отрисовки, в DisplayUnits

            protected Camera _camera;

            public Vector2 ParallaxSpeed;

            public ParallaxBackgroundItem(string textureName, float xParallaxSpeed, int layer, Camera camera, SpriteBatch spriteBatch)
                : this(textureName, new Vector2(xParallaxSpeed, 1.0f), layer, Vector2.Zero, camera, spriteBatch) { }

            public ParallaxBackgroundItem(string textureName, float xParallaxSpeed, int layer, Vector2 position, Camera camera, SpriteBatch spriteBatch)
                : this(textureName, new Vector2(xParallaxSpeed, 1.0f), layer, position, camera, spriteBatch) { }

            public ParallaxBackgroundItem(string textureName, float xParallaxSpeed, int layer, Vector2 position, Vector2 size, Camera camera, SpriteBatch spriteBatch)
                : this(textureName, new Vector2(xParallaxSpeed, 1.0f), layer, position, size, camera, spriteBatch) { }

            protected ParallaxBackgroundItem(string textureName, Vector2 parallaxSpeed, int layer, Camera camera, SpriteBatch spriteBatch)
            {
                this._textureName = textureName;
                this.ParallaxSpeed = parallaxSpeed;
                DrawOrder = layer;
                this._camera = camera;
                this._spriteBatch = spriteBatch;

                Visible = true;
            }

            public ParallaxBackgroundItem(string textureName, Vector2 parallaxSpeed, int layer, Vector2 position, Camera camera, SpriteBatch spriteBatch)
                : this(textureName, parallaxSpeed, layer, camera, spriteBatch)
            {
                this._position = position;
                this._size = Vector2.Zero;
            }

            public ParallaxBackgroundItem(string textureName, Vector2 parallaxSpeed, int layer, Vector2 position, Vector2 size, Camera camera, SpriteBatch spriteBatch)
                : this(textureName, parallaxSpeed, layer, camera, spriteBatch)
            {
                this._position = position;
                this._size = size;
            }

            public void Initialize()
            {
            }

            public void LoadContent(ContentManager content)
            {
                _texture = content.Load<Texture2D>(_textureName);
                //Если пользователь не указал размер, то он автоматически присваивается равным размеру текстуры
                if (_size == Vector2.Zero)
                    _size = ConvertUnits.ToSimUnits(_texture.Width, _texture.Height);

                //Рассчитываем прямоугольник для отрисовки
                Vector2 displayPosition = ConvertUnits.ToDisplayUnits(_position);
                Vector2 displaySize = ConvertUnits.ToDisplayUnits(_size);
                this._rect = new Rectangle((int)displayPosition.X, (int)displayPosition.Y, (int)displaySize.X, (int)displaySize.Y);
            }

            public virtual void Draw(GameTime gameTime)
            {
                if (Visible)
                {
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetViewMatrix(ParallaxSpeed));
                    _spriteBatch.Draw(_texture, _rect, Color.White);
                    _spriteBatch.End();
                }
            }

            public int DrawOrder { get; set; }

            public event EventHandler<EventArgs> DrawOrderChanged;

            public bool Visible { get; set; }

            public event EventHandler<EventArgs> VisibleChanged;
        }
        #endregion
    }
}
