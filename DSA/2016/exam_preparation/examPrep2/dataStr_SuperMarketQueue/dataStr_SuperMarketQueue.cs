using System;
using System.Collections.Generic;
using System.Text;
using Wintellect.PowerCollections;

namespace dataStr_SuperMarketQueue
{
    class dataStr_SuperMarketQueue
    {
        static BigList<string> queue;
        static Dictionary<string, int> peopleByName;
        static StringBuilder answer;

        static void Main(string[] args)
        {
            queue = new BigList<string>();
            peopleByName = new Dictionary<string, int>();
            answer = new StringBuilder();

            while (true)
            {
                var line = Console.ReadLine().Split(' ');
                var commandName = line[0];

                if (commandName == "End")
                {
                    break;
                }

                ProcessCommand(line);
            }
            Console.WriteLine(answer.ToString().TrimEnd());
        }

        //use SB instead of CW
        static void ProcessCommand(string[] line)
        {
            var commandName = line[0];
            switch (commandName)
            {
                case "Append":
                    string name = line[1];
                    queue.Add(name);

                    if (!peopleByName.ContainsKey(name))
                    {
                        peopleByName.Add(name, 0);
                    }

                    peopleByName[name]++;
                    answer.AppendLine("OK");
                    break;

                case "Insert":
                    int placeToInsert = int.Parse(line[1]);
                    string nameToInsert = line[2];

                    if (placeToInsert > queue.Count)
                    {
                        answer.AppendLine("Error");
                        break;
                    }

                    if (!peopleByName.ContainsKey(nameToInsert))
                    {
                        peopleByName.Add(nameToInsert, 0);
                    }

                    peopleByName[nameToInsert]++;
                    queue.Insert(placeToInsert, nameToInsert);
                    answer.AppendLine("OK");
                    break;

                case "Find":
                    string byName = line[1];
                    int numByName = 0;

                    if (peopleByName.ContainsKey(byName))
                    {
                        numByName = peopleByName[byName];
                    }

                    answer.AppendLine(numByName.ToString());
                    break;

                case "Serve":
                    int countToServe = int.Parse(line[1]);
                    if (countToServe > queue.Count)
                    {
                        answer.AppendLine("Error");
                        break;
                    }

                    StringBuilder toRemoveBuilder = new StringBuilder();

                    for (int i = 0; i < countToServe; i++)
                    {
                        string person = queue[i];
                        toRemoveBuilder.Append(string.Format("{0} ", person));

                        if (peopleByName[person] > 0)
                        {
                            peopleByName[person]--;
                        }
                    }

                    queue.RemoveRange(0, countToServe);

                    answer.AppendLine(toRemoveBuilder.ToString().TrimEnd());
                    break;

                default:
                    break;
            }
        }
    }
}
