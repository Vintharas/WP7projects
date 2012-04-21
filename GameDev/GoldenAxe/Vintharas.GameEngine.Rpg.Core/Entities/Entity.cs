using System.Collections.Generic;

namespace Vintharas.GameEngine.Rpg.Core.Entities
{
    /// <summary>
    /// Class that represents an rpg entity, this is a player charater, npc, monster, etc
    /// </summary>
    public class Entity
    {

        public EntityType Type { get; set; }
        public string ClassID { get; set; }
        public string RaceID { get; set; }
        public List<EntityStat> Stats { get; private set; }

        public string Name
        {
            get { return name; }
            set
            {
                if (Type == EntityType.Character)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        name = value;
                    }
                }
                else
                    name = value;
            }
        }
        private string name;


        public byte Level
        {
            get { return level; }
            set
            {
                if (Type > EntityType.Character)
                    level = value;
            }
        }
        private byte level;

        public int Experience
        {
            get { return experience; }
            set
            {
                if (Type > EntityType.Character)
                    experience = value;
            }
        }
        private int experience;

        public short BaseHP
        {
            get { return baseHP; }
            set
            {
                if (Type > EntityType.Character)
                    baseHP = value;
            }
        }
        private short baseHP;

        public short CurrentHP
        {
            get { return currentHP; }
            set
            {
                if (Type > EntityType.Character)
                    currentHP = value;
            }
        }
        private short currentHP;


        // RESISTANCES
        public EntityResistances EntityResistances { get; set; }
        // BONUSES. Any misc, offensive of defensive bonuses
        public EntityBonuses EntityBonuses { get; set; }

        public EntityAlignment Alignment { get; set; }
        public EntitySex Sex { get; set; }
        public short Age { get; set; }
        public string PortraitFilename { get; set; }
        public bool IsVendor { get; set; }
        public string SpriteFilename { get; set; }

        public Entity()
        {
            Stats = new List<EntityStat>();
        }


        public int MaxWeight()
        {
            //find the strength stat
            int str = 0;

            foreach (EntityStat stat in Stats)
            {
                if (stat.StatName.ToLower() == "strength")
                {
                    str = stat.CurrentValue;
                    break;
                }
            }

            return str * Stat.PoundsPerStatPoint;
        }

    }
}