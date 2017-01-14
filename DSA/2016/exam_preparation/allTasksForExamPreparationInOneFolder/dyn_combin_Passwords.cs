using System;

namespace Passwords
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string relation = Console.ReadLine();
            int K = int.Parse(Console.ReadLine());
            char[] pass = new char[N];

            counter = K;
            GetPassword(pass, 0, relation);
           
        }

        static int counter;

        static void GetPassword(char[] pass, int index, string relation)
        {
            if (index == 0)
            {
                for (char c = '0'; c <= '9'; c++)
                {
                    if (counter <= 0)
                    {
                        return;
                    }
                    pass[index] = c;
                    GetPassword(pass, 1, relation);
                }
                return;
            }

            if (index - 1 >= relation.Length)
            {
                counter--;
                if (counter == 0)
                {
                     Console.WriteLine(string.Join("", pass));
                }
                return;
            }

            if (counter <= 0)
            {
                return;
            }

            if (relation[index - 1] == '=')
            {
                pass[index] = pass[index - 1];
                GetPassword(pass, index + 1, relation);
            }
            else if (relation[index - 1] == '<')
            {
                char last = pass[index - 1] == '0' ? '9' : (char)(pass[index - 1] - 1);

                for (char c = '1'; c <= last; c++)
                {
                    pass[index] = c;
                    GetPassword(pass, index + 1, relation);
                }
            }
            else if (pass[index - 1] != '0')
            {
                pass[index] = '0';
                GetPassword(pass, index + 1, relation);

                for (char c = (char)(pass[index - 1] + 1); c <= '9'; c++)
                {
                    pass[index] = c;
                    GetPassword(pass, index + 1, relation);
                }
            }
        }
    }
}
