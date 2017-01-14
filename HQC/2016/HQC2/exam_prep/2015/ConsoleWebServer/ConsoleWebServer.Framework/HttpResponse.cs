namespace ConsoleWebServer.Framework
{
    using System;
    using System.Net;
    using System.Text;

    public class HttpResponse : HttpMessage
    {
        private const string DefaultContentType = "text/plain; charset=utf-8";

        private const string ServerEngineName = "ConsoleWebServer";

        public HttpResponse(Version httpVersion, HttpStatusCode statusCode, string body, string contentType = DefaultContentType)
            : base(httpVersion.ToString())
        {
            this.Body = body;
            this.StatusCode = statusCode;

            string serverHeader = "Server";
            this.AddHeader(serverHeader, ServerEngineName);

            string contentLengthHeader = "Content-Length";
            this.AddHeader(contentLengthHeader, body.Length.ToString());

            string contentTypeHeader = "Content-Type";
            this.AddHeader(contentTypeHeader, contentType);
        }

        public HttpStatusCode StatusCode { get; private set; }

        public string Body { get; private set; }

        public string StatusCodeAsString
        {
            get
            {
                return this.StatusCode.ToString();
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            int statusCodeAsInt = (int)this.StatusCode;
            stringBuilder.AppendLine(
                string.Format(
                    "{0}{1} {2} {3}",
                    ProtocolType,
                    this.ProtocolVersion,
                    statusCodeAsInt,
                    this.StatusCodeAsString));

            var headerStringBuilder = new StringBuilder();

            foreach (var key in this.Headers.Keys)
            {
                headerStringBuilder.AppendLine(string.Format("{0}: {1}", key, string.Join("; ", this.Headers[key])));
            }

            stringBuilder.AppendLine(headerStringBuilder.ToString());

            if (!string.IsNullOrWhiteSpace(this.Body))
            {
                stringBuilder.AppendLine(this.Body);
            }

            return stringBuilder.ToString();
        }
    }
}