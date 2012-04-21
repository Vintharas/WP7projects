namespace Vintharas.GameEngine.Rpg.Core.General
{
    public class RPGGame
    {
        public string GameName
        {
            get { return gameName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    gameName = value;
            }
        }
        private string gameName;

        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    description = value;
            }
        }
        private string description;

    }
}