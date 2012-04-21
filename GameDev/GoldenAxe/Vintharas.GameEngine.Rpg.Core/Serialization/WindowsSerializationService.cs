using System.IO;
using Vintharas.GameEngine.Rpg.Core.Entities;
using Vintharas.GameEngine.Rpg.Core.Interfaces;

namespace Vintharas.GameEngine.Rpg.Core.Serialization
{
    public class WindowsSerializationService : ISerializationService
    {
        /// <summary>
        /// Load a stat from an xml game file located in isolated storage
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Stat LoadStat(string filename)
        {
            return new Stat();
        } 
    }
}