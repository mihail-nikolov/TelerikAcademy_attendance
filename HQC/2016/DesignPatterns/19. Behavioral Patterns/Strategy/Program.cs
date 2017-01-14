using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main()
        {
            List<Song> mySongs = new List<Song>
            {
                new Song("Led Zeppelin","Whole Lotta Love","Rock"),
                new Song("Jamiroquai", "Cosmic Girl","Acid jazz"),
                new Song("Deep Purple", "Mistreated", "Rock")
            };

            MusicLibrary myLibrary = new MusicLibrary(mySongs);
            myLibrary.SetSortStrategy(new SortByGenre());
            myLibrary.Sort();

            Console.WriteLine("--------------------------------------------------------------");

            myLibrary.SetSortStrategy(new SortByAuthor());
            myLibrary.Sort();

            Console.WriteLine("--------------------------------------------------------------");

            myLibrary.SetSortStrategy(new SortByTitle());
            myLibrary.Sort();
        }
    }
}
