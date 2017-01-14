namespace ConsoleWebServer.Framework
{
    using System.IO;
    using System.Text;
    using Exceptions;

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

            foreach (var key in this.Headers.Keys)
            {
                sb.AppendLine(string.Format("{0}: {1}", key, string.Join("; ", this.Headers[key])));
            }

            return sb.ToString();
        }

        public HttpRequest Parse(string reqAsStr)
        {
            var textReader = new StringReader(reqAsStr);
            var firstLine = textReader.ReadLine();
            var requestObject = this.CreateRequest(firstLine);

            string line = textReader.ReadLine();

            while (line != null)
            {
                this.AddHeaderToRequest(requestObject, line);
                line = textReader.ReadLine();
            }

            return requestObject;
        }

        private HttpRequest CreateRequest(string firstRequestLine)
        {
            var firstRequestLinePartsArray = firstRequestLine.Split(' ');
            int numberOfParameters = 3;
            if (firstRequestLinePartsArray.Length != numberOfParameters)
            {
                string exceptionMessage = "Invalid format for the first request line. Expected format: [Method] [Uri] HTTP/[Version]";
                throw new ParserException(exceptionMessage);
            }

            string method = firstRequestLinePartsArray[0];
            string uri = firstRequestLinePartsArray[1];
            string httpVersion = firstRequestLinePartsArray[2];
            var requestObject = new HttpRequest(method, uri, httpVersion);

            return requestObject;
        }

        private void AddHeaderToRequest(HttpRequest request, string headerLine)
        {
            int parametersToGet = 2;
            var headerParameters = headerLine.Split(new[] { ':' }, parametersToGet);
            var headerName = headerParameters[0].Trim();
            var headerValue = string.Empty;

            if (headerParameters.Length == parametersToGet)
            {
                headerValue = headerParameters[1].Trim();
            }

            request.AddHeader(headerName, headerValue);
        }
    }
}