using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Screens
{
    public class ScreenManager : DrawableGameComponent
    {

        public enum GameScreen
        {
            Splash,
            Start,
            InGame
        }

        private Game game;
        private SpriteBatch spriteBatch;
        private Dictionary<GameScreen, Screen> PersistentGameScreens;
        private Screen activeScreen;

        public ScreenManager(Game game) : base(game)
        {
            this.game = game;
            PersistentGameScreens = new Dictionary<GameScreen, Screen>();
        }

        public override void Initialize()
        {
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            activeScreen = new SplashScreen(game, spriteBatch, NavigateToScreen);
            activeScreen.Initialize();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            activeScreen.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            activeScreen.Draw(gameTime);
            base.Draw(gameTime);
        }

        public void NavigateToScreen(GameScreen screen)
        {
            switch (screen)
            {
                case GameScreen.Start:
                    if (PersistentGameScreens.ContainsKey(GameScreen.Start))
                        activeScreen = PersistentGameScreens[GameScreen.Start];
                    else
                    {
                        activeScreen = new StartScreen(game, spriteBatch, NavigateToScreen);
                        activeScreen.Initialize();
                    }
                    break;
            }
        }

       

    }
}