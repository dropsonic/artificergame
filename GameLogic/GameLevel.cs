using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Content;

namespace GameLogic
{
    /// <summary>
    /// Игровой уровень.
    /// </summary>
    public class GameLevel : IUpdateableVisualComponent
    {
        public List<GameObject> Objects = new List<GameObject>();

        public World FarseerWorld;

        public GameLevel(World world)
        {
            this.FarseerWorld = world;
        }

        public void LoadContent(ContentManager content)
        {
            for (int i = 0; i < Objects.Count; i++)
                Objects[i].LoadContent(content);
        }

        public void Initialize()
        {
            for (int i = 0; i < Objects.Count; i++)
                Objects[i].Initialize();
        }

        public bool Enabled
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler<EventArgs> EnabledChanged;

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            FarseerWorld.Step(dt);
        }

        public int UpdateOrder
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler<EventArgs> UpdateOrderChanged;

        public void Draw(GameTime gameTime)
        {
            for (int i = 0; i < Objects.Count; i++)
                Objects[i].Draw(gameTime);
        }

        public int DrawOrder
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public bool Visible
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler<EventArgs> VisibleChanged;
    }
}
