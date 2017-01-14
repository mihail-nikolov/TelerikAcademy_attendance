using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingXML
{
    public class Album
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Year { get; set; }
        public string Producer { get; set; }
        public uint Price { get; set; }
        public List<Song> Songs { get; set; }

        public Album(string name, string artist, string year, string producer, uint price, List<Song> songs)
        {
            this.Name = name;
            this.Artist = artist;
            this.Producer = producer;
            this.Year = year;
            this.Price = price;
            this.Songs = songs;
        }
    }
}
