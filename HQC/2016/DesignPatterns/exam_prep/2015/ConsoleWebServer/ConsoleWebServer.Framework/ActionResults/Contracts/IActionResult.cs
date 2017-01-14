using System.Collections.Generic;

namespace ConsoleWebServer.Framework.ActionResults.Contracts
{
    public interface IActionResult
    {
        HttpResponse GetResponse();

        List<KeyValuePair<string, string>> ResponseHeaders { get; }
    }
}