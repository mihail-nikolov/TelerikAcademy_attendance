using System;


namespace bonus_score
{
    class BonusScore
    {
        static void Main()
        {   
            double answer = 0;
            Console.Write("n = ");
            double n = double.Parse(Console.ReadLine());
            if (n >= 1 && n <= 3)
            {
                answer = 10 * n;
            }
            else if (n >= 4 && n <= 6)
            {
                answer = 100 * n;
            }
            else if (n >= 7 && n <= 9)
            {
                answer = 1000 * n;
            }
            else
            {
                Console.WriteLine("invalid score");
                return;
            }
            Console.WriteLine("n = {0}", answer);
        }
    }
}
