using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nf_kf_nkf
{
    class NfKfNKf
    {
        static void Main(string[] args)
        {
            int n = 10;
            int k = 6;
            int nMinusK = n - k;
            int nMinusKRes = 1;
            int nFactRes = 1;
            int kFactRes = 1;

            for (int i = n; i >= 1; i--)
            {
                nFactRes *= i;
            }
            for (int i = k; i >= 1; i--)
            {
                kFactRes *= i;
            }
            for (int i = nMinusK; i >= 1; i--)
            {
                nMinusKRes *= i;
            }
            Console.WriteLine(nFactRes / (kFactRes * nMinusKRes));
        }
    }
}
