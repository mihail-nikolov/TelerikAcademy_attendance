using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 2. Maximal sum

    Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.
*/
namespace _2.MaximalSum
{
    class MaximalSum
    {
        static void printMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,2} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static int goingThrough(int size, int row, int col, int[,] matrix)
        {
            int sum = 0;
            int[] matrixData = new int[size];
            for (int platRow = 0; platRow < row + size; platRow++)
            {
                for (int platCol = 0; platCol < col + size; platCol++)
                {
                    sum += matrix[platRow, platCol];
                }
            }
            return sum;
        }
        static void printSubMatrix(int[,] matrix, int theRow, int theCol, int size)
        {
            for (int i = theRow; i < theRow + size; i++)
            {
                for (int j = theCol; j < theCol + size; j++)
                {
                    Console.Write("{0,2} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main()
        {
           // int N = 4;
            //int M = 5;
            int size = 3;
            int theRow = 0;
            int theCol = 0;
            int biggestSum = 0;
            int[,] matrix = {
                                {1, 2, 3, 4, 5, 6,},
                                {12, 123, 124, 124, 1231, 1},
                                {1, 23, 23, 24, 234, 123},
                                {12, 123, 124, 124, 1231, 1},
                            };
            printMatrix(matrix);
            for (int row = 0; row < matrix.GetLength(0) - size; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - size; col++)
                {
                    int sum = goingThrough(size, row, col, matrix);
                    if (sum > biggestSum)
                    {
                        theRow = row;
                        theCol = col;
                        biggestSum = sum;
                    }
                }
            }
            printSubMatrix(matrix, theRow, theCol, size);
            Console.WriteLine("the max sum is: {0}",biggestSum);
        }
    }
}
