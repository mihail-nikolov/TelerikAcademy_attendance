using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Multiverse
{
    class Program
    {
        public static Dictionary<string, int> thirteenthNumSys = new Dictionary<string, int>{
            {"CHU", 0}, {"TEL", 1}, {"OFT", 2}, 
            {"IVA", 3}, {"EMY", 4}, {"VNB", 5}, 
            {"POQ", 6}, {"ERI", 7}, {"CAD", 8},
            {"K-A", 9}, {"IIA", 10}, {"YLO", 11}, {"PLA", 12}
        };
        static void Main(string[] args)
        {
            string mystring = Console.ReadLine();
            List<string> myWordsList = new List<string>{};
            for (int i = 0; i < mystring.Length - 2; i+=3)
            {
                string tmpStr = mystring[i].ToString() + mystring[i + 1] + mystring[i + 2];
                //Console.WriteLine(tmpStr);
                myWordsList.Add(tmpStr);
            }
            if (myWordsList.Count > 0 && myWordsList.Count < 10)
            {
                double output = 0;
                for (int i = 0; i < myWordsList.Count; i++)
                {
                    string tmpStrFromList = myWordsList[i];
                   /* if (!thirteenthNumSys.ContainsKey(tmpStrFromList))
                    {
                        throw new ArgumentException();
                    }*/
                    output += thirteenthNumSys[tmpStrFromList] * Math.Pow(13, myWordsList.Count - 1 - i);
                }
                Console.WriteLine(output);
            }
        }
    }
}
