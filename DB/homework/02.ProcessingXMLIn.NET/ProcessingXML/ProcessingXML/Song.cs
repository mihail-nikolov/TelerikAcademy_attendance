using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessingXML
{
    public class Song
    {
        public string Title { get; set; }
        public string Duration { get; set; }

        public Song(string title, string duration)
        {
            this.Title = title;
            this.Duration = duration;
        }
    }
}
