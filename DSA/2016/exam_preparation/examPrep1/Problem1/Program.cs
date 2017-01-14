using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    class Program
    {
        public static void Main()
        {
            var game = new Game();
            while (true)
            {
                string commandLine = Console.ReadLine();
                var commandLineArr = commandLine.Split(' ');

                string command = commandLineArr[0];

                switch (command)
                {
                    case "end": return;
                    case "add":
                        var unit = new Unit(commandLineArr[1], commandLineArr[2], int.Parse(commandLineArr[3]));
                        var addMsg = game.AddUnit(unit);
                        Console.WriteLine(addMsg);
                        break;
                    case "remove":
                        var name = commandLineArr[1];
                        var removeMsg = game.RemoveUnit(name);
                        Console.WriteLine(removeMsg);
                        break;
                    case "find":
                        var findMsg = game.FindUnit(commandLineArr[1]);
                        Console.WriteLine(findMsg);
                        break;
                    case "power":
                        var powerMsg = game.GetNumberOfUnitsByPower(int.Parse(commandLineArr[1]));
                        Console.WriteLine(powerMsg);
                        
                        break;

                    default: throw new ArgumentException();
                }
            }
        }

        public class Unit:IComparable<Unit>
        {
            private string name;
            private string type;
            private int attack;

            public Unit(string name, string type, int attack)
            {
                this.Name = name;
                this.Type = type;
                this.Attack = attack;
            }

            public string Name
            {
                get
                {
                    return this.name;
                }
                private set
                {
                    if (value.Length < 1 || value.Length > 30)
                    {
                        throw new ArgumentException();
                    }
                    this.name = value;
                }
            }

            public string Type
            {
                get
                {
                    return this.type;
                }
                private set
                {
                    if (value.Length < 1 || value.Length > 40)
                    {
                        throw new ArgumentException();
                    }
                    this.type = value;
                }
            }

            public int Attack
            {
                get
                {
                    return this.attack;
                }
                private set
                {
                    if (value < 100 || value > 1000)
                    {
                        throw new ArgumentException();
                    }
                    this.attack = value;
                }
            }

            public override string ToString()
            {
                return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
            }

            public int CompareTo(Unit other)
            {
                var result = this.Attack.CompareTo(other.Attack);
                if (result == 0)
                {
                    return this.Name.CompareTo(other.Name);
                }
                else if (result == -1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public class Game
        {
            const string UnitAddedSuccessFormat = "SUCCESS: {0} added!";
            const string UnitAddedErrorFormat = "FAIL: {0} already exists!";
            const string UnitRemovedSuccessFormat = "SUCCESS: {0} removed!";
            const string UnitRemovedErrorFormat = "FAIL: {0} could not be found!";
            const string FilterSuccessFormat = "RESULT: {0}";

            private Dictionary<string, Unit> unitsGroupedByName;
            private Dictionary<string, SortedSet<Unit>> unitsGroupedByType;
            private SortedSet<Unit> units;

            public Game()
            {
                this.unitsGroupedByName = new Dictionary<string, Unit>();
                this.unitsGroupedByType = new Dictionary<string, SortedSet<Unit>>();
                this.units = new SortedSet<Unit>();
            }

            public string AddUnit(Unit unit)
            {
                if (this.unitsGroupedByName.ContainsKey(unit.Name))
                {
                    return string.Format(UnitAddedErrorFormat, unit.Name);
                }

                this.unitsGroupedByName.Add(unit.Name, unit);

                if (!this.unitsGroupedByType.ContainsKey(unit.Type))
                {
                    var units = new SortedSet<Unit>() { unit };
                    this.unitsGroupedByType.Add(unit.Type, units);
                }
                else
                {
                    this.unitsGroupedByType[unit.Type].Add(unit);
                }

                this.units.Add(unit);

                return string.Format(UnitAddedSuccessFormat, unit.Name);
            }

            public string RemoveUnit(string name)
            {
                if (!this.unitsGroupedByName.ContainsKey(name))
                {
                    return string.Format(UnitRemovedErrorFormat, name);
                }
                var unit = unitsGroupedByName[name];

                this.unitsGroupedByName.Remove(name);

                if (this.unitsGroupedByType[unit.Type].Count == 1)
                {
                    this.unitsGroupedByType.Remove(unit.Type);
                }
                else
                {
                    this.unitsGroupedByType[unit.Type].Remove(unit);
                }

                this.units.Remove(unit);
                return string.Format(UnitRemovedSuccessFormat, name);
            }

            public string FindUnit(string type)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("RESULT:");
                if (!this.unitsGroupedByType.ContainsKey(type))
                {
                    return sb.ToString();
                }

                var units = this.unitsGroupedByType[type].Take(10).ToArray();
                return this.ConvertToString(units);
            }

            public string GetNumberOfUnitsByPower(int number)
            {
                if (this.units.Count == 0)
                {
                    return "RESULT:";
                }

                var units = this.units.Take(number).ToArray();
                return this.ConvertToString(units);
            }

            private string ConvertToString(Unit[] units)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("RESULT: ");

                var unitsToStr = new string[units.Length];
                for (int i = 0; i < units.Length; i++)
                {
                    unitsToStr[i] = units[i].ToString();
                }
                sb.Append(string.Join(", ", unitsToStr));
                return sb.ToString().TrimEnd();
            }
        }
    }
}

