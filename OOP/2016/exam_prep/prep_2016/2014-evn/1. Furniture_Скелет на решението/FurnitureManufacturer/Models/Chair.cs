using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Chair : Furniture, IChair, IFurniture
    {
        public Chair(string model, string materialType, decimal price, decimal height, int numberOfLegs) 
            : base(model, materialType, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; private set; }

        public override string ToString()
        {
            string st = base.ToString();
            st += string.Format(", Legs: {0}", this.NumberOfLegs);
            return st;
        }
    }
}
