using FurnitureManufacturer.Interfaces;
using System;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        private decimal height;
        private decimal price;
        private string model;

        public Furniture(string model, string materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = materialType;
            this.Price = price;
            this.Height = height;
        }
        public decimal Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("height > 0");
                }
                this.height = value;
            }
        }

        public string Material { get; private set; }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new Exception("model cannot be null or < 3 sym");
                }
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("price > 0");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}
