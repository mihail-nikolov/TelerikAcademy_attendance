using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    //The 'Strategy' abstract class
    public abstract class SortStrategy
    {
        public abstract void Sort(List<Song> songs);
    }
}
