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

namespace WP7GameGestures
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private String message = "Do Something";
        private Vector2 messagePos = Vector2.Zero;
        private Color color = Color.Black;

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

            TouchPanel.EnabledGestures = GestureType.DoubleTap |
                                         GestureType.DragComplete |
                                         GestureType.Flick |
                                         GestureType.FreeDrag |
                                         GestureType.Hold |
                                         GestureType.HorizontalDrag |
                                         GestureType.Pinch |
                                         GestureType.PinchComplete |
                                         GestureType.Tap |
                                         GestureType.VerticalDrag;
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                switch (gesture.GestureType)
                {
                    case GestureType.Tap:
                        message = "That was a Tap";
                        color = Color.Red;
                        break;
                    case GestureType.DoubleTap:
                        message = "That was a Double Tap";
                        color = Color.Orange;
                        break;
                    case GestureType.Hold:
                        message = "That was a Hold";
                        color = Color.Yellow;
                        break;
                    case GestureType.HorizontalDrag:
                        message = "That was an Horizontal Drag";
                        color = Color.Blue;
                        break;
                    case GestureType.VerticalDrag:
                        message = "That was a Vertical Drag";
                        color = Color.Indigo;
                        break;
                    case GestureType.FreeDrag:
                        message = "That was a FreeDrag";
                        color = Color.Green;
                        break;
                    case GestureType.DragComplete:
                        message = "Drag Gesture complete";
                        color = Color.Gold;
                        break;
                    case GestureType.Flick:
                        message = "That was a Flick";
                        color = Color.Violet;
                        break;
                    case GestureType.Pinch:
                        message = "That was a Pinch";
                        color = Color.Violet;
                        break;
                    case GestureType.PinchComplete:
                        message = "Pinch Gesture completed";
                        color = Color.Silver;
                        break;
                }
                messagePos = gesture.Position;
            }
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
            spriteBatch.DrawString(spriteFont, message, messagePos, color);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
