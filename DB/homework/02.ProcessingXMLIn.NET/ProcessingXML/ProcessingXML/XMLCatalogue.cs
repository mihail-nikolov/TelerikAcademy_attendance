using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace ProcessingXML
{
    public class XMLCatalogue
    {
        public void CreateCatalogue(string filename, string name, List<Album> albums)
        {
            string fileName = string.Format("../../{0}.xml", filename);
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("catalogue");
                writer.WriteAttributeString("name", name);

                foreach (var album in albums)
                {
                    WriteAlbum(writer, album);
                }

                writer.WriteEndDocument();
            }
            Console.WriteLine("01. Document {0} created.", fileName);
            Console.WriteLine();
        }
        private static void WriteAlbum(XmlWriter writer, Album album)
        {
            writer.WriteStartElement("album");
            writer.WriteElementString("name", album.Name);
            writer.WriteElementString("artist", album.Artist);
            writer.WriteElementString("year", album.Year);
            writer.WriteElementString("producer", album.Producer);
            writer.WriteElementString("price", album.Price.ToString());
            writer.WriteStartElement("songs");
            foreach (var song in album.Songs)
            {
                writer.WriteStartElement("song");
                writer.WriteElementString("title", song.Title);
                writer.WriteElementString("duration", song.Duration);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public static void ExtractArtists(string filename, string DOMorXPATH)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string fileName = string.Format("../../{0}.xml", filename);
            xmlDoc.Load(fileName);
            XmlNode rootNode = xmlDoc.DocumentElement;
            Hashtable artists = new Hashtable();
            string method = DOMorXPATH;

            switch (method)
            {
                case "DOM":
                    foreach (XmlNode node in rootNode.ChildNodes)
                    {
                        string artist = node["artist"].InnerText;
                        if (artists.Contains(artist))
                        {
                            int value = (int)artists[artist];
                            value += 1;
                            artists[artist] = (object)value;
                            //Console.WriteLine(artists[artist]);
                        }
                        else
                        {
                            artists.Add(artist, 1);
                        }
                    }
                    break;
                case "XPATH":
                    string xPathQuery = "/catalogue/album";
                    XmlNodeList artistList = xmlDoc.SelectNodes(xPathQuery);
                    foreach (XmlNode node in artistList)
                    {
                        string artist = node.SelectSingleNode("artist").InnerText;
                        if (artists.Contains(artist))
                        {
                            int value = (int)artists[artist];
                            value += 1;
                            artists[artist] = (object)value;
                        }
                        else
                        {
                            artists.Add(artist, 1);
                        }
                    }
                    break;
                default: Console.WriteLine("Please choose DOM or XPATH...");
                    break;
            }


            foreach (DictionaryEntry a in artists)
            {
                Console.WriteLine("Artist: {0} --> Numbers of Albums in the catalog: {1}", a.Key, a.Value);
            }
            Console.WriteLine();
        }

        public static void RemoveAlbumWithPriceHigherThan20(string filename)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string fileName = string.Format("../../{0}.xml", filename);
            xmlDoc.Load(fileName);
            XmlNode rootNode = xmlDoc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                int price = Int32.Parse(node["price"].InnerText);
                if (price > 20)
                {
                    Console.WriteLine("The Album {0} is being deleted now..", node["name"].InnerText);
                    rootNode.RemoveChild(node);
                }
            }
            xmlDoc.Save(fileName);
            Console.WriteLine();
        }

        public static void ExtractSongs(string filename)
        {
            string fileName = string.Format("../../{0}.xml", filename);
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
            Console.WriteLine();
        }

        public static void ExtractSongsLINQ(string filename)
        {
            string fileName = string.Format("../../{0}.xml", filename);
            XDocument xmlDoc = XDocument.Load(fileName);
            var songs =
                from song in xmlDoc.Descendants("song")
                select new
                {
                    Title = song.Element("title").Value,
                };
            Console.WriteLine("Found {0} songs:", songs.Count());
            foreach (var s in songs)
            {
                Console.WriteLine(s.Title);
            }
            Console.WriteLine();
        }

        public static void ExtractPrices(string filename)
        {
            XmlDocument xmlDoc = new XmlDocument();
            string fileName = string.Format("../../{0}.xml", filename);
            xmlDoc.Load(fileName);
            XmlNode rootNode = xmlDoc.DocumentElement;
            string xPathQuery = "/catalogue/album[year<=2010]/price";
            XmlNodeList albums = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode node in albums)
            {
                Console.WriteLine("Price = {0} (year {1})", node.InnerText, node.ParentNode["year"].InnerText);
            }

            Console.WriteLine();
        }

        public static void ExtractPricesLINQ(string filename)
        {
            string file = string.Format("../../{0}.xml", filename);
            XDocument xmlDoc = XDocument.Load(file);
            var albums =
                from album in xmlDoc.Descendants("album")
                where Int32.Parse(album.Element("year").Value) <= 2010
                select new
                {
                    Year = album.Element("year").Value,
                    Price = album.Element("price").Value,
                };
            Console.WriteLine("Found {0} albums:", albums.Count());

            foreach (var a in albums)
            {
                Console.WriteLine("Price = {0} (year {1})", a.Price, a.Year);
            }

            Console.WriteLine();
        }

        public static void TransformInHTML(string filename)
        {
            string fileFrom = string.Format("../../{0}.xml", filename);
            string fileTo = string.Format("../../{0}.html", filename);
            string fileXSLT = string.Format("../../{0}.xslt", filename);
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(fileXSLT);
            xslt.Transform(fileFrom, fileTo);

            Console.WriteLine();
        }
    }
}
