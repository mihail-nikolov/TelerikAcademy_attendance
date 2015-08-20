using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Toothpaste : ProductAbstr, IToothpaste
    {
        private IList<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.IngredientsList = ingredients;
        }
        public string Ingredients
        {
            get { return string.Join(", ", this.ingredients); }
        }
        public IList<string> IngredientsList
        {
            get { return new List<string>(this.ingredients); }
            protected set
            {
                this.CheckIngredients(value);
                this.ingredients = value;
            }
        }

        private void CheckIngredients(IList<string> ingredients)
        {
            string theErrMessage = string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", 4, 12);
            
            foreach (var ing in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(ing, 12, 4, theErrMessage);
            }
        }
        public override string Print()
        {
            string baseStr = base.Print();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(baseStr);
            sb.AppendLine(string.Format("  * Ingredients: {0} ", this.Ingredients));
            return sb.ToString().TrimEnd();
        }
    }
}
