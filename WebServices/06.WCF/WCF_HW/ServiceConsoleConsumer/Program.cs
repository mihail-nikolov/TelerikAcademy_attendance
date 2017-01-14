using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DayOfWeekServiceProvider;
using System.ServiceModel.Description;

namespace ServiceConsoleConsumer
{
    class Program
    {
        static void Main()
        {
            //var serviceAddress = new Uri("http://localhost:52598/DayOfWeekProvider.svc");
            //var selfHost = new ServiceHost
            //                (typeof(DayOfWeekProvider),
            //                serviceAddress);
            //var smb = new ServiceMetadataBehavior();
            //smb.HttpGetEnabled = true;
            //selfHost.Description.Behaviors.Add(smb);
            //selfHost.Open();
            //Console.WriteLine("Service started on {0}", serviceAddress);
            //Console.WriteLine("press any key to exit");
            //Console.ReadLine();

            var dayOfWeekProvider = new DayOfWeekProvider();
            Console.WriteLine(dayOfWeekProvider.GetDate(DateTime.Now));
        }
    }
}
