using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity.Validation;

namespace EntityFW_NorthwindHandler
{
    class Program
    {
        static void Main()
        {
            //DAOClass.InsertCustomer("TestCompanyName");
            // DAOClass.ModifyCustomer("YNEA", "modifiedCUstomerAddedByMe");
            // DAOClass.DeleteCustomer("YNEA");
            var myCustomers = DAOClass.FindAllCustomersWIthOrdersAfter1997ShippedToCanada();
            Console.WriteLine(myCustomers.Count);
            foreach (var customer in myCustomers)
            {
                Console.WriteLine(customer.CompanyName);
            }
            var Customers = DAOClass.FindAllCustomersWithOrdersFrom1997ShippedToCanadaWithNativeSqlQuery();
            Console.WriteLine("==================");
            foreach (var item in Customers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("----------------------");
            var orders = DAOClass.FindAllSalesBy("RJ", new DateTime(1996, 07, 10), new DateTime(2015, 10, 10));
            foreach (var order in orders)
            {
                Console.WriteLine(order.ShipName);
            }
        }

    }
}
