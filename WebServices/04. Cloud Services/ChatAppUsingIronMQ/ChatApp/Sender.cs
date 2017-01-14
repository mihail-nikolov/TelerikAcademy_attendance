namespace ChatAppReceiver
{
    using System;
    using System.Threading;
    using IronMQ;
    using IronMQ.Data;

    class Program
    {
        static void Main()
        {
            Client client = new Client(
"564852659195a8000700009a",
"1dsAqtoppOzDR5YJ9UMp");

            Queue queueSender = client.Queue("Chat");
            Console.WriteLine("Enter message : ");
            while (true)
            {
                string msgToSend = Console.ReadLine();
                queueSender.Push(msgToSend);
                Console.WriteLine("Message sent.");
            }
        }
    }
}
