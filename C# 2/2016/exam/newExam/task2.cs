using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newExam
{
    public class task2
    {
        static bool isEven(int num)
        {
            if (num % 2 == 0)
            {
                return true;
            }
            return false;
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
                    else if(move < 0)
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

        public static void Startup()
        {
            int collectedSouls = 0;
            int collectedFood = 0;
            int deadlocks = 0;
            string mapstr = Console.ReadLine();
            StringBuilder map = new StringBuilder(mapstr);
            int[] positions = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int currentIndex = 0;

            bool fuckedUp = false;
            int posFuckedUp = 0;

            for (int i = 0; i <= positions.Length; i++)
            {
                if (map[currentIndex] == '*')
                {
                    collectedFood++;
                    map[currentIndex] = '0';
                }
                else if (map[currentIndex] == '@')
                {
                    collectedSouls++;
                    map[currentIndex] = '0';
                }
                else if (map[currentIndex] == 'x')
                {
                    deadlocks++;
                    map[currentIndex] = '0';
                    if (isEven(currentIndex))
                    {
                        if (collectedSouls == 0)
                        {
                            fuckedUp = true;
                            posFuckedUp = i;
                            break;
                        }
                        collectedSouls--;
                    }
                    else
                    {
                        if (collectedFood == 0)
                        {
                            fuckedUp = true;
                            posFuckedUp = i;
                            break;
                        }
                        collectedFood--;
                    }
                }
                if (i == positions.Length)
                {
                    break;
                }

                int move = positions[i];
                currentIndex = changeCurPos(currentIndex, move, map.Length);
            }

            if (fuckedUp)
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine("Jumps before deadlock: {0}", posFuckedUp);
            }
            else
            {
                Console.WriteLine("Coder souls collected: {0}", collectedSouls);
                Console.WriteLine("Food collected: {0}", collectedFood);
                Console.WriteLine("Deadlocks: {0}", deadlocks);
            }
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        task2.Startup();
    //    }
    //}
}
