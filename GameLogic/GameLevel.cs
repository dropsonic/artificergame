using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics.Joints;
using System.Collections;

namespace GameLogic
{
    public class GameLevel : IDrawable, IUpdateable, IEnumerable<GameObject>
    {
        private static readonly Vector2 defaultGravity = new Vector2(0f, 9.81f);

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
            set 
            {
                _camera = value;
                foreach (GameObject obj in _objects)
                    obj.Camera = value;
                if (_spriteBatch != null)
                    Visible = true;
            }
        }

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
            set 
            { 
                _spriteBatch = value;
                foreach (GameObject obj in _objects)
                    obj.SpriteBatch = value;
                if (_camera != null)
                    Visible = true;
            }
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

        public GameLevel()
        {
            _objects = new List<GameObject>();
            _sorted = true;

            _joints = new List<Joint>();

            _world = new World(defaultGravity);

            Enabled = true;
            Visible = false;
        }

        public GameLevel(Camera camera, SpriteBatch spriteBatch)
            : this()
        {
            _camera = camera;
            _spriteBatch = spriteBatch;
            Visible = true;
        }

        public GameLevel(Camera camera, SpriteBatch spriteBatch, Vector2 gravity)
            : this(camera, spriteBatch)
        {
            _world.Gravity = gravity;
        }

        public GameLevel(Camera camera, SpriteBatch spriteBatch, World world)
            : this(camera, spriteBatch)
        {
            _world = world;
        }

        public void AddObject(GameObject gameObject)
        {
            _objects.Add(gameObject);
            _sorted = false;
        }

        public void RemoveObject(GameObject gameObject)
        {
            foreach (GameObjectPart part in gameObject)
                part.RemoveBody(World);
            _objects.Remove(gameObject);
            
        }

        public void AddJoint(Joint joint)
        {
            _joints.Add(joint);
            _world.AddJoint(joint);
        }
        public void RemoveJoint(Joint joint)
        {
            _joints.Remove(joint);
            _world.RemoveJoint(joint);
        }

        /// <summary>
        /// Сортирует все игровые объекты по их DrawOrder.
        /// </summary>
        private void SortObjects()
        {
            _objects.Sort((x, y) => Comparer<int>.Default.Compare(x.DrawOrder, y.DrawOrder));
            _sorted = true;
        }

        /// <summary>
        /// Создаёт полную копию GameLevel.
        /// </summary>
        /// <returns></returns>
        public GameLevel DeepCopy()
        {
            //Создаём новый GameLevel
            GameLevel result = new GameLevel(_camera, _spriteBatch, _world.Gravity);

            //Копируем все joint'ы
            foreach (Joint joint in _joints)
            {
                Joint newJoint = joint.Copy();
                result.AddJoint(newJoint);
                result._world.AddJoint(newJoint);
            }

            //Копируем в него все объекты
            foreach (GameObject gameObject in _objects)
            {
                GameObject newGameObject = gameObject.CopyObjectToWorld(result._world, Vector2.Zero); //копируем объект
                result.AddObject(newGameObject); //добавляем его в новый GameLevel
                for (int i = 0; i < newGameObject.PartsCount; i++)
                {
                    //Меняем ссылки на Body в joint'ах на новые
                    for (int j = 0; j < _joints.Count; j++)
                    {
                        if (_joints[j].BodyA == gameObject[i].Body)
                            result._joints[j].BodyA = newGameObject[i].Body;
                        if (_joints[j].BodyB == gameObject[i].Body)
                            result._joints[j].BodyB = newGameObject[i].Body;
                    }
                }
            }

            return result;
        }
        #region IEnumerable
        public IEnumerator<GameObject> GetEnumerator() { return _objects.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        #endregion

        #region IDrawable
        public void Draw(GameTime gameTime)
        {
            if (_visible)
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

        #region IUpdatable
        private bool _enabled;
        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                if (EnabledChanged != null)
                    EnabledChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler<EventArgs> EnabledChanged;

        public void Update(GameTime gameTime)
        {
            if (_enabled)
                // variable time step but never less then 30 Hz
                _world.Step(MathHelper.Min((float)gameTime.ElapsedGameTime.TotalSeconds, (1f / 30f)));
            else
                _world.Step(0f);
        }

        private int _updateOrder;
        public int UpdateOrder
        {
            get { return _updateOrder; }
            set
            {
                _updateOrder = value;
                if (UpdateOrderChanged != null)
                    UpdateOrderChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler<EventArgs> UpdateOrderChanged;
        #endregion
    }
}
