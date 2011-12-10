﻿using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using RpgGameEngine.Core.Entities;
using RpgGameEngine.Core.Interfaces;

namespace RpgGameEngine.Core.Serialization 
{
    /// <summary>
    /// Serialization service for windows phone 7. Makes use of the phone isolated storage
    /// </summary>
    public class PhoneSerializationService : ISerializationService
    {
        /// <summary>
        /// Load a stat from an xml game file located in isolated storage
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Stat LoadStat(string filename)
        {
            // Obtain a virtual store for the application.
            IsolatedStorageFile myStore = IsolatedStorageFile.GetUserStoreForApplication();
            try
            {
                // Specify the file path and options.
                using (var fileStream = new IsolatedStorageFileStream(filename, FileMode.Open, myStore))
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