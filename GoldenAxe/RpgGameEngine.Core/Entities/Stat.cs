using RpgGameEngine.Core.General;

namespace RpgGameEngine.Core.Entities
{
    /// <summary>
    /// Class that represents an rpg stat, something like Strength, Dexterity, Intelligence, etc
    /// </summary>
    public class Stat
    {
        public StatType Type
        {
            get { return type; }
            set { type = value; }
        }
        private StatType type;
        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrEmpty(value)) name = value; }
        }
        private string name;
        public string Abbreviation
        {
            get { return abbreviation; }
            set { if (!string.IsNullOrEmpty(value)) abbreviation = value; }
        }
        private string abbreviation;
        public string Description
        {
            get { return description; }
            set { if (!string.IsNullOrEmpty(value)) description = value; }
        }
        private string description;
        public string StatCalculation
        {
            get { return statCalculation; }
            set
            {
                if (type == StatType.Calculated)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        statCalculation = value;
                    }
                }
                else
                    statCalculation = value;
            }
        }
        private string statCalculation;

        private static readonly char[] operators = {'+', '-', '*', '/'};

        public const short MaxStatValue = (short) DiceType.d100;
        public const int PoundsPerStatPoint = 3; // Pounds of equipment Per Stat Point

        public Stat(){}

        public Stat(string name)
        {
            this.name = name;
        }


        
    }
}