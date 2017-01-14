using System;

using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Commands.Contracts;

namespace SchoolSystem.Framework.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "End";
        private const string NullProvidersExceptionMessage = "cannot be null.";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;
        private readonly ISchool school;
        private readonly IStudentFactory studentFactory;
        private readonly ITeacherFactory teacherFactory;
        private readonly IMarkFactory markFactory;
        private readonly ICommandFactory commandFactory;

        /* Could also extract Database provider for Teachers and Students collections
           But it will become too complex for the purposes of this exam */

        public Engine(IReader readerProvider, IWriter writerProvider, IParser parserProvider,
                      ISchool school, IStudentFactory studentFactory, ITeacherFactory teacherFactory,
                      IMarkFactory markFactory, ICommandFactory commandFactory)
        {
            if (readerProvider == null)
            {
                throw new ArgumentNullException($"Reader {NullProvidersExceptionMessage}");
            }

            if (writerProvider == null)
            {
                throw new ArgumentNullException($"Writer {NullProvidersExceptionMessage}");
            }

            if (parserProvider == null)
            {
                throw new ArgumentNullException($"Parser {NullProvidersExceptionMessage}");
            }

            if (school == null)
            {
                throw new ArgumentNullException($"School {NullProvidersExceptionMessage}");
            }

            if (studentFactory == null)
            {
                throw new ArgumentNullException($"StudentFactory {NullProvidersExceptionMessage}");
            }

            if (teacherFactory == null)
            {
                throw new ArgumentNullException($"teacherFactory {NullProvidersExceptionMessage}");
            }

            if (markFactory == null)
            {
                throw new ArgumentNullException($"markFactory {NullProvidersExceptionMessage}");
            }

            if (commandFactory == null)
            {
                throw new ArgumentNullException($"commandFactory {NullProvidersExceptionMessage}");
            }

            this.reader = readerProvider;
            this.writer = writerProvider;
            this.parser = parserProvider;
            this.school = school;
            this.studentFactory = studentFactory;
            this.teacherFactory = teacherFactory;
            this.markFactory = markFactory;
            this.commandFactory = commandFactory;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();

                    if (commandAsString == TerminationCommand || string.IsNullOrEmpty(commandAsString))
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.parser.ParseCommand(commandAsString, this.commandFactory);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters, this.school, this.studentFactory, this.teacherFactory, this.markFactory);
            this.writer.WriteLine(executionResult);
        }
    }
}
