using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class SortByAuthor : SortStrategy
    {
        public override void Sort(List<Song> songs)
        {
            Console.WriteLine("Sorting by Author...");
            List<Song> sortedSongs = songs.OrderBy(s => s.Author).ToList();
            sortedSongs.ForEach(s => { Console.WriteLine(s.ToString()); });
            Console.WriteLine();
        }
    }
}
