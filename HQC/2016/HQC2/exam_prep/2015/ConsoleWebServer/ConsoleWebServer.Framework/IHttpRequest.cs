﻿namespace ConsoleWebServer.Framework
{
    public interface IHttpRequest: IHttpMessage
    {
        string Uri { get; }

        string Method { get; }

        ActionDescriptor Action { get; }

        string ToString();

        HttpRequest Parse(string reqAsStr);
    }
}
