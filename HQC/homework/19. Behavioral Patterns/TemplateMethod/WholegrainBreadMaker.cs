using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public class WholegrainBreadMaker : BreadMaker
    {

        public override void SelectIngredients()
        {
            Console.WriteLine(@"Selecting:
- 2 teaspoons dry east
- 1 teaspoon sugar
- 1 and 1/2 cup lakewarm water
- 2 tablespoons olive oil
- 250 grams whole-wheat flour
- 250 grams bread flour
- 2 teaspoons salt");
        }

        public override void FermentDough()
        {
            Console.WriteLine("Cover tightly with plastic and let rise in a warm spot for 1 1/2 to 2 hours, or in the refrigerator for 4 to 8 hours, until doubled...");
        }

        public override void PreshapeDough()
        {
            Console.WriteLine("Shape in balls with the size of a fist...");
        }

        public override void RestDough()
        {
            Console.WriteLine("Cover with lightly oiled plastic and let the dough rest for 15 minutes...");
        }

        public override void FinalShapeDough()
        {
            Console.WriteLine("Roll or press out the dough into a rectangle the size of the sheet pan...");
        }

        public override void FinalFermentDough()
        {
            Console.WriteLine("Cover with a damp towel and let rest for 30 minutes...");
        }

        public override void Bake()
        {
            Console.WriteLine("Preheat the oven to 425 degrees, preferably with a baking stone in it. Bake, setting the pan on top of the baking stone (if using), for 20 to 25 minutes, until deep golden brown...");
        }
    }
}
