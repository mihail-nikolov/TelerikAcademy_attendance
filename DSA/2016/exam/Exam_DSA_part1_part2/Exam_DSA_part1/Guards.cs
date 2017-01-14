//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Text;
//using System.Threading.Tasks;

//namespace Exam_DSA_part1
//{
//    class Guards
//    {
//        static ulong[,] table;
//        static bool[,] enemies;

//        static void Main(string[] args)
//        {
//            string[] firstLine = Console.ReadLine().Split(' ');

//            int rows = int.Parse(firstLine[0]);
//            int cols = int.Parse(firstLine[1]);
//            table = new ulong[rows, cols];
//            enemies = new bool[rows, cols];

//            int numGuards = int.Parse(Console.ReadLine());

//            for (int i = 0; i < numGuards; i++)
//            {
//                var guardPosition = Console.ReadLine().Split(' ');
//                int guardI = int.Parse(guardPosition[0]);
//                int guardJ = int.Parse(guardPosition[1]);
//                enemies[guardI, guardJ] = true;

//                string guardLook = guardPosition[2];
//                switch (guardLook)
//                {
//                    case "U":
//                        if (guardI == 0)
//                        {
//                            break;
//                        }
//                        table[guardI - 1, guardJ] = 2; break;

//                    case "D":
//                        if (guardI == table.GetLength(0) - 1)
//                        {
//                            break;
//                        }
//                        table[guardI + 1, guardJ] = 2; break;

//                    case "L":
//                        if (guardJ == 0)
//                        {
//                            break;
//                        }
//                        table[guardI, guardJ - 1] = 2; break;

//                    case "R":
//                        if (guardJ == table.GetLength(1) - 1)
//                        {
//                            break;
//                        }
//                        table[guardI, guardJ + 1] = 2; break;
//                    default: break;
//                }
//            }

//            //Console.WriteLine("TABLE");
//            //printTable();
//            //Console.WriteLine();
//            //Console.WriteLine();

//            FillTable();

//            ulong answer = table[rows - 1, cols - 1];
//            var enemy = enemies[rows - 1, cols - 1];
//            if (enemy)
//            {
//                Console.WriteLine("Meow");
//            }
//            else
//            {
//                Console.WriteLine(answer);
//            }

//        }

//        static void FillTable()
//        {
//            table[0, 0] = 1;
//            for (int i = 0; i < table.GetLength(0); i++)
//            {
//                for (int j = 0; j < table.GetLength(1); j++)
//                {
//                    if (i == 0 && j == 0)
//                    {
//                        continue;
//                    }
//                    //enemy
//                    if (enemies[i, j])
//                    {
//                        continue;
//                    }
//                    //firstRow
//                    if (i == 0)
//                    {
//                        if (enemies[i, j - 1])
//                        {
//                            enemies[i, j] = true;
//                            table[i, j] = 0;
//                            continue;
//                        }

//                        table[i, j] += 1 + table[i, j - 1];
//                        continue;
//                    }
//                    //firstColumn
//                    if (j == 0)
//                    {
//                        if (enemies[i - 1, j])
//                        {
//                            enemies[i, j] = true;
//                            table[i, j] = 0;
//                            continue;
//                        }

//                        table[i, j] += 1 + table[i - 1, j];
//                        continue;
//                    }

//                    //if enemies up AND left
//                    if (enemies[i - 1, j] && enemies[i, j - 1])
//                    {
//                        table[i, j] = 0;
//                        enemies[i, j] = true;
//                        continue;
//                    }


//                    // enemies up -> come from left
//                    if (enemies[i - 1, j])
//                    {
//                        table[i, j] += 1 + table[i, j - 1];
//                        continue;
//                    }

//                    // enemies left -> come from up
//                    if (enemies[i, j - 1])
//                    {
//                        table[i, j] += 1 + table[i - 1, j];
//                        continue;
//                    }

//                    // no enemies up and left
//                    table[i, j] += 1 + Math.Min(table[i - 1, j], table[i, j - 1]);

//                }
//                //printTable();
//                //Console.WriteLine();
//            }
//        }

//        static void printTable()
//        {
//            for (int i = 0; i < table.GetLength(0); i++)
//            {
//                for (int j = 0; j < table.GetLength(1); j++)
//                {
//                    if (table[i, j] == 0)
//                    {
//                        Console.Write("x ");
//                        continue;
//                    }
//                    Console.Write("{0} ", table[i, j]);
//                }
//                Console.WriteLine();
//            }
//        }
//    }
//}
