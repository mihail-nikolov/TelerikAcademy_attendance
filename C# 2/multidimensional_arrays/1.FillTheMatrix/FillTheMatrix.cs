using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 1. Fill the matrix

    Write a program that fills and prints a matrix of size (n, n) as shown below:
*/
namespace _1.FillTheMatrix
{
    class FillTheMatrix
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
        static int[,] caseA(int n)
        {
            int counter = 1;
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[j, i] = counter;
                    counter++;
                }
            }
            return matrix;
        }
        static int[,] caseB(int n)
        {
            int counter = 1;
            int[,] matrix = new int[n, n];
            for (int col = 0; col < n; col++)
            {
                if ((col + 1) / 2 != 0)
                {
                    for (int row = n - 1; row >= 0; row--)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
                else
                {
                    for (int row = 0; row < n; row++)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
            }
            return matrix;
        }
        static int[,] caseC(int n)
        {
            int row = n - 1;
            int col = 0;
            int[,] matrix = new int[n, n];
            for (int i = 1; i <= n * n; i++)
            {
                matrix[row, col] = i;
                row++;
                col++;
                if ((row > n - 1 && col <= n - 1))
                {
                    row = (n - 1) - col;
                    col = 0;
                }
                if ((row > n - 1 && col > n - 1))
                {
                    row = 0;
                    col = 1;
                }
                if ((row <= n - 1 && col > n - 1))
                {
                    col = (n - 1) - row + 2;
                    row = 0;
                }
            }
            return matrix;
        }
        static int[,] caseD(int n)
        {
            int[,] matrix = new int[n, n];
            string direction = "down";
            int row = 0;
            int col = 0;
            for (int i = 1; i <= n * n; i++)
            {
                if (direction == "down" && (row > n - 1 || matrix[row, col] != 0))
                {
                    direction = "right";
                    row--;
                    col++;
                }
                if (direction == "right" && (col > n - 1 || matrix[row, col] != 0))
                {
                    direction = "up";
                    col--;
                    row--;
                }
                if (direction == "left" && (col < 0 || matrix[row, col] != 0))
                {
                    direction = "down";
                    col++;
                    row++;
                }
                if (direction == "up" && row < 0 || matrix[row, col] != 0)
                {
                    direction = "left";
                    row++;
                    col--;
                }
                matrix[row, col] = i;
                if (direction == "down")
                {
                    row++;
                }
                if (direction == "right")
                {
                    col++;
                }
                if (direction == "up")
                {
                    row--;
                }
                if (direction == "left")
                {
                    col--;
                }
            }
            return matrix;
        }
        static void Main()
        {
            int n = 4;
            int[,] matrix1 = caseA(n);
            printMatrix(matrix1);
            int[,] matrix2 = caseB(n);
            printMatrix(matrix2);
            int[,] matrix3 = caseC(n);
            printMatrix(matrix3);
            int[,] matrix4 = caseD(n);
            printMatrix(matrix4);
        }
    }
}
