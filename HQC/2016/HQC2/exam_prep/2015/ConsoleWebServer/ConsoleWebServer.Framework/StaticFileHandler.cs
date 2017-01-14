namespace ConsoleWebServer.Framework
{
    using System;
    using System.IO;
    using System.Net;

    public class StaticFileHandler
    {
        public bool CanHandle(HttpRequest request)
        {
            var lastIndeOfDotOfRequestUri = request.Uri.LastIndexOf(".", StringComparison.Ordinal);
            var lastIndeOfSlashOfRequestUri = request.Uri.LastIndexOf("/", StringComparison.Ordinal);
            bool answer = lastIndeOfDotOfRequestUri > lastIndeOfSlashOfRequestUri;
            return answer;
        }

        public HttpResponse Handle(HttpRequest request)
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
    }
}