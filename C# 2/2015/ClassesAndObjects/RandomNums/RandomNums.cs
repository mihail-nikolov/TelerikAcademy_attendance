﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*     

Problem 2. Random numbers

    Write a program that generates and prints to the console 10 random values in the range [100, 200].
*/

namespace RandomNums
{
    class Program
    {
        static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                int num = rnd.Next(100, 201);
                Console.WriteLine(num);
            }
        }
    }
}
