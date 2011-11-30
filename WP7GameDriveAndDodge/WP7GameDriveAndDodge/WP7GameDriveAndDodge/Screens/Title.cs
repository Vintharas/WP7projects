using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using WP7GameDriveAndDodge.Sprites;
using WP7GameDriveAndDodge.Texts;

namespace WP7GameDriveAndDodge.Screens
{
    public class Title : Screen
    {
        private const string ActionStart = "Start";
        private const string ActionExit = "Exit";

        private Background background;
        private Text titleText;
        private Button startButton;
        private Button exitButton;


        public Title(Game game, SpriteBatch spriteBatch, ChangeScreen changeScreen) : base(game, spriteBatch, changeScreen)
        {
        }

        protected override void SetupInputs()
        {
            input.AddTouchGestureInput(ActionStart, GestureType.Tap,
                                       startButton.CollisionRectangle);
            input.AddTouchGestureInput(ActionExit, GestureType.DoubleTap,
                                       exitButton.CollisionRectangle);
        }

        public override void Activate()
        {
            music.PlayBackgroundMusic("Music/RaceSong");
        }

        protected override void LoadScreenContent(ContentManager content)
        {
            background = new Background(content);
            titleText = new Text(font, "Drive & Dodge!", 
                new Vector2(0, (int)(ScreenHeight/3)),
                Color.Brown, Color.Beige,
                Text.Alignment.Horizontal, 
                new Rectangle(0, 0, ScreenWidth, 0));
            startButton = new Button(content, "Start Game", new Vector2(30, 500), Color.BurlyWood);
            exitButton = new Button(content, "Exit", new Vector2(30, 650), Color.BurlyWood );

        }

        protected override void UpdateScreen(GameTime gameTime, DisplayOrientation screenOrientation)
        {
            if (input.IsPressed(ActionStart))
            {
                soundEffects.PlaySound("SoundEffects/Select");
                changeScreenDelegate(ScreenState.MainGame);
            }
            else if (input.IsPressed(ActionExit))
            {
                soundEffects.PlaySound("SoundEffects/Select");
                changeScreenDelegate(ScreenState.Exit);
            }
        }

        protected override void DrawScreen(SpriteBatch spriteBatch, DisplayOrientation screenOrientation)
        {
            background.Draw(spriteBatch);
            titleText.Draw(spriteBatch);
            startButton.Draw(spriteBatch);
            exitButton.Draw(spriteBatch);
        }

        public override void SaveScreenState()
        {

        }
    }
}