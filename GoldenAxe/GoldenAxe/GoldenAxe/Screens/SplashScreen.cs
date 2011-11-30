using System;
using GoldenAxe.Common;
using GoldenAxe.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Screens
{
    public class SplashScreen : Screen
    {
        private double screenDuration = 4000;
        private double totalEllapsedTime = 0;

        public SplashScreen(Game game, SpriteBatch spriteBatch, Action<ScreenManager.GameScreen> navigateToScreen) : base(game, spriteBatch, navigateToScreen)
        {
            ScreenGameComponents.Add(new NonAnimatedSprite(game, "Images/Background/vintharaslogo", DrawablePosition.Centered, spriteBatch));
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        /// <summary>
        /// Update screen status
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            totalEllapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (totalEllapsedTime >= screenDuration)
                NavigateToScreen(ScreenManager.GameScreen.Start);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw screen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
        
    }
}