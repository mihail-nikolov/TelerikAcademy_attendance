using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Table : FurnitureAbstract, ITable 
    {
        private decimal length;
        private decimal width;
        //private decimal area;

        public Table(string model, MaterialType material, decimal price, decimal height, decimal len, decimal wid)
            :base(model, material, price, height)
        {
            this.Length = len;
            this.Width = wid;
        }
        
        public decimal Length
        {
            get { return this.length; }
            protected set
            {
                if (value <= 0 )
                {
                    throw new ArgumentException("Length cannot be less or equal to 0.00 m.");
                }
                this.length = value; 
            }
        }

        public decimal Width
        {
            get { return this.width; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be less or equal to 0.00 m.");
                }
                this.width = value;
            }
        }

        public decimal Area
        {
            get { return this.Length * this.Width; }
        }
        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}", 
                this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area);
        }
    }
}
