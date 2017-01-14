using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.VariablesDataExpressionsAndConstantsHW
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public void PrintStatistics(double[] numbers, int count)
        {
            double max = numbers[0];
            for (int i = 1; i < count; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            PrintMax(max);

            double min = numbers[0];
            for (int i = 0; i < count; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            PrintMin(min);

            double sum = 0;
            for (int i = 0; i < count; i++)
            {
                sum += numbers[i];
            }
            double average = sum / count;
            PrintAvg(average);
        }
    }
}
