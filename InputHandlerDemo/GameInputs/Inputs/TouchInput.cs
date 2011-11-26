using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace GameInputs.Inputs
{
    public class TouchInput
    {
        public static TouchCollection CurrentTouchLocationState;
        public static TouchCollection PreviousTouchLocationState;

        public Vector2? CurrentTouchPosition()
        {
            foreach (TouchLocation touchLocation in CurrentTouchLocationState)
            {
                switch (touchLocation.State)
                {
                    case TouchLocationState.Pressed:
                    case TouchLocationState.Moved:
                        return touchLocation.Position;
                }
            }
            return null;
        }
        public Vector2? PreviousTouchPosition()
        {
            foreach (TouchLocation touchLocation in PreviousTouchLocationState)
            {
                switch (touchLocation.State)
                {
                    case TouchLocationState.Pressed:
                    case TouchLocationState.Moved:
                        return touchLocation.Position;
                }
            }
            return null;
        }

        /// <summary>
        /// Begin updating touch user input
        /// </summary>
        public static void BeginUpdate()
        {
            CurrentTouchLocationState = TouchPanel.GetState();
        }

        /// <summary>
        /// End updating touch user input
        /// </summary>
        public static void EndUpdate()
        {
            PreviousTouchLocationState = CurrentTouchLocationState;
        }
    }
}