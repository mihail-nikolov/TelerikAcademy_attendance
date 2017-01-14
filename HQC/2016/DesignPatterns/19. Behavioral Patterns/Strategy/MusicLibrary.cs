using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    //The 'Context' class
    public class MusicLibrary
    {
        private List<Song> songs;
        private SortStrategy sortStrategy;

        public MusicLibrary(List<Song> songs)
        {
            this.songs = songs;
        }

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            this.sortStrategy = sortStrategy;
        }

        public void Sort()
        {
            sortStrategy.Sort(this.Songs);
        }

        public List<Song> Songs
        {
            get
            {
                return this.songs;
            }
            set
            {
                this.songs = value;
            }
        }
    }
}
