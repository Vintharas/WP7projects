using System.Collections.Generic;
using RpgGameEngine.Core.Mechanics;

namespace RpgGameEngine.Core.Entities
{
    public class EntityResistances
    {
        // RESISTANCES
        public byte DiseaseResistance { get; set; }
        public byte PoisonResistance { get; set; }
        public byte MagicResistance { get; set; }
        // Affects is empty for these
        public List<Resister> DamageResistances { get; private set; }
        public List<Damager> DamageWeaknesses { get; private set; }

        public EntityResistances()
        {
            DamageResistances = new List<Resister>();
            DamageWeaknesses = new List<Damager>();
        }

        public void AddDamageResistance(Resister resistance)
        {
            if (DamageResistances == null)
                DamageResistances = new List<Resister>();

            DamageResistances.Add(resistance);
        }

        public void SetDamageResistances(List<Resister> resistances)
        {
            if (resistances != null)
            {
                DamageResistances = new List<Resister>();

                foreach (Resister resistance in resistances)
                    DamageResistances.Add(resistance);
            }
        }

        public void AddDamageWeakness(Damager weakness)
        {
            if (DamageWeaknesses == null)
                DamageWeaknesses = new List<Damager>();

            DamageWeaknesses.Add(weakness);
        }

        public void SetDamageWeaknesses(List<Damager> weaknesses)
        {
            if (weaknesses != null)
            {
                DamageWeaknesses = new List<Damager>();

                foreach (Damager weakness in weaknesses)
                    DamageWeaknesses.Add(weakness);
            }
        }
    }
}