namespace LargeProductsPriceCollection
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using Wintellect.PowerCollections;

    //Write a program to read a large collection of products(name + price) and efficiently find the first 20 products in the price range[a…b].

    //Test for 500 000 products and 10 000 price searches.
    //Hint: you may use OrderedBag<T> and sub-ranges.

    public class Startup
    {
        private static readonly Stopwatch stopWatch = new Stopwatch();

        static void Main()
        {
            var products = new OrderedBag<Product>();
            var numberProducts = 500000;
            var numberOfSearches = 10000;

            Console.WriteLine("Reading {0} products...", numberProducts);
            stopWatch.Start();
            for (int i = 0; i < numberProducts; i++)
            {
                var product = new Product("Product " + i, 100 + i);
                products.Add(product);
            }
            stopWatch.Stop();
            Console.WriteLine("{0} products added for {1} seconds.", products.Count, stopWatch.Elapsed);

            
            Console.WriteLine("Finding top 20 products in {0} different price ranges...", numberOfSearches);
            stopWatch.Restart();
            for (int i = 0; i < numberOfSearches; i++)
            {
                var minPrice = 100 + i*10;
                var maxPrice = 200 + i*10;
                var minProduct = new Product(string.Empty, minPrice);
                var maxProduct = new Product(string.Empty, maxPrice);
                var topTwentyInRange = products.Range(minProduct, true, maxProduct, true).Take(20).ToList();

                //Console.WriteLine("Sub-range [{0}...{1}]: {2}", minPrice, maxPrice, topTwentyInRange);
            }
            stopWatch.Stop();
            Console.WriteLine("{0} searches done for {1} seconds.", numberOfSearches, stopWatch.Elapsed);

        }
    }
}
