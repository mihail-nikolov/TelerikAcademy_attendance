using System;
using System.Collections.Generic;
using System.Text;

namespace Passwords
{
    class Program
    {
        //static private DekNumOrder collection = new DekNumOrder();
        static private string collection = "1234567890";

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string relation = Console.ReadLine();
            int K = int.Parse(Console.ReadLine());

            try
            {
                string[] possibleNumbers = GetPossibleNumbersArray(N, relation);
                Console.WriteLine(string.Join(", ", possibleNumbers));
                //string answer = GetKthPassword(possibleNumbers, K, N);

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static int GetKthPassword(int index, int n, int k, int[] digits, string relations, char[] output)
        {
            if (k <= 0)
            {
                return k;
            }

            if (index == n)
            {
                k--;
                if (k == 0)
                {
                    for (int i = 0; i < n; i++)
                    {
                        output[i] = (char)(digits[i] + '0');
                    }
                }
                return k;
            }

            if (index == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    digits[0] = i;
                    k = GetKthPassword(1, n, k, digits, relations, output);
                }

                return k;
            }

            if (relations[index - 1] == '<')
            {
                int digit = digits[index - 1] == 0 ? 10 : digits[index - 1];
                for (int i = 1; i < digit; i++)
                {
                    digits[index] = i;
                    k = GetKthPassword(index + 1, n, k, digits, relations, output);
                }

                return k;
            }

            if (relations[index - 1] == '>')
            {
                int digit = digits[index - 1];
                if (digit == 0)
                {
                    return k;
                }

                digits[index] = 0;
                k = GetKthPassword(index + 1, n, k, digits, relations, output);

                for (int i = digit + 1; i < 10; i++)
                {
                    digits[index] = i;
                    k = GetKthPassword(index + 1, n, k, digits, relations, output);
                }

                return k;
            }

            digits[index] = digits[index - 1];
            return GetKthPassword(index + 1, n, k, digits, relations, output);
        }

        private static bool CheckIfElementsCorrespondingToSign(int a, char sign, int b)
        {
            switch (sign)
            {
                case '<': return a < b;
                case '>': return a > b;
                case '=': return a == b;
                default:
                    throw new ArgumentException("sign should be > < =");
            }
        }

        private static string[] GetPossibleNumbersArray(int n, string relation)
        {
            string[] possibleNumbers = new string[n];
            possibleNumbers[0] = collection.ToString();
            int currentPosition = 0;

            if (relation[0] == '<')
            {
                currentPosition = 9;
            }

            for (int i = 0; i < relation.Length; i++)
            {
                if (relation[i] == '>')
                {
                    if (currentPosition < 9)
                    {
                        currentPosition++;
                        possibleNumbers[i + 1] = collection.Substring(currentPosition);
                    }
                }
                else if (relation[i] == '<')
                {
                    if (currentPosition > 0)
                    {
                        currentPosition--;
                        possibleNumbers[i + 1] = collection.Substring(0, currentPosition + 1);
                    }
                }
                else
                {
                    possibleNumbers[i + 1] = collection;
                }
            }

            return possibleNumbers;
        }

        private static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    public class DekNumOrder
    {
        private List<int> collection;

        public DekNumOrder()
        {
            collection = new List<int>()
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 0
                };
        }

        public void Push()
        {
            int lastNumber = collection[collection.Count - 1];
            if (lastNumber == 9)
            {
                this.collection.Add(0);
            }
            else if (lastNumber > 0 && lastNumber < 9)
            {
                this.collection.Add(lastNumber + 1);
            }
        }

        public int Pop()
        {
            int lastNumber = collection[collection.Count - 1];

            if (this.collection.Count == 1)
            {
                return lastNumber;
            }

            this.collection.Remove(lastNumber);

            return lastNumber;
        }

        public void Enqueue()
        {
            int firstNumber = collection[0];
            if (firstNumber >= 1)
            {
                this.collection.Insert(0, firstNumber - 1);
            }
        }

        public int Deque()
        {
            if (this.collection.Count == 1)
            {
                return 0;
            }

            int lastNumber = collection[collection.Count - 1];
            this.collection.Remove(lastNumber);

            return lastNumber;
        }

        public override string ToString()
        {
            return string.Join("", this.collection.ToArray());
        }
    }
}
