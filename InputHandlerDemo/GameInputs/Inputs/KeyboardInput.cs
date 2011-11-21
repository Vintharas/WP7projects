using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameInputs.Inputs
{
    public class KeyboardInput
    {
        // desktop and wp7 keyboard state
        public static KeyboardState CurrentKeyboardState;
        public static KeyboardState PreviousKeyboardState;
        // keyboard inputs (desktop, wp7)
        private Dictionary<Keys, bool> keyboardInputs = new Dictionary<Keys, bool>();

        /// <summary>
        /// Begin updating keyboard user input
        /// </summary>
        public static void BeginUpdate()
        {
            CurrentKeyboardState = Keyboard.GetState(PlayerIndex.One);
        }

        /// <summary>
        /// End updating keyboard user input
        /// </summary>
        public static void EndUpdate()
        {
            PreviousKeyboardState = CurrentKeyboardState;
        }

        /// <summary>
        /// Add keyboard input
        /// </summary>
        /// <param name="theKey"></param>
        /// <param name="isReleasedPreviously"></param>
        public void Add(Keys theKey, bool isReleasedPreviously)
        {
            if (keyboardInputs.ContainsKey(theKey))
                keyboardInputs[theKey] = isReleasedPreviously;
            else
                keyboardInputs.Add(theKey, isReleasedPreviously);
        }

        /// <summary>
        /// Check whether any keyboard input has been pressed
        /// </summary>
        /// <returns></returns>
        public bool IsPressed()
        {
            return keyboardInputs.Keys.Any(IsPressed);
        }

        /// <summary>
        /// Check whether a given keyboard key is pressed
        /// </summary>
        /// <param name="aKey"></param>
        /// <returns></returns>
        private bool IsPressed(Keys aKey)
        {
            if (keyboardInputs[aKey] &&
                CurrentKeyboardState.IsKeyDown(aKey) &&
                !PreviousKeyboardState.IsKeyDown(aKey))
                return true;
            if (!keyboardInputs[aKey] &&
                CurrentKeyboardState.IsKeyDown(aKey))
                return true;
            return false;
        }
    }
}