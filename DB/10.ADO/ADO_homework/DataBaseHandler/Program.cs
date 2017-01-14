namespace DataBaseHandler
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            SqlConnection dbConnection = new SqlConnection(
                "Server=.\\SQLEXPRESS; " +
                 "Database=Northwind; " +
                "Integrated Security=true");


            using (dbConnection)
            {
                dbConnection.Open();
                int numberOfRows = NorthwindHandler.GetNumOfRowsInCategories(dbConnection);
                Console.WriteLine("num of rows in categories --> {0}", numberOfRows);


                string[][] arrayOfDescriptionAndNamePairs = new string[][] { };
                arrayOfDescriptionAndNamePairs = NorthwindHandler.GetNameAndDescription(dbConnection, numberOfRows);
                string[] categories = new string[numberOfRows];
                for (int i = 0; i < arrayOfDescriptionAndNamePairs.Length; i++)
                {
                    Console.WriteLine("name: {0}, description: {1}", arrayOfDescriptionAndNamePairs[i][0], arrayOfDescriptionAndNamePairs[i][1]);
                }


                Dictionary<string, List<string>> productNameAndCategory = NorthwindHandler.GetCategoryNameAndProductsInIt(dbConnection);
                foreach (KeyValuePair<string, List<string>> pair in productNameAndCategory)
                {
                    Console.WriteLine("============================");
                    Console.WriteLine(pair.Key);
                    Console.WriteLine("-----------------------------");
                    var products = pair.Value;
                    foreach (var product in products)
                    {
                        Console.WriteLine(product);
                    }
                }
                Console.WriteLine("============================");
                Console.WriteLine("============================");
                Console.WriteLine("Products count:{0}", NorthwindHandler.GetNumOfRowsInProducts(dbConnection));

                //Uncomment and add product to check if it works

                //NorthwindHandler.AddProduct(
                //                   dbConnection,
                //                    "pechenoPueshko",
                //                    3,
                //                    5,
                //                    "no idea",
                //                    12.3,
                //                    5,
                //                    5,
                //                    8,
                //                    true);
                //Console.WriteLine("============================");
                //Console.WriteLine("Products count:{0}", NorthwindHandler.GetNumOfRowsInProducts(dbConnection));

                Console.WriteLine("============================");

                NorthwindHandler.ExtractImagesFromCategories(dbConnection, numberOfRows);

                var allProductnames = NorthwindHandler.GetAllProductNames(dbConnection);
                var allProductsContainsString = NorthwindHandler.GetAllProductsThatContains("pecheno", allProductnames);
                foreach (var product in allProductsContainsString)
                {
                    Console.WriteLine(product);
                }
                Console.WriteLine("============================");
            }
            dbConnection.Close();

        }
    }
}
