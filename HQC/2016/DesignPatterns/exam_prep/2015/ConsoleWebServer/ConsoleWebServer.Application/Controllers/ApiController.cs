namespace ConsoleWebServer.Application.Controllers
{
    using System;
    using System.Linq;
    using Framework;
    using Framework.ActionResults.Contracts;

    public class ApiController : Controller
    {
        public ApiController(IHttpRequest request, IActionResultFactory actionResultFactory) 
            : base(request, actionResultFactory)
        {
        }

        public IActionResult ReturnMe(string param)
        {
            return this.Json(new { param });
        }

        public IActionResult GetDateWithCors(string corsSettings)
        {
            var requestReferer = string.Empty;
            string refererKey = "Referer";
            string invalidRefererException = "Invalid referer!";

            if (this.Request.Headers.ContainsKey(refererKey))
            {
                requestReferer = this.Request.Headers[refererKey].FirstOrDefault();
            }

            if (string.IsNullOrWhiteSpace(requestReferer) || !requestReferer.Contains(corsSettings))
            {
                throw new ArgumentException(invalidRefererException);
            }   

            string dateFormat = "yyyy-MM-dd";
            string moreInfoResponse = "Data available for " + corsSettings;
            var model = new { date = DateTime.Now.ToString(dateFormat), moreInfo = moreInfoResponse };

            return this.ActionResultFactory.GetJsonActionResultWithCors(this.Request, model, corsSettings);
        }
    }
}