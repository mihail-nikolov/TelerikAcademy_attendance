using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProcessingJSON
{
    //Homework

    //Using JSON.NET and the Telerik Academy Youtube RSS feed, implement the following:
    //    The RSS feed is located at https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw
    //    Download the content of the feed programatically
    //        You can use WebClient.DownloadFile()
    //    Parse teh XML from the feed to JSON
    //    Using LINQ-to-JSON select all the video titles and print the on the console
    //    Parse the videos' JSON to POCO
    //    Using the POCOs create a HTML page that shows all videos from the RSS
    //        Use <iframe>
    //        Provide a links, that nagivate to their videos in YouTube

    class Program
    {
        static void Main()
        {
            var webClient = new WebClient();
            var data = webClient.DownloadData("https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw");
            var content = Encoding.UTF8.GetString(data);
            //Console.WriteLine(content);

            var doc = new XmlDocument();
            doc.LoadXml(content);


            var jsonContent = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            //Console.WriteLine(jsonContent);

            JObject jObj = JObject.Parse(jsonContent);

            //To check the Key values in the JSON 
            //foreach (var item in jObj)
            //{
            //    Console.WriteLine(item.Key);
            //}

            //JObject feed = (JObject)jObj["feed"];
            //To check the Key values in 'feed'
            //foreach (var item in feed)
            //{
            //    Console.WriteLine(item.Key);
            //}


            var titles = jObj["feed"]["entry"].Select(e => e["title"]);
            //Console.WriteLine(rssTitle[0]);
            foreach (var t in titles)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine();

            VideosFeed telerikVideos = new VideosFeed();
            IList<Video> pocoVideos = new List<Video>();
            var videos = jObj["feed"]["entry"];
            foreach (var v in videos)
            {
                var poco = JsonConvert.DeserializeObject<Video>(v.ToString());
                pocoVideos.Add(poco);
            }
            telerikVideos.Feeds = pocoVideos;
            foreach (var item in telerikVideos.Feeds)
            {
                Console.WriteLine("Title: {0} - Link: {1}", item.Title, item.Link["@href"]);
            }

            //How to make an HTML page with the videos?? XmlWriter???
        }
    }

    public class Video
    {
        public string Title { get; set; }

        //[JsonProperty("link")]
        public IDictionary<string, string> Link { get; set; }
    }
    public class VideosFeed
    {
        [JsonProperty("entry")]
        public IList<Video> Feeds { get; set; }

    }
}
