namespace ConsoleWebServer.Framework.ActionResults
{
    using System.Collections.Generic;

    public class ContentActionResultWithCors : ContentActionResult
    {
        public ContentActionResultWithCors(IHttpRequest request, object model, string corsSettings) : base(request, model)
        {
            string corsHeader = "Access-Control-Allow-Origin";
            this.ResponseHeaders.Add(new KeyValuePair<string, string>(corsHeader, corsSettings));
        }
    }
}