using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using System.Reflection;
using FarseerTools;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GameLogic
{
    public class GameObject : IDrawable, IEnumerable<GameObjectPart>
    {
        #region Общие поля и свойства
        //Список частей объекта
        private List<GameObjectPart> _parts;
        private bool _sorted; //показывает, отсортирован ли список по DrawOrder элементов

        private List<Joint> _joints;

        [XMLExtendedSerialization.XMLDoNotSerialize]
        private SpriteBatch _spriteBatch;
        private Camera _camera;

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
            set 
            { 
                _spriteBatch = value;
                foreach (var part in _parts)
                    part.SpriteBatch = value;
            }
        }

        public Camera Camera
        {
            get { return _camera; }
            set { _camera = value; }
        }

        private Vector2 _origin;

        /// <summary>
        /// Центр координат объекта.
        /// </summary>
        public Vector2 Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }
        public ReadOnlyCollection<Joint> Joints
        {
            get { return _joints.AsReadOnly(); }
        }

        public ReadOnlyCollection<GameObjectPart> Parts
        {
            get { return _parts.AsReadOnly(); }
        }
        public GameObjectPart this[int index]
        {
            get { return _parts[index]; }
            set
            {
                _parts[index] = value;
                _sorted = false;
            }
        }

        /// <summary>
        /// Количество объектов GameObjectPart, содержащихся в данном GameObject.
        /// </summary>
        public int PartsCount
        {
            get { return _parts.Count; }
        }
        #endregion

        #region IEnumerable
        public IEnumerator<GameObjectPart> GetEnumerator() { return _parts.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        #endregion

        #region Шаблонизация объекта
        private World _world;

        /// <summary>
        /// World для создания и хранения в нём всех Body и Joint'ов объекта.
        /// </summary>
        public World World
        {
            get { return _world; }
            set { _world = value; }
        }

        /// <summary>
        /// Копирует игровой объект в world.
        /// </summary>
        /// <param name="world">World, в который требуется скопировать объект.</param>
        /// <param name="position">Позиция объекта (его точки Origin) в координатах World.</param>
        public GameObject CopyObjectToWorld(World world, Vector2 position)
        {
            //Создаём новый экземпляр GameObject
            GameObject result = new GameObject(world, _camera, _spriteBatch, position);

            //Копируем joint'ы между частями
            foreach (var joint in _joints)
            {
                Joint newJoint = joint.Copy();
                result.AddJoint(newJoint);
                world.AddJoint(newJoint);
            }

            //Копируем все части
            foreach (var part in _parts)
            {
                GameObjectPart newPart = part.DeepClone(world, position);

                //Меняем привязки joint'ов на новые копии body.
                for (int i = 0; i < _joints.Count; i++)
                {
                    if (_joints[i].BodyA == part.Body)
                        result._joints[i].BodyA = newPart.Body;
                    else if (_joints[i].BodyB == part.Body)
                        result._joints[i].BodyB = newPart.Body;
                }
                result.AddPart(newPart);
            }

            return result;
        }
        #endregion

        #region Конструкторы
        public GameObject()
        {
            _parts = new List<GameObjectPart>();
            _sorted = true;
            _joints = new List<Joint>();
            _origin = Vector2.Zero;

            _world = new World(Vector2.Zero);
            Visible = true;
        }

        public GameObject(Camera camera, SpriteBatch spriteBatch)
            : this()
        {
            _spriteBatch = spriteBatch;
            _camera = camera;
        }

        public GameObject(Camera camera, SpriteBatch spriteBatch, Vector2 origin)
            : this(camera, spriteBatch)
        {
            _origin = origin;
        }

        public GameObject(World world, Camera camera, SpriteBatch spriteBatch)
            : this(camera, spriteBatch)
        {
            _world = world;
        }

        public GameObject(World world, Camera camera, SpriteBatch spriteBatch, Vector2 origin)
            : this(world, camera, spriteBatch)
        {
            _origin = origin;
        }
        #endregion

        #region Добавление и сортировка
        /// <summary>
        /// Сортирует все части объекта по их DrawOrder.
        /// </summary>
        private void SortParts()
        {
            _parts.Sort((x, y) => Comparer<int>.Default.Compare(x.DrawOrder, y.DrawOrder));
            _sorted = true;
        }

        public void AddPart(GameObjectPart part)
        {
            part.SpriteBatch = _spriteBatch;
            _parts.Add(part);
            _sorted = false;
        }

        public void RemovePart(GameObjectPart part)
        {
            _parts.Find(item => item == part).RemoveBody(World);
            _parts.Remove(part);
        }

        public void AddPart(Sprite sprite, Body body)
        {
            AddPart(new GameObjectPart(_spriteBatch, sprite, body));
        }

        public void AddJoint(Joint joint)
        {
            _joints.Add(joint);
            _world.AddJoint(joint);
        }

        public void RemoveJoint(Joint joint)
        {
            _joints.Remove(joint);
        }



        #endregion

        #region IDrawable
        public void Draw(GameTime gameTime)
        {
            if (_visible)
            {
                if (_sorted)
                {
                    SpriteBatch.Begin(0, null, null, null, null, null, _camera.GetViewMatrix());
                    foreach (var part in _parts)
                        part.Draw(gameTime);
                    SpriteBatch.End();
                }
                else
                {
                    SortParts();
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
    }
}