namespace ConsumingWebServicesHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    class Startup
    {
        static void Main()
        {
            Console.Write("enter query: ");
            string inputString = Console.ReadLine();
            Console.Write("count of articles: ");
            int countOfArticles = int.Parse(Console.ReadLine());

            var articles = GetArticles(inputString);
            PrintArticles(articles, countOfArticles);

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        static List<Content> GetArticles(string inputQuery)
        {          
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://www.justice.gov/api/v1/");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Other");

            List<Content> articlesList = new List<Content>();

            var task = httpClient.GetAsync(inputQuery)
              .ContinueWith((taskwithresponse) =>
              {
                  var response = taskwithresponse.Result;
                  var jsonString = response.Content.ReadAsStringAsync();
                  jsonString.Wait();
                  var result = JsonConvert.DeserializeObject<JObject>(jsonString.Result);
                  var children = result["results"].Children();

                  foreach (var article in children)
                  {
                      var articleObj = JsonConvert.DeserializeObject<Content>(article.ToString());
                      articlesList.Add(articleObj);
                  }
                  
              });
            task.Wait();

            return articlesList;
        }

        static void PrintArticles(List<Content> articles, int count)
        {

            if (count > articles.Count())
            {
                count = articles.Count();
            }

            for (int i = 0; i < count; i++)
            {
                var articleObj = articles[i];
                Console.WriteLine("{0} --> {1}", articleObj.Title, articleObj.Url);
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine();
            }
        }
        
    }
}
