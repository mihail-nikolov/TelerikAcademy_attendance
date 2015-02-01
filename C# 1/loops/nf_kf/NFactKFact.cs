using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nf_kf
{
    class NFactKFact
    {
        static void Main(string[] args)
        {
            int n = 5;
            int k = 2;
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
            Console.WriteLine(nFactRes/kFactRes);
        }
    }
}
