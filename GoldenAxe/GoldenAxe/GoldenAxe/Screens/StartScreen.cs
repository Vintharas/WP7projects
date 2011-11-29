using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Screens
{
    public class StartScreen : Screen
    {
        public StartScreen(Game game, SpriteBatch spriteBatch, Action<ScreenManager.GameScreen> navigateToScreen)
            : base(game, spriteBatch, navigateToScreen)
        {
        }
    }
}