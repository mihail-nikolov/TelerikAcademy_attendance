using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public class Table : Furniture, IFurniture, ITable
    {
        public Table(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public decimal Length { get; private set; }

        public decimal Width { get; private set; }

        public override string ToString()
        {
            string st = base.ToString();
            st += string.Format(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);
            return st;
        }
    }
}
