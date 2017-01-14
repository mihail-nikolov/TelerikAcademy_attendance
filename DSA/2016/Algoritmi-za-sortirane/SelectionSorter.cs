namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {          
            int minIndex = 0;
            T temp;

            for (int i = 0; i < collection.Count - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    var nextNumberOrderOfAppearence = collection[j].CompareTo(collection[minIndex]);
                    if (nextNumberOrderOfAppearence < 0)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    temp = collection[i];
                    collection[i] = collection[minIndex];
                    collection[minIndex] = temp;
                }
            }
        }
    }
}
