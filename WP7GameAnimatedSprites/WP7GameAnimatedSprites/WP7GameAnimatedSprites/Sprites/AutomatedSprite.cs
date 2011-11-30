using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WP7GameAnimatedSprites.Sprites
{
    public class AutomatedSprite :Sprite
    {
        public override Vector2 Direction
        {
            get { return speed; }
        }

        public AutomatedSprite(Texture2D textureImage, Vector2 position, Point frameSize, Point currentFrame, Point sheetSize, int collisionOffset, Vector2 speed, string collisionCueName) : base(textureImage, position, frameSize, currentFrame, sheetSize, collisionOffset, speed, collisionCueName)
        {
        }

        public AutomatedSprite(Texture2D textureImage, Vector2 position, Point frameSize, Point currentFrame, Point sheetSize, int collisionOffset, Vector2 speed, string collisionCueName, int defaultMillisecondsPerFrame) : base(textureImage, position, frameSize, currentFrame, sheetSize, collisionOffset, speed, collisionCueName, defaultMillisecondsPerFrame)
        {
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            position += Direction;
            base.Update(gameTime, clientBounds);
        }
    }
}