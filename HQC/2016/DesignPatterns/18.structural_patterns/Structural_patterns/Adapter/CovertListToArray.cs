using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public static class CovertListToArray
    {
        public static int[] convert(List<int> a)
        {
            int[] b = a.ToArray();
            return b;
        }
    }
}
