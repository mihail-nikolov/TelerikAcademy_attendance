namespace SchoolSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;
    using Models.Contracts;

    public class Engine
    {
        private ISchool school;

        public Engine(IReader reader, IWriter writer, ISchool school)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.school = school;
        }

        public IReader Reader { get; set; }

        public IWriter Writer { get; set; }

        public void Run()
        {
            string endCommand = "End";
            while (true)
            {
                try
                {
                    var commandString = this.Reader.Read();
                    if (string.IsNullOrEmpty(commandString) || commandString == endCommand)
                    {
                        break;
                    }

                    var commandName = commandString.Split(' ')[0];

                    var assembley = this.GetType().GetTypeInfo().Assembly;
                    var typeInfo = assembley.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                        .FirstOrDefault();

                    if (typeInfo == null)
                    {
                        string errorMessage = "The passed command is not found!";
                        throw new ArgumentException(errorMessage);
                    }

                    var command = Activator.CreateInstance(typeInfo) as ICommand;
                    var parameters = commandString.Split(' ').ToList();
                    parameters.RemoveAt(0);

                    string commandOutput = command.Execute(parameters, this.school);
                    this.Writer.WriteLine(commandOutput);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
