using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePatternExample
{
    public class PrepareController
    {
        public void PutProducts()
        {
            Console.WriteLine("Putting all products in a cup...");
        }

        public void MixProducts()
        {
            Console.WriteLine("Stirring up the products...");
        }
    }
}
