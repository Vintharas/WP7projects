using Microsoft.Xna.Framework;

namespace GoldenAxe.Fonts
{
    /// <summary>
    /// Class that encapsulates the description of a font
    /// </summary>
    public class FontDescription
    {
        public string AssetName { get; set; }
        public Vector2 Position { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }

        public FontDescription(string assetName, string text, Color color, Vector2 position)
        {
            AssetName = assetName;
            Text = text;
            Color = color;
            Position = position;
        }
    }
}