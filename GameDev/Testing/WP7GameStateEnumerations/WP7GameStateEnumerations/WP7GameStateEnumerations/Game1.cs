using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace WP7GameStateEnumerations
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        enum ScreenState
        {
            Splash,
            Title,
            MainGame,
            Nag
        }
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private ScreenState currentScreen;
        private SpriteFont spriteFont;
        private decimal nagStartTime = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);

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
            currentScreen = ScreenState.Splash;
            ;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            spriteFont = Content.Load<SpriteFont>("SpriteFont1");
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
            switch (currentScreen)
            {
                case ScreenState.Splash:
                    UpdateSplashScreen(gameTime);
                    break;
                case ScreenState.Title:
                    UpdateTitleScreen();
                    break;
                case ScreenState.MainGame:
                    UpdateMainGameScreen();
                    break;
                case ScreenState.Nag:
                    UpdateNagScreen(gameTime);
                    break;
            }
            base.Update(gameTime);
        }

        private void UpdateSplashScreen(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds > 4)
                currentScreen = ScreenState.Title;
        }

        private void UpdateTitleScreen()
        {
            TouchCollection currentTouchState = TouchPanel.GetState();
            if (currentTouchState.Count > 0)
                currentScreen = ScreenState.MainGame;
        }

        private void UpdateMainGameScreen()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                currentScreen = ScreenState.Nag;
        }

        private void UpdateNagScreen(GameTime gameTime)
        {
            if (nagStartTime == 0)
                nagStartTime = gameTime.TotalGameTime.Seconds;
            if (gameTime.TotalGameTime.Seconds - nagStartTime > 4)
                this.Exit();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //Call the Draw method associated with the current screen
            switch (currentScreen)
            {
                case ScreenState.Splash:
                    DrawSplashScreen();
                    break;
                case ScreenState.Title:
                    DrawTitleScreen();
                    break;
                case ScreenState.MainGame:
                    DrawMainGameScreen();
                    break;
                case ScreenState.Nag:
                    DrawNagScreen();
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void DrawSplashScreen()
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.DrawString(spriteFont, "SPLASH", new Vector2(50f, 150f),
                 Color.Tomato);
            spriteBatch.DrawString(spriteFont, "Wait 4 Seconds", new Vector2(50f,
                 450f), Color.Tomato);
        }

        private void DrawTitleScreen()
        {
            GraphicsDevice.Clear(Color.Green);
            spriteBatch.DrawString(spriteFont, "TITLE", new Vector2(50f, 150f),
                 Color.White);
            spriteBatch.DrawString(spriteFont, "Touch Me", new Vector2(50f, 450f),
                 Color.White);
        }
        private void DrawMainGameScreen()
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(spriteFont, "MAIN", new Vector2(50f, 150f),
                 Color.Yellow);
            spriteBatch.DrawString(spriteFont, "Press the Back Button", new
                 Vector2(50f, 450f), Color.Yellow);
        }
        private void DrawNagScreen()
        {
            GraphicsDevice.Clear(Color.Pink);
            spriteBatch.DrawString(spriteFont, "NAG", new Vector2(50f, 150f), Color.Black);
            spriteBatch.DrawString(spriteFont, "BUY ME", new Vector2(150f, 250f),
                 Color.Black);
            spriteBatch.DrawString(spriteFont, "NAG", new Vector2(50f, 350f),
                 Color.Black);
            spriteBatch.DrawString(spriteFont, "BUY ME", new Vector2(150f, 450f),
                 Color.Black);
            spriteBatch.DrawString(spriteFont, "NAG", new Vector2(50f, 550f),
                 Color.Black);
            spriteBatch.DrawString(spriteFont, "BUY ME", new Vector2(150f, 650f),
                 Color.Black);
        }

    }
}
