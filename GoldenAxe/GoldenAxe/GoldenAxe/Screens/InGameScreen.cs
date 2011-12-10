using System;
using GoldenAxe.GameObjects.Player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Screens
{
    public class InGameScreen : Screen
    {
        public InGameScreen(Game game, SpriteBatch spriteBatch, Action<ScreenManager.GameScreen> navigateToScreen) : base(game, spriteBatch, navigateToScreen)
        {
            ScreenGameComponents.Add(new Barbarian(game, new Vector2(50, 240), spriteBatch));
        }


    }
}