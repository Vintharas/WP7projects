using GoldenAxe.Common;
using GoldenAxe.Fonts;
using Microsoft.Xna.Framework;

namespace GoldenAxe.Controls
{
    public class ButtonDescription
    {
        public FontDescription FontDescription { get; set; }
        public Vector2 Position { get; set; }
        public DrawablePosition FixedPosition { get; set; }
        public Rectangle Area { get; set; }


        public ButtonDescription(FontDescription fontDescription, Vector2 position, Rectangle area)
        {
            FontDescription = fontDescription;
            Position = position;
            Area = area;
        }

        public ButtonDescription(FontDescription fontDescription, DrawablePosition fixedPosition, Rectangle area)
        {
            FontDescription = fontDescription;
            FixedPosition = fixedPosition;
            Area = area;
        }
    }
}