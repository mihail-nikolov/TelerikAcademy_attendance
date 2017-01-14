using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    //The Abstract class
    public abstract class BreadMaker
    {
        public abstract void SelectIngredients();

        public void MixDough()
        {
            Console.WriteLine("Combining all ingredients and mixing...");
        }

        public abstract void FermentDough();

        public abstract void PreshapeDough();

        public abstract void RestDough();

        public abstract void FinalShapeDough();

        public abstract void FinalFermentDough();


        public abstract void Bake();

        public void Cool()
        {
            Console.WriteLine("Cooling the bread to room temperature...");
        }

        //The 'Template' method
        public void MakeBread()
        {
            SelectIngredients();
            MixDough();
            FermentDough();
            PreshapeDough();
            RestDough();
            FinalFermentDough();
            FinalShapeDough();
            Bake();
            Cool();
        }

    }
}
