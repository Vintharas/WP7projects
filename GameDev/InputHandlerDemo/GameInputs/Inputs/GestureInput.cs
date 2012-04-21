using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace GameInputs.Inputs
{
    public class GestureInput
    {
        public bool PinchGestureAvailable { get; set; }
        public GestureDefinition CurrentGestureDefinition { get; set; }

        private static List<GestureDefinition> detectedGestures = new List<GestureDefinition>();
        private Dictionary<int, GestureDefinition> gestureInputs = new Dictionary<int, GestureDefinition>();

        /// <summary>
        /// Begin updating user gesture input
        /// </summary>
        public static void BeginUpdate()
        {
            // clear detected gestures
            detectedGestures.Clear();
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();
                detectedGestures.Add(new GestureDefinition(gesture));
            }
        }

        /// <summary>
        /// Add new gesture input
        /// </summary>
        /// <param name="theGesture"></param>
        /// <param name="theTouchArea"></param>
        public void Add(GestureType theGesture, Rectangle theTouchArea)
        {
            // add new gesture as an enabled gesture
            TouchPanel.EnabledGestures = theGesture | TouchPanel.EnabledGestures;
            gestureInputs.Add(gestureInputs.Count, new GestureDefinition(theGesture, theTouchArea));
            if (theGesture == GestureType.Pinch)
                PinchGestureAvailable = true;
        }

        /// <summary>
        /// Check whether there's any gesture input
        /// </summary>
        /// <param name="currentObjectLocation"></param>
        /// <returns></returns>
        public bool IsPressed(Rectangle? theNewDetectionLocation)
        {
            CurrentGestureDefinition = null;
            if (detectedGestures.Count == 0)
                return false;
            // check if any of the gestures defined in the gestureInputs dictionary
            // have been performed and detected
            foreach (GestureDefinition userDefinedGesture in gestureInputs.Values)
            {
                foreach (GestureDefinition detectedGesture in detectedGestures)
                {
                    // If a rectangle area to check against has been passed use that one,
                    // otherwise use the one originally defined
                    Rectangle areaToCheck = userDefinedGesture.CollisionArea;
                    if (theNewDetectionLocation != null)
                        areaToCheck = (Rectangle)theNewDetectionLocation;
                    // If the gesture detected was made in an area of interest,
                    // then the gesture is considered detected.
                    if (detectedGesture.CollisionArea.Intersects(areaToCheck))
                    {
                        if (CurrentGestureDefinition == null)
                        {
                            CurrentGestureDefinition = new GestureDefinition(detectedGesture.Gesture);
                        }
                        else
                        {
                            // Some gestures like FreeDrag and Flick are registered
                            // many, many times in a single Update frame. Since
                            // there is only one variable to store the gesture
                            // info, you must add on any additional gesture values
                            // so there is a combination of all the gesture
                            // information in currentGesture.
                            CurrentGestureDefinition.Delta += detectedGesture.Delta;
                            CurrentGestureDefinition.Delta2 += detectedGesture.Delta2;
                            CurrentGestureDefinition.Position += detectedGesture.Position;
                            CurrentGestureDefinition.Position2 += detectedGesture.Position2;
                        }
                    }
                }
            }
            if (CurrentGestureDefinition != null)
                return true;
            return false;
        }
    }
}