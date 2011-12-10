using System;
using System.Data.SqlTypes;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using RpgGameEngine.Core.Entities;

namespace RpgGameEngine.Core.General
{
    public static class Helpers
    {
        private static Random rnd = new Random();
        
        /// <summary>
        /// Get a dice throw
        /// </summary>
        /// <param name="dice"></param>
        /// <returns></returns>
        public static short GetRandomNumber(DiceType dice)
        {
            return (short) rnd.Next(1, (int) dice + 1);
        }

        /// <summary>
        /// Get a random number between the min and max parameters
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomNumber(int min, int max)
        {
            return rnd.Next(min, max + 1);
        }       

        
    }
}