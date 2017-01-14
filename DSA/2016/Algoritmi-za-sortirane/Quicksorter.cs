namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int left = 0;
            int right = collection.Count - 1;
            quickSortMethod(collection, left, right);
            //Console.WriteLine("Done!");
        }

        public static void quickSortMethod(IList<T> collection, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(collection, left, right);
                if (pivot > 1)
                {
                    quickSortMethod(collection, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    quickSortMethod(collection, pivot + 1, right);
                }
                //Console.WriteLine(pivot);
            }
        }

        public static int Partition(IList<T> collection, int left, int right)
        {
            T pivot = collection[left];
            //Console.WriteLine("Pivot {0}", pivot);
            while (true)
            {
                while (collection[left].CompareTo(pivot) < 0)
                {
                    left++;
                }
                while (collection[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                if (left < right)
                {
                    if (collection[right].CompareTo(pivot) == 0)
                    {
                        return right++;                        
                    }
                    //if (collection[left].CompareTo(pivot) == 0)
                    //{
                    //    return left++;
                    //}

                    Swap(collection, left, right);
                }
                else
                {
                    return right;
                }
            }
        }

        public static void Swap(IList<T> collection, int i, int j)
        {
            T tmp = collection[i];
            collection[i] = collection[j];
            collection[j] = tmp;
            //Console.WriteLine("Swaped!");
        }
    }
}
