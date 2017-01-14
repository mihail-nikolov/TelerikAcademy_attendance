using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyOfCreatures.Logic.Battles;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleDamage: Specialty
    {
        private int rounds;

        public DoubleDamage(int rounds)
        {
            if (rounds <= 0 || rounds > 10)
            {
                throw new ArgumentException("rounds has to be in interval (0; 10]");
            }
            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(
           ICreaturesInBattle attackerWithSpecialty,
           ICreaturesInBattle defender,
           decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            this.rounds--;
            if (this.rounds >= 0)
            {
                return currentDamage * 2;
            }
            
            return currentDamage;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.rounds);
        }
    }
}
