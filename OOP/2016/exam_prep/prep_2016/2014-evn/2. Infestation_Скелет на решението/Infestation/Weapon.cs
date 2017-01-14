using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Weapon : ISupplement
    {
        public int AggressionEffect
        {
            get; set;
        }

        public int HealthEffect
        {
            get
            {
                return 0;
            }
        }

        public int PowerEffect
        {
            get; set;
        }

        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement.GetType().Name == "WeaponrySkill")
            {
                this.PowerEffect = 10;
                this.AggressionEffect = 3;
            }
        }
    }
}
