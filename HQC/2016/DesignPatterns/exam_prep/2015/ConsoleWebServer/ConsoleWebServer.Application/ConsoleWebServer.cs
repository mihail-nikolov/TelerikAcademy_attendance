namespace ConsoleWebServer.Application
{
    using System.Text;
    using Framework;

    public class ConsoleWebServer: IWebServer
    {
        private readonly IResponseProvider responseProvider;
        private readonly IReader reader;
        private readonly IWriter writer;

        public ConsoleWebServer(IResponseProvider responseProvider, IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.responseProvider = responseProvider;
        }

        public void Start()
        {
            var requestBuilder = new StringBuilder();
            string inputLine = reader.ReadLine();

            while (inputLine != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = this.responseProvider.GetResponse(requestBuilder.ToString());
                    
                    writer.WriteLine(response);
                    
                    requestBuilder.Clear();
                }
                else
                {
                    requestBuilder.AppendLine(inputLine);
                }

                inputLine = reader.ReadLine();
            }
        }
    }
}