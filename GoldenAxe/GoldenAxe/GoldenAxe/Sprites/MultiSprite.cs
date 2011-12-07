using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Sprites
{
    /// <summary>
    /// Class that represents a multisprite, a sprite that can have different states and draw different animations
    /// depending on the state
    /// </summary>
    public abstract class MultiSprite
    {
        public Dictionary<string, SpriteSheet> States;
        public string CurrentState;
        public SpriteSheet CurrentSheet { get { return States[CurrentState]; } }

        private Texture2D TextureImage { get { return CurrentSheet.textureImage; } }
        private Point CurrentFrame { get { return CurrentSheet.CurrentFrame; }}
        private Point FrameSize { get { return CurrentSheet.FrameSize; } }

        private const int DEFAULT_MILLISECONDS_PER_FRAME = 16;
        private readonly int millisecondsPerFrame;
        private int timeSinceLastFrame;

        // Gets the collision rect based on position, framesize and collision offset
        public Rectangle collisionRect
        {
            get
            {
                return new Rectangle(
                    (int)(position.X + (collisionOffset)),
                    (int)(position.Y + (collisionOffset)),
                    (int)((FrameSize.X - (collisionOffset * 2))),
                    (int)((FrameSize.Y - (collisionOffset * 2))));
            }
        }
        private readonly int collisionOffset;
        // Get current position of the sprite
        public Vector2 GetPosition
        {
            get { return position; }
        }
        protected Vector2 position;

        /// <summary>
        /// Initialize members. No offset, default milliseconds per frame
        /// </summary>
        /// <param name="position"></param>
        public MultiSprite(Vector2 position) : this(position, 0, DEFAULT_MILLISECONDS_PER_FRAME){}

        /// <summary>
        /// Initialize members. Default milliseconds per frame
        /// </summary>
        public MultiSprite(Vector2 position, int collisionOffset) : this(position, collisionOffset, DEFAULT_MILLISECONDS_PER_FRAME){}

        /// <summary>
        /// Initialize members
        /// </summary>
        /// <param name="position"></param>
        /// <param name="collisionOffset"></param>
        /// <param name="millisecondsPerFrame"></param>
        public MultiSprite(Vector2 position, int collisionOffset, int millisecondsPerFrame)
        {
            this.position = position;
            this.collisionOffset = collisionOffset;
            this.millisecondsPerFrame = millisecondsPerFrame;
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            // Update frame if time to do so based on framerate
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                // Increment to next frame
                timeSinceLastFrame = 0;
                CurrentSheet.NextFrame();
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureImage,
                             position,
                             new Rectangle(CurrentFrame.X*FrameSize.X,
                                           CurrentFrame.Y*FrameSize.Y,
                                           FrameSize.X, FrameSize.Y),
                             Color.White, 0, Vector2.Zero,
                             1f, SpriteEffects.None, 0);
        }



        // Detect if this sprite is off the screen and irrelevant
        public bool IsOutOfBounds(Rectangle clientRect)
        {
            if (position.X < -FrameSize.X ||
                position.X > clientRect.Width ||
                position.Y < -FrameSize.Y ||
                position.Y > clientRect.Height)
            {
                return true;
            }

            return false;
        }
         
    }
}