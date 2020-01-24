using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps_Cookies
{
    public class HeapList
    {
        private SortedList<int, int> items;
        
        public HeapList()
        {
            items = new SortedList<int, int>(new AllowDuplicatesComparer());
        }

        private class AllowDuplicatesComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                var ret = x.CompareTo(y);

                return (ret == 0) ? 1 : ret;
            }
        }

        public void Push(int value)
        {
            items.Add(value, value);

        }

        public int Top
        {
            get { return items.Values[0]; }
        }

        public int Bottom
        {
            get { return items.Values[items.Count - 1]; }
        }

        public int Pop()
        {
            var value = items.Values[0];
            items.RemoveAt(0);
            return value;
        }

        public int Count
        {
            get { return items.Count; }
        }

        public bool IsEmpty
        {
            get { return items.Count == 0; }
        }
    }
}
