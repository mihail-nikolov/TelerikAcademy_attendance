using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 7.* Largest area in matrix

    Write a program that finds the largest area of equal neighbour elements in a rectangular matrix and prints its size.
*/
namespace _7.LargestAreaInMatrix
{
    class LargestAreaInMatrix
    {
        static void Main()
        {
            int n = 4;
            int[,] matrix = caseA(n);
            printMatrix(matrix);
        }
    }
}
