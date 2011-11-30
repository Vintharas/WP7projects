using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace WP7GameDriveAndDodge.Sprites
{
    public class Sprite
    {
        //TODO: Implemente ON/OFF collision areas

        public Vector2 Position;
        public delegate void CollisionDelegate();
        protected Texture2D texture;
        protected Color color = Color.White;

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle((int)Position.X,
                                     (int)Position.Y,
                                     Width, Height);
            }
        }
        public int Height { get { return texture.Height; } }
        public int Width { get { return texture.Width; } }


        public Sprite(ContentManager content, string assetName)
        {
            texture = content.Load<Texture2D>(assetName);
        }

        public void Update(GameTime gameTime)
        {
            UpdateSprite(gameTime);
        }
        protected virtual void UpdateSprite(GameTime gameTime){}

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, Position, color);
            DrawSprite(batch);
        }
        protected virtual void DrawSprite(SpriteBatch batch){}

        public bool IsCollidingWith(Sprite spriteToCheck)
        {
            return CollisionRectangle.Intersects(spriteToCheck.CollisionRectangle);
        }



    }
}