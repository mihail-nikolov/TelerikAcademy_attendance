using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class Song
    {
        private string author;
        private string title;
        private string genre;

        public Song(string author, string title, string genre)
        {
            this.Author = author;
            this.Title = title;
            this.Genre = genre;
        }
        public string Author
        {
            get
            {
                return this.author;
            }
            private set
            {
                this.author = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            private set
            {
                this.title = value;
            }
        }

        public string Genre
        {
            get
            {
                return this.genre;
            }
            private set
            {
                this.genre = value;
            }
        }

        public override string ToString()
        {
            return String.Format(@"""{0}"" by {1} ({2})",
                this.Title, this.Author, this.Genre);
        }

    }
}
