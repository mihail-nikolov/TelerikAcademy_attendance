namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Collections.Generic;

    public class JsonActionResultWithCorsWithoutCaching : JsonActionResultWithCors
    {
        public JsonActionResultWithCorsWithoutCaching(HttpRequest request, object model, string corsSettings)
            : base(request, model, corsSettings)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}
