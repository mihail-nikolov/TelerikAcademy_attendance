using ConsoleWebServer.Framework.ActionResults.Contracts;
using System.Collections.Generic;

namespace ConsoleWebServer.Framework.ActionResults
{
    public class ActionResultWithCorsDecorator : ActionResult
    {
        private IActionResult actionResult;
        private readonly string corsSettings;

        public ActionResultWithCorsDecorator(IActionResult actionResult, string corsSettings)
        {
            this.corsSettings = corsSettings;
            this.actionResult = actionResult;
        }

        public override HttpResponse GetResponse()
        {
            string corsHeader = "Access-Control-Allow-Origin";
            this.actionResult.ResponseHeaders.Add(new KeyValuePair<string, string>(corsHeader, this.corsSettings));
            return this.actionResult.GetResponse();
        }
    }
}
