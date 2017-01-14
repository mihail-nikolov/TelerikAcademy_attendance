using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePatternExample
{
    class Program
    {
        static void Main()
        {
            MuesliMaker myMuesli = new MuesliMaker();
            myMuesli.MakeMuesli();
        }
    }
}
