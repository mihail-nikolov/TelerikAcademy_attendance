using System;

namespace Problem2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SuperMarket
    {
        HashSet<Product> products;
        Dictionary<double, SortedSet<Product>> byPrice;
        Dictionary<string, SortedSet<Product>> byType;
        SortedSet<double> prices;

        public SuperMarket()
        {
            this.products = new HashSet<Product>();
            this.byPrice = new Dictionary<double, SortedSet<Product>>();
            this.byType = new Dictionary<string, SortedSet<Product>>();
            this.prices = new SortedSet<double>();
        }

        public bool AddProduct(Product product)
        {
            if (this.products.Contains(product))
            {
                return false;
            }

            if (!(this.byPrice.ContainsKey(product.Price)))
            {
                this.byPrice[product.Price] = new SortedSet<Product>();
            }
            if (!(this.byType.ContainsKey(product.Type)))
            {
                this.byType[product.Type] = new SortedSet<Product>();
            }

            this.products.Add(product);
            this.byPrice[product.Price].Add(product);
            this.byType[product.Type].Add(product);
            this.prices.Add(product.Price);

            return true;
        }

        public IEnumerable<Product> FilterProducts(double from, double to)
        {
            var selectedPrices = this.prices.GetViewBetween(from, to);

            List<Product> products = new List<Product>();

            foreach (var price in selectedPrices)
            {
                if (products.Count >= 10)
                {
                    break;
                }
                foreach (var product in this.byPrice[price])
                {
                    if (products.Count >= 10)
                    {
                        break;
                    }
                    products.Add(product);
                }
            }
            return products;
        }

        public IEnumerable<Product> FilterProducts(string type)
        {
            if (!(byType.ContainsKey(type)))
            {
                return null;
            }
            return this.byType[type].Take(10);
        }
    }

    public enum CommandType
    {
        End,
        Add,
        FilterByPrice,
        FilterByType
    }

    public class Command
    {
        public string Params { get; set; }

        public static Dictionary<string, CommandType> stringToCommandType;

        static Command()
        {
            stringToCommandType = new Dictionary<string, CommandType>();
            stringToCommandType["add"] = CommandType.Add;
            stringToCommandType["end"] = CommandType.End;
            stringToCommandType["filter by type"] = CommandType.FilterByType;
            stringToCommandType["filter by price"] = CommandType.FilterByPrice;
        }

        public CommandType Type { get; set; }

        public static Command ParseCommand(string input)
        {
            foreach (var pair in stringToCommandType)
            {
                if (input.StartsWith(pair.Key))
                {
                    return new Command()
                    {
                        Type = pair.Value,
                        Params = input.Substring(pair.Key.Length).Trim()
                    };
                }
            }
            return null;
        }
    }
    public class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Product;
            if (other == null)
            {
                return false;
            }

            return this.Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return 23 + this.Name.GetHashCode() >> 17 ^
                   (23 + this.Price.GetHashCode() >> 17 ^
                    (23 + this.Type.GetHashCode() >> 17));
        }

        public int CompareTo(Product other)
        {
            var priceCompareResult = this.Price.CompareTo(other.Price);
            if (priceCompareResult == 0)
            {
                var namesCompareResult = this.Name.CompareTo(other.Name);
                if (namesCompareResult == 0)
                {
                    return this.Type.CompareTo(other.Type);
                }
                else
                {
                    return namesCompareResult;
                }
            }
            else
            {
                return priceCompareResult;
            }
        }

        public static Product ParseProduct(string productString)
        {
            string[] parts = productString.Split(' ');
            var name = parts[0];
            var price = double.Parse(parts[1]);
            var type = parts[2];
            return new Product()
            {
                Name = name,
                Price = price,
                Type = type
            };
        }
    }
    class Program
    {
        const string ProductAddedSuccessFormat = "Ok: Product {0} added successfully";
        const string ProductAddedErrorFormat = "Error: Product {0} already exists";
        const string FilterSuccessFormat = "Ok: {0}";
        const string InvalidTypeErrorFormat = "Error: Type {0} does not exists";

        public static void Main(string[] args)
        {
            var market = new SuperMarket();
            while (true)
            {
                string input = Console.ReadLine();
                var command = Command.ParseCommand(input);
                switch (command.Type)
                {
                    case CommandType.Add:
                        var product = Product.ParseProduct(command.Params);
                        var addResult = market.AddProduct(product);
                        string format;
                        if (addResult)
                        {
                            format = ProductAddedSuccessFormat;
                        }
                        else
                        {
                            format = ProductAddedErrorFormat;
                        }
                        Console.WriteLine(format, product.Name);
                        break;
                    case CommandType.FilterByPrice:
                        double from = 0;
                        double to = double.MaxValue;
                        var paramParts = command.Params.Split(' ');
                        int currentIndex = 0;
                        if (paramParts[currentIndex] == "from")
                        {
                            from = double.Parse(paramParts[currentIndex + 1]);
                            currentIndex += 2;
                        }
                        if (currentIndex < paramParts.Length && paramParts[currentIndex] == "to")
                        {
                            to = double.Parse(paramParts[currentIndex + 1]);
                        }
                        var result = market.FilterProducts(from, to);
                        Console.WriteLine(FilterSuccessFormat, string.Join(", ", result));
                        break;
                    case CommandType.FilterByType:
                        var filterByTypeResult = market.FilterProducts(command.Params);
                        if (filterByTypeResult == null)
                        {
                            Console.WriteLine(InvalidTypeErrorFormat, command.Params);
                        }
                        else
                        {
                            Console.WriteLine(FilterSuccessFormat, string.Join(", ", filterByTypeResult));
                        }
                        break;
                    case CommandType.End:
                        return;
                }
            }
        }

    }
}
