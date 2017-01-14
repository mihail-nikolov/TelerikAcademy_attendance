using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class WeaponrySkill : ISupplement
    {
        public int AggressionEffect
        {
            get
            {
                return 0;
            }
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
            get
            {
                return 0;
            }
        }

        public void ReactTo(ISupplement otherSupplement)
        {
            
        }
    }
}
