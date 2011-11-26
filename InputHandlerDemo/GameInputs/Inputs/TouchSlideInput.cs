using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace GameInputs.Inputs
{
    public class TouchSlideInput : TouchInput
    {

        private Dictionary<Direction, float> touchSlideInputs = new Dictionary<Direction, float>();

        /// <summary>
        /// Add touch slide input
        /// </summary>
        /// <param name="theDirection"></param>
        /// <param name="slideDistance"></param>
        public void Add(Direction theDirection, float slideDistance)
        {
            if (touchSlideInputs.ContainsKey(theDirection))
                touchSlideInputs[theDirection] = slideDistance;
            else
                touchSlideInputs.Add(theDirection, slideDistance);
        }

        /// <summary>
        /// Check whether there was any touch slide input pressed
        /// </summary>
        /// <returns></returns>
        public bool IsPressed()
        {
            foreach (Direction slideDirection in touchSlideInputs.Keys)
            {
                if (CurrentTouchPosition() != null && PreviousTouchPosition() != null)
                {
                    switch (slideDirection)
                    {
                        case Direction.Up:
                            if (CurrentTouchPosition().Value.Y + touchSlideInputs[slideDirection] < PreviousTouchPosition().Value.Y)
                                return true;
                            break;
                        case Direction.Down:
                            if (CurrentTouchPosition().Value.Y - touchSlideInputs[slideDirection] > PreviousTouchPosition().Value.Y)
                                return true;
                            break;
                        case Direction.Left:
                            if (CurrentTouchPosition().Value.X + touchSlideInputs[slideDirection] < PreviousTouchPosition().Value.X)
                                return true;
                            break;
                        case Direction.Right:
                            if (CurrentTouchPosition().Value.X - touchSlideInputs[slideDirection] > PreviousTouchPosition().Value.X)
                                return true;
                            break;
                    }
                }
            }
            return false;
        }
    }
}