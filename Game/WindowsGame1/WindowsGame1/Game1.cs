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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Camera camera;
        ParallaxBackground background;

        World world;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 480;
            graphics.ApplyChanges();
            int width = GraphicsDevice.Viewport.Width * 2;
            int height = GraphicsDevice.Viewport.Height;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(GraphicsDevice.Viewport) { Position = new Vector2(width / 2.0f, 0), Limits = new Rectangle(0, 0, width, height) };
            background = new ParallaxBackground(camera, spriteBatch);

            background.AddBackground("sky", 0.1f, 0, new Rectangle(0, 0, width, height));

            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 1; j <= 4; j++)
                    background.AddBackground(String.Format("cloud{0}", j), (float)random.NextDouble(), 4*i + j, new Vector2(random.Next(width), random.Next(height)));
            }

            background.AddBackground("balloon", 1.0f, 13, new Rectangle(500, 100, 100 + 100, 200 + 135));

            world = new World(new Vector2(0, 9.81f));

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
            background.LoadContent(Content);
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
                camera.Move(new Vector2(-5.0f, 0));
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                camera.Move(new Vector2(5.0f, 0));
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                camera.Move(new Vector2(0, -5.0f));
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                camera.Move(new Vector2(0, 5.0f));

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                camera.Zoom += 0.01f;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                camera.Zoom -= 0.01f;

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                camera.Rotation += 0.01f;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                camera.Rotation -= 0.01f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                camera.Zoom = 1.0f;
                camera.Rotation = 0;
            }

            // TODO: Add your update logic here

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
            background.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
