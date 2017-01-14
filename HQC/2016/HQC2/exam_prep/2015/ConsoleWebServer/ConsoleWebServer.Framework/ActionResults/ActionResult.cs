namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Collections.Generic;
    using Contracts;

    public abstract class ActionResult : IActionResult
    {
        protected readonly object model;

        public ActionResult(IHttpRequest request, object model)
        {
            this.model = model;
            this.Request = request;
            this.ResponseHeaders = new List<KeyValuePair<string, string>>();
        }

        public object Model
        {
            get
            {
                return this.model;
            }
        }

        public IHttpRequest Request { get; private set; }

        public List<KeyValuePair<string, string>> ResponseHeaders { get; private set; }

        public abstract HttpResponse GetResponse();
    }
}
