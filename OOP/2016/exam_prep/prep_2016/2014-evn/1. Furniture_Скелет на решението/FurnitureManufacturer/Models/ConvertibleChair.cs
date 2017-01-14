using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair, IFurniture, IChair
    {
        private decimal normalHeight;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            this.normalHeight = this.Height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            if (!this.IsConverted)
            {
                this.IsConverted = true;
                this.Height = 0.10m;
            }
            else
            {
                this.IsConverted = false;
                this.Height = normalHeight;
            }
        }

        public override string ToString()
        {
            string st =  base.ToString();
            st += string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
            return st;
        }
    }
}
