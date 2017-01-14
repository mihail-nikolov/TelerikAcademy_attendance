namespace ConsoleWebServer.Framework
{
    using System.Text;

    public class HttpRequest : HttpMessage, IHttpRequest, IHttpMessage
    {
        public HttpRequest(string method, string uri, string httpVersion)
            : base(httpVersion)
        {
            this.Uri = uri;
            this.Method = method;
            this.Action = new ActionDescriptor(uri);
        }

        public string Uri { get; private set; }

        public string Method { get; private set; }

        public ActionDescriptor Action { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(
                string.Format(
                    "{0} {1} {2}{3}",
                    this.Method,
                    this.Action,
                    ProtocolType,
                    this.ProtocolVersion));
            sb.AppendLine(base.ToString().Trim());

            return sb.ToString();
        }
    }
}