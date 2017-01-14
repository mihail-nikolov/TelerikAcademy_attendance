namespace Cosmetics.Products
{
    using Common;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Category : ICategory
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
            get
            {
                return this.name;
            }
            private set
            {
                string nullMess = string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category name");
                Validator.CheckIfStringIsNullOrEmpty(value, nullMess);
                string theErrMessage = string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", 2, 15);
                Validator.CheckIfStringLengthIsValid(value, 15, 2, theErrMessage);
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            Validator.CheckIfNull(cosmetics, "product object should not be null");
            this.products.Add(cosmetics);
        }

        public string Print()
        {
            StringBuilder strb = new StringBuilder();
            string countWord = "products";
            int prodCount = this.products.Count;
            if (prodCount == 1)
            {
                countWord = "product";
            }
            strb.AppendLine(string.Format("{0} category - {1} {2} in total", this.Name, prodCount, countWord));
            foreach (var product in this.products.OrderBy(pr => pr.Brand).ThenByDescending(pr => pr.Price))
            {
                strb.AppendLine(product.Print());
            }
            return strb.ToString().TrimEnd();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            string nullMess = string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name);
            var product = this.products.Find(x => x.Name == cosmetics.Name);
            Validator.CheckIfNull(product);
            this.products.RemoveAll(x => x.Name == cosmetics.Name);
        }
    }
}
