using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WP7GameDriveAndDodge.Sprites
{
    public class Road : Sprite
    {
        private int velocity;

        public Road(ContentManager content) : base(content, "Images/Road")
        {
            Reset();
        }

        public void Reset()
        {
            velocity = 5;
            Position.Y = 0;
        }

        protected override void UpdateSprite(Microsoft.Xna.Framework.GameTime gameTime)
        {
            Position.Y -= velocity;
        }

        protected override void DrawSprite(Microsoft.Xna.Framework.Graphics.SpriteBatch batch)
        {
            batch.End();

            batch.Begin(SpriteSortMode.Immediate,
                        null, SamplerState.LinearWrap, null, null);
            batch.Draw(texture, Vector2.Zero,
                       new Rectangle(0, (int) Position.Y, Width, Height), Color.White);
            batch.End();
            batch.Begin();
        }
    }
}