namespace CalendarSystem.Engine
{
    using CalendarSystem.Events;
    using CalendarSystem.Events.Contracts;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class CommandHandler
    {
        private const string AddEventCommand = "AddEvent";
        private const string DeleteEventCommand = "DeleteEvents";
        private const string ListEventCommand = "ListEvents";
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

        private const string EventAdded = "Event added";
        private const string NoEventsFound = "No events found";


        private readonly IEventsManager eventsManager;

        public CommandHandler(IEventsManager eventsManager)
        {
            this.eventsManager = eventsManager;
        }

        public IEventsManager EventsProcessor
        {
            get
            {
                return this.eventsManager;
            }
        }

        public Command Parse(string commandLine)
        {
            int j = commandLine.IndexOf(' ');
            if (j == -1)
            {
                string message = string.Format("Invalid command: {0}", commandLine);
                throw new Exception(message);
            }

            string name = commandLine.Substring(0, j);
            string arg = commandLine.Substring(j + 1);

            var commandArguments = arg.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                arg = commandArguments[i];
                commandArguments[i] = arg.Trim();
            }

            var command = new Command(name, commandArguments);

            return command;
        }

        public string ProcessCommand(Command command)
        {
            if ((command.CommandName == AddEventCommand) && (command.Parameters.Length == 2))
            {
                string answer = this.CreateEvent(command.Parameters[0], command.Parameters[1]);
                return answer;
            }
            else if ((command.CommandName == AddEventCommand) && (command.Parameters.Length == 3))
            {
                string answer = this.CreateEvent(command.Parameters[0], command.Parameters[1], command.Parameters[2]);
                return answer;
            }
            else if ((command.CommandName == DeleteEventCommand) && (command.Parameters.Length == 1))
            {
                int eventsRemoved = this.eventsManager.DeleteEventsByTitle(command.Parameters[0]);

                if (eventsRemoved == 0)
                {
                    return NoEventsFound;
                }

                string answer = string.Format("{0} events deleted", eventsRemoved);
                return answer;
            }
            else if ((command.CommandName == ListEventCommand) && (command.Parameters.Length == 2))
            {
                var dateTime = DateTime.ParseExact(command.Parameters[0], DateTimeFormat, CultureInfo.InvariantCulture);
                var commandName = int.Parse(command.Parameters[1]);
                var events = this.eventsManager.ListEvents(dateTime, commandName).ToList();

                var sb = new StringBuilder();

                if (!events.Any())
                {
                    return NoEventsFound;
                }

                foreach (var ev in events)
                {
                    sb.AppendLine(ev.ToString());
                }

                return sb.ToString().Trim();
            }
            else
            {
                string errorMessage = string.Format("{0} not found", command.CommandName);
                throw new Exception(errorMessage);
            }
        }

        private string CreateEvent(string dateTimeParameter, string title, string location = null)
        {
            var date = DateTime.ParseExact(dateTimeParameter, DateTimeFormat, CultureInfo.InvariantCulture);

            var currentEvent = new Event(date, title, location);
            this.eventsManager.AddEvent(currentEvent);

            return EventAdded;
        }
    }
}
