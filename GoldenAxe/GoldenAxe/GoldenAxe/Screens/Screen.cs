using System;
using System.Collections.Generic;
using GoldenAxe.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GoldenAxe.Screens
{
    public class Screen : DrawableGameComponent
    {
        protected Game game;
        protected Action<ScreenManager.GameScreen> navigateToScreen;
        protected SpriteBatch spriteBatch;
        protected List<DrawableGameComponent> drawableComponents;

        public Screen(Game game, SpriteBatch spriteBatch, Action<ScreenManager.GameScreen> navigateToScreen) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.navigateToScreen = navigateToScreen;
            drawableComponents = new List<DrawableGameComponent>();
        }

        /// <summary>
        /// Navigate to new screen
        /// </summary>
        /// <param name="gameScreen"></param>
        protected void NavigateToScreen(ScreenManager.GameScreen gameScreen)
        {
            navigateToScreen(gameScreen);
        }

        /// <summary>
        /// Initialize all components that exist in the screen
        /// </summary>
        public override void Initialize()
        {
            foreach(var component in drawableComponents)
                component.Initialize();
            base.Initialize();
        }

        /// <summary>
        /// Update all components that exist in the screen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            foreach(var component in drawableComponents)
                component.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw all components that exist in the screen
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            foreach(var component in drawableComponents)
                component.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}