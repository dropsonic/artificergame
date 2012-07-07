using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;

namespace GameLogic
{
    /// <summary>
    /// Динамический объект фона.
    /// </summary>
    /// <example>Плывущие облачка, вращающиеся лопасти мельницы.</example>
    public class ParallaxBackgroundDynamicItem : ParallaxBackgroundItem
    {
        Body _body;
        World _world;

        private void CreateBody(Vector2 position, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping)
        {
            _body = BodyFactory.CreateBody(_world, position);
            _body.BodyType = BodyType.Kinematic;
            _body.CollidesWith = Category.None;

            _body.AngularVelocity = angularVelocity;
            _body.AngularDamping = angularDamping;
            _body.LinearVelocity = linearVelocity;
            _body.LinearDamping = linearDamping;

            _body.Rotation = _rotation;
        }

        public ParallaxBackgroundDynamicItem(ParallaxBackground parent, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position)
            : this(parent, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, new Vector2(xParallaxSpeed, 1.0f), layer, position) { }

        public ParallaxBackgroundDynamicItem(ParallaxBackground parent, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, float rotation)
            : this(parent, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, new Vector2(xParallaxSpeed, 1.0f), layer, position, rotation) { }

        public ParallaxBackgroundDynamicItem(ParallaxBackground parent, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, Vector2 size)
            : this(parent, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, new Vector2(xParallaxSpeed, 1.0f), layer, position, size) { }

        public ParallaxBackgroundDynamicItem(ParallaxBackground parent, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, float xParallaxSpeed, int layer, Vector2 position, Vector2 size, float rotation)
            : this(parent, angularVelocity, angularDamping, linearVelocity, linearDamping, sprite, new Vector2(xParallaxSpeed, 1.0f), layer, position, size, rotation) { }

        public ParallaxBackgroundDynamicItem(ParallaxBackground parent, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position)
            : base(parent, sprite, parallaxSpeed, layer, position)
        {
            _world = parent.World;
            CreateBody(position, angularVelocity, angularDamping, linearVelocity, linearDamping);
        }

        public ParallaxBackgroundDynamicItem(ParallaxBackground parent, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, float rotation)
            : base(parent, sprite, parallaxSpeed, layer, position, rotation)
        {
            _world = parent.World;
            CreateBody(position, angularVelocity, angularDamping, linearVelocity, linearDamping);
        }

        public ParallaxBackgroundDynamicItem(ParallaxBackground parent, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, Vector2 size)
            : base(parent, sprite, parallaxSpeed, layer, position, size)
        {
            _world = parent.World;
            CreateBody(position, angularVelocity, angularDamping, linearVelocity, linearDamping);
        }

        public ParallaxBackgroundDynamicItem(ParallaxBackground parent, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, Sprite sprite, Vector2 parallaxSpeed, int layer, Vector2 position, Vector2 size, float rotation)
            : base(parent, sprite, parallaxSpeed, layer, position, size, rotation)
        {
            _world = parent.World;
            CreateBody(position, angularVelocity, angularDamping, linearVelocity, linearDamping);
        }

        public override void Draw(GameTime gameTime)
        {
            if (Visible)
            {
                _parallaxBackground.SpriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetViewMatrix(ParallaxSpeed));

                //Пересчитываем позицию и прямоугольник для отображения
                Vector2 displayPosition = ConvertUnits.ToDisplayUnits(_body.Position);
                _rect = new Rectangle((int)displayPosition.X, (int)displayPosition.Y, (int)_displaySize.X, (int)_displaySize.Y);

                _spriteBatch.Draw(_sprite.Texture, _rect, null, Color.White, _body.Rotation, _sprite.Origin, SpriteEffects.None, 0);
                _spriteBatch.End();
            }
        }
    }
}