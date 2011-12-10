using RpgGameEngine.Core.Entities;

namespace RpgGameEngine.Core.Interfaces
{
    public interface ISerializationService
    {
        Stat LoadStat(string filename);
    }
}