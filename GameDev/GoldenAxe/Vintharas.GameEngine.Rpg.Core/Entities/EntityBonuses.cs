using System.Collections.Generic;

namespace Vintharas.GameEngine.Rpg.Core.Entities
{
    public class EntityBonuses
    {
        // BONUSES. Any misc, offensive of defensive bonuses
        private List<Bonus> defBonuses;
        private List<Bonus> offBonuses;
        private List<Bonus> miscBonuses;

        public List<Bonus> DefensiveBonuses
        {
            get { return defBonuses; }
            set { defBonuses = value; }
        }

        public List<Bonus> OffensiveBonuses
        {
            get { return offBonuses; }
            set { offBonuses = value; }
        }

        public List<Bonus> MiscBonuses
        {
            get { return miscBonuses; }
            set { miscBonuses = value; }
        }

        public short GetTotalOffBonus()
        {
            short total = 0;
            Bonus bns;

            if (!(offBonuses == null))
            {
                for (short i = 0; i < offBonuses.Count; i++)
                {
                    bns = (Bonus)offBonuses[i];
                    total += bns.Amount;
                }
            }

            return total;
        }

        public short GetTotalMiscBonus()
        {
            short total = 0;
            Bonus bns;

            if (!(miscBonuses == null))
            {
                for (short i = 0; i < miscBonuses.Count; i++)
                {
                    bns = (Bonus)miscBonuses[i];
                    total += bns.Amount;
                }
            }

            return total;
        }

        public short GetTotalDefBonus()
        {
            short total = 0;
            Bonus bns;

            if (!(defBonuses == null))
            {
                for (short i = 0; i < defBonuses.Count; i++)
                {
                    bns = (Bonus)defBonuses[i];
                    total += bns.Amount;
                }
            }

            return total;
        }

        public void AddDefensiveBonus(Bonus bonus)
        {
            if (defBonuses == null)
                defBonuses = new List<Bonus>();

            defBonuses.Add(bonus);
        }

        public void SetDefensiveBonuses(List<Bonus> bonuses)
        {
            if (bonuses != null)
            {
                defBonuses = new List<Bonus>();

                foreach (Bonus bonus in bonuses)
                    defBonuses.Add(bonus);
            }
        }

        public void AddOffensiveBonus(Bonus bonus)
        {
            if (offBonuses == null)
                offBonuses = new List<Bonus>();

            offBonuses.Add(bonus);
        }

        public void SetOffensiveBonuses(List<Bonus> bonuses)
        {
            if (bonuses != null)
            {
                offBonuses = new List<Bonus>();

                foreach (Bonus bonus in bonuses)
                    offBonuses.Add(bonus);
            }
        }

        public void AddMiscBonus(Bonus bonus)
        {
            if (miscBonuses == null)
                miscBonuses = new List<Bonus>();

            miscBonuses.Add(bonus);
        }

        public void SetMiscBonuses(List<Bonus> bonuses)
        {
            if (bonuses != null)
            {
                miscBonuses = new List<Bonus>();

                foreach (Bonus bonus in bonuses)
                    miscBonuses.Add(bonus);
            }
        }
    }
}