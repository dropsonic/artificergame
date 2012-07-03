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
    public partial class ParallaxBackground
    {
        #region ParallaxBackgroundDynamicItem
        /// <summary>
        /// Динамический объект фона.
        /// </summary>
        /// <example>Плывущие облачка, вращающиеся лопасти мельницы.</example>
        private class ParallaxBackgroundDynamicItem : ParallaxBackgroundItem
        {
            Body _body;

            private void CreateBody(World world, Vector2 position, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping)
            {
                _body = BodyFactory.CreateBody(world, position);
                _body.BodyType = BodyType.Kinematic;
                _body.CollidesWith = Category.None;

                _body.AngularVelocity = angularVelocity;
                _body.AngularDamping = angularDamping;
                _body.LinearVelocity = linearVelocity;
                _body.LinearDamping = linearDamping;
            }

            public ParallaxBackgroundDynamicItem(World world, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, string textureName, Vector2 parallaxSpeed, int layer, Vector2 position, Camera camera, SpriteBatch spriteBatch)
                : this(world, angularVelocity, angularDamping, linearVelocity, linearDamping, textureName, parallaxSpeed, layer, position, Vector2.Zero, camera, spriteBatch) { }

            public ParallaxBackgroundDynamicItem(World world, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, string textureName, Vector2 parallaxSpeed, int layer, Vector2 position, Vector2 size, Camera camera, SpriteBatch spriteBatch)
                : base(textureName, parallaxSpeed, layer, position, size, camera, spriteBatch)
            {
                CreateBody(world, position, angularVelocity, angularDamping, linearVelocity, linearDamping);
            }

            public override void Draw(GameTime gameTime)
            {
                if (Visible)
                {
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetViewMatrix(ParallaxSpeed));
                    Vector2 displayPosition = ConvertUnits.ToDisplayUnits(_body.Position);
                    _rect = new Rectangle((int)displayPosition.X, (int)displayPosition.Y, (int)_displaySize.X, (int)_displaySize.Y);
                    _spriteBatch.Draw(_texture, _rect, null, Color.White, _body.Rotation, _size / 2, SpriteEffects.None, 0);
                    _spriteBatch.End();
                }
            }
        }
        #endregion
    }
}