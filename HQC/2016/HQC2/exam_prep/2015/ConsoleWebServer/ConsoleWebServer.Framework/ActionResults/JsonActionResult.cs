namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Net;
    using Contracts;
    using Newtonsoft.Json;

    public class JsonActionResult : ActionResult, IActionResult
    {
        public JsonActionResult(IHttpRequest request, object model)
            : base(request, model)
        {
        }

        public string GetContent()
        {
            return JsonConvert.SerializeObject(this.Model);
        }

        public virtual HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.OK;
        }

        public override HttpResponse GetResponse()
        {
            string contentType = "application/json";
            var response = new HttpResponse(this.Request.ProtocolVersion, this.GetStatusCode(), this.GetContent(), contentType);

            foreach (var responseHeader in this.ResponseHeaders)
            {
                response.AddHeader(responseHeader.Key, responseHeader.Value);
            }

            return response;
        }
    }
}