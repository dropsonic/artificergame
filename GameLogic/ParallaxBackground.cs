using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;

namespace GameLogic
{
    /// <summary>
    /// Параллаксный фон.
    /// </summary>
    /// <remarks>
    /// Все положения и размеры задаются в метрах.
    /// </remarks>
    public class ParallaxBackground : IDrawable
    {
        private SortedList<int, ParallaxBackgroundItem> _backgrounds;
        private World _world;
        private Camera _camera;
        private SpriteBatch _spriteBatch;

        public ParallaxBackground(World world, Camera camera, SpriteBatch spriteBatch)
        {
            _backgrounds = new SortedList<int, ParallaxBackgroundItem>();
            this._world = world;
            this._camera = camera;
            this._spriteBatch = spriteBatch;

            Visible = true;
        }

        public SortedList<int, ParallaxBackgroundItem> Backgrounds
        {
            get { return _backgrounds; }
            set { _backgrounds = value; }
        }

        public World World
        {
            get { return _world; }
            set { _world = value; }
        }

        public Camera Camera
        {
            get { return _camera; }
            set { _camera = value; }
        }

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
            set { _spriteBatch = value; }
        }

        #region AddBackground
        private void AddBackground(ParallaxBackgroundItem background)
        {
            _backgrounds.Add(background.DrawOrder, background);
        }

        public void AddBackground(Sprite sprite, float xParallaxSpeed, int layer)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(this, sprite, xParallaxSpeed, layer);
            AddBackground(background);
        }

        public void AddBackground(Sprite sprite, float xParallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(this, sprite, xParallaxSpeed, layer, position);
            AddBackground(background);
        }

        public void AddBackground(Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, Vector2 size)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(this, sprite, xParallaxSpeed, layer, position, size);
            AddBackground(background);
        }

        public void AddBackground(Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(this, sprite, parallaxSpeed, layer, position);
            AddBackground(background);
        }

        public void AddBackground(Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, Vector2 size)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(this, sprite, parallaxSpeed, layer, position, size);
            AddBackground(background);
        }
        #endregion

        #region AddDynamicBackground
        private void AddDynamicBackground(ParallaxBackgroundDynamicItem background)
        {
            _backgrounds.Add(background.DrawOrder, background);
        }

        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, new Vector2(xParallaxSpeed, 1.0f), layer, position);
            AddDynamicBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, Vector2 size)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, new Vector2(xParallaxSpeed, 1.0f), layer, position, size);
            AddDynamicBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, parallaxSpeed, layer, position);
            AddDynamicBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, Vector2 size)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, parallaxSpeed, layer, position, size);
            AddDynamicBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, Vector2 linearVelocity, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, 0, linearVelocity, 0, sprite, new Vector2(xParallaxSpeed, 1.0f), layer, position);
            AddDynamicBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, Vector2 linearVelocity, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, Vector2 size)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, 0, linearVelocity, 0, sprite, new Vector2(xParallaxSpeed, 1.0f), layer, position, size);
            AddDynamicBackground(background);
        }
        #endregion

        public void Draw(GameTime gameTime)
        {
            if (Visible)
            {
                /*for (int i = 0; i < _backgrounds.Count; i++)
                    _backgrounds[i].Draw(gameTime);*/
                foreach (var background in _backgrounds)
                    background.Value.Draw(gameTime);
            }
        }

        public int DrawOrder { get; set; }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public bool Visible { get; set; }

        public event EventHandler<EventArgs> VisibleChanged;
    }
}
