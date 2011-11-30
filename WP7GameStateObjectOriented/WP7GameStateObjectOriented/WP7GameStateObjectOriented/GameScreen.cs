using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WP7GameStateObjectOriented.Screens;

namespace WP7GameStateObjectOriented
{
    public class GameScreen : Screen
    {
        public GameScreen(EventHandler screenEvent, SpriteFont font, GraphicsDevice graphics) : base(screenEvent, font, graphics)
        {
            BackgroundColor = Color.Black;
        }

        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                ScreenEvent.Invoke(this, new EventArgs());
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Graphics.Clear(BackgroundColor);
            // screen-specific draw goes here
            spriteBatch.DrawString(Font, "MAIN", new Vector2(50f, 150f), Color.Yellow);
            spriteBatch.DrawString(Font, "Press the Back button", new Vector2(50f, 450f), Color.Yellow);
            base.Draw(spriteBatch);
        }
    }
}