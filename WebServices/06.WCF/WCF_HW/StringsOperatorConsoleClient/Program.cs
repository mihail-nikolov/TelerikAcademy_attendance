using StringsOperationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace StringsOperatorConsoleClient
{
    class Program
    {
        static void Main()
        {
            var stringsOperator = new StringsOperator();
            Console.WriteLine(stringsOperator.GetCountFStringContainsSecond("aabca","a"));
        }
    }
}
