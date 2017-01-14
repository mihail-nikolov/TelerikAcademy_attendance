using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    static class IntArraySorter
    {
        public static void sort(int[] a)
        {
            int variableForSwap;
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i; j < a.Length; j++)
                {
                    if (a[j] > a[i])
                    {
                        variableForSwap = a[j];
                        a[j] = a[i];
                        a[i] = variableForSwap;
                    }
                }
            }
        }
    }
}
