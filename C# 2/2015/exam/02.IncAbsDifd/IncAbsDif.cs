using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IncAbsDifd
{
    class IncAbsDif
    {
        static int[] GetAbsSeq(int[] seq)
        {
            int[] absSeq = new int[seq.Length - 1];
            for (int i = 1; i < seq.Length; i++)
            {
                absSeq[i - 1] = Math.Abs(seq[i] - seq[i - 1]);
            }
            return absSeq;
        }
        static bool IsInc(int[] seq)
        {
            bool answer = true;
            for (int i = 1; i < seq.Length; i++)
            {
                bool answer1 = seq[i] - seq[i - 1] >= 0;
                bool answer2 = seq[i] - seq[i - 1] <= 1;
                if (answer1 == false | answer2 == false)
                {
                    return false;
                }
            }
            return answer;
        }
        static void Main()
        {
            int numSeq= int.Parse(Console.ReadLine());
            for (int i = 0; i < numSeq; i++)
            {
                string seq = Console.ReadLine();
                string[] seqArr = seq.Split(' ');
                int[] myInts = Array.ConvertAll(seqArr, int.Parse);
                int[] absSeq = GetAbsSeq(myInts);
               /* foreach (var item in absSeq)
                {
                    Console.WriteLine(item);
                }*/
                Console.WriteLine(IsInc(absSeq));
            }
        }
    }
}
