using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class AdjustableChair : Chair, IAdjustableChair, IFurniture, IChair
    {
        public AdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
    }
}
