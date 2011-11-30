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

namespace WP7GameMicrophoneSample
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private Microphone mic;
        private Texture2D micButtons;

        Rectangle recordButton = new Rectangle(50, 200, 100, 50);
        Rectangle playButton = new Rectangle(150, 200, 100, 50);

        private String message = String.Empty;
        private byte[] audioBuffer;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);

            mic = Microphone.Default;
            mic.BufferDuration = TimeSpan.FromSeconds(1);
            audioBuffer = new byte[mic.GetSampleSizeInBytes(mic.BufferDuration)];
            mic.BufferReady += BufferIsReady;
        }

        private void BufferIsReady(object sender, EventArgs e)
        {
            mic.GetData(audioBuffer);
            message = "Start talking... ";
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
            micButtons = Content.Load<Texture2D>("recorderbuttons");
            TouchPanel.EnabledGestures = GestureType.Tap;
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
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                switch (gesture.GestureType)
                {
                    case GestureType.Tap:
                        {
                            Rectangle touchRect = new Rectangle((int)gesture.Position.X,
                                                                (int)gesture.Position.Y, 10, 10);
                            if (touchRect.Intersects(recordButton))
                            {
                                mic.Start();
                                message = "Preparing to record...";
                            }
                            if (touchRect.Intersects(playButton))
                            {
                                mic.Stop();
                                message = "Playing...";
                                if (audioBuffer == null || audioBuffer.Length == 0)
                                    message = "Buffer empty...";
                                else
                                {
                                    SoundEffect recording = new SoundEffect(audioBuffer, mic.SampleRate,
                                                                            AudioChannels.Mono);
                                    recording.Play();
                                }
                            }
                            break;
                        }
                }
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
            spriteBatch.DrawString(spriteFont, 
                "Mic Name: " + mic.Name, 
                new Vector2(50,50), Color.Black);
            spriteBatch.DrawString(spriteFont,
                "Wired? " + mic.IsHeadset,
                new Vector2(50,100), Color.Black );
            spriteBatch.Draw(micButtons, new Vector2(50,200), Color.White );
            spriteBatch.DrawString(spriteFont, message, new Vector2(50,300), Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
