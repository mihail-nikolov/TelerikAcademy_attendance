using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel.Extended
{
    public class Weapon : Item
    {
        const int moneyValue = 10;

        public Weapon(string name, Location location = null) 
            : base(name, Weapon.moneyValue, ItemType.Weapon, location)
        {
        }
    }
}
