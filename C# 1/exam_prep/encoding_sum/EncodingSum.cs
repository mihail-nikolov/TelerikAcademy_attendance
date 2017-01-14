using System;


class EncodingSum
{
    static void Main(string[] args)
    {
        string inputStr = Console.ReadLine();
        int M = int.Parse(Console.ReadLine());
        int result = 0;
        
        for (int i = 0; i <= inputStr.Length - 1; i++)
        {
            if (inputStr[i] == '@')
            {
                break;
            }
            else if (Char.IsDigit(inputStr[i]))
            {
                result *= (int)Char.GetNumericValue(inputStr[i]);
            }
            else if (Char.IsLetter(inputStr[i]))
            {
                int index = char.ToUpper(inputStr[i]) - 65;
                result += index;
            }
            else
            {
                result %= M;
            }
        }
        Console.WriteLine(result);
    }
}

