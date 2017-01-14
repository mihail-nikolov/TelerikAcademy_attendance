namespace CalendarSystem.ConsoleApplication
{
    using CalendarSystem.Engine;
    using CalendarSystem.Events;
    using System;

    public class Startup
    {
        public static void Main()
        {
            var eventsManager = new EventsManagerFast();
            var commandHandler = new CommandHandler(eventsManager);

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End" || line == null)
                {
                    break;
                }

                try
                {
                    var command = commandHandler.Parse(line);
                    Console.WriteLine(commandHandler.ProcessCommand(command));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
