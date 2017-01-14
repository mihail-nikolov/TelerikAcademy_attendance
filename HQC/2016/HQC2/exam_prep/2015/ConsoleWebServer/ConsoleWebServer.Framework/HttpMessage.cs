namespace ConsoleWebServer.Framework
{
    using System;
    using System.Collections.Generic;

    public abstract class HttpMessage: IHttpMessage
    {
        protected const string ProtocolType = "HTTP/";

        public HttpMessage(string httpVersion)
        {
            this.ProtocolVersion = Version.Parse(httpVersion.ToString().ToLower().Replace(ProtocolType.ToLower(), string.Empty));
            this.Headers = new SortedDictionary<string, ICollection<string>>();
        }

        public Version ProtocolVersion { get; protected set; }

        public IDictionary<string, ICollection<string>> Headers { get; protected set; }

        public void AddHeader(string name, string value)
        {
            if (!this.Headers.ContainsKey(name))
            {
                this.Headers.Add(name, new HashSet<string>());
            }

            this.Headers[name].Add(value);
        }
    }
}
