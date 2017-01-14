namespace Problem1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        const string UnitAddedSuccessFormat = "SUCCESS: {0} added!";
        const string UnitAddedErrorFormat = "FAIL: {0} already exists!";
        const string UnitRemovedSuccessFormat = "SUCCESS: {0} removed!";
        const string UnitRemovedErrorFormat = "FAIL: {0} could not be found!";
        const string FilterSuccessFormat = "RESULT: {0}";

        public static void Main()
        {
            var game = new Game();
            while (true)
            {
                string input = Console.ReadLine();
                var command = Command.ParseCommand(input);
                switch (command.Type)
                {
                    case CommandType.Add:
                        var unit = Unit.ParseUnit(command.Params);
                        var addResult = game.AddUnit(unit);
                        string format;
                        if (addResult)
                        {
                            format = UnitAddedSuccessFormat;
                        }
                        else
                        {
                            format = UnitAddedErrorFormat;
                        }
                        Console.WriteLine(format, unit.Name);
                        break;
                    case CommandType.Remove:
                        var name = command.Params;
                        var removeResult = game.RemoveUnit(name);
                        string removeformat;
                        if (removeResult)
                        {
                            removeformat = UnitRemovedSuccessFormat;
                        }
                        else
                        {
                            removeformat = UnitRemovedErrorFormat;
                        }
                        Console.WriteLine(removeformat, name);
                        break;
                    case CommandType.Power:
                        var numToTake = int.Parse(command.Params);
                        var filterByPowerResult = game.FilterByPower(numToTake);
                        if (filterByPowerResult == null)
                        {
                            Console.WriteLine(FilterSuccessFormat, "");
                        }
                        else
                        {
                            Console.WriteLine(FilterSuccessFormat, string.Join(", ", filterByPowerResult));
                        }
                        break;
                    case CommandType.Find:
                        var filterByTypeResult = game.FilterByType(command.Params);
                        if (filterByTypeResult == null)
                        {
                            Console.WriteLine(FilterSuccessFormat, "");
                        }
                        else
                        {
                            Console.WriteLine(FilterSuccessFormat, string.Join(", ", filterByTypeResult));
                        }
                        break;
                    case CommandType.End:
                        return;
                }
            }
        }
    }



    public enum CommandType
    {
        End,
        Add,
        Power,
        Find,
        Remove
    }

    public class Command
    {
        public string Params { get; set; }

        public static Dictionary<string, CommandType> stringToCommandType;

        static Command()
        {
            stringToCommandType = new Dictionary<string, CommandType>();
            stringToCommandType["add"] = CommandType.Add;
            stringToCommandType["end"] = CommandType.End;
            stringToCommandType["find"] = CommandType.Find;
            stringToCommandType["power"] = CommandType.Power;
            stringToCommandType["remove"] = CommandType.Remove;
        }

        public CommandType Type { get; set; }

        public static Command ParseCommand(string input)
        {
            foreach (var pair in stringToCommandType)
            {
                if (input.StartsWith(pair.Key))
                {
                    return new Command()
                    {
                        Type = pair.Value,
                        Params = input.Substring(pair.Key.Length).Trim()
                    };
                }
            }
            return null;
        }
    }

    public class Unit : IComparable<Unit>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public override string ToString()
        {
            return string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Unit;
            if (other == null)
            {
                return false;
            }

            return this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return 23 + this.Name.GetHashCode() >> 17 ^
                   (23 + this.Attack.GetHashCode() >> 17 ^
                    (23 + this.Type.GetHashCode() >> 17));
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

        public static Unit ParseUnit(string unitString)
        {
            string[] parts = unitString.Split(' ');
            var name = parts[0];
            var type = parts[1];
            var attack = int.Parse(parts[2]);

            return new Unit()
            {
                Name = name,
                Type = type,
                Attack = attack
            };
        }
    }

    public class Game
    {
        SortedSet<Unit> units;
        Dictionary<string, Unit> unitNames;
        Dictionary<string, SortedSet<Unit>> byType;


        public Game()
        {
            this.units = new SortedSet<Unit>();
            this.byType = new Dictionary<string, SortedSet<Unit>>();
            this.unitNames = new Dictionary<string, Unit>();
        }

        public bool AddUnit(Unit unit)
        {
            if (this.unitNames.ContainsKey(unit.Name))
            {
                return false;
            }

            if (!(this.byType.ContainsKey(unit.Type)))
            {
                this.byType[unit.Type] = new SortedSet<Unit>();
            }

            this.units.Add(unit);
            this.byType[unit.Type].Add(unit);
            this.unitNames.Add(unit.Name, unit);

            return true;
        }

        public bool RemoveUnit(string name)
        {
            if (!this.unitNames.ContainsKey(name))
            {
                return false;
            }

            var clonedUnit = this.unitNames[name];

            this.byType[clonedUnit.Type].Remove(clonedUnit);
            this.units.Remove(clonedUnit);
            this.unitNames.Remove(name);
            
            return true;
        }

        public IEnumerable<Unit> FilterByPower(int numToTake)
        {
            if (this.units.Count == 0)
            {
                return null;
            }
            return this.units.Take(numToTake);
        }

        public IEnumerable<Unit> FilterByType(string type)
        {
            if (!(byType.ContainsKey(type)))
            {
                return null;
            }
            return this.byType[type].Take(10);
        }
    }
}
