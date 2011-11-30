using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using WP7GameDriveAndDodge.Screens;

namespace WP7GameDriveAndDodge.Sprites
{
    public class Hazards
    {
        private Random random = new Random();
        private List<Sprite> roadHazards = new List<Sprite>();
        private int velocity;
        private int lastYPositionOfHazardInChain;
        private int leftLanePosition;
        private int rightLanePosition;
        private ContentManager content;
        public int HazardCount;

        public Hazards(ContentManager content, int rightLanePosition, int leftLanePosition, int velocity)
        {
            this.content = content;
            this.rightLanePosition = rightLanePosition;
            this.leftLanePosition = leftLanePosition;
            this.velocity = velocity;
            Reset();
        }

        public void Reset()
        {
            HazardCount = 0;
            PlaceHazards();
        }

        private void PlaceHazards()
        {
            roadHazards.Clear();
            for (int aNumberOfHazards = 0; aNumberOfHazards < 10; aNumberOfHazards++)
            {
                Sprite hazard = new Sprite(content, "Images/Hazard");
                int yPosition = aNumberOfHazards * -300;
                hazard.Position = new Vector2(GetLanePosition(), yPosition);
                roadHazards.Add(hazard);
                if (yPosition < lastYPositionOfHazardInChain)
                    lastYPositionOfHazardInChain = yPosition;
            }
        }

        public void Update(GameTime gameTime,
            Sprite collisionSprite,
            Sprite.CollisionDelegate collisionDelegate)
        {
            foreach (Sprite hazard in roadHazards)
            {
                if (collisionSprite.IsCollidingWith(hazard))
                {
                    collisionDelegate();
                    return;
                }
                if (hazard.Position.Y >= Screen.ScreenHeight)
                {
                    HazardCount += 1;
                    hazard.Position.Y = GetLanePosition();
                    hazard.Position.Y = lastYPositionOfHazardInChain - 300;
                }
                hazard.Position.Y += velocity;
            }
            lastYPositionOfHazardInChain += velocity;
        }

        private int GetLanePosition()
        {
            int xPosition = leftLanePosition;
            if (random.Next(0, 2) == 0)
                xPosition = rightLanePosition;
            return xPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite hazard in roadHazards)
            {
                hazard.Draw(spriteBatch);
            }
        }
    }
}