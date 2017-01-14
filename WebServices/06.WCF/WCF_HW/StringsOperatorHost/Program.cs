using StringsOperationLibrary;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace StringsOperatorHost
{
    class Program
    {
        static void Main()
        {
            var serviceAddress = new Uri("http://localhost:13337/StringsOperator.svc");
            var selfHost = new ServiceHost
                            (typeof(StringsOperator),
                            serviceAddress);
            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);
            selfHost.Open();
            Console.WriteLine("Service started on {0}", serviceAddress);
            Console.WriteLine("press any key to exit");
            Console.ReadLine();
        }
    }
}
