namespace ConsoleWebServer.Framework
{
    using System;
    using System.Net;
    using Handlers;

    public class ResponseProvider: IResponseProvider
    {
        private readonly IHandler startHandler;
        private readonly IHttpResponseFactory factory;

        public ResponseProvider(IHandler startHandler, IHttpResponseFactory responseFactory)
        {
            this.startHandler = startHandler;
            this.factory = responseFactory;
        }
        public IHttpResponse GetResponse(string requestAsString)
        {
            HttpRequest request;
            try
            {
                var requestParser = new RequestParser();
                request = requestParser.Parse(requestAsString);
            }
            catch (Exception ex)
            {
                int minor = 1;
                int major = 1;
                Version version = new Version(major, minor);
                var httpresponse = this.factory.CreateHttpResponse(version, HttpStatusCode.BadRequest, ex.Message);
                return httpresponse;
            }

            var response = this.startHandler.Handle(request);
            return response;
        }
    }
}