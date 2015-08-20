using ArmyOfCreatures.Logic.Creatures;
using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class AncientBehemoth:Creature
    {
        private const int ACIENT_BEHEMOTH_ATTACK = 19;
        private const int ACIENT_BEHEMOTH_DEFENSE = 19;
        private const int ACIENT_BEHEMOTH_HEALTH_POINTS = 40;
        private const decimal ACIENT_BEHEMOTH_DAMAGE = 300;
        public AncientBehemoth(int attack, int defense, int healthPoints, decimal damage)
            : base(ACIENT_BEHEMOTH_ATTACK, ACIENT_BEHEMOTH_DEFENSE, 
            ACIENT_BEHEMOTH_HEALTH_POINTS, ACIENT_BEHEMOTH_DAMAGE)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(80));
            this.AddSpecialty(new DoubleDefenseWhenDefending(5)); 
        }
    }
}
