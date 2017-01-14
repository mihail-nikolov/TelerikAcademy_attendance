using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    [Version("5.6")]
    class SampleClass
    {
        public static void Sample()
        {
            Type type = typeof(SampleClass);
            object[] attributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attr in attributes)
            {
                Console.WriteLine("The version is {0}. ", attr.Version);
            }
        }
    }
}