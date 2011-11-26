using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Sprites
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class SpriteManager : DrawableGameComponent
    {
        // SpriteBatch for drawing

        // Scoring
        private readonly List<AutomatedSprite> livesList = new List<AutomatedSprite>();
        private int automatedSpritePointValue = 10;
        private int chasingSpritePointValue = 20;
        private int evadingSpritePointValue;
        private UserControlledSprite player;

        private SpriteBatch spriteBatch;

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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            player = new UserControlledSprite(
                Game.Content.Load<Texture2D>(@"Images/Player/warrior_walking"),
                new Vector2(Game.GraphicsDevice.Viewport.Width/2,
                            Game.GraphicsDevice.Viewport.Height/2),
                new Point(40, 70), 10, new Point(0, 0),
                new Point(4, 1), new Vector2(6, 6), 40);

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            UpdateSprites(gameTime);
            base.Update(gameTime);
        }

        protected void UpdateSprites(GameTime gameTime)
        {
            // Update player
            player.Update(gameTime, Game.Window.ClientBounds);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            // Draw the player
            player.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}