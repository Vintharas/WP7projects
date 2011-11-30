using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WP7GameStateObjectOriented.Screens
{
    public class NagScreen : Screen 
    {
        private decimal nagStartTime = 0;

        public NagScreen(EventHandler screenEvent, SpriteFont font, GraphicsDevice graphics) : base(screenEvent, font, graphics)
        {
            BackgroundColor = Color.Pink;
        }

        public override void Update(GameTime gameTime)
        {
            if (nagStartTime == 0)
                nagStartTime = gameTime.TotalGameTime.Seconds;
            if (gameTime.TotalGameTime.Seconds - nagStartTime > 4)
                ScreenEvent.Invoke(this, new EventArgs());
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Graphics.Clear(BackgroundColor);
            // screen-specific draw goes here
            spriteBatch.DrawString(Font, "NAG", new Vector2(50f, 150f), Color.Black);
            spriteBatch.DrawString(Font, "Buy me!", new Vector2(50f, 450f), Color.Black);
            base.Draw(spriteBatch);
        }
    }
}