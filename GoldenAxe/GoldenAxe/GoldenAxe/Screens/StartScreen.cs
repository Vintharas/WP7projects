using System;
using GoldenAxe.Common;
using GoldenAxe.Controls;
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
            // Font for the start button
            FontDescription startFontDescription = new FontDescription(
                        "Fonts/TitleFont", 
                        "Start!", 
                        Color.Red, 
                        Vector2.Zero);
            Button startButton = new Button(game, spriteBatch,
                                            new ButtonDescription(startFontDescription, DrawablePosition.BottomCentered,
                                                                  new Vector2(200, 100)));
            startButton.ButtonClicked = StartButtonWasClicked;
            ScreenGameComponents.Add(startButton);
        }

        /// <summary>
        /// Handle the click event of the start button
        /// </summary>
        private void StartButtonWasClicked()
        {
            NavigateToScreen(ScreenManager.GameScreen.InGame);
        }

        public override void Draw(GameTime gameTime)
        { 
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
       
    }
}