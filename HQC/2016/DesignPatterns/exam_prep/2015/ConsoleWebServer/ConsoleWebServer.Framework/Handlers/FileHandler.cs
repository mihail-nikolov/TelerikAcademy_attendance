namespace ConsoleWebServer.Framework.Handlers
{
    using System;
    using System.IO;
    using System.Net;

    public class FileHandler: Handler
    {
        public override IHttpResponse HandleRequest(IHttpRequest request)
        {
            string filePath = Environment.CurrentDirectory + "/" + request.Uri;
            if (!File.Exists(filePath))
            {
                string body = "File not found!";
                return new HttpResponse(request.ProtocolVersion, HttpStatusCode.NotFound, body);
            }

            string fileContents = File.ReadAllText(filePath);
            var response = new HttpResponse(request.ProtocolVersion, HttpStatusCode.OK, fileContents);
            return response;
        }

        protected override bool CanHandle(IHttpRequest request)
        {
            var lastIndeOfDotOfRequestUri = request.Uri.LastIndexOf(".", StringComparison.Ordinal);
            var lastIndeOfSlashOfRequestUri = request.Uri.LastIndexOf("/", StringComparison.Ordinal);
            bool answer = lastIndeOfDotOfRequestUri > lastIndeOfSlashOfRequestUri;
            return answer;
        }
    }
}