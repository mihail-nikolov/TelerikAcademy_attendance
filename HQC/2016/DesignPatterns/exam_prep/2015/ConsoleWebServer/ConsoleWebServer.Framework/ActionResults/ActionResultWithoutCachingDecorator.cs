using ConsoleWebServer.Framework.ActionResults.Contracts;
using System.Collections.Generic;

namespace ConsoleWebServer.Framework.ActionResults
{
    public class ActionResultWithoutCachingDecorator : ActionResult
    {
        private IActionResult actionResult;

        public ActionResultWithoutCachingDecorator(IActionResult actionResult)
        {
            this.actionResult = actionResult;
        }

        public override HttpResponse GetResponse()
        {
            this.actionResult.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
            return this.actionResult.GetResponse();
        }
    }
}

