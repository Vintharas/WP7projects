using System;
using DriveAndDodge.Inputs;
using Microsoft.Devices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using WP7GameDriveAndDodge.Sprites;

namespace WP7GameDriveAndDodge.Screens
{
    public class MainGame : Screen
    {
        private Background background;
        private Road road;
        private Car car;
        private Hazards hazards;

        private int previousHazardCount;

        private const string ActionMoveLeft = "Left";
        private const string ActionMoveRight = "Right";


        public MainGame(Game game, SpriteBatch spriteBatch, ChangeScreen changeScreen) : base(game, spriteBatch, changeScreen)
        {
            isTouchIndicatorEnabled = true;
        }

        protected override void SetupInputs()
        {
            input.AddTouchSlideInput(ActionMoveLeft, Input.Direction.Left, 5.0f);
            input.AddAccelerometerInput(ActionMoveLeft, Input.Direction.Left, 0.10f);
            input.AddTouchGestureInput(ActionMoveLeft, GestureType.Tap, ScreenRightHalf);
            
            input.AddTouchSlideInput(ActionMoveRight, Input.Direction.Right, 5.0f);
            input.AddTouchGestureInput(ActionMoveRight, GestureType.Tap, ScreenLeftHalf);
            input.AddAccelerometerInput(ActionMoveRight, Input.Direction.Right, 0.10f);

        }

        protected override void LoadScreenContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            background = new Background(content);
            road = new Road(content);
            car = new Car(new Vector2(120, 599),
                content,
                soundEffects, 
                input, ActionMoveLeft, ActionMoveRight, 120, 280);
            hazards = new Hazards(content, 5, 120, 280);
        }

        public override void Activate()
        {
            car.Reset();
            hazards.Reset();
            road.Reset();
        }

        protected override void UpdateScreen(GameTime gameTime, DisplayOrientation screenOrientation)
        {
            road.Update(gameTime);
            car.Update(gameTime);
            hazards.Update(gameTime, car, HandleCarCollision);
            if (previousHazardCount != hazards.HazardCount)
            {
                soundEffects.PlaySound("SoundEffects/HazardPass");
                previousHazardCount = hazards.HazardCount;
            }
        }

        private void HandleCarCollision()
        {
            soundEffects.PlaySound("SoundEffects/Crash");

            VibrateController vibrate = VibrateController.Default;
            vibrate.Start(TimeSpan.FromSeconds(1));

            changeScreenDelegate(ScreenState.GameOver);
        }

        protected override void DrawScreen(SpriteBatch spriteBatch, DisplayOrientation screenOrientation)
        {
            background.Draw(spriteBatch);
            road.Draw(spriteBatch);
            car.Draw(spriteBatch);
            hazards.Draw(spriteBatch);
        }
    }
}