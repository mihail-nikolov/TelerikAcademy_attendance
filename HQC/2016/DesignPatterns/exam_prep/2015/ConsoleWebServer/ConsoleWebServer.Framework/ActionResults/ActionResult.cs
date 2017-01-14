namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Collections.Generic;
    using Contracts;

    public abstract class ActionResult : IActionResult
    {
        public ActionResult()
        {
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public IHttpRequest Request { get; protected set; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        public abstract HttpResponse GetResponse();
    }
}
