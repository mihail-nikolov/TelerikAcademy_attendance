using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using System.IO;
using System.Reflection;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        private const string CreateStudentCommandName = "CreateStudent";
        private const string CreateTeacherCommandName = "CreateTeacher";
        private const string RemoveStudentCommandName = "RemoveStudent";
        private const string RemoveTeacherCommandName = "RemoveTeacher";
        private const string StudentListMarksCommandName = "StudentListMarks";
        private const string TeacherAddMarkCommandName = "TeacherAddMark";

        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope();
            Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();
            Bind<IParser>().To<CommandParserProvider>().InSingletonScope();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                Bind<IStudentFactory>().ToFactory().InSingletonScope().Intercept().With<TimeMeasurmentInterceptor>();
                Bind<IMarkFactory>().ToFactory().InSingletonScope().Intercept().With<TimeMeasurmentInterceptor>();
            }
            else
            {
                Bind<IStudentFactory>().ToFactory().InSingletonScope();
                Bind<IMarkFactory>().ToFactory().InSingletonScope();
            }
            
            Bind<ITeacherFactory>().ToFactory().InSingletonScope();

            Bind<ICommand>().To<CreateStudentCommand>().InSingletonScope().Named(CreateStudentCommandName);
            Bind<ICommand>().To<CreateTeacherCommand>().InSingletonScope().Named(CreateTeacherCommandName);
            Bind<ICommand>().To<RemoveStudentCommand>().InSingletonScope().Named(RemoveStudentCommandName);
            Bind<ICommand>().To<RemoveTeacherCommand>().InSingletonScope().Named(RemoveTeacherCommandName);
            Bind<ICommand>().To<StudentListMarksCommand>().InSingletonScope().Named(StudentListMarksCommandName);
            Bind<ICommand>().To<TeacherAddMarkCommand>().InSingletonScope().Named(TeacherAddMarkCommandName);
        }
    }
}