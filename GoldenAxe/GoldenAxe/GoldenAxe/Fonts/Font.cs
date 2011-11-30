using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Fonts
{
    public class Font : DrawableGameComponent
    {
        
        private SpriteBatch spriteBatch;
        private FontDescription fontDescription;

        private SpriteFont spriteFont;

        public Font(Game game, 
                    SpriteBatch spriteBatch, 
                    FontDescription fontDescription) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.fontDescription = fontDescription;
        }

        protected override void LoadContent()
        {
            spriteFont = Game.Content.Load<SpriteFont>(fontDescription.AssetName);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(spriteFont, 
                fontDescription.Text, 
                fontDescription.Position, 
                fontDescription.Color);
            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}