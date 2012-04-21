using System.Collections.Generic;
using Vintharas.GameEngine.Rpg.Core.General;

namespace Vintharas.GameEngine.Rpg.Core.Entities
{
    /// <summary>
    /// Class that represents and rpg entity class, i.e. warrior, barbarian, wizard, thief, etc
    /// 
    /// It contains the name, description, hp and stats modifications based on a class
    /// </summary>
    public class EntityClass
    {
        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrEmpty(value)) name = value; }
        }
        private string name = "";
        public string Description
        {
            get { return description; }
            set { if (!string.IsNullOrEmpty(value)) description = value; }
        }

        private string description = "";
        public DiceType HPDice
        {
            get { return hpDice; }
            set { hpDice = value; }
        }

        private DiceType hpDice;
        public Dictionary<string, int> StatModifiers
        {
            get { return statModifiers; }
            set { statModifiers = value; }
        }

        private Dictionary<string, int> statModifiers;

        public int StatModifiersCount
        {
            get { return (statModifiers != null) ? statModifiers.Count : 0; }
        }

        public EntityClass()
        {
            //empty constructor for use with the toolset. During the game the constructor below is used.
        }

        public EntityClass(string name)
        {
            this.name = name;
        }

        public int GetStatModifier(string name)
        {
            int value = 0;

            if (statModifiers != null)
                statModifiers.TryGetValue(name, out value);

            return value;
        }

        public void AddStatModifier(string name, int value)
        {
            if (statModifiers == null)
                statModifiers = new Dictionary<string, int>();

            statModifiers.Add(name, value);
        }

        public void RemoveStatModifier(string name)
        {
            if (statModifiers == null)
                return;

            statModifiers.Remove(name);
        }

        public void ClearStatModifiers()
        {
            if (statModifiers != null)
                statModifiers.Clear();
        }

        public Dictionary<string, int> GetStatMods()
        {
            return statModifiers;
        }
    }
}