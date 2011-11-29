﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Sprites
{
    public abstract class Sprite
    {
        // Stuff needed to draw the sprite
        private const int defaultMillisecondsPerFrame = 16;
        private readonly int collisionOffset;
        private readonly int millisecondsPerFrame;
        private readonly Vector2 originalSpeed;
        private readonly Texture2D textureImage;
        private Point currentFrame;
        protected Point frameSize;
        protected float originalScale = 1;

        // Speed stuff
        protected Vector2 position;
        protected float scale = 1;
        private Point sheetSize;
        protected Vector2 speed;
        private int timeSinceLastFrame;

        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize,
                      int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
                      string collisionCueName, int scoreValue)
            : this(textureImage, position, frameSize, collisionOffset, currentFrame,
                   sheetSize, speed, defaultMillisecondsPerFrame, collisionCueName,
                   scoreValue)
        {
        }

        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize,
                      int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
                      int millisecondsPerFrame, string collisionCueName, int scoreValue)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.frameSize = frameSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.speed = speed;
            originalSpeed = speed;
            this.collisionCueName = collisionCueName;
            this.millisecondsPerFrame = millisecondsPerFrame;
            this.scoreValue = scoreValue;
        }

        public Sprite(Texture2D textureImage, Vector2 position, Point frameSize,
                      int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed,
                      string collisionCueName, int scoreValue, float scale)
            : this(textureImage, position, frameSize, collisionOffset, currentFrame,
                   sheetSize, speed, defaultMillisecondsPerFrame, collisionCueName,
                   scoreValue)
        {
            this.scale = scale;
        }

        // Sound stuff
        public string collisionCueName { get; private set; }

        // Abstract definition of direction property
        public abstract Vector2 direction { get; }

        // Get current position of the sprite
        public Vector2 GetPosition
        {
            get { return position; }
        }


        // Get/set score
        public int scoreValue { get; protected set; }

        // Gets the collision rect based on position, framesize and collision offset
        public Rectangle collisionRect
        {
            get
            {
                return new Rectangle(
                    (int) (position.X + (collisionOffset*scale)),
                    (int) (position.Y + (collisionOffset*scale)),
                    (int) ((frameSize.X - (collisionOffset*2))*scale),
                    (int) ((frameSize.Y - (collisionOffset*2))*scale));
            }
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            // Update frame if time to do so based on framerate
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                // Increment to next frame
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
            spriteBatch.Draw(textureImage,
                             position,
                             new Rectangle(currentFrame.X*frameSize.X,
                                           currentFrame.Y*frameSize.Y,
                                           frameSize.X, frameSize.Y),
                             Color.White, 0, Vector2.Zero,
                             scale, SpriteEffects.None, 0);
        }



        // Detect if this sprite is off the screen and irrelevant
        public bool IsOutOfBounds(Rectangle clientRect)
        {
            if (position.X < -frameSize.X ||
                position.X > clientRect.Width ||
                position.Y < -frameSize.Y ||
                position.Y > clientRect.Height)
            {
                return true;
            }

            return false;
        }

        public void ModifyScale(float modifier)
        {
            scale *= modifier;
        }

        public void ResetScale()
        {
            scale = originalScale;
        }

        public void ModifySpeed(float modifier)
        {
            speed *= modifier;
        }

        public void ResetSpeed()
        {
            speed = originalSpeed;
        }
    }
}