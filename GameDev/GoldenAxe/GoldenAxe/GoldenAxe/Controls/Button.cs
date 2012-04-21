using System;
using GoldenAxe.Fonts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace GoldenAxe.Controls
{
    public class Button : DrawableGameComponent
    {
        public Action ButtonClicked { get; set; }

        private ButtonDescription buttonDescription;
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private Texture2D dummyTexture;

        private FontDescription FontDescription { get { return buttonDescription.FontDescription; } }
        private Rectangle Area { get { return buttonDescription.Area; } }
        private Vector2 textPosition;



        public Button(Game game, SpriteBatch spriteBatch, ButtonDescription buttonDescription) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.buttonDescription = buttonDescription;
        }

        protected override void LoadContent()
        {
            // load dummy texture
            dummyTexture = new Texture2D(GraphicsDevice, 1, 1);
            dummyTexture.SetData(new Color[] { Color.White });
            // load button content
            spriteFont = Game.Content.Load<SpriteFont>(FontDescription.AssetName);
            Vector2 fontSize = spriteFont.MeasureString(FontDescription.Text);
            // Set text as centered within the button area
            textPosition = new Vector2(Area.X + Area.Width / 2 - fontSize.X/2,
                           Area.Y + Area.Height / 2 - fontSize.Y / 2);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // Check if button was clicked (tapped)
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gestureSample = TouchPanel.ReadGesture();
                if (gestureSample.GestureType == GestureType.Tap 
                    && Area.Contains((int)gestureSample.Position.X, (int)gestureSample.Position.Y)
                    && ButtonClicked != null)
                ButtonClicked();
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(dummyTexture, Area, Color.White);
            spriteBatch.DrawString(spriteFont, FontDescription.Text, textPosition, FontDescription.Color);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        
    }
}