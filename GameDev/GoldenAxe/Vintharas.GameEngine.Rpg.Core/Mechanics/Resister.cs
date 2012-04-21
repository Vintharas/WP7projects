namespace Vintharas.GameEngine.Rpg.Core.Mechanics
{
    public struct Resister
    {
        public DamageType Type;
        // Format = "n,n"
        public string DamageAmount;
        // The type of entity the damage affects, empty for all types
        public string Affects;
    }
}