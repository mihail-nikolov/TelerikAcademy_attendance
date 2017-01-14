//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Wintellect.PowerCollections;

//namespace Exam_DSA_part1
//{
//    class Program
//    {
//        static int[] currentIncreasing;

//        static void Main(string[] args)
//        {
//            currentIncreasing = new int[2];
//            int n = int.Parse(Console.ReadLine());

//            int[] predictions = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
//            int money = 0;

//            for (int i = 0; i < n; i++)
//            {
//                if (i != n - 2)
//                {
//                    currentIncreasing = CheckToWhenIncreasing(i, predictions);
//                }

//            }

//            Console.WriteLine(money);
//        }

//        static int[] CheckToWhenIncreasing(int start, int[] predictions)
//        {
//            int[] answer = new int[2];
//            for (int i = start + 1; i < predictions.Length; i++)
//            {
//                if (predictions[start] > predictions[i])
//                {
//                    answer[0] = 1;
//                    answer[1] = i;
//                }
//            }
//            return answer;
//        }
//    }
//}
