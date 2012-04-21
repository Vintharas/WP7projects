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
using GameInputs.Inputs;

namespace InputHandlerDemo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        private SpriteFont font;
        private Texture2D square;
        private string action;
        
        private GameInput gameInput;
        private TouchIndicatorCollection touchIndicators;

        private Rectangle jumpRectangle = new Rectangle(0, 0, 480, 100);
        private Rectangle upRectangle = new Rectangle(0, 150, 480, 100);
        private Rectangle pauseRectangle = new Rectangle(0, 500, 200, 100);
        private Rectangle exitRectangle = new Rectangle(220, 500, 200, 100);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            action = "";
            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);

            graphics.PreferredBackBufferWidth = 480;
            graphics.PreferredBackBufferHeight = 800;
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
            gameInput = new GameInput();
            touchIndicators = new TouchIndicatorCollection();
            AddInputs();
            base.Initialize();
        }

        private void AddInputs()
        {
            // Add the keyboard, gamepad and touch inputs for Jump
            gameInput.AddKeyboardInput(Actions.Jump, Keys.A, true);
            gameInput.AddKeyboardInput(Actions.Jump, Keys.Space, false);
            gameInput.AddTouchTapInput(Actions.Jump, jumpRectangle, false);
            gameInput.AddTouchSlideInput(Actions.Jump, Direction.Right, 5.0f);
            // Add keyboard, gamepad and touch inputs for Pause
            gameInput.AddGamePadInput(Actions.Pause, Buttons.Start, true);
            gameInput.AddKeyboardInput(Actions.Pause, Keys.P, true);
            gameInput.AddTouchTapInput(Actions.Pause, pauseRectangle, true);
            gameInput.AddAccelerometerInput(Actions.Pause, Direction.Down, 0.10f);
            // Action Up
            gameInput.AddGamePadInput(Actions.Up, Buttons.RightThumbstickUp, false);
            gameInput.AddGamePadInput(Actions.Up, Buttons.LeftThumbstickUp, false);
            gameInput.AddGamePadInput(Actions.Up, Buttons.DPadUp, false);
            gameInput.AddKeyboardInput(Actions.Up, Keys.Up, false);
            gameInput.AddKeyboardInput(Actions.Up, Keys.W, true);
            gameInput.AddTouchTapInput(Actions.Up, upRectangle, true);
            gameInput.AddTouchSlideInput(Actions.Up, Direction.Up, 5.0f);
            gameInput.AddAccelerometerInput(Actions.Up, Direction.Up, 0.10f);
            // Action Exit
            gameInput.AddGamePadInput(Actions.Exit, Buttons.Back, false);
            gameInput.AddKeyboardInput(Actions.Exit, Keys.Escape, false);
            gameInput.AddTouchTapInput(Actions.Exit, exitRectangle, true);
            // Add some gestures
            gameInput.AddTouchGestureInput(Actions.Jump, GestureType.VerticalDrag, jumpRectangle);
            gameInput.AddTouchGestureInput(Actions.Pause, GestureType.Hold, pauseRectangle);
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
            font = Content.Load<SpriteFont>("Display");
            square = Content.Load<Texture2D>("Pixel");
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

            // TODO: Add your update logic here
            // update current game status
            gameInput.BeginUpdate();
            if (gameInput.IsPressed(Actions.Exit, PlayerIndex.One))
                this.Exit();
            if (gameInput.IsPressed(Actions.Jump, PlayerIndex.One))
                action = Actions.Jump;
            if (gameInput.IsPressed(Actions.Pause, PlayerIndex.One))
                action = Actions.Pause;
            if (gameInput.IsPressed(Actions.Up, PlayerIndex.One))
                action = Actions.Up;
            touchIndicators.Update(gameTime, Content);
            // save current status as previous status
            gameInput.EndUpdate();

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
            spriteBatch.Begin();
            
            spriteBatch.Draw(square, upRectangle, Color.Blue);
            spriteBatch.DrawString(font, "Up", new Vector2(upRectangle.Left + 20, upRectangle.Top + 20), Color.Black );

            spriteBatch.Draw(square, jumpRectangle, Color.Yellow);
            spriteBatch.DrawString(font, "Jump", new Vector2(jumpRectangle.Left + 20, jumpRectangle.Top + 20),Color.Black);

            spriteBatch.Draw(square, pauseRectangle, Color.Green);
            spriteBatch.DrawString(font, "Pause", new Vector2(pauseRectangle.Left + 20, pauseRectangle.Top + 20),
                                   Color.Black);

            spriteBatch.Draw(square, exitRectangle, Color.Red);
            spriteBatch.DrawString(font, "Exit", new Vector2(exitRectangle.Left + 20, exitRectangle.Top + 20), Color.Black);

            spriteBatch.DrawString(font, action, new Vector2(100, 350), Color.White);
            touchIndicators.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
