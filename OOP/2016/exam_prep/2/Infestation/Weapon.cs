using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Weapon:Supplement
    {
        public Weapon()
            :base(0, 0, 0)
        {

        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            WeaponrySkill weapSkill = otherSupplement as WeaponrySkill;
            if (weapSkill!=null)
            {
                weapSkill.AggressionEffect += 3;
                weapSkill.PowerEffect += 10;
            }
        }
    }
}
