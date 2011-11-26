﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Sprites
{
    internal class AutomatedSprite : Sprite
    {
        // Sprite is automated. Direction is same as speed

        public AutomatedSprite(Texture2D textureImage, Vector2 position,
                               Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
                               Vector2 speed, string collisionCueName, int scoreValue)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
                   sheetSize, speed, collisionCueName, scoreValue)
        {
        }

        public AutomatedSprite(Texture2D textureImage, Vector2 position,
                               Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
                               Vector2 speed, int millisecondsPerFrame, string collisionCueName,
                               int scoreValue)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
                   sheetSize, speed, millisecondsPerFrame, collisionCueName, scoreValue)
        {
        }

        public AutomatedSprite(Texture2D textureImage, Vector2 position,
                               Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
                               Vector2 speed, string collisionCueName, int scoreValue, float scale)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
                   sheetSize, speed, collisionCueName, scoreValue, scale)
        {
        }

        public override Vector2 direction
        {
            get { return speed; }
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            // Move sprite based on direction
            position += direction;
            base.Update(gameTime, clientBounds);
        }
    }
}