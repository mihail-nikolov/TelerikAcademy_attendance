using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    public class WhiteBreadMaker : BreadMaker
    {
        public override void SelectIngredients()
        {
            Console.WriteLine(@"Selecting:
- 2 teaspoons dry east
- 2 teaspoon sugar
- 1 cup lakewarm water
- 2 tablespoons butter
- 6 cups whole-wheat flour
- 1 teaspoons salt");
        }

        public override void FermentDough()
        {
            Console.WriteLine("Cover the bowl and let the dough rise in a warm spot until doubled in bulk, about one hour...");
        }

        public override void PreshapeDough()
        {
            Console.WriteLine("Divide the dough in two and shape each half into a loose ball...");
        }

        public override void RestDough()
        {
            Console.WriteLine("Let the balls rest for 10 minutes...");
        }

        public override void FinalShapeDough()
        {
            Console.WriteLine("Shape each ball of dough into a loaf (see this tutorial for step-by-step instructions) and transfer to the loaf pans...");
        }

        public override void FinalFermentDough()
        {
            Console.WriteLine("Let the loaves rise a second time until they start to dome over the edge of the pan, 30-40 minutes...");
        }

        public override void Bake()
        {
            Console.WriteLine("Heat the oven to 425° F about halfway through the second rise. Slash the tops of the loaves with a serrated knife and put them in the oven. Immediately turn down the heat to 375°F and bake for 30-35 minutes...");
        }
    }
}
