using Vintharas.GameEngine.Rpg.Core.Entities;

namespace Vintharas.GameEngine.Rpg.Core.Interfaces
{
    public interface ISerializationService
    {
        Stat LoadStat(string filename);
    }
}