using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Chair : FurnitureAbstract, IChair
    {
        private int numOfLegs;

        public Chair(string model, MaterialType material, decimal price, decimal height, int numOfLegs)
            :base(model, material, price, height)
        {
            this.NumberOfLegs = numOfLegs;
        }

        public override decimal Height
        {
            get
            {
                return base.Height;
            }
            protected set
            {
                base.Height = value;
            }
        }
        public int NumberOfLegs
        {
            get { return this.numOfLegs; }
            protected set { this.numOfLegs = value; }//validation legs > 0;
        }
        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        }
    }
}
