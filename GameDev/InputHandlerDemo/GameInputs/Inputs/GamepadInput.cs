using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameInputs.Inputs
{
    public class GamepadInput
    {
        public static Dictionary<PlayerIndex, GamePadState> CurrentGamePadState = new Dictionary<PlayerIndex, GamePadState>();
        public static Dictionary<PlayerIndex, GamePadState> PreviousGamePadState = new Dictionary<PlayerIndex, GamePadState>();
        public static Dictionary<PlayerIndex, bool> GamepadConnectionState = new Dictionary<PlayerIndex, bool>(); 

        private Dictionary<Buttons, bool> gamepadInputs = new Dictionary<Buttons, bool>();
        
        private static List<PlayerIndex> allPlayers = new List<PlayerIndex>
                                                          {
            PlayerIndex.One,
            PlayerIndex.Two, 
            PlayerIndex.Three, 
            PlayerIndex.Four};

        /// <summary>
        /// Initialize game pad state
        /// </summary>
        public GamepadInput()
        {
            if (CurrentGamePadState.Count == 0)
                InitializeGamePadState();
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
            foreach (var player in allPlayers)
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
        /// Begin updating gamepad user input
        /// </summary>
        static public void BeginUpdate()
        {
            // Update gamepad state
            foreach (var player in allPlayers)
                CurrentGamePadState[player] = GamePad.GetState(player);
        }

        /// <summary>
        /// Finish updating gamepad user input
        /// </summary>
        public static void EndUpdate()
        {
            // update previous game pad state
            foreach (var player in allPlayers)
                PreviousGamePadState[player] = CurrentGamePadState[player];
        }

        /// <summary>
        /// Add gamepad input
        /// </summary>
        /// <param name="theButton"></param>
        /// <param name="isReleasedPreviously"></param>
        public void Add(Buttons theButton, bool isReleasedPreviously)
        {
            if (gamepadInputs.ContainsKey(theButton))
                gamepadInputs[theButton] = isReleasedPreviously;
            else
                gamepadInputs.Add(theButton, isReleasedPreviously);
        }

        /// <summary>
        /// Check whether any gamepad input is pressed
        /// </summary>
        /// <param name="playerIndex"></param>
        /// <returns></returns>
        public bool IsPressed(PlayerIndex playerIndex)
        {
            return gamepadInputs.Keys.Any(button => IsPressed(playerIndex, button));
        }

        /// <summary>
        /// Check whether a given game input is pressed
        /// </summary>
        /// <param name="playerIndex"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        private bool IsPressed(PlayerIndex playerIndex, Buttons button)
        {
            if (gamepadInputs[button] &&
                CurrentGamePadState[playerIndex].IsButtonDown(button) &&
                !PreviousGamePadState[playerIndex].IsButtonDown(button))
                return true;
            if (!gamepadInputs[button] &&
                CurrentGamePadState[playerIndex].IsButtonDown(button))
                return true;
            return false;
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