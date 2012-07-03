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
    public partial class ParallaxBackground : IVisualComponent
    {
        private SortedList<int, ParallaxBackgroundItem> _backgrounds;
        private Camera _camera;
        private SpriteBatch _spriteBatch;

        public ParallaxBackground(Camera camera, SpriteBatch spriteBatch)
        {
            _backgrounds = new SortedList<int, ParallaxBackgroundItem>();
            this._camera = camera;
            this._spriteBatch = spriteBatch;

            Visible = true;
        }

        #region AddBackground
        private void AddBackground(ParallaxBackgroundItem background)
        {
            _backgrounds.Add(background.DrawOrder, background);
        }

        public void AddBackground(string textureName, float xParallaxSpeed, int layer)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(textureName, xParallaxSpeed, layer, _camera, _spriteBatch);
            AddBackground(background);
        }

        public void AddBackground(string textureName, float xParallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(textureName, xParallaxSpeed, layer, position, _camera, _spriteBatch);
            AddBackground(background);
        }

        public void AddBackground(string textureName, float xParallaxSpeed, int layer, Rectangle rect)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(textureName, xParallaxSpeed, layer, rect, _camera, _spriteBatch);
            AddBackground(background);
        }

        public void AddBackground(string textureName, Vector2 parallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(textureName, parallaxSpeed, layer, position, _camera, _spriteBatch);
            AddBackground(background);
        }

        public void AddBackground(string textureName, Vector2 parallaxSpeed, int layer, Rectangle position)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(textureName, parallaxSpeed, layer, position, _camera, _spriteBatch);
            AddBackground(background);
        }
        #endregion

        #region AddDynamicBackground
        private void AddDynamicBackground(ParallaxBackgroundDynamicItem background)
        {
            _backgrounds.Add(background.DrawOrder, background);
        }

        public void AddDynamicBackground(World world, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, string textureName, float xParallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(world, angularVelocity, angularDamping, linearVelocity, linearDamping, textureName, new Vector2(xParallaxSpeed, 0), layer, position, _camera, _spriteBatch);
            AddDynamicBackground(background);
        }

        public void AddDynamicBackground(World world, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, string textureName, float xParallaxSpeed, int layer, Rectangle rect)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(world, angularVelocity, angularDamping, linearVelocity, linearDamping, textureName, new Vector2(xParallaxSpeed, 0), layer, rect, _camera, _spriteBatch);
            AddDynamicBackground(background);
        }

        public void AddDynamicBackground(World world, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, string textureName, Vector2 parallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(world, angularVelocity, angularDamping, linearVelocity, linearDamping, textureName, parallaxSpeed, layer, position, _camera, _spriteBatch);
            AddDynamicBackground(background);
        }

        public void AddDynamicBackground(World world, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, string textureName, Vector2 parallaxSpeed, int layer, Rectangle rect)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(world, angularVelocity, angularDamping, linearVelocity, linearDamping, textureName, parallaxSpeed, layer, rect, _camera, _spriteBatch);
            AddDynamicBackground(background);
        }

        public void AddDynamicBackground(World world, float angularVelocity, Vector2 linearVelocity, string textureName, float xParallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(world, angularVelocity, 0, linearVelocity, 0, textureName, new Vector2(xParallaxSpeed, 0), layer, position, _camera, _spriteBatch);
            AddDynamicBackground(background);
        }

        public void AddDynamicBackground(World world, float angularVelocity, Vector2 linearVelocity, string textureName, float xParallaxSpeed, int layer, Rectangle rect)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(world, angularVelocity, 0, linearVelocity, 0, textureName, new Vector2(xParallaxSpeed, 0), layer, rect, _camera, _spriteBatch);
            AddDynamicBackground(background);
        }
        #endregion

        public void Initialize() { }

        public void LoadContent(ContentManager content)
        {
            /*for (int i = 0; i < _backgrounds.Count; i++)
                _backgrounds[i].LoadContent(content);*/
            foreach (var background in _backgrounds)
                background.Value.LoadContent(content);
        }

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
