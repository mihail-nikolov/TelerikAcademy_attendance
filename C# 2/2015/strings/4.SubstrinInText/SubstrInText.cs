using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 4. Sub-string in text

    Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).

Example:

The target sub-string is in

The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

The result is: 9.*/
namespace _4.SubstrinInText
{
    class SubstrInText
    {

        static void Main()
        {
            string myStr = "The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string lookedStr = "in";
            int count = 0;
            int lengthToLook = myStr.Length - lookedStr.Length;
            for (int i = 0; i < lengthToLook; i++)
            {
                if (myStr.Length - i >= lookedStr.Length)
                {
                    if (myStr.Substring(i,lookedStr.Length).Equals(lookedStr))
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
