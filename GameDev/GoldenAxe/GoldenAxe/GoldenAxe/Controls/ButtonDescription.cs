using GoldenAxe.Fonts;
using Microsoft.Xna.Framework;
using Vintharas.BloodAndSteel.Common;

namespace GoldenAxe.Controls
{
    public class ButtonDescription
    {
        public FontDescription FontDescription { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Position { get; set; }
        public DrawablePosition FixedPosition { get; set; }

        public Rectangle Area
        {
            get
            {
                if(FixedPosition == DrawablePosition.None)
                    return new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
                else
                {
                    Vector2 buttonPosition = Helpers.GetPositionFromDrawablePosition(FixedPosition, Size);
                    return new Rectangle((int) buttonPosition.X, (int) buttonPosition.Y, (int) Size.X, (int) Size.Y);
                }
            }
        }

        public ButtonDescription(FontDescription fontDescription, Vector2 position, Vector2 size)
        {
            FontDescription = fontDescription;
            Position = position;
            Size = size;
        }

        public ButtonDescription(FontDescription fontDescription, DrawablePosition fixedPosition, Vector2 size)
        {
            FontDescription = fontDescription;
            FixedPosition = fixedPosition;
            Size = size;
        }
    }
}