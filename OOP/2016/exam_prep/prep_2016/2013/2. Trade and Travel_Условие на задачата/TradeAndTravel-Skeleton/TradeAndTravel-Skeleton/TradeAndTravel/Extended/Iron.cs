namespace TradeAndTravel.Extended
{
    public class Iron : Item
    {
        const int moneyValue = 3;

        public Iron(string name, Location location = null) 
            : base(name, Iron.moneyValue, ItemType.Weapon, location)
        {
        }
    }
}
