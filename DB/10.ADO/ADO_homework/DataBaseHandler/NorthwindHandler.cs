namespace DataBaseHandler
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class NorthwindHandler
    {
        public static int GetNumOfRowsInCategories(SqlConnection dbConnection)
        {
            SqlCommand command = new SqlCommand(
                "SELECT COUNT(*) FROM Categories", dbConnection);
            int categoriesCount = (int)command.ExecuteScalar();

            return categoriesCount;
        }

        public static int GetNumOfRowsInProducts(SqlConnection dbConnection)
        {
            SqlCommand command = new SqlCommand(
                "SELECT COUNT(*) FROM Products", dbConnection);
            int productsNumber = (int)command.ExecuteScalar();

            return productsNumber;
        }

        public static string[][] GetNameAndDescription(SqlConnection dbConnection, int tableLength)
        {
            string[][] nameAndDescriptionArray = new string[tableLength][];
            SqlCommand command = new SqlCommand(
                "SELECT CategoryName, Description FROM Categories", dbConnection);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                int counter = 0;

                while (reader.Read())
                {
                    string[] nameAndDescriptionPair = new string[300];
                    string name = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];
                    nameAndDescriptionPair[0] = name;
                    nameAndDescriptionPair[1] = description;
                    nameAndDescriptionArray[counter] = nameAndDescriptionPair;
                    counter++;
                }
                nameAndDescriptionArray.Where(s => s != null).ToArray();
                return nameAndDescriptionArray;
            }
        }

        public static List<string> GetAllProductNames(SqlConnection dbConnection)
        {
            var productNames = new List<string>() { };
            SqlCommand command = new SqlCommand(
                "SELECT ProductName FROM Products", dbConnection);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["ProductName"];
                    productNames.Add(name);
                }
                return productNames;
            }
        }

        public static List<string> GetAllProductsThatContains(string pattern, List<string> products)
        {
            var productsContainingPattern = new List<string>() { };
            foreach (var product in products)
            {
                if (product.Contains(pattern))
                {
                    productsContainingPattern.Add(product);
                }
            }
            return productsContainingPattern;
        }

        public static Dictionary<string, List<string>> GetCategoryNameAndProductsInIt(SqlConnection dbConnection)
        {
            Dictionary<string, List<string>> productNameAndCategory = new Dictionary<string, List<string>>() { };
            SqlCommand command = new SqlCommand(
                @"SELECT c.CategoryName, p.ProductName
	                FROM Categories c
	                LEFT JOIN Products p
	                ON c.CategoryID=p.CategoryID", dbConnection);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];
                    if (productNameAndCategory.ContainsKey(categoryName))
                    {
                        productNameAndCategory[categoryName].Add(productName);
                    }
                    else
                    {
                        var products = new List<string>();
                        products.Add(productName);
                        productNameAndCategory.Add(categoryName, products);
                    }
                }
                return productNameAndCategory;
            }
        }

        public static void AddProduct(
            SqlConnection dbConnection,
            string productName,
            int supplierId,
            int categoryId,
            string quantityPerUnit,
            double unitPrice,
            int unitsInStock,
            int unitsOnOrder,
            int reorderLevel,
            bool discontinued)
        {
            SqlCommand command = new SqlCommand(@"INSERT INTO Products 
                             (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) 
                                VALUES 
                                          (@productName, @supplierId, @categoryId ,@quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)"
                            , dbConnection);
            command.Parameters.AddWithValue("@productName", productName);
            command.Parameters.AddWithValue("@supplierId", supplierId);
            command.Parameters.AddWithValue("@categoryId", categoryId);
            command.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            command.Parameters.AddWithValue("@unitPrice", unitPrice);
            command.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            command.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            command.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            command.Parameters.AddWithValue("@discontinued", discontinued);
            command.ExecuteNonQuery();
        }

        public static void ExtractImagesFromCategories(SqlConnection dbConnection, int categoriesCount)
        {
            for (int i = 1; i <= categoriesCount; i++)
            {
                string query = string.Format("SELECT Picture, CategoryID FROM Categories WHERE CategoryID = {0}", i);
                SqlCommand cmd = new SqlCommand(query, dbConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    reader.Read();
                    var image = (byte[])reader["Picture"];
                    var imageIndex = (int)reader["CategoryID"];
                    string filename = string.Format(@"..\..\picture_{0}.JPG", imageIndex);
                    ImageHandler.WriteBinaryFile(filename, image);
                }
            }
        }
    }
}
