namespace ConsoleWebServer.Framework.Handlers
{
    public class HandlersFactory : IHandlersFactory
    {
        public IHandler CreateAndAttachHandlers()
        {
            var headHandler = new HeadHandler();
            var optionsHandler = new OptionsHandler();
            var fileHandler = new FileHandler();
            var controllerHandler = new ControllerHandler();

            headHandler.SetSuccessor(optionsHandler);
            optionsHandler.SetSuccessor(fileHandler);
            fileHandler.SetSuccessor(controllerHandler);

            return headHandler;
        }
    }
}
