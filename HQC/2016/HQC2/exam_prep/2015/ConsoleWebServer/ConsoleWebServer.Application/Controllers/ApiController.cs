namespace ConsoleWebServer.Application.Controllers
{
    using System;
    using System.Linq;
    using Framework;
    using Framework.ActionResults;
    using Framework.ActionResults.Contracts;

    public class ApiController : Controller
    {
        public ApiController(IHttpRequest request) : base(request)
        {
        }

        public IActionResult ReturnMe(string param)
        {
            return this.Json(new { param });
        }

        public IActionResult GetDateWithCors(string domainName)
        {
            var requestReferer = string.Empty;
            string refererKey = "Referer";
            string invalidRefererException = "Invalid referer!";

            if (this.Request.Headers.ContainsKey(refererKey))
            {
                requestReferer = this.Request.Headers[refererKey].FirstOrDefault();
            }

            if (string.IsNullOrWhiteSpace(requestReferer) || !requestReferer.Contains(domainName))
            {
                throw new ArgumentException(invalidRefererException);
            }

            string dateFormat = "yyyy-MM-dd";
            string moreInfoResponse = "Data available for " + domainName;
            var model = new { date = DateTime.Now.ToString(dateFormat), moreInfo = moreInfoResponse };

            return new JsonActionResultWithCors(this.Request, model, domainName);
        }
    }
}