using System;


namespace PrintLongSeq
{
    class PrintLongSeq
    {
        static void Main(string[] args)
        {
            string numbers = "";
            for (int i = 2; i < 1002; i++)
            {   
                numbers += Math.Pow(-1, i) * i;
                if (i != 1001)
                {
                    numbers += ", ";
                }
            }
            Console.WriteLine(numbers);
        }
    }
}
