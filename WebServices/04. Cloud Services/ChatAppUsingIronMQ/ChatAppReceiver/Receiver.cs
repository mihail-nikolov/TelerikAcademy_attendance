namespace ChatAppReceiver
{
    using System;
    using System.Threading;
    using IronMQ;
    using IronMQ.Data;
    using System.Net;
    using System.Net.NetworkInformation;

    class Receiver
    {
        static void Main()
        {
            Client client = new Client(
"564852659195a8000700009a",
"1dsAqtoppOzDR5YJ9UMp");
            

            Queue queueListener = client.Queue("Chat");
            Console.WriteLine(" -- CHAT -- ");
            while (true)
            {
                Message msg = queueListener.Get();
                if (msg != null)
                {
                    Console.WriteLine("{0} : {1}", GetIPAddress(Dns.GetHostName()), msg.Body);
                    queueListener.DeleteMessage(msg);
                }
                Thread.Sleep(100);
            }
        }

        public static IPAddress GetIPAddress(string hostName)
        {
            Ping ping = new Ping();
            var replay = ping.Send(hostName);

            //if (replay.Status == IPStatus.Success)
            //{
            return replay.Address.MapToIPv4();
            //}
            //return null;
        }
    }
}
