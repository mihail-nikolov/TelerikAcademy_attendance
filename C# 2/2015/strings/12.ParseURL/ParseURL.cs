using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Problem 12. Parse URL

    Write a program that parses an URL address given in the format: [protocol]://[server]/[resource] and extracts from it the [protocol], [server] and [resource] elements.
*/
namespace _12.ParseURL
{
    class ParseURL
    {
        static void Main()
        {
            string address = "http://telerikacademy.com/Courses/Courses/Details/212";
            int indexProtocolEnd = address.IndexOf(':');
            string protocol = address.Substring(0, indexProtocolEnd);
            Console.WriteLine("[protocol] = {0}", protocol);

            string protocolServerDivider = "//";
            int indexServerStart = address.IndexOf(protocolServerDivider);
            string serverResourceDivider = "/";
            int indexServerEnd = address.IndexOf(serverResourceDivider, indexServerStart + (protocolServerDivider.Length));
            int serverLength = indexServerEnd - (indexServerStart + protocolServerDivider.Length);
            string server = address.Substring(indexServerStart + (protocolServerDivider.Length), serverLength);

            Console.WriteLine("[server] = {0}", server);
            int resourceLength = address.Length - indexServerEnd;
            string resource = address.Substring(indexServerEnd, resourceLength);
            Console.WriteLine("[resource] = {0}", resource);
        }
    }
}
