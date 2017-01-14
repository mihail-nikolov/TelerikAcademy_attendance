namespace ConsoleWebServer.Framework.Handlers
{
    public interface IHandlersFactory
    {
        IHandler CreateAndAttachHandlers();
    }
}
