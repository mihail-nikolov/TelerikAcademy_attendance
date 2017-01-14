using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class ShoppingCart:IShoppingCart
    {
        private List<IProduct> cartProducts;
        public void AddProduct(IProduct product)
        {
            this.cartProducts.Add(product);
        }

        public ShoppingCart()
        {
            this.cartProducts = new List<IProduct>();
        }

        public void RemoveProduct(IProduct product)
        {
            string cosmNameToDelete = product.Name;
            foreach (var cosm in this.cartProducts)
            {
                if (cosm.Name == cosmNameToDelete)
                {
                    this.cartProducts.Remove(cosm);
                    break;
                }
            }
        }

        public bool ContainsProduct(IProduct product)
        {
            foreach (var prod in this.cartProducts)
            {
                if (product.Name == prod.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public decimal TotalPrice()
        {
            decimal totPrice = 0;
            foreach (var pr in this.cartProducts)
            {
                totPrice += pr.Price;
            }
            return totPrice;
        }
    }
}
