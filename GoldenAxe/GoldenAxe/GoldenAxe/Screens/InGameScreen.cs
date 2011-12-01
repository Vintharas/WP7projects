using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Screens
{
    public class InGameScreen : Screen
    {
        public InGameScreen(Game game, SpriteBatch spriteBatch, Action<ScreenManager.GameScreen> navigateToScreen) : base(game, spriteBatch, navigateToScreen)
        {
        }
    }
}