using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePatternExample
{
    public class ProductsController
    {
        public void GetProducts()
        {
            Console.WriteLine(@"Got:
- a cup of yogurt,
- a cup of oatnuts,
- a couple slices of fresh fruit,
- а pinch of cinammon,
- a spoon of honey");
        }

    }
}
