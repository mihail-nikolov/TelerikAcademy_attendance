using System.Collections.Generic;
using System.Linq;

namespace Infestation
{
    abstract class InfestingUnit : Unit
    {
        public InfestingUnit(string id, UnitClassification unitType, int health)
            : base(id, unitType, health, 1, 1)
        {
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = false;

            if (this.Id != unit.Id && this.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification))
            {
                attackUnit = true;
            }
            return attackUnit;
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));
            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MaxValue, 0, 0);
            foreach (var unit in attackableUnits)
            {
                if (unit.Health < optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
