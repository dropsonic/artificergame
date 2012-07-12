﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using FarseerTools;

namespace GameLogic
{
    public abstract class GameObject : IVisualComponent
    {
        public Body ObjectBody;
        public Sprite Sprite;

        private byte _layer = 0;
        public byte Layer
        {
            get { return _layer; }
            set { _layer = value; }
        }

        public GameObject() { }

        public GameObject(Body body)
        {
            this.ObjectBody = body;
        }

        public GameObject(Body body, Sprite sprite)
        {
            this.ObjectBody = body;
            this.Sprite = sprite;
        }

        #region IVisualComponent
        public abstract void Initialize();

        public abstract void LoadContent(ContentManager content);

        public abstract void Draw(GameTime gameTime);

        public abstract int DrawOrder { get; }

        public abstract event EventHandler<EventArgs> DrawOrderChanged;

        public abstract bool Visible { get; }

        public abstract event EventHandler<EventArgs> VisibleChanged;
        #endregion
    }
}