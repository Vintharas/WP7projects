using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GameInputs.Inputs
{
    public class TouchTapInput : TouchInput
    {
        public Rectangle CurrentTouchRectangle
        {
            get
            {
                Vector2? touchPosition = CurrentTouchPosition();
                if (touchPosition == null)
                    return Rectangle.Empty;
                return new Rectangle((int)touchPosition.Value.X - 5,
                    (int)touchPosition.Value.Y - 5,
                    10, 10);
            }
        }

        private Dictionary<Rectangle, bool> touchTapInputs = new Dictionary<Rectangle, bool>();
       



        /// <summary>
        /// Add touch tap input
        /// </summary>
        /// <param name="theTouchArea"></param>
        /// <param name="isReleasedPreviously"></param>
        public void Add(Rectangle theTouchArea, bool isReleasedPreviously)
        {
            if (touchTapInputs.ContainsKey(theTouchArea))
                touchTapInputs[theTouchArea] = isReleasedPreviously;
            else
                touchTapInputs.Add(theTouchArea, isReleasedPreviously);
        }

        /// <summary>
        /// Check whether any touchtap input is pressed
        /// </summary>
        /// <returns></returns>
        public bool IsPressed()
        {
            foreach (Rectangle touchArea in touchTapInputs.Keys)
            {
                if (touchTapInputs[touchArea] &&
                    touchArea.Intersects(CurrentTouchRectangle) &&
                    PreviousTouchPosition() == null)
                    return true;
                if (!touchTapInputs[touchArea] &&
                    touchArea.Intersects(CurrentTouchRectangle))
                    return true;
            }
            return false;
        }
    }
}