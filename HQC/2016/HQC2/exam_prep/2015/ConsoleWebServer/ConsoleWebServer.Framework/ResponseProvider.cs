namespace ConsoleWebServer.Framework
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Reflection;
    using ActionResults.Contracts;
    using Exceptions;

    public class ResponseProvider
    {
        public HttpResponse GetResponse(string requestAsString)
        {
            HttpRequest request;
            try
            {
                string getMethod = "GET";
                string httpVersion = "1.1";
                string uri = "/";
                var requestParser = new HttpRequest(getMethod, uri, httpVersion);
                request = requestParser.Parse(requestAsString);
            }
            catch (Exception ex)
            {
                int minor = 1;
                int major = 1;
                Version version = new Version(major, minor);
                return new HttpResponse(version, HttpStatusCode.BadRequest, ex.Message);
            }

            var response = this.Process(request);
            return response;
        }

        private HttpResponse Process(HttpRequest request)
        {
            string optionsMethod = "options";
            string headMethod = "head";
            int protocolMajorVersion = 3;

            bool canHandleRequest = new StaticFileHandler().CanHandle(request);

            if (request.Method.ToLower() == headMethod)
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
            else if (request.Method.ToLower() == optionsMethod)
            {
                string controller = "Controller";
                var routes = 
                    Assembly.GetEntryAssembly()
                        .GetTypes()
                        .Where(x => x.Name.EndsWith(controller) && typeof(Controller).IsAssignableFrom(x))
                        .Select(x => new { x.Name, Methods = x.GetMethods().Where(m => m.ReturnType == typeof(IActionResult)) })
                        .SelectMany(
                            x =>
                            x.Methods.Select(
                                m =>
                                string.Format("/{0}/{1}/{{parameter}}", x.Name.Replace(controller, string.Empty), m.Name)))
                        .ToList();

                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Join(Environment.NewLine, routes));
            }
            else if (canHandleRequest)
            {
                return new StaticFileHandler().Handle(request);
            }
            else if (request.ProtocolVersion.Major < protocolMajorVersion)
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
            else
            {
                string body = "Request cannot be handled.";
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotImplemented, body);
            }
        }

        private Controller CreateController(HttpRequest request)
        {
            string controller = "Controller";
            var controllerClassName = request.Action.ControllerName + controller;
            var type =
                Assembly.GetEntryAssembly()
                    .GetTypes()
                    .FirstOrDefault(x => x.Name.ToLower() == controllerClassName.ToLower() && typeof(Controller).IsAssignableFrom(x));

            if (type == null)
            {
                string message = string.Format("Controller with name {0} not found!", controllerClassName);
                throw new HttpNotFound(message);
            }

            var instance = (Controller)Activator.CreateInstance(type, request);
            return instance;
        }
    }
}