using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WP7GameAnimatedSprites.Sprites;


namespace WP7GameAnimatedSprites
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private UserControlledSprite player;
        private List<Sprite> spriteList = new List<Sprite>();
 

        public SpriteManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            player = new UserControlledSprite(
                Game.Content.Load<Texture2D>(@"Images/threerings"),
                Vector2.Zero, new Point(75, 75), new Point(0, 0),
                new Point(6, 8), 10, new Vector2(6, 6));
            spriteList.Add(new BouncingSprite(
                Game.Content.Load<Texture2D>(@"Images/skullball"),
                new Vector2(150, 150), new Point(75, 75), new Point(0, 0),
                new Point(6, 8), 10, new Vector2(1,1)));
            spriteList.Add(new BouncingSprite(
                Game.Content.Load<Texture2D>(@"Images/skullball"),
                new Vector2(300, 150), new Point(75, 75), new Point(0, 0),
                new Point(6, 8), 10, new Vector2(2, 2)));
            spriteList.Add(new BouncingSprite(
                Game.Content.Load<Texture2D>(@"Images/plus"),
                new Vector2(150, 300), new Point(75, 75), new Point(0, 0),
                new Point(6, 4), 10, new Vector2(2, 2)));
            spriteList.Add(new BouncingSprite(
                Game.Content.Load<Texture2D>(@"Images/plus"),
                new Vector2(600, 400), new Point(75, 75), new Point(0, 0),
                new Point(6, 4), 10, new Vector2(3, 3)));

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            // UPdate player
            player.Update(gameTime, Game.GraphicsDevice.Viewport.Bounds);
            // Update all sprites
            foreach (Sprite s in spriteList)
            {
                s.Update(gameTime, Game.GraphicsDevice.Viewport.Bounds);
                // Detect collisions
                if (s.CollisionRect.Intersects(player.CollisionRect))
                    Game.Exit();
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Allows the game compontent to draw itself
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack,
                              BlendState.AlphaBlend);
            // draw player
            player.Draw(gameTime, spriteBatch);
            // draw sprites
            foreach(Sprite s in spriteList)
                s.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
