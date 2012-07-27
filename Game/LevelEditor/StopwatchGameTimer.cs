using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace LevelEditor
{
    using Action = System.Action;

    public class StopwatchGameTimer
    {
        private GameTime _gameTime;
        private Stopwatch _stopwatch;
        private bool _enabled;
        public GameTime GameTime
        {
            get
            {
                return _gameTime;
            }
        }
        public bool Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                if (value == true)
                {
                    _stopwatch.Restart();
                    _gameTime = new GameTime();
                }
                else
                {
                    _stopwatch.Reset();
                    _gameTime = new GameTime();
                }
                _enabled = value;
            }
        }

        public StopwatchGameTimer()
        {
            _gameTime = new GameTime();
            _stopwatch = new Stopwatch();
            _enabled = false;
        }

        public void UpdateGameTime()
        {
            if (_enabled)
                _gameTime = new GameTime(_stopwatch.Elapsed, _stopwatch.Elapsed - _gameTime.TotalGameTime);
        }
    }
}