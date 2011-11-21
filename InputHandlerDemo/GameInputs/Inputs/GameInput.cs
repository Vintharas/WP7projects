using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace GameInputs.Inputs
{
    public class GameInput
    {
        // dictionary that will store all the input types you use in a game
        private Dictionary<string, Input> Inputs = new Dictionary<string,Input>();

        private IEnumerable<PlayerIndex> allPlayers = new List<PlayerIndex>
                                                          {
                                                              PlayerIndex.One,
                                                              PlayerIndex.Two,
                                                              PlayerIndex.Three,
                                                              PlayerIndex.Four
                                                          };
        /// <summary>
        /// Get the input for any given action, or create a new one in case
        /// the action is a new one
        /// </summary>
        /// <param name="theAction"></param>
        /// <returns></returns>
        public Input GetInput(string theAction)
        {
            // Add the actoin if it doesn't already exist
            if(!Inputs.ContainsKey(theAction))
                Inputs.Add(theAction, new Input());
            return Inputs[theAction];
        }

        public void BeginUpdate()
        {
            Input.BeginUpdate();
        }

        public void EndUpdate()
        {
            Input.EndUpdate();
        }

        public bool IsConnected(PlayerIndex player)
        {
            // if there never was a gamepad connected, just say the
            // gamepad is still connected;
            if (!Input.GamepadConnectionState[player])
                return true;
            return Input.IsConnected(player);
        }

        /// <summary>
        /// Check whether the inputs associated to an action were
        /// pressed
        /// </summary>
        /// <param name="theAction"></param>
        /// <returns></returns>
        public bool IsPressed(string theAction)
        {
            return Inputs.ContainsKey(theAction) 
                   && Inputs[theAction].IsPressed(PlayerIndex.One);
        }

        /// <summary>
        /// Check whether the inputs associated to an action were
        /// pressed
        /// </summary>
        /// <param name="theAction"></param>
        /// <param name="thePlayer"></param>
        /// <returns></returns>
        public bool IsPressed(string theAction, PlayerIndex thePlayer)
        {
            return Inputs.ContainsKey(theAction)
                   && Inputs[theAction].IsPressed(thePlayer);
        }

        /// <summary>
        /// Check whether the inputs associated to an action were
        /// pressed
        /// </summary>
        /// <param name="theAction"></param>
        /// <param name="thePlayer"></param>
        /// <returns></returns>
        public bool IsPressed(string theAction, PlayerIndex? thePlayer)
        {
            if (thePlayer == null)
            {
                PlayerIndex theReturnedControllingPlayer;
                return IsPressed(theAction, thePlayer, out theReturnedControllingPlayer);
            }
            return IsPressed(theAction, (PlayerIndex) thePlayer);
        }

        /// <summary>
        /// Check whether the inputs associated to an action were
        /// pressed
        /// </summary>
        /// <param name="theAction"></param>
        /// <param name="thePlayer"></param>
        /// <returns></returns>
        public bool IsPressed(string theAction, PlayerIndex? thePlayer,
            out PlayerIndex theControllingPlayer)
        {
            if (!Inputs.ContainsKey(theAction))
            {
                theControllingPlayer = PlayerIndex.One;
                return false;
            }
            if (thePlayer == null)
            {
                foreach(PlayerIndex player in allPlayers)
                {
                    if (IsPressed(theAction, player))
                    {
                        theControllingPlayer = player;
                        return true;
                    }
                }
                theControllingPlayer = PlayerIndex.One;
                return false;
            }
            theControllingPlayer = (PlayerIndex) thePlayer;
            return IsPressed(theAction, (PlayerIndex) thePlayer);
        }

        /// <summary>
        /// Add a new mapping between an action and a gamepad input
        /// </summary>
        /// <param name="theAction"></param>
        /// <param name="theButton"></param>
        /// <param name="isReleasedPreviously"></param>
        public void AddGamePadInput(string theAction,
                            Buttons theButton,
                            bool isReleasedPreviously)
        {
            GetInput(theAction).AddGamepadInput(theButton, isReleasedPreviously);
        }

        /// <summary>
        /// Add a new mapping between an action and a touch tap input
        /// </summary>
        /// <param name="theAction"></param>
        /// <param name="theTouchArea"></param>
        /// <param name="isReleasedPreviously"></param>
        public void AddTouchTapInput(string theAction,
                                     Rectangle theTouchArea,
                                     bool isReleasedPreviously)
        {
            GetInput(theAction).AddTouchTapInput(theTouchArea, isReleasedPreviously);
        }

        /// <summary>
        /// Add a new mapping between an action and a touch slide input
        /// </summary>
        /// <param name="theAction"></param>
        /// <param name="theDirection"></param>
        /// <param name="slideDistance"></param>
        public void AddTouchSlideInput(string theAction, Direction theDirection,
                                       float slideDistance)
        {
            GetInput(theAction).AddTouchSlideInput(theDirection, slideDistance);
        }

        /// <summary>
        /// Add a new mapping between an action and a keyboard input
        /// </summary>
        /// <param name="theAction"></param>
        /// <param name="theKey"></param>
        /// <param name="isReleasedPreviously"></param>
        public void AddKeyboardInput(string theAction, Keys theKey, bool isReleasedPreviously)
        {
            GetInput(theAction).AddKeyboardInput(theKey, isReleasedPreviously);
        }

        /// <summary>
        /// Add a new mapping between an action and a gesture input
        /// </summary>
        /// <param name="theAction"></param>
        /// <param name="theGesture"></param>
        /// <param name="theRectangle"></param>
        public void AddTouchGestureInput(string theAction, GestureType theGesture,
                                         Rectangle theRectangle)
        {
            GetInput(theAction).AddTouchGestureInput(theGesture, theRectangle);
        }

        /// <summary>
        /// Add a new mapping between an action and an accelerometer input
        /// </summary>
        /// <param name="theAction"></param>
        /// <param name="theDirection"></param>
        /// <param name="tiltThreshold"></param>
        public void AddAccelerometerInput(string theAction, Direction theDirection,
                                          float tiltThreshold)
        {
            GetInput(theAction).AddAccelerometerInput(theDirection, tiltThreshold);
        }

        public Vector2 CurrentGesturePosition(string theAction)
        {
            return GetInput(theAction).CurrentGesturePosition();
        }

        public Vector2 CurrentGestureDelta(string theAction)
        {
            return GetInput(theAction).CurrentGestureDelta();
        }

        public Vector2 CurrentGesturePosition2(string theAction)
        {
            return GetInput(theAction).CurrentGesturePosition2();
        }

        public Vector2 CurrentGestureDelta2(string theAction)
        {
            return GetInput(theAction).CurrentGestureDelta2();
        }

        public Point CurrentTouchPoint(string theAction)
        {
            Vector2? currentPosition = GetInput(theAction).CurrentTouchPosition();
            if (currentPosition == null)
                return new Point(-1, -1);
            return new Point((int)currentPosition.Value.X,
                             (int)currentPosition.Value.Y);
        }

        public Vector2 CurrentTouchPosition(string theAction)
        {
            Vector2? currentTouchPosition = GetInput(theAction).CurrentTouchPosition();
            if (currentTouchPosition == null)
                return new Vector2(-1, -1);
            return (Vector2) currentTouchPosition;
        }

        /// <summary>
        /// Get the scale change of a pinch gesture
        /// </summary>
        /// <param name="theAction"></param>
        /// <returns></returns>
        public float CurrentGestureScaleChange(string theAction)
        {
            // Scaling is dependent on the Pinch gesture. If no input
            // has been set up for the pinch then just return 0 indicating
            // that no scale change has occurred.
            if (!GetInput(theAction).PinchGestureAvailable)
                return 0;
            // Get the current and previous locations of the two fingers
            Vector2 currentPositionFingerOne = CurrentGesturePosition(theAction);
            Vector2 previousPositionFingerOne = CurrentGesturePosition(theAction) - CurrentGestureDelta(theAction);
            Vector2 currentPositionFingerTwo = CurrentGesturePosition2(theAction);
            Vector2 prevoiusPositionFingerTwo = CurrentGesturePosition2(theAction) - CurrentGestureDelta2(theAction);
            // Figure out distance between the current and previous locations
            float currentDistance = Vector2.Distance(currentPositionFingerOne,
                                                     currentPositionFingerTwo);
            float previousDistance = Vector2.Distance(previousPositionFingerOne,
                                                      prevoiusPositionFingerTwo);
            // Calculate the difference between the two and use that to
            // alter the scale
            float scaleChange = (currentDistance - previousDistance)*01f;
            return scaleChange;
        }

        /// <summary>
        /// Get the current accelerometer reading for a given action
        /// </summary>
        /// <param name="theAction"></param>
        /// <returns></returns>
        public Vector3 CurrentAccelerometerReading(string theAction)
        {
            return GetInput(theAction).CurrentAccelerometerReading;
        }

    }
}