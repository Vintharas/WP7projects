using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WP7GameStateObjectOriented.Screens
{
    public class Screen
    {
        public Color BackgroundColor;
        protected GraphicsDevice Graphics { get; set; }
        protected SpriteFont Font { get; set; }
        /// <summary>
        /// Use to notify the game that it's time for a screen change
        /// </summary>
        protected EventHandler ScreenEvent { get; set; }

        /// <summary>
        /// Initialize members
        /// </summary>
        /// <param name="screenEvent"></param>
        /// <param name="font"></param>
        /// <param name="graphics"></param>
        public Screen(EventHandler screenEvent, SpriteFont font, GraphicsDevice graphics)
        {
            ScreenEvent = screenEvent;
            Font = font;
            Graphics = graphics;
        }

        /// <summary>
        /// Update any information specific to the screen
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime){}

        /// <summary>
        /// Draw any objects specific to the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch){}
    }
}