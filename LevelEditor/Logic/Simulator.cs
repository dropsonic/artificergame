﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameLogic;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Dynamics;
using FarseerTools;

namespace LevelEditor
{
    /// <summary>
    /// Состояние симуляции.
    /// </summary>
    public enum SimulationState
    {
        Simulation,
        Paused,
        Stopped
    }

    public class Simulator
    {
        public Simulator()
        {
            _timer = new StopwatchGameTimer();
            Stop();
        }

        public Simulator(GameLevel level)
            : this()
        {
            GameLevel = level;
        }

        private SimulationState _state;
        private StopwatchGameTimer _timer;
        private TimeSpan _worldTime = TimeSpan.Zero;

        private GameLevel _initialLevel;
        private GameLevel _simulatedLevel;

        public const float NormalSimulationSpeed = 1.0f;
        private float _simulationSpeed;

        private FixedMouseJoint _mouseJoint;
        private Vector2 _mousePosition;

        /// <summary>
        /// Скорость хода времени при симуляции.
        /// </summary>
        public float SimulationSpeed
        {
            get { return _simulationSpeed; }
            set { _simulationSpeed = value; }
        }

        public GameLevel GameLevel
        {
            get
            {
                //if (_state == SimulationState.Simulation || _state == SimulationState.Paused)
                //    return _simulatedLevel;
                //else
                //    return _initialLevel;
                return _simulatedLevel;
            }
            set
            {
                _initialLevel = value;
            }
        }

        #region Управление состоянием
        /// <summary>
        /// Состояние (запущена, пауза, остановлена).
        /// </summary>
        public SimulationState State
        {
            get
            {
                return _state;
            }
            private set
            {
                _state = value;
                OnSimulateChanged();
            }
        }

        /// <summary>
        /// Запускает симуляцию.
        /// </summary>
        public void Start()
        {
            ResetLevelTo(_initialLevel);
            State = SimulationState.Simulation;
            _timer.Enabled = true;
        }

        /// <summary>
        /// Ставит симуляцию на паузу.
        /// </summary>
        public void Pause()
        {
            if (_state == SimulationState.Simulation)
            {
                State = SimulationState.Paused;
                _timer.Enabled = false;
            }
        }

        /// <summary>
        /// Останавливает симуляцию.
        /// </summary>
        public void Stop()
        {
            State = SimulationState.Stopped;
            _timer.Enabled = false;
            ResetLevelTo(_initialLevel);
        }

        /// <summary>
        /// Вызывается при изменении State.
        /// </summary>
        public event EventHandler SimulateChanged;

        protected void OnSimulateChanged()
        {
            _worldTime = TimeSpan.Zero;

            if (SimulateChanged != null)
                SimulateChanged(this, EventArgs.Empty);
        }

        private void ResetLevelTo(GameLevel levelState)
        {
            if (levelState == null)
                return;

            _simulatedLevel = _initialLevel.DeepCopy();
            _simulatedLevel.World.ProcessChanges();
        }
        #endregion

        private void Update()
        {
            if (_state == SimulationState.Simulation)
            {
                if (_worldTime == TimeSpan.Zero && _simulationSpeed <= 0)
                    throw new Exception("Попытка запустить симуляцию с отрицательным значением шага");
                TimeSpan elapsed = TimeSpan.FromMilliseconds(_timer.GameTime.ElapsedGameTime.TotalMilliseconds * _simulationSpeed);
                _worldTime += elapsed;
                if (_worldTime <= TimeSpan.Zero)
                {
                    State = SimulationState.Stopped;
                    return;
                }
                if (_simulationSpeed == NormalSimulationSpeed)
                    _simulatedLevel.Update(_timer.GameTime);
                else
                    _simulatedLevel.Update(new GameTime(_timer.GameTime.TotalGameTime, elapsed));
            }
        }

        public Vector2 MousePosition
        {
            get { return _mousePosition; }
            set { _mousePosition = value; }
        }

        public void CreateMouseJoint()
        {
            if (_mouseJoint == null)
            {
                Fixture savedFixture = _simulatedLevel.World.TestPoint(ConvertUnits.ToSimUnits(_mousePosition));
                if (savedFixture != null)
                {
                    Body body = savedFixture.Body;
                    _mouseJoint = new FixedMouseJoint(body, ConvertUnits.ToSimUnits(_mousePosition));
                    _mouseJoint.MaxForce = 1000.0f * body.Mass;
                    _simulatedLevel.World.AddJoint(_mouseJoint);
                    body.Awake = true;
                }
            }
        }
        public void RemoveMouseJoint()
        {
            if (_mouseJoint != null)
            {
                _simulatedLevel.World.RemoveJoint(_mouseJoint);
                _mouseJoint = null;
            }
        }
        public void UpdateMouseJoint()
        {
            if (_mouseJoint != null)
            {
                _mouseJoint.WorldAnchorB = ConvertUnits.ToSimUnits(_mousePosition);
            }
        }
    }
}
