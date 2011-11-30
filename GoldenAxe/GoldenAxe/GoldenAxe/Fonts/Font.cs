using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Fonts
{
    public class Font : DrawableGameComponent
    {
        private string assetName;
        private Vector2 position;
        private SpriteBatch spriteBatch;
        private string text;
        private Color color;

        private SpriteFont spriteFont;

        public Font(Game game, 
                    SpriteBatch spriteBatch, 
                    string assetName,
                    string text,
                    Color color,
                    Vector2 position) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.assetName = assetName;
            this.text = text;
            this.color = color;
            this.position = position;
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, text, position, color);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}