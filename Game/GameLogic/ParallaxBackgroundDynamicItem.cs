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

            public ParallaxBackgroundDynamicItem(World world, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, string textureName, Vector2 ParallaxSpeed, int layer, Vector2 position, Camera camera, SpriteBatch spriteBatch)
                : base(textureName, ParallaxSpeed, layer, position, camera, spriteBatch)
            {
                CreateBody(world, position, angularVelocity, angularDamping, linearVelocity, linearDamping);
            }

            public ParallaxBackgroundDynamicItem(World world, float angularVelocity, float angularDamping, Vector2 linearVelocity, float linearDamping, string textureName, Vector2 parallaxSpeed, int layer, Rectangle rect, Camera camera, SpriteBatch spriteBatch)
                : base(textureName, parallaxSpeed, layer, camera, spriteBatch)
            {
                CreateBody(world, new Vector2(rect.Left, rect.Top), angularVelocity, angularDamping, linearVelocity, linearDamping);
            }

            public override void Draw(GameTime gameTime)
            {
                if (Visible)
                {
                    _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetViewMatrix(ParallaxSpeed));
                    if (_usingRect)
                        _spriteBatch.Draw(_texture, _rect, null, Color.White, _body.Rotation, _body.Position, SpriteEffects.None, 0);
                    else
                        _spriteBatch.Draw(_texture, _position, Color.White);

                    _spriteBatch.End();
                }
            }
        }
        #endregion
    }
}