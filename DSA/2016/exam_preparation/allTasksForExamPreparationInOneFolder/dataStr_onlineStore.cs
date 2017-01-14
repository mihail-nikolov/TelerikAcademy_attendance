using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace dataStr_onlineStore
{
    class Program
    {
        private const string NoProductsFound = "No products found";
        private static int productId = 0;

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int numberCommands = int.Parse(Console.ReadLine());
            var store = new Store();

            StringBuilder answer = new StringBuilder();
            for (int i = 0; i < numberCommands; i++)
            {
                var line = Console.ReadLine();
                var parsedLine = ParseCommand(line);
                string commandName = parsedLine[0];
                switch (commandName)
                {
                    case "AddProduct":
                        var product = new Product(parsedLine[1], decimal.Parse(parsedLine[2]), parsedLine[3], productId);
                        productId++;
                        store.AddProduct(product);
                        answer.AppendLine("Product added");
                        break;

                    case "DeleteProducts":
                        if (parsedLine.Count == 2)
                        {
                            int removed = store.DeleteProductsByProducer(parsedLine[1]);
                            if (removed == 0)
                            {
                                answer.AppendLine(NoProductsFound);
                            }
                            else
                            {
                                answer.AppendLine(string.Format("{0} products deleted", removed));
                            }
                        }
                        else
                        {
                            int removed = store.DeleteProductsByNameAndProducer(parsedLine[1], parsedLine[2]);
                            if (removed == 0)
                            {
                                answer.AppendLine(NoProductsFound);
                            }
                            else
                            {
                                answer.AppendLine(string.Format("{0} products deleted", removed));
                            }
                        }
                        break;

                    case "FindProductsByName":
                        var productsByName = store.FindProductByName(parsedLine[1]);
                        if (productsByName.Count > 0)
                        {
                            StringBuilder sbByName = new StringBuilder();
                            var ordered = productsByName.OrderBy(x => x.productToString);

                            foreach (var pr in ordered)
                            {
                                sbByName.AppendLine(pr.productToString);
                            }

                            answer.AppendLine(sbByName.ToString().TrimEnd());
                        }
                        else
                        {
                            answer.AppendLine(NoProductsFound);
                        }

                        break;

                    case "FindProductsByProducer":
                        var productsByProducer = store.FindProductByProducer(parsedLine[1]);
                        if (productsByProducer.Count > 0)
                        {
                            StringBuilder sbByPr = new StringBuilder();
                            var ordered = productsByProducer.OrderBy(x => x.productToString);

                            foreach (var pr in ordered)
                            {
                                sbByPr.AppendLine(pr.productToString);
                            }

                            answer.AppendLine(sbByPr.ToString().TrimEnd());
                        }
                        else
                        {
                            answer.AppendLine(NoProductsFound);
                        }

                        break;

                    case "FindProductsByPriceRange":
                        var productsByPrice = store.FindProductByPrice(decimal.Parse(parsedLine[1]), decimal.Parse(parsedLine[2]));

                        if (productsByPrice.Any())
                        {
                            var ordered = productsByPrice.OrderBy(x => x.productToString);

                            StringBuilder sbByPrice = new StringBuilder();
                            foreach (var pr in ordered)
                            {
                                sbByPrice.AppendLine(pr.productToString);
                            }

                            answer.AppendLine(sbByPrice.ToString().TrimEnd());
                        }
                        else
                        {
                            answer.AppendLine(NoProductsFound);
                        }

                        break;

                    default:
                        break;
                }
            }
            Console.WriteLine(answer.ToString().TrimEnd());
        }

        static List<string> ParseCommand(string line)
        {
            List<string> answer = new List<string>();
            int indexOfWhitSpace = line.IndexOf(' ');
            var commandName = line.Substring(0, indexOfWhitSpace);
            answer.Add(commandName);
            var parameters = line.Substring(indexOfWhitSpace + 1).Split(';');
            answer.AddRange(parameters);
            return answer;
        }
    }

    class Store
    {
        public Store()
        {
            this.ByName = new Dictionary<string, HashSet<Product>>();
            this.ByProducer = new Dictionary<string, HashSet<Product>>();
            this.ByNameAndProducer = new Dictionary<string, HashSet<Product>>();
            this.ByPrice = new Dictionary<decimal, HashSet<Product>>();
        }

        public Dictionary<string, HashSet<Product>> ByName { get; set; }

        public Dictionary<string, HashSet<Product>> ByProducer { get; set; }

        public Dictionary<string, HashSet<Product>> ByNameAndProducer { get; set; }

        public Dictionary<decimal, HashSet<Product>> ByPrice { get; set; }

        public void AddProduct(Product product)
        {
            //NAME
            if (!this.ByName.ContainsKey(product.Name))
            {
                this.ByName[product.Name] = new HashSet<Product>();
            }
            this.ByName[product.Name].Add(product);

            //PRODUCER
            if (!this.ByProducer.ContainsKey(product.Producer))
            {
                this.ByProducer[product.Producer] = new HashSet<Product>();
            }
            this.ByProducer[product.Producer].Add(product);

            //PRODUCERandNAME
            string nameAndProducer = string.Format("{0};{1}", product.Name, product.Producer);
            if (!this.ByNameAndProducer.ContainsKey(nameAndProducer))
            {
                this.ByNameAndProducer[nameAndProducer] = new HashSet<Product>();
            }
            this.ByNameAndProducer[nameAndProducer].Add(product);

            //PRICE
            if (!this.ByPrice.ContainsKey(product.Price))
            {
                this.ByPrice[product.Price] = new HashSet<Product>();
            }
            this.ByPrice[product.Price].Add(product);
        }

        public HashSet<Product> FindProductByName(string name)
        {
            HashSet<Product> products = new HashSet<Product>();
            if (this.ByName.ContainsKey(name))
            {
                products = this.ByName[name];
            }

            return products;
        }

        public HashSet<Product> FindProductByProducer(string producer)
        {
            HashSet<Product> products = new HashSet<Product>();
            if (this.ByProducer.ContainsKey(producer))
            {
                products = this.ByProducer[producer];
            }

            return products;
        }

        public IEnumerable<Product> FindProductByPrice(decimal from, decimal to)
        {
            var neededProducts = this.ByPrice.Where(x => x.Key >= from && x.Key <= to).SelectMany(x => x.Value);

            return neededProducts;
        }

        public int DeleteProductsByProducer(string producer)
        {
            if (this.ByProducer.ContainsKey(producer))
            {
                var productsByProducer = this.ByProducer[producer];
                foreach (var pr in productsByProducer)
                {
                    bool answer = this.ByName[pr.Name].Remove(pr);

                    string nameAndProducer = string.Format("{0};{1}", pr.Name, pr.Producer);
                    answer = this.ByNameAndProducer[nameAndProducer].Remove(pr);

                    answer = this.ByPrice[pr.Price].Remove(pr);
                }

                this.ByProducer.Remove(producer);
                return productsByProducer.Count;
            }

            return 0;
        }

        public int DeleteProductsByNameAndProducer(string name, string producer)
        {
            string nameAndProducer = string.Format("{0};{1}", name, producer);
            if (this.ByNameAndProducer.ContainsKey(nameAndProducer))
            {
                var productsByNameAndProducer = this.ByNameAndProducer[nameAndProducer];
                foreach (var pr in productsByNameAndProducer)
                {
                    bool answer = this.ByName[pr.Name].Remove(pr);

                    answer = this.ByPrice[pr.Price].Remove(pr);

                    answer = this.ByProducer[pr.Producer].Remove(pr);
                }

                this.ByNameAndProducer.Remove(nameAndProducer);
                return productsByNameAndProducer.Count;
            }

            return 0;
        }
    }

    class Product : IComparable<Product>, IEquatable<Product>
    {
        public string productToString;
        private int id;

        public Product(string name, decimal price, string producer, int id)
        {
            this.id = id;
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
            this.productToString = string.Format("{{{0};{1};{2}}}", this.Name, this.Producer, this.Price.ToString("F2"));
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Producer { get; set; }

        public int CompareTo(Product other)
        {
            var answer = this.Name.CompareTo(other.Name);
            if (answer == 0)
            {
                answer = this.Producer.CompareTo(other.Producer);
                if (answer == 0)
                {
                    answer = this.Price.CompareTo(other.Price);
                    if (answer == 0)
                    {
                        answer = this.id.CompareTo(other.id);
                    }
                }
            }

            return answer;
        }

        //public override int GetHashCode()
        //{
        //    return this.id;
        //}

        public bool Equals(Product other)
        {
            return this.productToString.Equals(other.productToString);
        }
    }
}
