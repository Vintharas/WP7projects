using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace WP7GameStateObjectOriented.Screens
{
    public class TitleScreen : Screen 
    {
        public TitleScreen(EventHandler screenEvent, SpriteFont font, GraphicsDevice graphics) : base(screenEvent, font, graphics)
        {
            BackgroundColor = Color.Green;
        }

        public override void Update(GameTime gameTime)
        {
            TouchCollection currentTouchState = TouchPanel.GetState();
            if (currentTouchState.Count > 0)
                ScreenEvent.Invoke(this, new EventArgs());
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Graphics.Clear(BackgroundColor);

            // screen-specific draw goes here
            spriteBatch.DrawString(Font, "TITLE", new Vector2(50f, 150f), Color.White);
            spriteBatch.DrawString(Font, "Touch me", new Vector2(50f, 450f), Color.White);
            base.Draw(spriteBatch);
        }
    }
}