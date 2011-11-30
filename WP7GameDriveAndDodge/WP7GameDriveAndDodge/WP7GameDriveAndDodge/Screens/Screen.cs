using System;
using DriveAndDodge.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WP7GameDriveAndDodge.Sounds;

namespace WP7GameDriveAndDodge.Screens
{
    public abstract class Screen
    {
        protected static Game game;
        protected static ContentManager content;
        protected static SpriteBatch spriteBatch;
        protected static Random random = new Random();

        // Input Management
        protected GameInput input = new GameInput();
        public bool isTouchIndicatorEnabled = false;
        private TouchIndicatorCollection touchIndicator;
        // Sound Management
        protected static Music music;
        protected static SoundEffects soundEffects;

        public ChangeScreen changeScreenDelegate;
        public delegate void ChangeScreen(ScreenState screen);

        protected SpriteFont font;

        public Screen(Game game,
                      SpriteBatch spriteBatch,
                      ChangeScreen changeScreen)
        {
            Screen.game = game;
            Screen.content = game.Content;
            Screen.spriteBatch = spriteBatch;
            changeScreenDelegate = changeScreen;
            touchIndicator = new TouchIndicatorCollection();
            if (music == null)
                music = new Music(content);
            if (soundEffects == null)
                soundEffects = new SoundEffects(content);
        }

        public abstract void Activate();
        
        public void LoadContent()
        {
            font = content.Load<SpriteFont>("Fonts/screenFont");
            LoadScreenContent(content);
            SetupInputs();
        }

        protected abstract void SetupInputs();
        protected abstract void LoadScreenContent(ContentManager content);

        public void Update(GameTime gameTime)
        {
            input.BeginUpdate();
            if (isTouchIndicatorEnabled)
                touchIndicator.Update(gameTime, content);
            UpdateScreen(gameTime, game.GraphicsDevice.PresentationParameters.DisplayOrientation);
            input.EndUpdate();
        }

        protected abstract void UpdateScreen(GameTime gameTime, DisplayOrientation screenOrientation);

        public void Draw()
        {
            spriteBatch.Begin();
            DrawScreen(spriteBatch, 
                game.GraphicsDevice.PresentationParameters.DisplayOrientation);
            if (isTouchIndicatorEnabled)
                touchIndicator.Draw(spriteBatch);
            spriteBatch.End();
        }

        protected abstract void DrawScreen(SpriteBatch spriteBatch, DisplayOrientation screenOrientation);

        public void SaveState()
        {
            SaveScreenState();
        }

        public virtual void SaveScreenState()
        {
        }

        static public int ScreenWidth
        {
            get { return game.GraphicsDevice.PresentationParameters.BackBufferWidth; }
        }
        static public int ScreenHeight
        {
            get { return game.GraphicsDevice.PresentationParameters.BackBufferHeight; }
        }

        static public Rectangle ScreenRectangle
        {
            get{ return new Rectangle(0, 0, ScreenWidth, ScreenHeight);}
        }

        static public Rectangle ScreenLeftHalf
        {
            get {return new Rectangle(0, 0, (int)(ScreenWidth/2), ScreenHeight);}
        }

        static public Rectangle ScreenRightHalf
        {
            get {return new Rectangle((int)(ScreenWidth/2), 0, (int)(ScreenWidth/2), ScreenHeight);}
        }




    }
}