namespace ConsoleWebServer.Framework
{
    public interface IWriter
    {
        void WriteLine(object toWrite);
        void Write(object toWrite);
    }
}
