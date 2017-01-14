namespace Cosmetics.Products
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common;

    public abstract class Product : IProduct
    {
        private string name;
        private string brand;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                string nullMess = string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product brand");
                Validator.CheckIfStringIsNullOrEmpty(value, nullMess);
                string theErrMessage = string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", 2, 10);
                Validator.CheckIfStringLengthIsValid(value, 10, 2, theErrMessage);
                this.brand = value;
            }
        }

        public GenderType Gender { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                string nullMess = string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Product name");
                Validator.CheckIfStringIsNullOrEmpty(value, nullMess);
                string theErrMessage = string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", 3, 10);
                Validator.CheckIfStringLengthIsValid(value, 10, 3, theErrMessage);
                this.name = value;
            }
        }

        public virtual decimal Price { get; protected set; }

        public virtual string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            sb.AppendLine(string.Format("  * Price: ${0}", this.Price));
            sb.AppendLine(string.Format("  * For gender: {0}", this.Gender));
            return sb.ToString().TrimEnd();
        }
    }
}
