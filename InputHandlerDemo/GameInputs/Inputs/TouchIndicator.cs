using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace GameInputs.Inputs
{
    /// <summary>
    /// Class used to give a visual cue to users of precisely where
    /// they are touching the screen
    /// </summary>
    public class TouchIndicator
    {
        /// <summary>
        /// Used to return TouchLocation position to the Game class
        /// </summary>
        public int TouchID { get; set; }
        /// <summary>
        /// Modified in the Update() routine and used in the Draw() routine to control
        /// fading the indicator in or out
        /// </summary>
        private int alphaValue = 255;

        private Texture2D touchCircleIndicatorTexture;
        private Texture2D touchCrossHairIndicatorTexture;

        List<Vector2> touchPositions = new List<Vector2>();

        public TouchIndicator(int touchID, ContentManager content)
        {
            TouchID = touchID;
            touchCircleIndicatorTexture = content.Load<Texture2D>("Circle");
            touchCrossHairIndicatorTexture = content.Load<Texture2D>("Crosshair");
        }

        /// <summary>
        /// Get the touch position related to the TouchID
        /// </summary>
        /// <param name="touchLocationState"></param>
        /// <returns></returns>
        private Vector2? TouchPosition(TouchCollection touchLocationState)
        {
            TouchLocation touchLocation;
            if (touchLocationState.FindById(TouchID, out touchLocation))
                return touchLocation.Position;
            return null;
        }

        /// <summary>
        /// Update touch indicator 
        /// </summary>
        /// <param name="touchLocationState"></param>
        public void Update(TouchCollection touchLocationState)
        {
            Vector2? currentPosition = TouchPosition(touchLocationState);
            if (currentPosition == null)
            {
                if (touchPositions.Count > 0)
                {
                    alphaValue -= 20;
                    if (alphaValue <= 0)
                    {
                        touchPositions.Clear();
                        alphaValue = 255;
                    }
                }
            }
            else
            {
                if (alphaValue != 255)
                {
                    touchPositions.Clear();
                    alphaValue = 255;
                }
                touchPositions.Add((Vector2)currentPosition);
            }
        }

        /// <summary>
        /// Draw touch indicator
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (touchPositions.Count != 0)
            {
                Vector2 previousPosition = touchPositions[0];
                Vector2 offsetForCenteringTouchPosition = new Vector2(-25, -25);
                foreach (Vector2 touchPosition in touchPositions)
                {
                    DrawLine(spriteBatch,
                             touchCircleIndicatorTexture,
                             touchCrossHairIndicatorTexture,
                             previousPosition + offsetForCenteringTouchPosition,
                             touchPosition + offsetForCenteringTouchPosition,
                             new Color(0, 0, 255, alphaValue));
                    previousPosition = touchPosition;
                }
            }
        }

        /// <summary>
        /// Draw the crosshair image and a line as your drag
        /// your finger across the screen
        /// </summary>
        /// <param name="spritebatch"></param>
        /// <param name="linetexture"></param>
        /// <param name="touchTexture"></param>
        /// <param name="startingPoint"></param>
        /// <param name="endingPoint"></param>
        /// <param name="lineColor"></param>
        private void DrawLine(SpriteBatch spritebatch,
                              Texture2D linetexture, 
                              Texture2D touchTexture,
                              Vector2 startingPoint,
                              Vector2 endingPoint,
                              Color lineColor)
        {
            spritebatch.Draw(touchTexture, startingPoint, lineColor);

            Vector2 difference = startingPoint - endingPoint;
            float lineLength = difference.Length()/8;
            for (int i = 0; i < lineLength; i++)
            {
                spritebatch.Draw(linetexture, startingPoint, lineColor);
                startingPoint.X -= difference.X/lineLength;
                startingPoint.Y -= difference.Y/lineLength;
            }
            spritebatch.Draw(touchTexture, endingPoint, lineColor);
        }
    }
}