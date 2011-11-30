using GoldenAxe.Common;
using Microsoft.Xna.Framework;

namespace GoldenAxe.Controls
{
    public static class Helpers
    {
         public static int GAME_WINDOW_WIDTH = 800;
         public static int GAME_WINDOW_HEIGHT = 480;

        /// <summary>
        /// Get the position of a drawable game component from the drawablePosition enumeration
        /// </summary>
        /// <param name="drawablePosition"></param>
        /// <param name="drawableArea"></param>
        /// <returns></returns>
         public static Vector2 GetPositionFromDrawablePosition(DrawablePosition drawablePosition, Rectangle drawableArea)
         {
             switch (drawablePosition)
             {
                 case DrawablePosition.Centered:
                     return new Vector2(GAME_WINDOW_WIDTH/2 - drawableArea.Width/2, GAME_WINDOW_HEIGHT/2 - drawableArea.Height/2);
                 case DrawablePosition.TopCentered:
                    return new Vector2(GAME_WINDOW_WIDTH/2 - drawableArea.Width/2, 0);
                 case DrawablePosition.None:
                 default:
                     return Vector2.Zero;
             }
         }
    }
}