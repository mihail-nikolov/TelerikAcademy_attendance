namespace DSA_efficiency_HW
{
    using System;
    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            //01. A text file students.txt holds information about students and their courses in the following format:
            //Using SortedDictionary<K,T> print the courses in alphabetical order and for each of them prints the students ordered by family and then by name:

            string fileName = "../../TestFile.txt";
            var courseStudentArr = CourseStudentsOperations.fileReader(fileName);
            var courseStudentDict = CourseStudentsOperations.GetCourseInfo(courseStudentArr);
            CourseStudentsOperations.PrintSorted(courseStudentDict);

            Console.WriteLine("-------------------------------------------------");

            //02. A large trade company has millions of articles, each described by barcode, vendor, title and price.
            //Implement a data structure to store them that allows fast retrieval of all articles in given price range [x…y].
            //Hint: use OrderedMultiDictionary<K,T> from Wintellect's Power Collections for .NET.
            Console.Write("enter low price: ");
            int lowPrice = int.Parse(Console.ReadLine());

            Console.Write("enter high price: ");
            int highPrice = int.Parse(Console.ReadLine());

            var articles = GenerateArticles(15);

            var subrange = articles.Range(lowPrice, true, highPrice, true);
            foreach (var item in subrange)
            {
                Console.WriteLine(item);
            }
        }

        public static OrderedMultiDictionary<int, Article> GenerateArticles(int numberArticles)
        {
            Random r = new Random();

            var articles = new OrderedMultiDictionary<int, Article>(true);
            for (int i = 0; i < numberArticles; i++)
            {
                int randomPrice = r.Next(5, 1005);
                string articleBarcode = "barcode" + randomPrice.ToString();
                string articleVendor = "vendor" + randomPrice.ToString();
                var article = new Article(articleBarcode, articleVendor, randomPrice);
                articles.Add(randomPrice, article);
            }
            return articles;
        }
    }
}
