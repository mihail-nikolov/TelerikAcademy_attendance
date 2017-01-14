using System;
namespace ConsoleWebServer.Framework
{
    using System.Collections.Generic;

    public interface IHttpMessage
    {
        Version ProtocolVersion { get; }

        IDictionary<string, ICollection<string>> Headers { get; }

        void AddHeader(string name, string value);
    }
}
