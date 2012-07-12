using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics.Joints;

namespace GameLogic
{
    public class GameLevel : IDrawable
    {
        private World _world;
        private Camera _camera;
        private SpriteBatch _spriteBatch;

        private List<GameObject> _objects;
        private bool _sorted; //показывает, отсортирован ли список по DrawOrder элементов

        private List<Joint> _joints; //список joint'ов между игровыми объектами

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

        public GameObject this[int index]
        {
            get { return _objects[index]; }
            set
            {
                _objects[index] = value;
                _sorted = false;
            }
        }

        public GameLevel(World world, Camera camera, SpriteBatch spriteBatch)
        {
            _objects = new List<GameObject>();
            _sorted = true;

            _joints = new List<Joint>();

            _world = world;
            _camera = camera;
            _spriteBatch = spriteBatch;
        }

        public void AddObject(GameObject gameObject)
        {
            _objects.Add(gameObject);
            _sorted = false;
        }

        public void AddJoint(Joint joint)
        {
            _joints.Add(joint);
        }

        /// <summary>
        /// Сортирует все игровые объекты по их DrawOrder.
        /// </summary>
        private void SortObjects()
        {
            _objects.Sort((x, y) => Comparer<int>.Default.Compare(x.DrawOrder, y.DrawOrder));
            _sorted = true;
        }

        #region IDrawable
        public void Draw(GameTime gameTime)
        {
            if (_sorted)
            {
                foreach (var gameObject in _objects)
                    gameObject.Draw(gameTime);
            }
            else
            {
                SortObjects();
                Draw(gameTime);
            }
        }

        public int DrawOrder { get; set; }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public bool Visible { get; set; }

        public event EventHandler<EventArgs> VisibleChanged;
        #endregion
    }
}
