using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.CPBuilderExample
{
    class Program
    {
        static void Main()
        {
            TableConstructor constructor = new TableConstructor();
            TableBuilder builderAron = new AronBuilder();

            TableBuilder builderIKEA = new IKEABuilder();

            constructor.Construct(builderIKEA);
            constructor.Construct(builderAron);
            Console.WriteLine(builderAron.Table.ToString());
            Console.WriteLine("======================================");
            Console.WriteLine(builderIKEA.Table.ToString());
        }
    }
}
