using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main()
        {
            var mySchool = new School("PMG");
            IntArraySorter.sort(mySchool.Marks);
            foreach (var mark in mySchool.Marks)
            {
                Console.Write("{0} ",mark);
            }
            Console.WriteLine();
            Console.WriteLine("============================");
            var myUni = new University("UACEG");
            int[] convertedMarks = CovertListToArray.convert(myUni.Marks);
            IntArraySorter.sort(convertedMarks);
            foreach (var mark in convertedMarks)
            {
                Console.Write("{0} ", mark);
            }
        }
    }
}
