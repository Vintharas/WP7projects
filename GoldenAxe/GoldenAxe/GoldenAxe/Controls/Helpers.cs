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
         public static Vector2 GetPositionFromDrawablePosition(DrawablePosition drawablePosition, Vector2 drawableArea)
         {
             switch (drawablePosition)
             {
                 case DrawablePosition.Centered:
                     return new Vector2(GAME_WINDOW_WIDTH/2 - drawableArea.X/2, GAME_WINDOW_HEIGHT/2 - drawableArea.Y/2);
                 case DrawablePosition.TopCentered:
                    return new Vector2(GAME_WINDOW_WIDTH/2 - drawableArea.X/2, 0);
                 case DrawablePosition.BottomCentered:
                    return new Vector2(GAME_WINDOW_WIDTH/2 - drawableArea.X/2, GAME_WINDOW_HEIGHT - drawableArea.Y);
                 case DrawablePosition.None:
                 default:
                     return Vector2.Zero;
             }
         }
    }
}