using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFW_NorthwindHandler
{
    public static class DAOClass
    {
        public static void InsertCustomer(string companyName)
        {
            var db = new NorthwindEntities();
            using (db)
            {
                string CustID = companyName.Substring(0, 3).ToUpper() + companyName[companyName.Length - 3].ToString().ToUpper();
                Customer custToadd = new Customer()
                {
                    CompanyName = companyName,
                    CustomerID = CustID
                };
                Console.WriteLine(custToadd.CustomerID);
                db.Customers.Add(custToadd);
                db.SaveChanges();
            }
        }

        public static void ModifyCustomer(string id, string newCustomerName)
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var currnetCustomer = db.Customers
                    .FirstOrDefault(c => c.CustomerID == id);
                Console.WriteLine("{0} --> {1}", currnetCustomer.CustomerID, currnetCustomer.CompanyName);
                currnetCustomer.CompanyName = newCustomerName;
                db.SaveChanges();
            }
        }

        public static void DeleteCustomer(string id)
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var currnetCustomer = db.Customers
                    .FirstOrDefault(c => c.CustomerID == id);
                Console.WriteLine("{0} --> {1}", currnetCustomer.CustomerID, currnetCustomer.CompanyName);
                db.Customers.Remove(currnetCustomer);
                db.SaveChanges();
            }
        }

        public static List<Customer> FindAllCustomersWIthOrdersAfter1997ShippedToCanada()
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var searchedCustomers = db.Orders
                    .Where(o => o.OrderDate.Value.Year == 1997 && o.ShipCountry == "Canada")
                    .Select(o => o.Customer)
                    .Distinct()
                    .ToList();
                return searchedCustomers;
            }
        }

        public static List<Order> FindAllSalesBy(string regionName, DateTime startDate, DateTime endDate)
        {
            var db = new NorthwindEntities();
            using (db)
            {
                var searchedOrders = db.Orders
                    .Where(o => o.ShippedDate > startDate && o.ShippedDate < endDate && o.ShipRegion == regionName)
                    .Select(o => o)
                    .ToList();

                return searchedOrders;
            }
        }

        public static ICollection<string> FindAllCustomersWithOrdersFrom1997ShippedToCanadaWithNativeSqlQuery()
        {
            var db = new NorthwindEntities();
            string nativeSqlQuery = @"
SELECT DISTINCT c.ContactName AS Name
FROM ORDERS o
JOIN CUSTOMERS c
 ON c.CustomerID = o.CustomerID
WHERE DATEPART(YEAR, OrderDate) = 1997 
 AND ShipCountry='Canada'";

            var ordersByQuery = db.Database.SqlQuery<string>(nativeSqlQuery).ToList();
            return ordersByQuery;
        }
    }
}
