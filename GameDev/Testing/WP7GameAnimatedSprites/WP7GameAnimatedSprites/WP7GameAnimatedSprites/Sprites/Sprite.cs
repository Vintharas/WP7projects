using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WP7GameAnimatedSprites.Sprites
{
    public abstract class Sprite
    {

        // Animation variables
        private Texture2D textureImage;
        protected Point frameSize;
        private Point currentFrame;
        private Point sheetSize;
        // Collision variables
        public Rectangle CollisionRect
        {
            get
            {
                return new Rectangle(
                    (int)position.X + collisionOffset,
                    (int)position.Y + collisionOffset,
                    frameSize.X - (collisionOffset*2),
                    frameSize.Y - (collisionOffset*2));
            }
        }
        private int collisionOffset;
        public string collisionCueName { get; private set; }
        // Frame rate variables
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame;
        private const int DEFAULT_MILLISECONDS_PER_FRAME = 16;
        // Positioning variables
        public abstract Vector2 Direction { get; }
        protected Vector2 speed;
        protected Vector2 position;
       

        protected Sprite(Texture2D textureImage,
            Vector2 position,
            Point frameSize,
            Point currentFrame,
            Point sheetSize,
            int collisionOffset,
            Vector2 speed,
            string collisionCueName)
            : this(textureImage, position, frameSize, currentFrame,
            sheetSize, collisionOffset, speed, collisionCueName, DEFAULT_MILLISECONDS_PER_FRAME){}

        protected Sprite(Texture2D textureImage, 
            Vector2 position, 
            Point frameSize, 
            Point currentFrame,
            Point sheetSize, 
            int collisionOffset, 
            Vector2 speed,
            string collisionCueName,
            int defaultMillisecondsPerFrame)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.frameSize = frameSize;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.collisionOffset = collisionOffset;
            this.speed = speed;
            this.collisionCueName = collisionCueName;
            this.millisecondsPerFrame = millisecondsPerFrame;
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            // perform sprite animation
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;
                ++currentFrame.X;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    ++currentFrame.Y;
                    if (currentFrame.Y >= sheetSize.Y)
                        currentFrame.Y = 0;
                }
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                textureImage,
                position,
                new Rectangle(currentFrame.X * frameSize.X,
                    currentFrame.Y * frameSize.Y,
                    frameSize.X,
                    frameSize.Y),
                    Color.White,
                    0,
                    Vector2.Zero,
                    1f,
                    SpriteEffects.None,
                    0);
        }
    }
}