using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Dynamics;
using FarseerTools;
using System.Collections;

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
        private List<ParallaxBackgroundItem> _backgrounds;
        private bool _sorted; //показывает, отсортированы ли элементы фона по DrawOrder

        private World _world;
        private Camera _camera;
        private SpriteBatch _spriteBatch;

        public ParallaxBackground(World world, Camera camera, SpriteBatch spriteBatch)
        {
            _backgrounds = new List<ParallaxBackgroundItem>();
            _sorted = true;

            this._world = world;
            this._camera = camera;
            this._spriteBatch = spriteBatch;

            Visible = true;
        }

        /// <summary>
        /// Возвращает элемент фона по индексу.
        /// </summary>
        /// <param name="index">Индекс элемента.</param>
        /// <seealso cref="http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx"/>
        public ParallaxBackgroundItem this[int index]
        {
            get { return _backgrounds[index]; }
            set 
            { 
                _backgrounds[index] = value;
                _sorted = false;
            }
        }
        #region IEnumerable
        public IEnumerator<ParallaxBackgroundItem> GetEnumerator() { return _backgrounds.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        #endregion

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
        public void AddBackground(ParallaxBackgroundItem background)
        {
            _backgrounds.Add(background);
            _sorted = false;
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

        public void AddBackground(Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, float rotation)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(this, sprite, xParallaxSpeed, layer, position, rotation);
            AddBackground(background);
        }

        public void AddBackground(Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, Vector2 size, float rotation)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(this, sprite, xParallaxSpeed, layer, position, size, rotation);
            AddBackground(background);
        }

        public void AddBackground(Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, float rotation)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(this, sprite, parallaxSpeed, layer, position, rotation);
            AddBackground(background);
        }

        public void AddBackground(Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, Vector2 size, float rotation)
        {
            ParallaxBackgroundItem background = new ParallaxBackgroundItem(this, sprite, parallaxSpeed, layer, position, size, rotation);
            AddBackground(background);
        }
        #endregion

        #region AddDynamicBackground
        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, xParallaxSpeed, layer, position);
            AddBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, float rotation)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, xParallaxSpeed, layer, position, rotation);
            AddBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, Vector2 size)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, xParallaxSpeed, layer, position, size);
            AddBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, Vector2 size, float rotation)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, xParallaxSpeed, layer, position, size, rotation);
            AddBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, parallaxSpeed, layer, position);
            AddBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, Vector2 size)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, parallaxSpeed, layer, position, size);
            AddBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, float rotation)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, parallaxSpeed, layer, position, rotation);
            AddBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, Vector2 size, float rotation)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, parallaxSpeed, layer, position, size, rotation);
            AddBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, Vector2 linearVelocity, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, 0, linearVelocity, 0, sprite, xParallaxSpeed, layer, position);
            AddBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, Vector2 linearVelocity, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, Vector2 size)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, 0, linearVelocity, 0, sprite, xParallaxSpeed, layer, position, size);
            AddBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, Vector2 linearVelocity, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, float rotation)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, 0, linearVelocity, 0, sprite, xParallaxSpeed, layer, position, rotation);
            AddBackground(background);
        }

        public void AddDynamicBackground(float angularVelocity, Vector2 linearVelocity, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, Vector2 size, float rotation)
        {
            ParallaxBackgroundDynamicItem background = new ParallaxBackgroundDynamicItem(this, angularVelocity, 0, linearVelocity, 0, sprite, xParallaxSpeed, layer, position, size, rotation);
            AddBackground(background);
        }
        #endregion

        /// <summary>
        /// Сортирует все элементы фона по их DrawOrder.
        /// </summary>
        private void SortBackgrounds()
        {
            _backgrounds.Sort((x, y) => Comparer<int>.Default.Compare(x.DrawOrder, y.DrawOrder));
            _sorted = true;
        }

        public void Draw(GameTime gameTime)
        {
            if (_sorted)
            {
                if (Visible)
                {
                    /*for (int i = 0; i < _backgrounds.Count; i++)
                        _backgrounds[i].Draw(gameTime);*/
                    foreach (var background in _backgrounds)
                        background.Draw(gameTime);
                }
            }
            else
            {
                SortBackgrounds();
                Draw(gameTime);
            }
        }

        public int DrawOrder { get; set; }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public bool Visible { get; set; }

        public event EventHandler<EventArgs> VisibleChanged;
    }
}
