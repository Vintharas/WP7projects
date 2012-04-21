using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace GameInputs.Inputs
{

    public class TouchIndicatorCollection
    {
         
        List<TouchIndicator> touchPositions = new List<TouchIndicator>();

        /// <summary>
        /// Update information regarding the status of the touch indicators.
        /// </summary>
        /// <param name="gametime"></param>
        /// <param name="content"></param>
        public void Update(GameTime gametime, ContentManager content)
        {
            TouchCollection currentTouchLocationState = TouchPanel.GetState();
            AddNewIndicators(content, currentTouchLocationState);
            foreach (TouchIndicator indicator in touchPositions)
                indicator.Update(currentTouchLocationState); 
        }

        /// <summary>
        /// Add new touch indicators for new touch inputs
        /// </summary>
        /// <param name="content"></param>
        /// <param name="currentTouchLocationState"></param>
        private void AddNewIndicators(ContentManager content, TouchCollection currentTouchLocationState)
        {
            foreach (TouchLocation location in currentTouchLocationState)
            {
                bool isTouchIdAlreadyStored = touchPositions.Any(indicator => location.Id == indicator.TouchID);
                if (!isTouchIdAlreadyStored)
                {
                    TouchIndicator indicator = new TouchIndicator(location.Id, content);
                    touchPositions.Add(indicator);
                }
            }
        }

        /// <summary>
        /// Draw the touch indicators
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(TouchIndicator indicator in touchPositions)
                indicator.Draw(spriteBatch);
        }
    }
}