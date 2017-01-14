using Ninject;

namespace ConsoleWebServer.Application
{
    public static class Startup
    {
        public static void Main()
        {
            //var handlersFactory = new HandlersFactory();
            //var responseProvider = new ResponseProvider(handlersFactory);
            //var reader = new ConsoleReader();
            //var writer = new ConsoleWriter();

            //var webSever = new ConsoleWebServer(responseProvider, reader, writer);

            IKernel kernel = new StandardKernel(new WebServerModule());

            IWebServer webServer = kernel.Get<IWebServer>();
            webServer.Start();
        }
    }
}