using System;
using GoldenAxe.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Screens
{
    public class StartScreen : Screen
    {
        public StartScreen(Game game, SpriteBatch spriteBatch, Action<ScreenManager.GameScreen> navigateToScreen)
            : base(game, spriteBatch, navigateToScreen)
        {
            ScreenGameComponents.Add(new NonAnimatedSprite(game, "Images/Background/titleLetters", SpritePosition.TopCentered, spriteBatch));
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
       
    }
}