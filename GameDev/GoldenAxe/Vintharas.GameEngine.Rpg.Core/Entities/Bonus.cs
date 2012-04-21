namespace Vintharas.GameEngine.Rpg.Core.Entities
{
    
    /// <summary>
    /// Class that represents a bonus that affects a given stat
    /// </summary>
    public class Bonus
    {
        public BonusType Type { get; set; }
        public short Amount { get; set; }
        public int TimeStarted { get; set; }
        public int Duration { get; set; }
        public float ElapsedTime { get; set; }
    }
}