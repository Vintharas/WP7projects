using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WP7GameStateObjectOriented.Screens
{
    public class SplashScreen : Screen
    {
        public SplashScreen(EventHandler screenEvent, SpriteFont font, GraphicsDevice graphics) : base(screenEvent, font, graphics)
        {
            BackgroundColor = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
            // screen-specific update code goes here
            if (gameTime.TotalGameTime.Seconds > 4)
                ScreenEvent.Invoke(this, new EventArgs());
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Graphics.Clear(BackgroundColor);
            // screen-specific draw goes here
            spriteBatch.DrawString(Font, "SPLASH", new Vector2(50f, 150f), Color.Tomato);
            spriteBatch.DrawString(Font, "Wait 4 seconds", new Vector2(50f, 450f), Color.Tomato);
            base.Draw(spriteBatch);
        }
    }
}