using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using RpgGameEngine.Core.Entities;
using RpgGameEngine.Core.Interfaces;

namespace RpgGameEngine.Core.Serialization
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
            try
            {
                // Specify the file path and options.
                using (var fileStream = new FileStream(filename, FileMode.Open))
                {
                    // Read the data.
                    using (XmlReader reader = XmlReader.Create(fileStream))
                    {
                        Stat stat = IntermediateSerializer.Deserialize<Stat>(reader, null);
                        reader.Close();
                        return stat;
                    }
                }

            }
            catch
            {
                return null;
            }
        } 
    }
}