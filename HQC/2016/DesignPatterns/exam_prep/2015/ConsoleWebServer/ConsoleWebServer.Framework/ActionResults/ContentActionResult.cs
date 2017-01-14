namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Net;
    using Contracts;

    public class ContentActionResult : ActionResult, IActionResult
    {
        private readonly object model;

        public ContentActionResult(IHttpRequest request, object model)
            : base()
        {
            this.model = model;
            this.Request = request;
        }

        public override HttpResponse GetResponse()
        {
            var response = new HttpResponse(this.Request.ProtocolVersion, HttpStatusCode.OK, this.model.ToString());
            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }
    }
}