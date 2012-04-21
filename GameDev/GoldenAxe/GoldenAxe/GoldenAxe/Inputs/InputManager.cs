using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace GoldenAxe.Inputs
{
    public class InputManager
    {
        public InputManager()
        {
            InitializeGestures();
        }

        private void InitializeGestures()
        {
            TouchPanel.EnabledGestures = GestureType.Tap;
        }
    }
}