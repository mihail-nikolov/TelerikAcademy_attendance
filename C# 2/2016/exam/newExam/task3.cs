using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newExam
{
    public class task3
    {
        static bool[][] tree;
        public static int GenNum(int row, int col)
        {
            if (!tree[row][col])
            {
                return ((row + 1) * (col + 1));
            }
            return 0;
        }

        static int changeCurPos(int curpos, int move, int len)
        {
            int newMove = curpos + move;
            if (newMove >= 0 && newMove < len)
            {
                return newMove;
            }
            else
            {
                int absMove = Math.Abs(move);
                while (absMove > 0)
                {
                    if (move > 0)
                    {
                        curpos++;
                        if (curpos >= len)
                        {
                            curpos = 0;
                        }
                    }
                    else if (move < 0)
                    {
                        curpos--;
                        if (curpos < 0)
                        {
                            curpos = len - 1;
                        }
                    }
                    absMove--;
                }
            }
            return curpos;
        }

        static void GenTree(int rows, int cols)
        {
            tree = new bool[rows][];
            int mid = rows / 2;
            for (int i = 0; i < rows; i++)
            {
                if (i >= mid)
                {
                    var toAdd = new bool[(rows - i) * cols];
                    tree[i] = toAdd;
                }
                else
                {
                    var toAdd = new bool[(i + 1) * cols];
                    tree[i] = toAdd;
                }

            }
        }

        public static int GetColHight(int col)
        {
            int count = 0;
            for (int i = 0; i < tree.Length; i++)
            {
                for (int j = 0; j < tree[i].Length; j++)
                {
                    if (j == col)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static void Startup()
        {
            int rabScore = 0;
            int porcScore = 0;

            int baseCols = int.Parse(Console.ReadLine());
            int baseRows = int.Parse(Console.ReadLine());

            string[] porcC = Console.ReadLine().Split(' ');
            List<int> porcCoords = new List<int> { int.Parse(porcC[0]), int.Parse(porcC[1]) };

            string[] rabC = Console.ReadLine().Split(' ');
            List<int> rabCoords = new List<int> { int.Parse(rabC[0]), int.Parse(rabC[1]) };

            GenTree(baseRows, baseCols);

            rabScore += GenNum(rabCoords[0], rabCoords[1]);
            tree[rabCoords[0]][rabCoords[1]] = true;
            porcScore += GenNum(porcCoords[0], porcCoords[1]);
            tree[porcCoords[0]][porcCoords[1]] = true;

            string line = Console.ReadLine();
            while (line != "END")
            {
                string[] lineC = line.Split(' ');
                string unit = lineC[0];
                string dir = lineC[1];
                int steps = int.Parse(lineC[2]);

                if (unit == "R")
                {
                    int curPos = 0;
                    int colHight = 0;
                    switch (dir)
                    {
                        case "T":
                            colHight = GetColHight(rabCoords[1]);
                            curPos = changeCurPos(rabCoords[0], -steps, colHight);
                            rabCoords[0] = curPos; break;
                        case "B":
                            colHight = GetColHight(rabCoords[1]);
                            curPos = changeCurPos(rabCoords[0], steps, colHight);
                            rabCoords[0] = curPos; break;
                        case "R":
                            curPos = changeCurPos(rabCoords[1], steps, tree[rabCoords[0]].Length);
                            rabCoords[1] = curPos; break;
                        case "L":
                            curPos = changeCurPos(rabCoords[1], -steps, tree[rabCoords[0]].Length);
                            rabCoords[1] = curPos; break;
                        default:
                            break;
                    }
                    rabScore += GenNum(rabCoords[0], rabCoords[1]);
                    tree[rabCoords[0]][rabCoords[1]] = true;
                }
                else
                {
                    int curPos = 0;
                    int colHight = 0;
                    switch (dir)
                    {
                        case "T":
                            colHight = GetColHight(porcCoords[1]);
                            curPos = changeCurPos(porcCoords[0], -1, colHight);
                            porcCoords[0] = curPos; break;
                        case "B":
                            colHight = GetColHight(porcCoords[1]);
                            curPos = changeCurPos(porcCoords[0], 1, colHight);
                            porcCoords[0] = curPos; break;
                        case "R":
                            curPos = changeCurPos(porcCoords[1], 1, tree[porcCoords[0]].Length);
                            porcCoords[1] = curPos; break;
                        case "L":
                            curPos = changeCurPos(porcCoords[1], -1, tree[porcCoords[0]].Length);
                            porcCoords[1] = curPos; break;
                        default:
                            break;
                    }
                    porcScore += GenNum(porcCoords[0], porcCoords[1]);
                    tree[porcCoords[0]][porcCoords[1]] = true;
                }
                line = Console.ReadLine();
            }
            if (porcScore > rabScore)
            {
                Console.WriteLine("The porcupine destroyed the rabbit with { 0} points.The rabbit must work harder.He scored {1} points only.", porcScore, rabScore);
            }
            else if (rabScore > porcScore)
            {
                Console.WriteLine("The rabbit WON with {0} points. The porcupine scored {1} points only.", rabScore, porcScore);
            }
            else
            {
                Console.WriteLine("Both units scored {0} points. Maybe we should play again?", rabScore);
            }
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //        task3.Startup();
    //    }
    //}
}
