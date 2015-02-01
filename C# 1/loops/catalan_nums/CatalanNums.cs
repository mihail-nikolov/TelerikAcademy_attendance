using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catalan_nums
{
    class CatalanNums
    {
        static void Main(string[] args)
        {
            int n = 5;
            int k = n + 1;
            int m = 2 * n;
            int nFactRes = 1;
            int kFactRes = 1;
            int mFaktRes = 1;

            for (int i = n; i >= 1; i--)
            {
                nFactRes *= i;
            }
            for (int i = k; i >= 1; i--)
            {
                kFactRes *= i;
            }
            for (int i = m; i >= 1; i--)
            {
                mFaktRes *= i;
            }
            Console.WriteLine(mFaktRes / (kFactRes * nFactRes));
        }
    }
}
