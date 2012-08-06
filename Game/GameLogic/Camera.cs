using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerTools;

namespace GameLogic
{
    /// <summary>
    /// Класс камеры.
    /// </summary>
    /// <see cref="http://www.david-gouveia.com/2d-camera-with-parallax-scrolling-in-xna/"/>
    /// <seealso cref="http://www.david-gouveia.com/limiting-2d-camera-movement-with-zoom/"/>
    public class Camera
    {
        //protected const float _minZoom = 0.1f;

        protected Viewport _viewport;

        protected Vector2 _origin; //Camera Origin
        protected float _zoom;      //Camera Zoom
        protected Matrix _transform;   //Matrix Transform
        protected Vector2 _position;   //Camera Position
        protected float _rotation;  //Camera Rotation
        private Rectangle? _limits; //Camera Position Limits

        protected bool _changed; //Определяет, были ли изменения параметров камеры с момента последнего расчёта View.

        protected Matrix _viewMatrix; //Сохраняет сюда матрицу вида с предыдущего вычисления
        protected Matrix _simViewMatrix;
 
        public Camera(Viewport viewport)
        {
            _viewport = viewport;

            _zoom = 1.0f;
            _rotation = 0.0f;
            _position = Vector2.Zero;
            _origin = new Vector2(viewport.Width / 2.0f, viewport.Height / 2.0f);

            OnChanged();
        }

        /// <summary>
        /// Центр камеры.
        /// </summary>
        public Vector2 Origin
        {
            get { return _origin; }
            set 
            {
                _origin = value;
                OnChanged();
            }
        }

        public float Zoom
        {
            get { return _zoom; }
            set 
            {
                _zoom = value;
                ValidateZoom();
                ValidatePosition();
                OnChanged();
            } 
        }

        public float Rotation
        {
            get { return _rotation; }
            set 
            { 
                _rotation = value;
                OnChanged();
            }
        }

        /// <summary>
        /// Позиция центра камеры в абсолютных координатах.
        /// </summary>
        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                ValidatePosition();
                OnChanged();
            }
        }

        public Rectangle? Limits
        {
            get { return _limits; }
            set
            {
                _limits = value;
                ValidateZoom();
                ValidatePosition();
                OnChanged();
            }
        }

        private void ValidateZoom()
        {
            if (_limits.HasValue)
            {
                float minZoomX = (float)_viewport.Width / _limits.Value.Width;
                float minZoomY = (float)_viewport.Height / _limits.Value.Height;
                _zoom = MathHelper.Max(_zoom, MathHelper.Max(minZoomX, minZoomY));
            }
        }

        private void ValidatePosition()
        {
            if (_limits.HasValue)
            {
                Vector2 cameraWorldMin = Vector2.Transform(Vector2.Zero, Matrix.Invert(GetViewMatrix()));
                Vector2 cameraSize = new Vector2(_viewport.Width, _viewport.Height) / _zoom;
                Vector2 limitWorldMin = new Vector2(_limits.Value.Left, _limits.Value.Top);
                Vector2 limitWorldMax = new Vector2(_limits.Value.Right, _limits.Value.Bottom);
                Vector2 positionOffset = _position - cameraWorldMin;
                _position = Vector2.Clamp(cameraWorldMin, limitWorldMin, limitWorldMax - cameraSize) + positionOffset;
            }
        }

        // Auxiliary function to move the camera
        public void Move(Vector2 amount)
        {
            Position += amount;
        }

        public void LookAt(Vector2 position)
        {
            Position = position - new Vector2(_viewport.Width / 2.0f, _viewport.Height / 2.0f);
        }

        public Matrix GetViewMatrix(Vector2 parallax)
        {
            if (_changed)
                //To add parallax, simply multiply it by the position
                _viewMatrix = Matrix.CreateTranslation(new Vector3(-Position * parallax, 0.0f)) *
                    //The next line has a catch. See note below.
                       Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                       Matrix.CreateRotationZ(Rotation) *
                       Matrix.CreateScale(Zoom, Zoom, 1) *
                       Matrix.CreateTranslation(new Vector3(Origin, 0.0f));

            return _viewMatrix;
        }

        public Matrix GetSimViewMatrix()
        {
            if(_changed)
                _simViewMatrix = Matrix.CreateTranslation(new Vector3(-ConvertUnits.ToSimUnits(Position), 0.0f)) *
                                 Matrix.CreateTranslation(new Vector3(-ConvertUnits.ToSimUnits(Origin), 0.0f)) *
                                 Matrix.CreateRotationZ(Rotation) *
                                 Matrix.CreateScale(Zoom, Zoom, 1) *
                                 Matrix.CreateTranslation(new Vector3(ConvertUnits.ToSimUnits(Origin), 0.0f));
            return _simViewMatrix;
        }

        public Matrix GetViewMatrix()
        {
            return GetViewMatrix(Vector2.One);
        }

        protected void OnChanged()
        {
            _changed = true;
        }
    }
}
