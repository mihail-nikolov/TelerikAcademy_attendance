using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Category:ICategory
    {
        private string name;
        private List<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }
        public string Name
        {
            get { return this.name; }
            protected set
            {
                string nullMess = string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name");
                Validator.CheckIfStringIsNullOrEmpty(value, nullMess);
                string theErrMessage = string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", 2, 15);
                Validator.CheckIfStringLengthIsValid(value, 15, 2, theErrMessage);
                this.name = value;
            }
        }

        public List<IProduct> Products
        {
            get { return new List<IProduct>(this.products); }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            string nullMess = string.Format(GlobalErrorMessages.ObjectCannotBeNull, "Cosmetics");
            Validator.CheckIfNull(cosmetics, nullMess);
            string theErrMessage = string.Format(GlobalErrorMessages.ObjectCannotBeNull, "The product");
            Validator.CheckIfNull(cosmetics, theErrMessage);
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            string theErrMessage = string.Format("Product {0} does not exist in category {1}!",
                cosmetics.Name, this.Name);
            string cosmNameToDelete = cosmetics.Name;
            foreach (var cosm in this.Products)
            {
                if (cosm.Name == cosmNameToDelete)
                {
                    this.products.Remove(cosm);
                    return;
                }
            }
            throw new ArgumentException(theErrMessage);
        }

        public string Print()
        {
            string productWord = "products";
            if (this.products.Count == 1)
            {
                productWord = "product";
            }
            string strToPrint = string.Format("{0} category - {1} {2} in total",
                this.Name, this.Products.Count, productWord);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(strToPrint);
            foreach (var  product in this.Products.OrderBy(pr=>pr.Brand).ThenByDescending(pr=>pr.Price))
            {
                sb.AppendLine(product.Print().TrimEnd());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
