using System.Net;

namespace ConsoleWebServer.Framework.Handlers
{
    public class HeadHandler : Handler
    {
        public override IHttpResponse HandleRequest(IHttpRequest request)
        {
            var response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, string.Empty);
            return response;
        }

        protected override bool CanHandle(IHttpRequest request)
        {
            return request.Method.ToLower() == "head";
        }
    }
}
