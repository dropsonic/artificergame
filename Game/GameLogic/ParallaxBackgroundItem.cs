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
            protected Rectangle _rect;
            protected Vector2 _position;
            protected Camera _camera;
            protected bool _usingRect; //true, если используем Rectangle; false, если используем Vector2

            public Vector2 ParallaxSpeed;

            public ParallaxBackgroundItem(string textureName, float xParallaxSpeed, int layer, Camera camera, SpriteBatch spriteBatch)
                : this(textureName, new Vector2(xParallaxSpeed, 1.0f), layer, Vector2.Zero, camera, spriteBatch) { }

            public ParallaxBackgroundItem(string textureName, float xParallaxSpeed, int layer, Vector2 position, Camera camera, SpriteBatch spriteBatch)
                : this(textureName, new Vector2(xParallaxSpeed, 1.0f), layer, position, camera, spriteBatch) { }

            public ParallaxBackgroundItem(string textureName, float xParallaxSpeed, int layer, Rectangle rect, Camera camera, SpriteBatch spriteBatch)
                : this(textureName, new Vector2(xParallaxSpeed, 1.0f), layer, rect, camera, spriteBatch) { }

            public ParallaxBackgroundItem(string textureName, Vector2 parallaxSpeed, int layer, Camera camera, SpriteBatch spriteBatch)
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
                _usingRect = false;
                this._position = position;
            }

            public ParallaxBackgroundItem(string textureName, Vector2 parallaxSpeed, int layer, Rectangle rect, Camera camera, SpriteBatch spriteBatch)
                : this(textureName, parallaxSpeed, layer, camera, spriteBatch)
            {
                _usingRect = true;
                this._rect = rect;
            }

            public void Initialize()
            {
            }

            public void LoadContent(ContentManager content)
            {
                _texture = content.Load<Texture2D>(_textureName);
            }

            public virtual void Draw(GameTime gameTime)
            {
                if (Visible)
                {
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetViewMatrix(ParallaxSpeed));
                    if (_usingRect)
                        _spriteBatch.Draw(_texture, _rect, Color.White);
                    else
                        _spriteBatch.Draw(_texture, _position, Color.White);

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
