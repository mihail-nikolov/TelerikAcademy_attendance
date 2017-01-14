namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public bool BinarySearch(T item)
        {
            int from = 0;
            int to = this.Items.Count - 1;

            while (from <= to)
            {
                int middle = (from + to) / 2;
                int compare = this.items[middle].CompareTo(item);

                if (compare == -1)
                {
                    from = middle + 1;
                }
                else if (compare == 1)
                {
                    to = middle;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void Shuffle()
        {
            throw new NotImplementedException();
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
