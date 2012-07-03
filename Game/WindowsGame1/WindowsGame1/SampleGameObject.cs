using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WindowsGame1
{
    public class SampleGameObject : GameObject
    {
        World _world;
        SpriteBatch _spriteBatch;
        Camera _camera;
        Vector2 _position;
        float _parallaxRatio;

        public SampleGameObject(World world, SpriteBatch spriteBatch, Camera camera, Vector2 position)
            : this(world, spriteBatch, camera, position, 1.0f) { }

        public SampleGameObject(World world, SpriteBatch spriteBatch, Camera camera, Vector2 position, float parallaxRatio)
        { 
            _world = world;
            _spriteBatch = spriteBatch;
            _camera = camera;
            _position = position;
            _parallaxRatio = parallaxRatio;
        }

        public override void Initialize()
        {
            ObjectBody = BodyFactory.CreateRectangle(_world, 1.0f, 1.0f, 1.0f, _position);
            //ObjectBody.BodyType = BodyType.Dynamic;
        }

        public override void LoadContent(ContentManager content)
        {
            Texture = content.Load<Texture2D>("square");
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetViewMatrix(new Vector2(_parallaxRatio, 1.0f)));
            Vector2 position = ObjectBody.Position * 64;
            _spriteBatch.Draw(Texture, position, Color.White);
            _spriteBatch.End();
        }

        public override int DrawOrder
        {
            get { throw new NotImplementedException(); }
        }

        public override event EventHandler<EventArgs> DrawOrderChanged;

        public override bool Visible
        {
            get { throw new NotImplementedException(); }
        }

        public override event EventHandler<EventArgs> VisibleChanged;
    }
}
