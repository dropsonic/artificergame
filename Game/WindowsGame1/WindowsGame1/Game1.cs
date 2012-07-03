using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using GameLogic;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        
        Camera _camera;
        ParallaxBackground _background;

        World _world;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _world = new World(new Vector2(0, 9.81f));

            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 480;
            ConvertUnits.SetDisplayUnitToSimUnitRatio(_graphics.PreferredBackBufferHeight / 30);

            _graphics.ApplyChanges();
            int width = GraphicsDevice.Viewport.Width * 2;
            int height = GraphicsDevice.Viewport.Height;

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _camera = new Camera(GraphicsDevice.Viewport) { Position = new Vector2(width / 2.0f, 0), Limits = new Rectangle(0, 0, width, height) };
            _background = new ParallaxBackground(_world, _camera, _spriteBatch);

            //Самый задний фон - картинка
            _background.AddBackground("sky", 0.1f, 0, Vector2.Zero, ConvertUnits.ToSimUnits(1000, 512));

            Random random = new Random();

            //Статичные параллаксные облака
            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j <= 3; j++)
                    _background.AddBackground(String.Format("cloud{0}", j), (float)random.NextDouble(), 3*i + j, ConvertUnits.ToSimUnits(random.Next(width), random.Next(200)));
            }
            
            //Воздушный шар
            _background.AddBackground("balloon", 1.0f, 10, ConvertUnits.ToSimUnits(500, 0), ConvertUnits.ToSimUnits(100 + 100, 200 + 135));

            //Динамичные параллаксные облака
            for (int i = 0; i < 2; i++)
            {
                for (int j = 1; j <= 3; j++)
                    _background.AddDynamicBackground(0f, new Vector2((float)random.NextDouble() * 4, 0), String.Format("cloud{0}", j), (float)random.NextDouble(), 10 + 3 * i + j, ConvertUnits.ToSimUnits(random.Next(width), random.Next(200)));
            }

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            // TODO: use this.Content to load your game content here
            _background.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                _camera.Move(new Vector2(-5.0f, 0));
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                _camera.Move(new Vector2(5.0f, 0));
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                _camera.Move(new Vector2(0, -5.0f));
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                _camera.Move(new Vector2(0, 5.0f));

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                _camera.Zoom += 0.01f;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                _camera.Zoom -= 0.01f;

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                _camera.Rotation += 0.01f;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                _camera.Rotation -= 0.01f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _camera.Zoom = 1.0f;
                _camera.Rotation = 0;
            }

            _world.Step(MathHelper.Min((float)gameTime.ElapsedGameTime.TotalSeconds, (1f / 30f)));

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _background.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
