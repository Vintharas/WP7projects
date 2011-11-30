using System;
using GoldenAxe.Common;
using GoldenAxe.Fonts;
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
            ScreenGameComponents.Add(new NonAnimatedSprite(game, "Images/Background/titleLetters", DrawablePosition.TopCentered, spriteBatch));
            FontDescription startFontDescription = new FontDescription(
                        "Fonts/TitleFont", 
                        "Start!", 
                        Color.Red, 
                        new Vector2(380, 410));
            ScreenGameComponents.Add(new Font(game, spriteBatch, 
                startFontDescription));
        }

        public override void Draw(GameTime gameTime)
        { 
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
       
    }
}