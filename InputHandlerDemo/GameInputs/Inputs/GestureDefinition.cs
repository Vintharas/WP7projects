using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace GameInputs.Inputs
{
    public class GestureDefinition
    {
        public GestureType Type { get; set; }
        public Rectangle CollisionArea { get; set; }
        public GestureSample Gesture { get; set; }
        public Vector2 Delta { get; set; }
        public Vector2 Delta2 { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Position2 { get; set; }

        public GestureDefinition(GestureType gestureType,
                                 Rectangle gestureArea)
        {
            Gesture = new GestureSample(gestureType, 
                                        new TimeSpan(0),
                                        Vector2.Zero,
                                        Vector2.Zero, 
                                        Vector2.Zero,
                                        Vector2.Zero);
            Type = gestureType;
            CollisionArea = gestureArea;
        }

        public GestureDefinition(GestureSample gestureSample)
        {
            Gesture = gestureSample;
            Type = gestureSample.GestureType;
            CollisionArea = new Rectangle((int)gestureSample.Position.X,
                                          (int)gestureSample.Position.Y, 
                                          5, 
                                          5);
            Delta = gestureSample.Delta;
            Delta2 = gestureSample.Delta2;
            Position = gestureSample.Position;
            Position2 = gestureSample.Position2;
        }
    }
}