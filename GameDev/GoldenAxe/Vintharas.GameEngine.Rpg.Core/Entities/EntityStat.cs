using System.Collections.Generic;

namespace Vintharas.GameEngine.Rpg.Core.Entities
{
    public class EntityStat
    {
        public string StatName
        {
            get { return stat; }
            set { if (!string.IsNullOrEmpty(value)) stat = value; }
        }
        private string stat;
        public short BaseValue
        {
            get { return value; }
            set { value = value; }
        }
        private short value;

        public List<Bonus> Bonuses
        {
            get { return bonuses; }
            set { bonuses = value; }
        }
        private List<Bonus> bonuses;

        /// <summary>
        /// Get the current value of the stat -> Base Value plus Bonuses
        /// </summary>
        public short CurrentValue
        {
            get
            {
                short val = value;

                if (bonuses != null)
                {
                    foreach (Bonus bonus in bonuses)
                        val += bonus.Amount;
                }

                return val;
            }
        }


        public EntityStat()
        {
            
        }

        public EntityStat(string stat, short value)
        {
            this.stat = stat;
            this.value = value;
        }

        public void IncreaseValue(short val)
        {
            value += val;
            if (value > Stat.MaxStatValue)
                value = Stat.MaxStatValue;
        }

        public void ReduceValue(short val)
        {
            value -= val;
            if (value < 1)
                value = 1;
        }

        public void AddBonus(Bonus bonus)
        {
            if (bonuses == null)
                bonuses = new List<Bonus>();

            bonuses.Add(bonus);
        }

        /// <summary>
        /// Update status of bonus
        /// </summary>
        /// <param name="time"></param>
        public void Update(float time)
        {
            if (bonuses == null)
                return;
            Bonus bonus;
            for (int i = bonuses.Count - 1; i >= 0; i--)
            {
                bonus = bonuses[i];
                bonus.ElapsedTime += time;
                if ((int)bonus.ElapsedTime >= bonus.Duration)
                    bonuses.Remove(bonus);
                else
                    bonuses[i] = bonus;
            }
        }


    }
}