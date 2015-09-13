namespace Abstract_factory
{
    using Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            FactoryBG myFactory = new FactoryBG("table factory Sofia");
            FactoryGermany myGermanFactory = new FactoryGermany("table factory Berlin");
            GlassTable myNewGlassTable = myFactory.createGlassTable();
            Console.WriteLine(myNewGlassTable.toString());
            Console.WriteLine("=====================================");
            myNewGlassTable = myGermanFactory.createGlassTable();
            Console.WriteLine(myNewGlassTable.toString());
        }
    }
}
