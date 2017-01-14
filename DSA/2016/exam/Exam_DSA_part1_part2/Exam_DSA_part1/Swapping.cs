////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;
////using System.Threading.Tasks;
////using Wintellect.PowerCollections;

////namespace Exam_DSA_part1
////{
////    class Swapping
////    {
////        static BigList<int> numbers;
////        static int[] swapNumbers;
////        static void Main(string[] args)
////        {
////            int n = int.Parse(Console.ReadLine());
////            swapNumbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();
////            //var genNumbers = Enumerable.Range(1, n).ToList<int>();

////            //asd.GetRange
////            numbers = new BigList<int>();

////            //first Iteration:
////            int indexToSwap = swapNumbers[0] - 1;
////            int numsCountLeft = indexToSwap + 1;


////            var numsToGet = numbers.GetRange(0, numsCountLeft);
////            numbers.Add(numsToGet[indexToSwap]);
////            if (numsToGet.Count > 1)
////            {
////                numsToGet.RemoveAt(numsToGet.Count - 1);
////                numbers.AddRange(numsToGet);
////                numbers.RemoveRange(0, indexToSwap + 1);
////            }
////            else
////            {
////                numbers.RemoveAt(indexToSwap);
////            }
////            for (int i = 1; i <= n; i++)
////            {
////                numbers.Add(i);
////            }

////            bool firstIteration = true;
////            for (int i = 0; i < swapNumbers.Length; i++)
////            {
////                int num = swapNumbers[i];
////                SwapAround(firstIteration, num);

////                if (i == 0)
////                {
////                    firstIteration = false;
////                }
////            }

////            Console.WriteLine(string.Join(" ", numbers));
////        }

////        static void SwapAround(bool firsIteration, int swapNumber)
////        {
////            int indexToSwap = 0;
////            if (firsIteration)
////            {
////                //int swapNumberInt = swapNumber - '0';
////                indexToSwap = swapNumber - 1;
////            }
////            else
////            {
////                for (int i = 0; i < numbers.Count; i++)
////                {
////                    if (numbers[i] == swapNumber)
////                    {
////                        indexToSwap = i;
////                    }
////                }
////            }
////            //list char???
////            int numsCountLeft = indexToSwap + 1;

////            var numsToGet = numbers.GetRange(0, numsCountLeft);
////            numbers.Add(numsToGet[indexToSwap]);
////            if (numsToGet.Count > 1)
////            {
////                numsToGet.RemoveAt(numsToGet.Count - 1);
////                numbers.AddRange(numsToGet);
////                numbers.RemoveRange(0, indexToSwap + 1);
////            }
////            else
////            {
////                numbers.RemoveAt(indexToSwap);
////            }
////        }
////    }
////}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Wintellect.PowerCollections;

//namespace Exam_DSA_part1
//{
//    class Swapping
//    {
//        static BigList<int> numbers;
//        static int[] swapNumbers;
//        static int n = 0;

//        static void Main(string[] args)
//        {
//            n = int.Parse(Console.ReadLine());
//            swapNumbers = Console.ReadLine().Split(' ').Select(x => int.Parse(x)).ToArray();

//            numbers = new BigList<int>();
//            int numToSwap = swapNumbers[0];
//            int indexToSwap = numToSwap - 1;


            
//            bool indexToSwapTouched = false;
//            if (indexToSwap == 0)
//            {
//                indexToSwapTouched = true;
//            }

//            int numToAdd = 1;
//            while (numbers.Count < n)
//            {
//                if (!indexToSwapTouched)
//                {
//                    numbers.Add(numToAdd);
//                    numToAdd++;
//                }
//                else
//                {
//                    numbers.Add(numToSwap - numToAdd);
//                    numToAdd--;
//                }



//            }

//            for (int i = 0; i < n; i++)
//            {
//                numbers.Add()
//            }

//            for (int i = 1; i < swapNumbers.Length; i++)
//            {
//                int num = swapNumbers[i];
//                SwapAround(num);
//            }

//            Console.WriteLine(string.Join(" ", numbers));
//        }

//        static void SwapAround(int swapNumber)
//        {
//            int indexToSwap = 0;
//            for (int i = 0; i < numbers.Count; i++)
//            {
//                if (numbers[i] == swapNumber)
//                {
//                    indexToSwap = i;
//                }
//            }

//            var newNumbers = new List<int>(n);
//            int coutToGet = n - (indexToSwap + 1);
//            newNumbers.AddRange(numbers.GetRange(indexToSwap + 1, coutToGet));

//            newNumbers.Add(numbers[indexToSwap]);

//            var numsToGet = numbers.GetRange(0, indexToSwap);

//            if (numsToGet.Count != 0)
//            {
//                newNumbers.AddRange(numsToGet);
//            }

//            numbers = new List<int>(newNumbers);


//            //numbers.Add(numsToGet[indexToSwap]);
//            //if (numsToGet.Count > 1)
//            //{
//            //    numsToGet.RemoveAt(numsToGet.Count - 1);
//            //    numbers.AddRange(numsToGet);
//            //    numbers.RemoveRange(0, indexToSwap + 1);
//            //}
//            //else
//            //{
//            //    numbers.RemoveAt(indexToSwap);
//            //}
//        }
//    }
//}
