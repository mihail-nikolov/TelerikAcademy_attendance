namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Collections.Generic;

    public class ContentActionResultWithCorsWithoutCaching : ContentActionResultWithCors
    {
        public ContentActionResultWithCorsWithoutCaching(IHttpRequest request, object model, string corsSettings)
            : base(request, model, corsSettings)
        {
            this.ResponseHeaders.Add(new KeyValuePair<string, string>("Cache-Control", "private, max-age=0, no-cache"));
        }
    }
}