using System;


namespace PrintSequence
{
    class PrintSequence
    {
        static void Main(string[] args)
        {
            string numbers = "";
            for (int i = 2; i < 12; i++)
            {
                numbers += Math.Pow(-1, i) * i;
                if (i != 11)
                {
                    numbers += ", ";
                }
            }
            Console.WriteLine(numbers);
        }
    }
}
