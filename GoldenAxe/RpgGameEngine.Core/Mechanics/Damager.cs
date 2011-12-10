using RpgGameEngine.Core.Entities;

namespace RpgGameEngine.Core.Mechanics
{
    public struct Damager
    {
        public DamageType Type;
        // Format = "n,n"
        public string DamageAmount;
        // The type of entity the damage affects, empty for all types
        public string Affects;
    }
}