using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace GameInputs.Inputs
{
    public class Input
    {
        // Gamepad input
        public static Dictionary<PlayerIndex, GamePadState> CurrentGamePadState {get { return GamepadInput.CurrentGamePadState; }}
        public static Dictionary<PlayerIndex, GamePadState> PreviousGamePadState {get { return GamepadInput.PreviousGamePadState; }}
        public static Dictionary<PlayerIndex, bool> GamepadConnectionState { get { return GamepadInput.GamepadConnectionState; } }
        private GamepadInput gamepadInput;

        // Keyboard input
        public static KeyboardState CurrentKeyboardState { get { return KeyboardInput.CurrentKeyboardState; } }
        public static KeyboardState PreviousKeyboardState { get { return KeyboardInput.PreviousKeyboardState; } }
        private KeyboardInput keyboardInput;

        // Accelerometer input
        private AccelerometerInput accelerometerInput;

        // Touch input
        public static TouchCollection CurrentTouchLocationState { get { return TouchInput.CurrentTouchLocationState; } }
        public static TouchCollection PreviousTouchLocationState { get { return TouchInput.PreviousTouchLocationState; } }
        private TouchSlideInput touchSlideInput;
        private TouchTapInput touchTapInput;

        // Phone Gestures input
        public bool PinchGestureAvailable { get { return gestureInput.PinchGestureAvailable; } }
        private GestureInput gestureInput;

        public Vector2 CurrentGesturePosition()
        {
            if (gestureInput.CurrentGestureDefinition == null)
                return Vector2.Zero;
            return gestureInput.CurrentGestureDefinition.Position;
        }
        public Vector2 CurrentGesturePosition2()
        {
            if (gestureInput.CurrentGestureDefinition == null)
                return Vector2.Zero;
            return gestureInput.CurrentGestureDefinition.Position2;
        }
        public Vector2 CurrentGestureDelta()
        {
            if (gestureInput.CurrentGestureDefinition == null)
                return Vector2.Zero;
            return gestureInput.CurrentGestureDefinition.Delta;
        }
        public Vector2 CurrentGestureDelta2()
        {
            if (gestureInput.CurrentGestureDefinition == null)
                return Vector2.Zero;
            return gestureInput.CurrentGestureDefinition.Delta2;
        }
        public Vector2? CurrentTouchPosition()
        {
            return touchTapInput.CurrentTouchPosition();
        }
        public Vector2? PreviousTouchPosition()
        {
            return touchTapInput.PreviousTouchPosition();
        }
        public Rectangle CurrentTouchRectangle
        {
            get { return touchTapInput.CurrentTouchRectangle; }
        }
        public Vector3 CurrentAccelerometerReading
        {
            get { return accelerometerInput.CurrentAccelerometerReading; }
        }

        /// <summary>
        /// Initialize current and previous GamePadState dictionaries,
        /// the GamePadConnectionState, and the Accelerometer sensor.
        /// </summary>
        public Input()
        {
            gamepadInput = new GamepadInput();
            keyboardInput = new KeyboardInput();
            accelerometerInput = new AccelerometerInput();
            touchTapInput = new TouchTapInput();
            touchSlideInput = new TouchSlideInput();
            gestureInput = new GestureInput();
        }

        /// <summary>
        /// Begin updating user input
        /// </summary>
        static public void BeginUpdate()
        {
            // update inputs
            GamepadInput.BeginUpdate();
            KeyboardInput.BeginUpdate();
            TouchInput.BeginUpdate();
            GestureInput.BeginUpdate();
        }

        /// <summary>
        /// End updating user input
        /// </summary>
        static public void EndUpdate()
        {
            GamepadInput.EndUpdate();
            KeyboardInput.EndUpdate();
            TouchInput.EndUpdate();
        }

        /// <summary>
        /// Add keyboard input
        /// </summary>
        /// <param name="theKey">Key input</param>
        /// <param name="isReleasedPreviously">Flag that indicates whether 
        /// holding down that key coutns as a single action(false) or
        /// repeats the same action until you release it (true)</param>
        public void AddKeyboardInput(Keys theKey, bool isReleasedPreviously)
        {
            keyboardInput.Add(theKey, isReleasedPreviously);
        }

        /// <summary>
        /// Add gamepad input
        /// </summary>
        /// <param name="theButton">button input</param>
        /// <param name="isReleasedPreviously">Flag that indicates whether holding
        /// down that buttonc ounts as a single action (false) or
        /// repeats the same action until you release it (true)</param>
        public void AddGamepadInput(Buttons theButton, bool isReleasedPreviously)
        {
            gamepadInput.Add(theButton, isReleasedPreviously);
        }

        /// <summary>
        /// Add touchpad input
        /// </summary>
        /// <param name="theTouchArea">Touch area input</param>
        /// <param name="isReleasedPreviously">Flat that indicates whether holding
        /// your finger against the screen after tapping it counts as a single
        /// action or repeats the same action (false) until release (true)</param>
        public void AddTouchTapInput(Rectangle theTouchArea, bool isReleasedPreviously)
        {
            touchTapInput.Add(theTouchArea, isReleasedPreviously);
        }

        /// <summary>
        /// Add touch slide input
        /// </summary>
        /// <param name="theDirection"></param>
        /// <param name="slideDistance"></param>
        public void AddTouchSlideInput(Direction theDirection, float slideDistance)
        {
            touchSlideInput.Add(theDirection, slideDistance);
        }

        /// <summary>
        /// Add touch gesture input
        /// </summary>
        /// <param name="theGesture"></param>
        /// <param name="theTouchArea"></param>
        public void AddTouchGestureInput(GestureType theGesture, Rectangle theTouchArea)
        {
            gestureInput.Add(theGesture, theTouchArea);
        }

        /// <summary>
        /// Add an accelerometer input
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="tiltThreshold"></param>
        public void AddAccelerometerInput(Direction direction, float tiltThreshold)
        {
            accelerometerInput.Add(direction, tiltThreshold);
        }

        /// <summary>
        /// Remove all accelerometer inputs
        /// </summary>
        public void RemoveAccelerometerInputs()
        {
            accelerometerInput.RemoveAccelerometerInputs();
        }

        /// <summary>
        /// Check whether a given player is connected
        /// </summary>
        /// <param name="playerIndex"></param>
        /// <returns></returns>
        static public bool IsConnected(PlayerIndex playerIndex)
        {
            return CurrentGamePadState[playerIndex].IsConnected;
        }

        /// <summary>
        /// Check whether any of the defined inputs has occurred
        /// </summary>
        /// <param name="playerIndex"></param>
        /// <returns></returns>
        public bool IsPressed(PlayerIndex playerIndex)
        {
            return IsPressed(playerIndex, null);
        }

        /// <summary>
        /// Check whether there are any inputs pressed
        /// </summary>
        /// <param name="playerIndex"></param>
        /// <param name="currentObjectLocation"></param>
        /// <returns></returns>
        public bool IsPressed(PlayerIndex playerIndex, Rectangle? currentObjectLocation)
        {
            return keyboardInput.IsPressed()
                   || gamepadInput.IsPressed(playerIndex)
                   || touchSlideInput.IsPressed()
                   || touchTapInput.IsPressed()
                   || gestureInput.IsPressed(currentObjectLocation)
                   || accelerometerInput.IsPressed();
        }
    }


}