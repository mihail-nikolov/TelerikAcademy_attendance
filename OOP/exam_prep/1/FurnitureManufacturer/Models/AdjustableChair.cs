using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class AdjustableChair:Chair, IAdjustableChair 
    {
        public AdjustableChair(string model, MaterialType material, decimal price, decimal height, int numOfLegs)
            :base(model, material, price, height, numOfLegs)
        {
            
        }
        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
        //public override string ToString()
        //{
        //    return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}",
        //        this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        //}
    }
}
