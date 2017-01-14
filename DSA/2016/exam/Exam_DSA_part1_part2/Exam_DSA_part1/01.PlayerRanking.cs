//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Wintellect.PowerCollections;

//namespace Exam_DSA_part1
//{
//    class Player : IComparable<Player>
//    {
//        public Player(string name, int age, int id)
//        {
//            this.Id = id;
//            this.Name = name;
//            this.Age = age;
//            this.PlayerTostring = string.Format("{0}({1})", this.Name, this.Age);
//        }

//        public string PlayerTostring { get; set; }

//        public string Name { get; set; }

//        public int Id { get; set; }

//        public int Age { get; set; }

//        public override string ToString()
//        {
//            return this.PlayerTostring;
//        }

//        public int CompareTo(Player other)
//        {
//            int answer = this.Name.CompareTo(other.Name);
//            if (answer == 0)
//            {
//                answer = this.Age.CompareTo(other.Age);
//                if (answer == 0)
//                {
//                    answer = this.Id.CompareTo(other.Id);
//                }
//                else
//                {
//                    answer = -answer;
//                }
//            }

//            return answer;
//        }

//        public override int GetHashCode()
//        {
//            return this.Id;
//        }
//    }

//    class PlayerRanking
//    {
//        static int id = 0;
//        static Dictionary<string, OrderedBag<Player>> byType; // possible improve?
//        static BigList<Player> byRank;

//        static void Main()
//        {
//            byType = new Dictionary<string, OrderedBag<Player>>();
//            byRank = new BigList<Player>();

//            while (true)
//            {
//                var line = Console.ReadLine().Split(' ');
//                var commandName = line[0];

//                if (commandName == "end")
//                {
//                    break;
//                }

//                ProcessCommand(line);
//            }
//        }

//        static void ProcessCommand(string[] line)
//        {
//            var commandName = line[0];
//            switch (commandName)
//            {
//                case "add":
//                    string name = line[1];
//                    string type = line[2];
//                    int age = int.Parse(line[3]);
//                    int position = int.Parse(line[4]);

//                    var playerToAdd = new Player(name, age, id);
//                    id++;

//                    if (!byType.ContainsKey(type))
//                    {
//                        byType.Add(type, new OrderedBag<Player>());
//                    }

//                    byType[type].Add(playerToAdd);
//                    byRank.Insert(position - 1, playerToAdd);

//                    string stringToAdd = string.Format("Added player {0} to position {1}", name, position);
//                    Console.WriteLine(stringToAdd);
//                    break;

//                case "find":
//                    string typeToFind = line[1];
//                    if (byType.ContainsKey(typeToFind))
//                    {
//                        var playersByTypeList = byType[typeToFind].Take(5);

//                        string playersByType = string.Join("; ", playersByTypeList);
//                        string byTypeAnswer = string.Format("Type {0}: {1}", typeToFind, playersByType);
//                        Console.WriteLine(byTypeAnswer);
//                    }
//                    else
//                    {
//                        string byTypeAnswer = string.Format("Type {0}: ", typeToFind);
//                        Console.WriteLine(byTypeAnswer);
//                    }

//                    break;

//                case "ranklist":
//                    int from = int.Parse(line[1]);
//                    int to = int.Parse(line[2]);

//                    int updatedTo = Math.Min(to, byRank.Count);
//                    StringBuilder currentAnswer = new StringBuilder();

//                    for (int i = from - 1; i < updatedTo; i++)
//                    {
//                        string pByR = string.Format("{0}. {1}; ", i + 1, byRank[i]);
//                        currentAnswer.Append(pByR);
//                    }

//                    Console.WriteLine(currentAnswer.ToString().TrimEnd(new char[] { ' ', ';' }));
//                    break;

//                default:
//                    break;
//            }
//        }
//    }
//}
