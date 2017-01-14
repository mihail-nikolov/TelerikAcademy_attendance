using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal CONVERTED_HEIGHT = 0.10M; 
        private bool isConverted;
        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numOfLegs)
            :base(model, material, price, height, numOfLegs)
        {
            this.isConverted = false;
        }

        public override decimal Height
        {
            get
            {
                if (this.IsConverted)
                {
                    return CONVERTED_HEIGHT;
                }
                return base.Height;
            }
            protected set
            {
                base.Height = value;
            }
        } 
        public bool IsConverted
        {
            get {return this.isConverted; }
            private set { isConverted = value; }
        }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.IsConverted = false;
            }
            else
            {
                this.isConverted = true;
            }
        }
        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height,
                this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal");
        }
    }
}
