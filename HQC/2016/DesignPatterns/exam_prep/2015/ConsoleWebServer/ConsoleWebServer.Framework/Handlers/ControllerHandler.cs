using ConsoleWebServer.Framework.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Reflection;

namespace ConsoleWebServer.Framework.Handlers
{
    public class ControllerHandler : Handler
    {
        public override IHttpResponse HandleRequest(IHttpRequest request)
        {
            HttpResponse response;
            try
            {
                var controller = this.CreateController(request);
                var actionInvoker = new ActionInvoker();
                var actionResult = actionInvoker.InvokeAction(controller, request.Action);
                response = actionResult.GetResponse();
            }
            catch (HttpNotFound exception)
            {
                response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, exception.Message);
            }
            catch (Exception exception)
            {
                response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.InternalServerError, exception.Message);
            }

            return response;
        }

        protected override bool CanHandle(IHttpRequest request)
        {
            int protocolMajorVersion = 3;
            return request.ProtocolVersion.Major < protocolMajorVersion;
        }

        // todo: factory
        private Controller CreateController(IHttpRequest request)
        {
            string controller = "Controller";
            var controllerClassName = request.Action.ControllerName + controller;
            var type =
                Assembly.GetEntryAssembly()
                    .GetTypes()
                    .FirstOrDefault(x => x.Name.ToLower() == controllerClassName.ToLower() && typeof(Controller).IsAssignableFrom(x));

            Console.WriteLine(controllerClassName);
            Console.WriteLine(type);
            if (type == null)
            {
                string message = string.Format("Controller with name {0} not found!", controllerClassName);
                throw new HttpNotFound(message);
            }

            Console.WriteLine(request);
            var instance = (Controller)Activator.CreateInstance(type, request);
            return instance;
        }
    }
}
