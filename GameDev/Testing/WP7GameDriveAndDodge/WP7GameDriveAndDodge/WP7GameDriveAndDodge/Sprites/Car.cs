using DriveAndDodge.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using WP7GameDriveAndDodge.Sounds;

namespace WP7GameDriveAndDodge.Sprites
{
    public class Car : Sprite
    {
        private SoundEffects soundEffects;
        private string moveLeftAction;
        private string moveRightAction;
        private int leftLanePosition;
        private int rightLanePosition;
        private Vector2 startPosition;
        private GameInput input;


        public Car(Vector2 startPosition,
                   ContentManager content,
                   SoundEffects soundEffects,
                   GameInput input,
                   string moveLeftInputAction,
                   string moveRightInputAction,
                   int leftLanePosition,
                   int rightLanePosition) : base(content, "Images/Car")
        {
            this.soundEffects = soundEffects;
            this.input = input;
            this.startPosition = startPosition;
            this.moveLeftAction = moveLeftInputAction;
            this.moveRightAction = moveRightInputAction;
            this.leftLanePosition = leftLanePosition;
            this.rightLanePosition = rightLanePosition;
        }

        public void Reset()
        {
            Position = startPosition;
        }

        protected override void UpdateSprite(GameTime gameTime)
        {
            if (input.IsPressed(moveLeftAction))
                ChangeLanes(leftLanePosition);
            else if (input.IsPressed(moveRightAction))
                ChangeLanes(rightLanePosition);
        }

        private void ChangeLanes(int lanePosition)
        {
            soundEffects.PlaySound("SoundEffects/ChangeLane");
            Position.X = lanePosition;
        }

    }
}