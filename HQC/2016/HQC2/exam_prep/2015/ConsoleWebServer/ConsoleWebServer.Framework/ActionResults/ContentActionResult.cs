namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Net;
    using Contracts;

    public class ContentActionResult : ActionResult, IActionResult
    {
        public ContentActionResult(IHttpRequest request, object model)
            : base(request, model)
        {
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