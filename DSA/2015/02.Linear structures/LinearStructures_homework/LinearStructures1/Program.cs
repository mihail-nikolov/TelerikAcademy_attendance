namespace LinearStructures1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {

        }

        public static void SortIncreasing(List<int> ListWithIntegeres)
        {
            ListWithIntegeres.OrderBy(n => n <= n + 1);
        }

        public static void RemoveAllNegatives(List<int> ListWithIntegeres)
        {
            ListWithIntegeres.RemoveAll(n => n < 0);
        }

        public static int CalculateAverageOfIntegerList(IList<int> ListWithIntegeres, int sum)
        {
            int average = sum / (ListWithIntegeres.Count);
            return average;
        }

        public static int CalculateSumOfIntegerList(IList<int> ListWithIntegeres)
        {
            int sum = 0;
            foreach (var num in ListWithIntegeres)
            {
                sum += num;
            }
            return sum;
        }

        public static void SequenceConsoleReader(IList<int> ListWithIntegeres)
        {
            string inputString = "";
            while (true)
            {
                inputString = Console.ReadLine();
                if (String.IsNullOrEmpty(inputString))
                {
                    break;
                }
                try
                {
                    int readNumber = Int32.Parse(inputString);
                    ListWithIntegeres.Add(readNumber);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        }
    }


}
