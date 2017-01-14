namespace Cosmetics.Products
{
    using Cosmetics.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ShoppingCart : IShoppingCart
    {
        private List<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            foreach (var prod in this.products)
            {
                if (product.Name == prod.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveProduct(IProduct product)
        {
            foreach (var item in this.products)
            {
                if (item.Name == product.Name)
                {
                    this.products.Remove(item);
                    break;         
                }
            }
        }

        public decimal TotalPrice()
        {
            decimal price = 0;
            foreach (var item in this.products)
            {
                price += item.Price;
            }
            return price;
        }
    }
}
