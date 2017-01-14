using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doge
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split(' ');
            int rows = int.Parse(firstLine[0]);
            int cols = int.Parse(firstLine[1]);
            int K = int.Parse(firstLine[2]);

            string[] secondLine = Console.ReadLine().Split(';');

            long[,] table = new long[rows, cols];
            bool[,] enemies = new bool[rows, cols];


            foreach (var enemy in secondLine)
            {
                var enemyCoords = enemy.Split(' ');
                enemies[int.Parse(enemyCoords[0]), int.Parse(enemyCoords[1])] = true;
            }

            table[0, 0] = 1;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    if (enemies[i, j])
                    {
                        continue;
                    }
                    if (i == 0)
                    {
                        table[i, j] = table[i, j - 1];
                        continue;
                    }
                    if (j == 0)
                    {
                        table[i, j] = table[i - 1, j];
                        continue;
                    }
                    table[i, j] = table[i - 1, j] + table[i, j - 1];
                }
            }

            //for (int i = 0; i < table.GetLength(0); i++)
            //{
            //    for (int j = 0; j < table.GetLength(1); j++)
            //    {
            //        Console.Write("{0} ", table[i, j]);
            //    }
            //    Console.WriteLine();
            //}
            Console.WriteLine(table[rows - 1, cols - 1]);
        }
    }
}
