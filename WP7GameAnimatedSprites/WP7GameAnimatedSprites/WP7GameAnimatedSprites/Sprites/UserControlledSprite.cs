using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WP7GameAnimatedSprites.Sprites
{
    public class UserControlledSprite : Sprite
    {
        public override Vector2 Direction
        {
            get
            {
                Vector2 inputDirection = Vector2.Zero;
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                    inputDirection.X -= 1;
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                    inputDirection.X += 1;
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    inputDirection.Y -= 1;
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    inputDirection.Y += 1;
                return inputDirection*speed;
            }
        }

        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, Point currentFrame, Point sheetSize, int collisionOffset, Vector2 speed) : base(textureImage, position, frameSize, currentFrame, sheetSize, collisionOffset, speed, "")
        {
        }

        public UserControlledSprite(Texture2D textureImage, Vector2 position, Point frameSize, Point currentFrame, Point sheetSize, int collisionOffset, Vector2 speed, int defaultMillisecondsPerFrame) : base(textureImage, position, frameSize, currentFrame, sheetSize, collisionOffset, speed, "", defaultMillisecondsPerFrame)
        {
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            position += Direction; 
            base.Update(gameTime, clientBounds);
        }
    }
}