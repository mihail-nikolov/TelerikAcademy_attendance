using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class AddAttackWhenSkip : Specialty
    {
        private int points;

        public AddAttackWhenSkip(int points)
        {
            this.Points = points;
        }

        public int Points
        {
            get { return this.points; }
            private set
            {
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentException("rounds has to be in interval (0; 10]");
                }
                this.points = value;
            }
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            if (skipCreature == null)
            {
                throw new ArgumentNullException("skipCreature");
            }

            skipCreature.PermanentAttack += this.Points;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.Points);
        }
    }
}
