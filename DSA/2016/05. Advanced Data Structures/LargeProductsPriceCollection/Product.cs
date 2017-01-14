using System;

namespace LargeProductsPriceCollection
{
    public class Product : IComparable<Product>
    {
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public int CompareTo(Product other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format("{0}: {1} -> {2:C}", this.GetType().Name, this.Name, this.Price);
        }
    }
}
