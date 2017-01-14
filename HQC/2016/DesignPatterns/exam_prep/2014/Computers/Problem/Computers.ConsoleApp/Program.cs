namespace Computers.ConsoleApp
{
    using System;
    using Computers.Logic.ComputerTypes;
    using Computers.Logic.Factories;
    using Logic.Factories.Contracts;

    public class Program
    {
        private const string HPFactoryName = "HP";
        private const string DellFactoryName = "Dell";
        private const string LenovoFactoryName = "Lenovo";

        private const string CommandCharge = "Charge";
        private const string CommandProcess = "Process";
        private const string CommandPlay = "Play";
        private const string CommandExit = "Exit";

        private const string ErrorInvalidCommand = "Invalid command!";
        private const string ErrorInvalidManufacturer = "Invalid manufacturer!";

        private const int CommandArrayLength = 2;

        public static void Main(string[] args)
        {
            IFactory factory = GetManufacturer();

            Laptop laptop = factory.CreateLaptop();
            PersonalComputer pc = factory.CreatePersonalComputer();
            Server server = factory.CreateServer();

            while (true)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    Console.WriteLine(ErrorInvalidCommand);
                }
                else if (line.StartsWith(CommandExit))
                {
                    break;
                }
                else
                {
                    var commandArray = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (commandArray.Length != CommandArrayLength)
                    {
                        Console.WriteLine(ErrorInvalidCommand);
                    }
                    else
                    {
                        var commandName = commandArray[0];
                        var commandAmount = int.Parse(commandArray[1]);

                        if (commandName == CommandCharge)
                        {
                            laptop.ChargeBattery(commandAmount);
                        }
                        else if (commandName == CommandProcess)
                        {
                            server.Process(commandAmount);
                        }
                        else if (commandName == CommandPlay)
                        {
                            pc.Play(commandAmount);
                        }
                        else
                        {
                            Console.WriteLine(ErrorInvalidCommand);
                        }
                    }
                }
            }
        }

        private static IFactory GetManufacturer()
        {
            var manufacturer = Console.ReadLine();
            IFactory factory;

            if (manufacturer == HPFactoryName)
            {
                factory = new HPFactory();
            }
            else if (manufacturer == DellFactoryName)
            {
                factory = new DellFactory();
            }
            else if (manufacturer == LenovoFactoryName)
            {
                factory = new LenovoFactory();
            }
            else
            {
                throw new ArgumentException(ErrorInvalidManufacturer);
            }

            return factory;
        }
    }
}
