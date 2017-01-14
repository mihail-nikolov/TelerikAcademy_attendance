namespace Cosmetics.Products
{
    using Common;
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Toothpaste : Product, IToothpaste
    {
        private IList<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.CheckIngradients(ingredients);
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredients.ToArray());
            }
        }

        private void CheckIngradients(IList<string> ingr)
        {
            foreach (var item in ingr)
            {
                string theErrMessage = string.Format(GlobalErrorMessages.InvalidStringLength, "Each Gradient name's length", 4, 12);
                Validator.CheckIfStringLengthIsValid(item, 12, 4, theErrMessage);
            }
        }

        public override string Print()
        {
            string baseStr =  base.Print();
            StringBuilder sb = new StringBuilder(baseStr);
            sb.AppendLine(string.Format("\n  * Ingredients: {0}", this.Ingredients));
            return sb.ToString().TrimEnd();
        }
    }
}
