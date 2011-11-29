using System;
using GoldenAxe.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Screens
{
    public class SplashScreen : Screen
    {

        public SplashScreen(Game game, SpriteBatch spriteBatch, Action<ScreenManager.GameScreen> navigateToScreen) : base(game, spriteBatch, navigateToScreen)
        {
            drawableComponents.Add(new NonAnimatedSprite(game, "Images/Background/vintharaslogo", SpritePosition.Centered, spriteBatch));
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
        
    }
}