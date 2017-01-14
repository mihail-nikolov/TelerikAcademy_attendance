namespace SchoolSystem.ConsoleApplication
{
    using Core;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            var consoleReader = new ConsoleReaderProvider();
            var consoleWriter = new ConsoleWriterProvider();
            var school = new School();

            var engine = new Engine(consoleReader, consoleWriter, school);
            engine.Run();
        }
    }
}
