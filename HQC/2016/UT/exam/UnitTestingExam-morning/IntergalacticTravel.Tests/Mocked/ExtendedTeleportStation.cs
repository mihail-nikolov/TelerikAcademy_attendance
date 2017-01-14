using IntergalacticTravel.Contracts;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.Mocked
{
    public class ExtendedTeleportStation : TeleportStation, ITeleportStation
    {
        public ExtendedTeleportStation(IBusinessOwner owner, IEnumerable<IPath> galacticMap, ILocation location) :
            base(owner, galacticMap, location)
        {
        }

        public IBusinessOwner Owner
        {
            get { return this.owner; }
        }

        public IEnumerable<IPath> GalacticMap
        {
            get { return this.galacticMap; }
        }

        public ILocation Location
        {
            get { return this.location; }
        }
    }
}
