using System.Collections.Generic;
using System.Management.Instrumentation;

namespace Heap_QHEAP1
{
    /// <summary>
    /// Min Heap 
    /// Duplicates not allowed
    /// </summary>
    public class Heap
    {
        private SortedSet<int> items;

        public Heap()
        {
            items = new SortedSet<int>();
        }

        public void Push(int value)
        {
            if (!items.Contains(value))
                items.Add(value);
        }

        public int Count
        {
            get { return items.Count; }
        }

        public bool IsEmpty
        {
            get { return items.Count == 0; }
        }

        public int Peek
        {
            get
            {
                if(IsEmpty)
                    throw new KeyNotFoundException("Heap is Empty");

                return items.Min; //Since it is a Min Heap
            }
        }

        public int Pop()
        {
            if(IsEmpty)
                throw new KeyNotFoundException("Heap is Empty");

            var value = items.Min;
            items.Remove(value);
            return value;
        }

        public bool Remove(int value)
        {
            return items.Remove(value);
        }
    }
}