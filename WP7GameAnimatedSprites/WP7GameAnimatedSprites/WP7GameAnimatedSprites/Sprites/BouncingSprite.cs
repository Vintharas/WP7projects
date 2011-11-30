using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WP7GameAnimatedSprites.Sprites
{
    public class BouncingSprite : AutomatedSprite
    {
        public BouncingSprite(Texture2D textureImage, 
            Vector2 position, 
            Point frameSize, 
            Point currentFrame, 
            Point sheetSize, 
            int collisionOffset, 
            Vector2 speed,
            string collisionCueName) : 
            base(textureImage, position, frameSize, currentFrame, sheetSize, collisionOffset, speed, collisionCueName)
        {
        }

        public BouncingSprite(Texture2D textureImage, 
            Vector2 position, 
            Point frameSize, 
            Point currentFrame, 
            Point sheetSize, 
            int collisionOffset, 
            Vector2 speed, 
            string collisionCueName,
            int defaultMillisecondsPerFrame) : base(textureImage, position, frameSize, currentFrame, sheetSize, collisionOffset, speed, collisionCueName, defaultMillisecondsPerFrame)
        {
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            // Check for collisions against boundaries of the screen
            if (position.X < 0)
            {
                position.X = 0;
                speed.X *= -1;
            }
            if (position.X + frameSize.X > clientBounds.Width)
            {
                position.X = clientBounds.Width - frameSize.X;
                speed.X *= -1;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
                speed.Y *= -1;
            }
            if (position.Y + frameSize.Y > clientBounds.Height)
            {
                position.Y = clientBounds.Height - frameSize.Y;
                speed.Y *= -1;
            }
            base.Update(gameTime, clientBounds);
        }
    }
}