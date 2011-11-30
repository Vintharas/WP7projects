using GoldenAxe.Fonts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Controls
{
    public class Button : DrawableGameComponent
    {
        private ButtonDescription buttonDescription;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;

        private FontDescription FontDescription { get { return buttonDescription.FontDescription; } }
        private Vector2 Position { get { return buttonDescription.Position; } }
        private Rectangle Area { get { return buttonDescription.Area; } }


        public Button(Game game, SpriteBatch spriteBatch, ButtonDescription buttonDescription) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.buttonDescription = buttonDescription;
        }

        
    }
}