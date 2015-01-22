using System;


namespace third_digit
{
    class ThirdDigiy
    {
        static void Main()
        {
            int number = 72;
            string numStr = number.ToString();
            char lookedNum = '7';
            if (numStr.Length >= 3)
             {
                 int lookedPos = numStr.Length - 3;
                 char numOntheLookedPosition = numStr[lookedPos];
                 if (lookedNum == numOntheLookedPosition)
                 {
                     Console.WriteLine(true);
                 }
             }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
