namespace ConsoleWebServer.Application
{
    using System;
    using System.Text;
    using Framework;

    public class ConsoleWebServer
    {
        private readonly ResponseProvider responseProvider;

        public ConsoleWebServer()
        {
            this.responseProvider = new ResponseProvider();
        }

        public void Start()
        {
            var requestBuilder = new StringBuilder();
            string inputLine = Console.ReadLine();

            while (inputLine != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = this.responseProvider.GetResponse(requestBuilder.ToString());
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(response);
                    Console.ResetColor();
                    requestBuilder.Clear();
                }
                else
                {
                    requestBuilder.AppendLine(inputLine);
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}