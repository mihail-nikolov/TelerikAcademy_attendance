using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineClasses
{
    public class GenericList<T> : IEnumerable<T>
    {
        private T[] items;
        private int capacity;
        private int count;

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public GenericList(int capacity)
        {
            this.Count = 0;
            this.Capacity = capacity;
            this.items = new T[capacity];
        }
        public int Count 
        {
            get { return this.count; } 
            private set { this.count = value; }
        }
        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }
        public void Add(T item)
        {
            if (this.Count == this.Capacity)
            {
                this.Capacity = 2 * this.Capacity;
                T[] oldItems = this.items;
                this.items = new T[this.Capacity];
                Array.Copy(oldItems, items, this.Count);
            }
            this.items[this.Count] = item;
            ++this.Count;
        }
        public void Insert(T item, int index)
        {
            if (index < 0 || index >= this.Capacity)
            {
                throw new ArgumentOutOfRangeException("index has to be in interval [0, Capacity - 1]");
            }
            if (this.Count == this.Capacity)
            {
                this.Capacity = 2 * this.Capacity;
                T[] oldItems = this.items;
                this.items = new T[this.Capacity];
                Array.Copy(oldItems, items, this.Count);
            }
            List<T> tmpList = this.items.ToList();
            tmpList.Insert(index, item);
            this.items = tmpList.ToArray();
            ++this.Count;
        }
        public void Remove(int indexToRemove)
        {
            this.items = this.items.Where((source, index) => index != indexToRemove).ToArray();
        }
        public int Find(T item)
        {
            return Array.IndexOf(this.items, item); 
        }
        public void Clear()
        {
            this.items = new T[this.Capacity];
            this.Count = 0;
        }
        public T Access(int index)
        {
            return this.items[index];
        }
        public override string ToString()
        {
            string arrStr = "";
            for (int i = 0; i < this.Count; i++)
            {
                arrStr += this.items[i] + " ";
            }
            return arrStr;
        }
        public T MIN<A>()
           where A:IComparable<A>
        {
            //T item = this.items.Max();
            return this.items.Min();
        }
        public T MAX<A>()
           where A:IComparable<A>
        {
            return this.items.Max();
        }
    }
}
