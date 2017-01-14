namespace TradeAndTravel.Extended
{
    public class Wood : Item
    {
        const int initialMoneyValue = 2;

        public Wood(string name, Location location = null)
            : base(name, Wood.initialMoneyValue, ItemType.Wood, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            if (interaction == "drop" && this.Value > 0)
            {
                this.Value--;
            }
        }
    }
}
