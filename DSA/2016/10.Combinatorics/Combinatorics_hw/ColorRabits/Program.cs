namespace ColorRabits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class Program
    {
        static void Main()
        {
            int numberOfAskedRabbits = int.Parse(Console.ReadLine());

            var answers = GetAnswersDictionary(numberOfAskedRabbits);
            int minNumOfRabbits = GetMinNumOfRabbits(answers, numberOfAskedRabbits);

            Console.WriteLine(minNumOfRabbits);
        }

        static int GetMinNumOfRabbits(Dictionary<int, int> answers, int numberOfAskedRabbits)
        {
            int minNumOfRabbits = 0;
            foreach (var item in answers)
            {
                var multiplier = item.Value / (item.Key + 1);
                if (item.Value % (item.Key + 1) != 0)
                {
                    multiplier += 1;
                }

                minNumOfRabbits += (item.Key + 1) * multiplier;
            }

            if (numberOfAskedRabbits > minNumOfRabbits)
            {
                minNumOfRabbits = numberOfAskedRabbits;
            }

            return minNumOfRabbits;
        }

        static Dictionary<int, int> GetAnswersDictionary(int numberOfAskedRabbits)
        {
            var answers = new Dictionary<int, int>();
            for (int i = 0; i < numberOfAskedRabbits; i++)
            {
                int answer = int.Parse(Console.ReadLine());
                if (answers.ContainsKey(answer))
                {
                    answers[answer] += 1;
                }
                else
                {
                    answers.Add(answer, 1);
                }

            }
            return answers;
        }
    }
}
