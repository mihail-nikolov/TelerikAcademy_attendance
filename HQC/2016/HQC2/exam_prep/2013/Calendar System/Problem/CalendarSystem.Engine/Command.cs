namespace CalendarSystem.Engine
{
    public class Command
    {
        internal Command(string name, string[] parameters)
        {
            this.CommandName = name;
            this.Parameters = parameters;
        }

        public string CommandName { get; private set; }

        public string[] Parameters { get; private set; }
    }
}
