using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace WP7GameDriveAndDodge.Screens
{

    public enum ScreenState
    {
        Title,
        MainGame,
        GameOver,
        InGameMenu,
        PreviousScreen,
        Exit
    }

    ///<summary>
    /// The ScreenStateSwitchboard class is the heart of controlling the game’s screen state. It helps 
    /// switch between the various screens and ensures that the Update() and Draw() methods are being 
    /// called on the currently active screen.
    /// </summary>T
    public class ScreenStateSwitchboard
    {
        private static Game game;
        private static SpriteBatch spriteBatch;
        private static Screen previousScreen;
        private static Screen currentScreen;
        static Dictionary<ScreenState, Screen> screens = new Dictionary<ScreenState,Screen>();

        public ScreenStateSwitchboard(Game game, SpriteBatch spriteBatch)
        {
            ScreenStateSwitchboard.game = game;
            ScreenStateSwitchboard.spriteBatch = spriteBatch;
            ChangeScreen(ScreenState.Title);
        }

        private void ChangeScreen(ScreenState screenState)
        {
            switch (screenState)
            {
                case ScreenState.Title:
                    {
                        ChangeScreen(screenState, CreateTitleScreen);
                        break;
                    }
                case ScreenState.MainGame:
                    {
                        ChangeScreen(screenState, CreateMainGameScreen);
                        break;
                    }
                case ScreenState.GameOver:
                    {
                        ChangeScreen(screenState, CreateGameOverScreen);
                        break;
                    }
                case ScreenState.InGameMenu:
                    {
                        ChangeScreen(screenState, CreateInGameMenuScreen);
                        break;
                    }
                case ScreenState.PreviousScreen:
                    {
                        currentScreen = previousScreen;
                        currentScreen.Activate();
                        break;
                    }
                case ScreenState.Exit:
                    {
                        game.Exit();
                        break;
                    }
            }
        }

        private void ChangeScreen(ScreenState screenState, Func<Screen> createScreen)
        {
            previousScreen = currentScreen;
            if (!screens.ContainsKey(screenState))
            {
                screens.Add(screenState, createScreen());
                screens[screenState].LoadContent();
            }
            currentScreen = screens[screenState];
            currentScreen.Activate();
        }

        private Screen CreateTitleScreen()
        {
            return new Title(game, spriteBatch, ChangeScreen);
        }

        private Screen CreateMainGameScreen()
        {
            return new MainGame(game, spriteBatch, ChangeScreen);
        }

        private Screen CreateInGameMenuScreen()
        {
            return new InGameMenu(game, spriteBatch, ChangeScreen);
        }

        private Screen CreateGameOverScreen()
        {
            return new GameOver(game, spriteBatch, ChangeScreen);
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void Draw()
        {
            currentScreen.Draw();
        }
    }
}