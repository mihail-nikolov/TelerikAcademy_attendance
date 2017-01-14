namespace Computers.Logic.Components
{
    public class RAM
    {
        private int value;

        public RAM(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; protected set; }

        internal void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        internal int LoadValue()
        {
            return this.value;
        }
    }
}