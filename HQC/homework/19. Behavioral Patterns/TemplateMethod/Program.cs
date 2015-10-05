using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main()
        {
            WhiteBreadMaker myWhiteBreadMaker = new WhiteBreadMaker();
            WholegrainBreadMaker myWholegrainBreadMaker = new WholegrainBreadMaker();
            myWhiteBreadMaker.MakeBread();
            Console.WriteLine();
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine();
            myWholegrainBreadMaker.MakeBread();
        }
    }
}
