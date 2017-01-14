using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
/*Problem 4. Download file

    Write a program that downloads a file from Internet (e.g. Ninja image) and stores it the current directory.
    Find in Google how to download files in C#.
    Be sure to catch all exceptions and to free any used resources in the finally block.
*/
namespace _4.DownloadFile
{
    class DownloadFile
    {
        static void Main()
        {
            try
            {
                using (WebClient Client = new WebClient())
                {
                    Client.DownloadFile("http://telerikacademy.com/Content/Images/news-img01.png", "news-img01.png");
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Invalid link or invalid filename");
            }
            catch (WebException)
            {
                Console.WriteLine("The file does not exist or an error occurred while downloading");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The method has been called simultaneously on multiple threads.");
            }
        }
    }
}
