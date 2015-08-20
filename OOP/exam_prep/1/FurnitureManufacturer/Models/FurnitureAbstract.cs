using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Interfaces;
using System.Globalization;
using System.Threading;

namespace FurnitureManufacturer.Models
{

    public abstract class FurnitureAbstract : IFurniture
    {

        private MaterialType material;
        private string model;
        private decimal price;
        private decimal height;

        public FurnitureAbstract(string model, MaterialType material, decimal price, decimal height)
        {
            this.Model = model;
            this.material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get { return this.model; }
            protected set
            {
                if (value == null || value == "" || value.Length <= 3)
                {
                    throw new ArgumentException("enter valid model with len > 3");
                }
                this.model = value;
            }
        }

        public string Material
        {
            get { return this.material.ToString(); }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("price have to be > 0.");
                }
                this.price = value;
            }
        }

        public virtual decimal Height
        {
            get { return this.height; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be less or equal to 0.00 m.");
                }
                this.height = value;
            }
        }
        //public override string ToString()
        //{
        //    return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
        //        this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        //}
    }
}
