using ArmyOfCreatures.Logic.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended.Creatures
{
    public class Goblin: Creature
    {
        private const int GOBLIN_ATTACK = 4;
        private const int GOBLIN_DEFENSE = 2;
        private const int GOBLIN_HEALTH_POINTS = 5;
        private const decimal GOBLIN_DAMAGE = 1.5M;
        public Goblin(int attack, int defense, int healthPoints, decimal damage)
            : base(GOBLIN_ATTACK, GOBLIN_DEFENSE, GOBLIN_HEALTH_POINTS, GOBLIN_DAMAGE)
        {

        }
    }
}
