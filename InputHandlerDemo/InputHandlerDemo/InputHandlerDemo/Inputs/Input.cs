using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework.Input.Touch;

namespace InputHandlerDemo.Inputs
{
    public class Input
    {
        // used in xbox and for wp7 back button
        static public Dictionary<PlayerIndex, GamePadState> CurrentGamePadState = new Dictionary<PlayerIndex, GamePadState>();
        static public Dictionary<PlayerIndex, GamePadState> PreviousGamePadState = new Dictionary<PlayerIndex, GamePadState>(); 
        static public Dictionary<PlayerIndex, bool> GamepadConnectionState = new Dictionary<PlayerIndex, bool>(); 
        // desktop and wp7 keyboard state
        public static KeyboardState CurrentKeyboardState;
        public static KeyboardState PreviousKeyboardState;
        // wp7 touch location state
        public static TouchCollection CurrentTouchLocationState;
        public static TouchCollection PreviousTouchLocationState;
      
        // keyboard inputs (desktop, wp7)
        private Dictionary<Keys, bool> keyboardInputs = new Dictionary<Keys, bool>();
        
        // gamepad inputs (xbox)
        private Dictionary<Buttons, bool> gamepadInputs = new Dictionary<Buttons, bool>();
        
        // windows phone 7 inputs
        public bool PinchGestureAvailable { get; set; }
        private static List<GestureDefinition> detectedGestures = new List<GestureDefinition>();
        private static Accelerometer accelerometerSensor;
        private static Vector3 currentAccelerometerReading;
        private Dictionary<Rectangle, bool> touchTapInputs = new Dictionary<Rectangle, bool>();
        private Dictionary<Direction, float> touchSlideInputs = new Dictionary<Direction, float>();
        private Dictionary<int, GestureDefition> gestureInputs = new Dictionary<int, GestureDefition>();
        private Dictionary<Direction, float> accelerometerInputs = new Dictionary<Direction, float>();
        private static List<PlayerIndex> allPlayers = new List<PlayerIndex> {
            PlayerIndex.One,
            PlayerIndex.Two, 
            PlayerIndex.Three, 
            PlayerIndex.Four}; 

        /// <summary>
        /// Initialize current and previous GamePadState dictionaries,
        /// the GamePadConnectionState, and the Accelerometer sensor.
        /// </summary>
        public Input()
        {
            if (CurrentGamePadState.Count == 0)
                InitializeGamePadState();
            if (accelerometerSensor == null)
                InitializeAccelerometerSensor();
                
            
        }

        /// <summary>
        /// Initialize Game pad state
        /// </summary>
        private void InitializeGamePadState()
        {
            InitializeGamePadState(CurrentGamePadState);
            InitializeGamePadState(PreviousGamePadState);
            InitializeGamePadConnectionState();
        }

        /// <summary>
        /// Initialize game pad state
        /// </summary>
        /// <param name="gamepadState"></param>
        private void InitializeGamePadState(Dictionary<PlayerIndex, GamePadState> gamepadState)
        {
            foreach(var player in allPlayers)
                gamepadState.AddGamePadState(player);
        }

        /// <summary>
        /// Initialize game pad connection state
        /// </summary>
        private void InitializeGamePadConnectionState()
        {
            foreach (var player in allPlayers)
                GamepadConnectionState.Add(player, CurrentGamePadState[player].IsConnected);
        }

        /// <summary>
        /// Initialize Accelerometer Sensor
        /// </summary>
        private void InitializeAccelerometerSensor()
        {
            accelerometerSensor = new Accelerometer();
            accelerometerSensor.CurrentValueChanged += 
                new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(AccelerometerReadingChanged);
        }

        /// <summary>
        /// Handle Accelerometer reading changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccelerometerReadingChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            currentAccelerometerReading.X = e.SensorReading.Acceleration.X;
            currentAccelerometerReading.Y = e.SensorReading.Acceleration.Y;
            currentAccelerometerReading.Z = e.SensorReading.Acceleration.Z;
        }

        /// <summary>
        /// Begin updating user input
        /// </summary>
        static public void BeginUpdate()
        {
            // update inputs
            UpdateGamePadState(CurrentGamePadState);
            CurrentTouchLocationState = TouchPanel.GetState();
            CurrentKeyboardState = Keyboard.GetState(PlayerIndex.One);
            // clear detected gestures
            detectedGestures.Clear();
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                detectedGestures.Add(new GestureDefinition(gesture));
            }
        }

        /// <summary>
        /// Update gamepad state
        /// </summary>
        /// <param name="currentGamePadState"></param>
        private static void UpdateGamePadState(Dictionary<PlayerIndex, GamePadState> gamePadState)
        {
            foreach (var player in allPlayers)
                gamePadState[player] = GamePad.GetState(player);
        }

        /// <summary>
        /// End updating user input
        /// </summary>
        static public void EndUpdate()
        {   
            // update previous game pad state
            foreach (var player in allPlayers)
                PreviousGamePadState[player] = CurrentGamePadState[player];
            // update previous touch  and keyboard
            PreviousTouchLocationState = CurrentTouchLocationState;
            PreviousKeyboardState = CurrentKeyboardState;
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
            if (keyboardInputs.ContainsKey(theKey))
                keyboardInputs[theKey] = isReleasedPreviously;
            else
                keyboardInputs.Add(theKey, isReleasedPreviously);
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
            if (gamepadInputs.ContainsKey(theButton))
                gamepadInputs[theButton] = isReleasedPreviously;
            else
                gamepadInputs.Add(theButton, isReleasedPreviously);
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
            if (touchTapInputs.ContainsKey(theTouchArea))
                touchTapInputs[theTouchArea] = isReleasedPreviously;
            else
                touchTapInputs.Add(theTouchArea, isReleasedPreviously);
        }

        /// <summary>
        /// Add touch slide input
        /// </summary>
        /// <param name="theDirection"></param>
        /// <param name="slideDistance"></param>
        public void AddTouchSlideInput(Direction theDirection, float slideDistance)
        {
            if (touchSlideInputs.ContainsKey(theDirection))
                touchSlideInputs[theDirection] = slideDistance;
            else
                touchSlideInputs.Add(theDirection, slideDistance);
        }

        public void AddTouchGesture(GestureType theGesture, Rectangle theTouchArea)
        {
            // add new gesture as an enabled gesture
            TouchPanel.EnabledGestures = theGesture | TouchPanel.EnabledGestures;
            gestureInputs.Add(gestureInputs.Count, new GestureDefition(theGesture, theTouchArea));
            if (theGesture == GestureType.Pinch)
                PinchGestureAvailable = true;
        }

    }

    public static class ExtensionHelpers
    {
        /// <summary>
        /// Add game pad state to a gamepadState dictionary
        /// </summary>
        /// <param name="gamePadState"></param>
        /// <param name="playerIndex"></param>
        public static void AddGamePadState(this Dictionary<PlayerIndex, GamePadState> gamePadState, PlayerIndex playerIndex)
        {
            gamePadState.Add(playerIndex, GamePad.GetState(playerIndex));
        }

    }
}