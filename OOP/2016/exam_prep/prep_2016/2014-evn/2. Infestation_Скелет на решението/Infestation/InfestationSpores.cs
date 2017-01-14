using System;

namespace Infestation
{
    class InfestationSpores : ISupplement
    {
        private bool hasEffect = true;
        private int aggression = 20;
        private int power = -1;

        public  int AggressionEffect
        {
            get
            {
                if (this.hasEffect)
                {
                    return this.aggression;
                }
                else
                {
                    return 0;
                }
            }
        }

        public  int PowerEffect
        {
            get
            {
                if (this.hasEffect)
                {
                    return this.power;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int HealthEffect
        {
            get
            {
                return 0;
            }
        }

        public void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.hasEffect = false;
            }
        }
    }
}
