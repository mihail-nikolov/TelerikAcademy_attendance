using ArmyOfCreatures.Logic;
using ArmyOfCreatures.Logic.Battles;
using System.Collections.Generic;
using System.Linq;

namespace ArmyOfCreatures.Tests.Mocked
{
    public class MockedBattleManager : BattleManager
    {

        public MockedBattleManager(ICreaturesFactory factory, ILogger logger) :
            base(factory, logger)
        {
            this.Creatures = new List<ICreaturesInBattle>();
        }

        public ICollection<ICreaturesInBattle> Creatures { get; set; }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            return this.Creatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
        }
    }
}
